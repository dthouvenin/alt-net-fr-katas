namespace Pierre

open Mazes.Core

type Wall = Vertical | Horizontal

type public Builder() =
    let width = 30
    let height = 20

    let rand =
        let r = new System.Random()
        fun max -> r.Next(max)

    let getOtherCell ((x,y), wallType) =
        match wallType with
        | Horizontal -> x, y-1
        | Vertical   -> x-1, y

    let rec perfectMaze keptWalls removableWalls (groups: Map<int * int, int>) =
        if groups |> Map.toSeq |> Seq.distinctBy snd |> Seq.length = 1 then keptWalls
        else
            let index = rand (Array.length removableWalls)
            let ((x, y), _) as wall = removableWalls.[index]
            let (x2, y2) = getOtherCell wall
            let g1 = groups.[x, y]
            let g2 = groups.[x2, y2]
            let keptWalls2 = keptWalls |> Array.filter ((<>) wall)
            let groups2 = groups |> Map.map (fun _ g -> if g = g2 then g1 else g)
            let removableWalls2 =
                removableWalls
                |> Seq.filter (fun ((x, y), wallType) ->
                                    let x2, y2 = getOtherCell ((x, y), wallType)
                                    let g = groups2.[x, y]
                                    let g2 = groups2.[x2, y2]
                                    g <> g2)
                |> Seq.toArray
            perfectMaze keptWalls2 removableWalls2 groups2

    interface IMazeBuilder with
        member this.Width = width
        member this.Height = height
        member this.MazeStartPosition = new Position(0, 0)
        member this.Build(maze) =
            for i in 0..height-1 do
                maze.AddVerticalWall(0, i)
                maze.AddVerticalWall(width, i)
            for i in 0..width-2 do
                maze.AddHorizontalWall(i, 0)
                maze.AddHorizontalWall(i, height)
            maze.AddHorizontalWall(width-1, 0)

            let allWalls =
                seq {
                    for x in 0..width-1 do
                    for y in 0..height-1 do
                    if x > 0 then yield (x, y), Vertical
                    if y > 0 then yield (x, y), Horizontal
                } |> Seq.toArray

            let allGroups =
                seq {
                    for x in 0..width-1 do
                    for y in 0..height-1 do
                    yield (x, y), x * height + y
                } |> Map.ofSeq

            let walls = perfectMaze allWalls allWalls allGroups

            for wall in walls do
                match wall with
                | (x, y), Vertical -> maze.AddVerticalWall(x, y)
                | (x, y), Horizontal -> maze.AddHorizontalWall(x, y)
