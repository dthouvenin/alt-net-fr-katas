namespace MazeSolver

open System
open Mazes.Core

type MazeSolver() =
    let mutable _maze = null
    let mutable _mouse = null
    interface IMazeSolver with
        member this.Init(maze, mouse) =
            _maze <- maze
            _mouse <- mouse
        member this.YouLoose() =
            ()
        member this.YouWin() =
            ()
        member this.YourTurn() =
            while not (_maze.CanIMove()) do
                _mouse.TurnLeft()
            _mouse.Move()
            _mouse.TurnRight()
