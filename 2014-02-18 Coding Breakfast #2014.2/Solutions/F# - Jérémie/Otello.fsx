type Color = White | Black | Empty

type Board = Color array array

type Position = Position of int * int

type Vector = Vector of int * int
    with
    static member (*) (v: Vector, i: int) =
            match v with
            | Vector(x,y) -> Vector (x*i, y*i)
    static member (+) (p: Position, v: Vector)=
            match p,v with
            | Position(x,y), Vector(vx,vy) -> Position(x + vx, y + vy)


let w = White
let b = Black
let e = Empty

let board = [|
    [| e; e; e; e; e; e; e; e |]
    [| e; e; e; e; e; e; e; e |]
    [| e; e; e; e; e; e; e; e |]
    [| e; e; e; w; b; e; e; e |]
    [| e; e; e; b; w; e; e; e |]
    [| e; e; e; e; e; e; e; e |]
    [| e; e; e; e; e; e; e; e |]
    [| e; e; e; e; e; e; e; e |] |]

let getCell x y board = 
    let row = Array.get board y
    Array.get row x



let inBoard (Position(x,y)) =
    x >= 0 && x < 8 && y >= 0 && y < 8
    
let (|InBoard|_|) p = if inBoard p then Some() else None


let find color board =
    seq {
        for y in [0..7] do
        for x in [0..7] do
        match board |> getCell x y with
        | c when c = color -> yield Position (x,y)
        | _ -> () }

let swap = function White -> Black | Black -> White | Empty -> Empty 

let isPlayable  (start: Position) (vector: Vector) playerColor board  =
    let otherColor = swap playerColor
    let (|Cell|) (Position(x,y)) = 
         getCell x y board
    let rec loop length =
        let pos = start + vector * length 
        match pos with
        | InBoard & Cell c when c = otherColor -> loop (length + 1)
        | InBoard & Cell Empty  when length > 1 -> Some pos
        | _ -> None
    loop 1

let vec x y = Vector(x,y)

let vectors = [
    vec -1 -1 
    vec -1  0
    vec -1  1
    vec  0  1
    vec  1  1
    vec  1  0
    vec  1 -1
    vec  0 -1]

let playableCells color board =
    seq {
        for p in board |> find color do
        for v in vectors do
        match isPlayable p v color board with
        | Some solution -> yield solution
        | None -> ()}

