module VampireBreakfast

// The solution
let rec pow a n = match n with | 0 -> 1 | 1 -> a | _ -> a * pow a (n-1)
let pow10 = pow 10

let getDigits n =
    let rec digits' n ds =
        if n < 10 then n :: ds
        else digits' (n / 10) (n % 10 :: ds)
    digits' n []

let getVampires n = seq {
    for x in pow10 (n-1) + 1 .. pow10 n - 1 do
    for y in x .. pow10 n - 1 do
    if x % 10 <> 0 || y % 10 <> 0 then
        let v = x * y
        let vDigits = getDigits v |> List.sort
        let xyDigits = (getDigits x @ getDigits y) |> List.sort
        if vDigits = xyDigits then yield x, y, v } |> Seq.toList

// The tests
open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

[<TestClass>]
type BreafastTests() =
    // Several power tests because I'm pow 10 keen
    [<TestMethod>] 
    member test.``10^0 is 1`` () =
        pow10 0 |> should equal 1

    [<TestMethod>] 
    member test.``10^1 is 10`` () =
        pow10 1 |> should equal 10

    [<TestMethod>] 
    member test.``10^2 is 100`` () =
        pow10 2 |> should equal 100

    [<TestMethod>] 
    member test.``10^3 is 1000`` () =
        pow10 3 |> should equal 1000

    [<TestMethod>]
    member test.``Digits of 1234 are 1,2,3,4`` () =
        getDigits 1234 |> should equal [1;2;3;4]

    [<TestMethod>] 
    member test.``Digits of 101010 are 1,0,1,0,1,0`` () =
        getDigits 101010 |> should equal [1;0;1;0;1;0]

    [<TestMethod>] 
    member test.``Vampire numbers of length 4 are well-known`` () =
        let knownVampires = [(15, 93, 1395); (21, 60, 1260); (21, 87, 1827);
                                (27, 81, 2187); (30, 51, 1530); (35, 41, 1435);
                                (80, 86, 6880)] |> Set.ofList
        getVampires 2 |> Set.ofList |> should equal knownVampires

    [<TestMethod>] 
    member test.``There are 148 distinct vampire numbers of size 6`` () =
        let vampiresCount = getVampires 3 |> Seq.distinctBy (fun (_, _, v) -> v) |> Seq.length
        vampiresCount |> should equal 148

    [<TestMethod>] 
    member test.``There is one bloody number of size 6 that can be generated in two ways`` () =
        let vampire = getVampires 3
                      |> Seq.groupBy (fun (_, _, v) -> v)
                      |> Seq.where (fun (v, ways) -> Seq.length ways = 2)
                      |> Seq.exactlyOne
                      |> fst

        vampire |> should equal 125460

