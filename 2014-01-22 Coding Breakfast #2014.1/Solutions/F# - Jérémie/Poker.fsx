type Color =
    | Spade
    | Heart
    | Club
    | Diamond

let isValue n v = if v = n then Some() else None

let (|Ace|_|) = isValue 14
let (|King|_|) = isValue 13
let (|Queen|_|) = isValue 12
let (|Jack|_|) = isValue 11

let svalue _ = 
        function
        | Ace -> "A"
        | King -> "K"
        | Queen -> "Q"
        | Jack -> "J"
        | n -> sprintf "%d" n

let scolor _ = 
          function
          | Spade -> "\u2660"
          | Heart -> "\u2665"
          | Club -> "\u2663"
          | Diamond -> "\u2666" 

type Card = Card of Color * int

let color (Card(c,_)) =  c
let value (Card(_,v)) =  v

let (|Color|) = color
let (|Value|) = value

let sort = List.sortBy value


let (|HandColor|_|) hand =
   let rec loop firstColor =
       function
       | Color(c) :: tail when c = firstColor -> loop firstColor tail
       | [] -> Some firstColor
       | _ -> None
   match hand with
   | Color(c) :: tail -> loop c tail
   | [] -> None

let (|Sequence|_|) hand =
    let rec loop previous =
        function
        | Value(v) :: tail when previous = v-1 -> loop v tail
        // match the special case of A 2 3 4 5 as 2 3 4 5 14 !!
        | [Value(Ace)] when previous = 5 -> Some 5 
        | [] -> Some previous
        | _ -> None
    match hand with
    | Value v :: tail -> loop v tail
    | [] -> None


let (|QuinteFlush|_|) hand =
   match hand with
   | Sequence(v) & HandColor(c) -> Some(c,v)
   | _ -> None

let (|GroupCards|) hand =
     hand
     |> Seq.countBy value
     |> Seq.sortBy snd
     |> Seq.toList
     |> List.rev


let (|Full|_|) hand=
    match hand with
     | GroupCards ((b,3) :: (p,2) :: []) -> Some(b,p)
     | _ -> None 

let (|Square|_|) hand = 
    match hand with
    | GroupCards ((s, 4) :: _) -> Some(s)
    | _ -> None

let (|Brelan|_|) hand =
    match hand with
    | GroupCards ((b,3) :: (_,1) :: _) -> Some(b)
    | _ -> None

let (|Pair|_|) hand =
    match hand with
    | GroupCards ((p,2) :: (_,1) :: _) -> Some(p)
    | _ -> None

let (|DoublePair|_|) hand =
    match hand with
    | GroupCards((p1, 2) :: (p2,2) :: _) -> Some(max p1 p2, min p1 p2)
    | _ -> None

let (|High|_|) hand =
    match hand with
    | GroupCards ((_,1) :: _) ->  Some(List.maxBy value hand)
    | _ -> None
let showHand hand =
    match sort hand with
    | QuinteFlush(c,v) -> sprintf "Quint Flush of %a%a" svalue v scolor c
    | Square(v) -> sprintf "Square of %a" svalue v
    | Sequence(v) -> sprintf "Sequence of %a" svalue v
    | HandColor(c) -> sprintf "Color of %a" scolor c 
    | Full(b,p) -> sprintf "Full of %a by %a" svalue b svalue p 
    | Brelan(b) -> sprintf "Brelan of %a" svalue b
    | DoublePair(p1, p2) -> sprintf "Double pair of %a and %a" svalue p1 svalue p2
    | Pair(p) -> sprintf "Pair of %a" svalue p
    | High(Card(c,v)) -> sprintf "Highest %a%a" svalue v scolor c
    | _ -> hand |> Seq.map (fun (Card(c,v)) -> sprintf "%a%a" svalue v scolor c) |> String.concat " "
    |> printfn "%s"

let h n= Card(Heart, n)
let s n= Card(Spade, n)
let c n= Card(Club, n)
let d n= Card(Diamond, n)

let a = 14
let k = 13
let q = 12
let j = 11

[h 7;h 8; h 9;h 10; h j] |> showHand
[h a;h 2; h 3;h 4; h 5] |> showHand
[h 10;h j; h q;h k; h a] |> showHand
[s 5; h 3; c q; d 4; h 8] |> showHand
[s 5; h 3; c 5; d 4; c 3] |> showHand

