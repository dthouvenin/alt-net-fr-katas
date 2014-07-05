namespace MazeSolver

open System
open System.Collections.Generic
open Mazes.Core

type Direction = Up | Right | Down | Left

type Position =
    struct
        val row: int
        val col: int
        new(r, c) = { row = r; col = c }
        override this.ToString() =
            sprintf "%d, %d" this.row this.col
    end
        
type MazeSolver() =
    let mutable _maze: IMaze = null
    let mutable _mouse: IMouse = null
    let mutable _direction = Up
    let mutable _position = Position(0, 0)
    let _visited = HashSet<Position>()
    let mutable _history = []
    let next (p: Position) = function
        | Up -> Position(p.row - 1, p.col)
        | Right -> Position(p.row, p.col + 1)
        | Down -> Position(p.row + 1, p.col)
        | Left -> Position(p.row, p.col - 1)
    let turnLeft () =
        _mouse.TurnLeft()
        _direction <-
            match _direction with
            | Up -> Left
            | Right -> Up
            | Down -> Right
            | Left -> Down
    let turnRight () =
        _mouse.TurnRight()
        _direction <-
            match _direction with
            | Up -> Right
            | Right -> Down
            | Down -> Left
            | Left -> Up
    let move () =
        _history <- _direction :: _history
        _mouse.Move()
        _position <- next _position _direction
        _visited.Add _position |> ignore
    let canMove () =
        not (_visited.Contains(next _position _direction)) && _maze.CanIMove()
    interface IMazeSolver with
        member this.Init(maze, mouse) =
            _maze <- maze
            _mouse <- mouse
            _visited.Add _position |> ignore
        member this.YouLoose() =
            ()
        member this.YouWin() =
            ()
        member this.YourTurn() =
            let mutable d = 0
            while d < 4 && not (canMove()) do
                if d < 3 then
                    turnLeft()
                d <- d + 1
            if d = 4 then
                let prev = _history.Head
                _history <- _history.Tail
                let mirror =
                    match prev with
                    | Up -> Down
                    | Right -> Left
                    | Down -> Up
                    | Left -> Right
                while _direction <> mirror do
                    turnRight()
            move()
            turnRight()
