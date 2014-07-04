module MazeSolverTest

open MazeSolver
open FsUnit
open Xunit
open Mazes.Core

type MouseAction = Move | TurnRight | TurnLeft

type MockMouse() =
    let mutable actions = []
    member this.Actions
        with get() = actions
    interface IMouse with
        member this.Move() =
            actions <- Move :: actions
        member this.TurnLeft() =
            actions <- TurnLeft :: actions
        member this.TurnRight() =
            actions <- TurnRight :: actions

type MockMaze(moves : bool list) =
    let mutable _moves = moves
    interface IMaze with
        member this.CanIMove() =
            match _moves with
            | b :: l ->
                _moves <- l
                b
            | [] -> failwith "Out of moves"
        member this.AmIOut() =
            false

[<Fact>]
let ``init`` () =
    let maze = MockMaze([])
    let mouse = MockMouse()
    let solver = MazeSolver() :> IMazeSolver
    solver.Init(maze :> IMaze, mouse :> IMouse)

[<Fact>]
let ``move and turn right if can move`` () =
    let maze = MockMaze([ true ])
    let mouse = MockMouse()
    let solver = MazeSolver() :> IMazeSolver
    solver.Init(maze :> IMaze, mouse :> IMouse)
    solver.YourTurn()
    List.rev mouse.Actions |> should equal [ Move ; TurnRight ]

[<Fact>]
let ``turn left if cannot move`` () =
    let maze = MockMaze([ false ; true ])
    let mouse = MockMouse()
    let solver = MazeSolver() :> IMazeSolver
    solver.Init(maze :> IMaze, mouse :> IMouse)
    solver.YourTurn()
    List.rev mouse.Actions |> should equal [ TurnLeft ; Move ; TurnRight ]

[<Fact>]
let ``turn left while cannot move`` () =
    let maze = MockMaze([ false ; false ; false ; true ])
    let mouse = MockMouse()
    let solver = MazeSolver() :> IMazeSolver
    solver.Init(maze :> IMaze, mouse :> IMouse)
    solver.YourTurn()
    List.rev mouse.Actions |> should equal [ TurnLeft ; TurnLeft ; TurnLeft ; Move ; TurnRight ]
