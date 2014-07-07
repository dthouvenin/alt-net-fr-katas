namespace Pierre

open Mazes.Core
open System.Collections.Generic

type Direction =
    | East
    | South
    | West
    | North

type Turn =
    | Right
    | Around
    | Left

type public Solver() =
    let mutable maze:IMaze = null
    let mutable mouse:IMouse = null
    let mutable enumerator:IEnumerator<unit> = null

    let applyMove direction (x, y) =
        match direction with
        | East -> x + 1, y
        | South -> x, y + 1
        | West -> x - 1, y
        | North -> x, y - 1

    let solve () =
        let position = ref (0, 0)
        let direction = ref East
        let visited = ref (Set.singleton !position)

        let isValidMove () =
            maze.CanIMove()
            && not ((!visited).Contains(!position |> applyMove (!direction)))

        let move () = mouse.Move()
                      position := !position |> applyMove (!direction)
                      visited := !visited |> Set.add (!position)

        let rec turn clockwiseSteps =
            if clockwiseSteps > 0 then
                mouse.TurnRight()
                direction :=
                    match !direction with
                    | East -> South
                    | South -> West
                    | West -> North
                    | North -> East
                turn (clockwiseSteps - 1)
            else if clockwiseSteps < 0 then
                mouse.TurnLeft()
                direction :=
                    match !direction with
                    | South -> East
                    | West -> South
                    | North -> West
                    | East -> North
                turn (clockwiseSteps + 1)

        let getClockwiseSteps = function
                                | Right -> 1
                                | Around -> 2
                                | Left -> -1


        let rec tryExplore () =
            let tryAheadThenTurn turnTo = seq {
                if isValidMove() then
                    yield move()
                    yield! tryExplore ()
                    do turnTo |> getClockwiseSteps |> fun s -> (((s + 4) % 4) - 2) |> turn 
                else
                    do turnTo |> getClockwiseSteps |> turn
            }

            seq {
                yield! tryAheadThenTurn Left
                yield! tryAheadThenTurn Around
                yield! tryAheadThenTurn Right
                yield move()
            }

        tryExplore ()

    interface IMazeSolver with
        member this.Init(refMaze:IMaze, refMouse:IMouse) =
            maze <- refMaze
            mouse <- refMouse
            enumerator <- solve().GetEnumerator()

        member this.YouWin() = ()
        member this.YouLoose() = ()
        member this.YourTurn() =
            enumerator.MoveNext() |> ignore
            enumerator.Current