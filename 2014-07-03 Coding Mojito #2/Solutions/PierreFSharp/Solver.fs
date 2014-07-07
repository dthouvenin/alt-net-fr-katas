namespace Pierre

open Mazes.Core
open System.Collections.Generic

type Direction =
    | East
    | South
    | West
    | North

type public Solver() =
    let mutable maze:IMaze = null
    let mutable mouse:IMouse = null
    let mutable enumerator:IEnumerator<unit> = null

    let run direction (x, y) =
        match direction with
        | East -> x + 1, y
        | South -> x, y + 1
        | West -> x - 1, y
        | North -> x, y - 1

    let turnRight = function
        | East -> South
        | South -> West
        | West -> North
        | North -> East

    let solve () =
        let position = ref (0, 0)
        let direction = ref East
        let visited = ref (Set.singleton !position)

        let isValidMove () =
            maze.CanIMove()
            && not ((!visited).Contains(!position |> run (!direction)))

        let move () = mouse.Move()
                      position := !position |> run (!direction)
                      visited := !visited |> Set.add (!position)
        let turn () = mouse.TurnRight()
                      direction := !direction |> turnRight

        let rec tryMove () = seq {
            for direction in 1 .. 4 do
                if isValidMove() then
                    yield move()
                    yield! tryMove()
                do turn()
            do turn()
            do turn()
            yield move()
            do turn()
            do turn()
        }

        tryMove ()

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