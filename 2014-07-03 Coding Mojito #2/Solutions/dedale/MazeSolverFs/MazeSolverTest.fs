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

type FakeMaze(moves : bool list) =
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

let play walls actions n =
    let maze = FakeMaze(walls)
    let mouse = MockMouse()
    let solver = MazeSolver() :> IMazeSolver
    solver.Init(maze :> IMaze, mouse :> IMouse)
    for i in 1 .. n do
        solver.YourTurn()
    List.rev mouse.Actions |> should equal actions

[<Fact>]
let ``init`` () =
    let maze = FakeMaze([])
    let mouse = MockMouse()
    let solver = MazeSolver() :> IMazeSolver
    solver.Init(maze :> IMaze, mouse :> IMouse)

[<Fact>]
let ``move and turn right if can move`` () =
    play [ true ] [ Move ; TurnRight ] 1

[<Fact>]
let ``turn left if cannot move`` () =
    play [ false ; true ] [ TurnLeft ; Move ; TurnRight ] 1

[<Fact>]
let ``turn left while cannot move`` () =
    play [ false ; false ; false ; true ] [ TurnLeft ; TurnLeft ; TurnLeft ; Move ; TurnRight ] 1

[<Fact>]
let ``step back if stuck`` () =
    play [ true ; false ; false ; false ] [ Move ; TurnRight ; TurnLeft ; TurnLeft ; TurnLeft ; Move ; TurnRight ] 2

[<Fact>]
let ``no cycle without walls`` () =
    play [ true ; true ; true ; true ; true ] [ Move ; TurnRight ; Move ; TurnRight ; Move ; TurnRight ; TurnLeft ; Move ; TurnRight ] 4

[<Fact>]
let ``step back in corridor`` () =
    play [ true ; false ; true ; false ; false ; false ] [ Move ; TurnRight ; TurnLeft ; Move ; TurnRight ; TurnLeft ; TurnLeft ; TurnLeft ; Move ; TurnRight ] 3
