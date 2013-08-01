type Edge = | Left | Right 

let skyline buildings =
    let handleEdge (_, heights) (x, kind, i, height) =
        match kind with
        | Left -> x, heights |> Map.add i height
        | Right -> x, heights |> Map.remove i 

    buildings
        // On décompose chaque immeuble en 2 bords,
        |> Seq.mapi (fun i (x, h, r) -> [(x, Left, i, h); (r, Right, i, h)])
        // qu'on fusionne en une seule séquence...
        |> Seq.collect id
        // qu'on trie en fonction de X...
        |> Seq.sort
        // puis à chaque X on construit la liste des immeubles correspondants
        |> Seq.scan handleEdge (0, Map.empty)
        // et on prend la hauteur maximum de ces immeubles (en chaque X)
        |> Seq.map (fun (x, heights) -> x, heights |> (Seq.map (fun kvp -> kvp.Value)) |> Seq.fold max 0)
        // on considère ensuite les valeurs 2 par 2
        |> Seq.pairwise
        // pour ne garder que celles qui correspondent à des changements de hauteur
        |> Seq.choose (fun ((x1, h1), (x2, h2)) -> if h1 <> h2 then Some([x2; h2]) else None)
        // et enfin on concatène tout pour mettre au format attendu par l'énoncé
        |> Seq.concat
        // et on force l'évaluation, parce que pour le moment c'était paresseux
        |> Seq.toList
    
let answer = skyline [(1, 11, 5); (2, 6, 7); (3, 13, 9); (12, 7, 16); (14, 3, 25); (19, 18, 22); (23, 13, 29); (24, 4, 28)]