open System


let digits x =
    let rec nextDigit =
        function
        | 0 -> []
        | x -> 
            let d = x % 10
            d :: nextDigit (x / 10) 
    nextDigit x 


let isVampire x y =
    let v = x * y
    let dx = digits x
    let dy = digits y
    let dv = digits v
    match dx, dy with
    | 0 :: _, 0 :: _  -> false
    | dx, dy when List.length dx <> List.length dy -> false
    | _ -> List.sort (dx @ dy) = List.sort dv

let rec npow = function 0 -> 1 | n -> 10 * npow (n-1)

let vampires n =
    match n%2 with
    | 0 ->
        seq {
            let start = npow (n/2 - 1)
            for x in start .. npow (n/2) do
            for y in x .. npow (n/2) do
            if isVampire x y then
                yield x * y, x, y 
        } 
    | _ -> Seq.empty
   


let isTrue = function true -> printfn "Ok" | false -> printfn "Fail"
let isFalse = function false -> printfn "Ok" | true -> printfn "Fail"

digits 1260 = [0;6;2;1] |> isTrue

isVampire 21 61 |> isFalse
isVampire 21 60 |> isTrue

vampires 3 |> Seq.isEmpty |> isTrue

vampires 4 |> Seq.isEmpty |> isFalse

vampires 4 |> Seq.toList

vampires 6 |> Seq.iter (fun (v,x,y) -> printfn "%d = %d x %d" v x y)
vampires 6 |> Seq.length
