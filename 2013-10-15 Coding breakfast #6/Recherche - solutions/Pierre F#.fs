module Search

// The solution
type Status = | Found of int | NoResult | Searching

let deadEnd = fun _ -> NoResult
let branch i left right (input: int array) =
    if input.[i] = i then Found i
    else if i < input.[i] then left input
    else right input

let search (input: int array) =
    if input.Length = 0 then NoResult
    else
        let rec dicho l r (input: int array) =
            if r - l = 1 then NoResult
            else let m = (l + r) / 2
                 branch m (dicho l m) (dicho m r) input
        let r = input.Length - 1
        branch 0 deadEnd (branch r (dicho 0 r) deadEnd) input


// The tests
open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest

[<TestClass>]
type SearchTests() =
    [<TestMethod>] 
    member test.``Empty array has no answer`` () =
        search [||] |> should equal NoResult

    [<TestMethod>] 
    member test.``Singleton 0 has answer 0`` () =
        search [|0|] |> should equal (Found 0)

    [<TestMethod>] 
    member test.``Singleton 1 has no answer`` () =
        search [|1|] |> should equal NoResult

    [<TestMethod>] 
    member test.``0-starting array has answer 0`` () =
        search [|0; 3; 7|] |> should equal (Found 0)

    [<TestMethod>] 
    member test.``1-starting array no answer`` () =
        search [|1; 3; 7|] |> should equal NoResult

    [<TestMethod>] 
    member test.``2-ending array of size 3 has answer 2`` () =
        search [|-5; -2; 2|] |> should equal (Found 2)

    [<TestMethod>] 
    member test.``1-ending array of size 3 has no answer`` () =
        search [|-5; -2; 1|] |> should equal NoResult

    [<TestMethod>] 
    member test.``1-middle array of size 3 has answer 1`` () =
        search [|-5; 1; 5|] |> should equal (Found 1)

    [<TestMethod>] 
    member test.``Sample set has answer 3`` () =
        search [|-2; 0; 1; 3; 5; 7|] |> should equal (Found 3)