(**
# F# Poker Kata par Jérémie, Thomas et Damien 
*j'espere que je ne me trompe pas dans les prénoms...*

[Lien GitHub](https://github.com/dthouvenin/alt-net-fr-katas/tree/master/2014-01-22%20Coding%20Breakfast%20%232014.1/Solutions/F%23%20-%20J%C3%A9r%C3%A9mie)

**Un mot sur FSharp.Formatting et literate F#**

La doc est totalement générée à partir du Markdown contenu dans le fichier Poker.fsx.

Ce fichier fsx est cependant un fichier F# script valide qui peut être executé dans fsi !

Plus d'infos sur [le site de FSharp.Formatting](http://tpetricek.github.io/FSharp.Formatting/index.html)



## Overview
*)

(** Les couleurs sont représentée par une discriminated union: *)
type Color =
    | Spade
    | Heart
    | Club
    | Diamond

(**
On représente les valeurs des cartes de 2 à 14 comme ceci :

    2  3  4  5  6  7  8  9 10  J  Q  K  A
    2  3  4  5  6  7  8  9 10 11 12 13 14

L'as vaut 14 pour simplifier la plupart des cas,
on a juste un cas particulier pour la suite.

Les actives patterns `Ace`, `King`, `Queen`, `Jack` permettent d'utiliser
les noms dans les patterns matching au lieu des valeurs 14, 11, 12 et 13.
*)
let isValue n v = if v = n then Some() else None

let (|Ace|_|) = isValue 14
let (|King|_|) = isValue 13
let (|Queen|_|) = isValue 12
let (|Jack|_|) = isValue 11

(** Une carte est simplement un tuple couleur, value: *)
type Card = Card of Color * int

(**
Les pattern matchings `Color` et `Value` matchent n'importe quelle carte
et en donne la couleur ou la valeur.
*)
let color (Card(c,_)) =  c
let value (Card(_,v)) =  v

let (|Color|) = color
let (|Value|) = value

(** La main est une liste de `Card`.
La plupart des fonctions ont besoin que la liste soit triée. *)
let sort = List.sortBy value

(**
## Couleur
L'active pattern `HandColor` indique si on a une couleur, et laquelle.

Il trouve la couleur de la première carte et vérifie recursivement que toutes les autre ont la même couleur.

Il retourne alors la couleur de la première carte.
*)
let (|HandColor|_|) hand =
   let rec loop firstColor =
       function
       | Color(c) :: tail when c = firstColor -> loop firstColor tail
       | [] -> Some firstColor
       | _ -> None
   match hand with
   | Color(c) :: tail -> loop c tail
   | [] -> None

(**
## Suite
L'active pattern `Sequence` indique si on a une suite, et quelle est la plus haute carte.

Il fonctionne sur une main classée de la plus petite à la plus grande valeur.

Il prend la valeur de la première (plus petite) carte, et vérifie recursivement que la
carte suivante - 1 à la valeur de la précédente. Arrivé au bout, il sort la valeur de la dernière (plus forte) carte.
*)
let (|Sequence|_|) hand =
    let rec loop previous =
        function
        | Value(v) :: tail when previous = v-1 -> loop v tail
(** Le cas particulier de la suite A 2 3 4 5 est assuré par une
condition de sortie supplémentaire : *)
        // match the special case of A 2 3 4 5 as 2 3 4 5 14 !!
        | [Value(Ace)] when previous = 5 -> Some 5 
(** Le pattern en est là quand il a trouvé 2 3 4 5.
Si la dernière carte est un as, on est en presence d'une suite à 5. *)
        | [] -> Some previous
        | _ -> None
    match hand with
    | Value v :: tail -> loop v tail
    | [] -> None

(**
## Quinte Flush
L'active pattern `QuinteFlush` indique si on a une suite et une couleur.

On utilise `&` pour combiner les deux active patterns.
*)
let (|QuinteFlush|_|) hand =
   match hand with
   | Sequence(v) & HandColor(c) -> Some(c,v)
   | _ -> None
(**
## Autres combinaisons
Pour les autres mains, on utilise l'active pattern `GroupCards`
qui retourne une liste de paires (value,count) classée 
par count décroissant.

On matchera alors les counts de cette liste pour trouver
les carrés, full, brelans, doubles paires et paires.
*)
let (|GroupCards|) hand =
     hand
     |> Seq.countBy value
     |> Seq.sortBy snd
     |> Seq.toList
     |> List.rev

(** 
### Carré
Le carré contient un groupe de 4 cartes identiques, et une carte seule
*)

let (|Square|_|) = 
    function
    | GroupCards [s, 4; _] -> Some(s)
    | _ -> None
(**
### Full
Le full contient un brelan et une paire
*)
let (|Full|_|) =
     function
     | GroupCards [b,3; p,2] -> Some(b,p)
     | _ -> None 
(**
### Brelan
Le brelan contient un groupe de 3 cartes identiques et 2 cartes seules
*)
let (|Brelan|_|) =
    function
    | GroupCards [b,3; _; _] -> Some(b)
    | _ -> None
(**
### Double paire
La double paire contient deux paires, et une carte seule.

On retourne la plus haute valeur en premier.
*)
let (|DoublePair|_|) =
    function
    | GroupCards [p1, 2; p2,2; _] -> Some(max p1 p2, min p1 p2)
    | _ -> None

(**
### Paire
La paire contient deux cartes identiques et trois cartes seules. 
*)
let (|Pair|_|) =
    function
    | GroupCards [p,2; _,1; _; _]  -> Some(p)
    | _ -> None
(**
### La plus haute carte
Sinon on prend simplement la carte la plus haute.
*)
let (|High|_|) =
    function
    | GroupCards ((_,1) :: _) as hand ->  Some(List.maxBy value hand)
    | _ -> None

(**
## Nommage d'une combinaison

Les fonction svalue et scolor sont utilisée pour le pretty print, 
avec les noms de cartes et les caractères unicodes pour les couleurs.
*)
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

(**
la fonction `showHand` prend une main, la trie,
et match avec les active patterns de chaque combinaison pour afficher
le résultat.
*)
let showHand hand =
    match sort hand with
    | QuinteFlush(c,v) -> sprintf "Quint Flush of %a%a" svalue v scolor c
    | Square(v) -> sprintf "Square of %a" svalue v
    | Full(b,p) -> sprintf "Full of %a by %a" svalue b svalue p 
    | HandColor(c) -> sprintf "Color of %a" scolor c 
    | Sequence(v) -> sprintf "Sequence of %a" svalue v
    | Brelan(b) -> sprintf "Brelan of %a" svalue b
    | DoublePair(p1, p2) -> sprintf "Double pair of %a and %a" svalue p1 svalue p2
    | Pair(p) -> sprintf "Pair of %a" svalue p
    | High(Card(c,v)) -> sprintf "Highest %a%a" svalue v scolor c
    | _ -> hand 
           |> Seq.map (fun (Card(c,v)) -> sprintf "%a%a" svalue v scolor c)
           |> String.concat " "
    |> printfn "%s"

(**
## Testes

Les examples utilisent les fonctions `h`,`s`,`c` et `d` pour
`Hear`, `Spade`, `Club` et `Diamond`. Elles prennent une valeur et 
constuisent une carte de la couleur donnée.
*)
let h n= Card(Heart, n)
let s n= Card(Spade, n)
let c n= Card(Club, n)
let d n= Card(Diamond, n)

(** Les valeurs `a`, `k`, `q`, `j` représentent les valeurs
    de l'as (14), roi (13), reine (12) et valet (11).  *)
let a = 14
let k = 13
let q = 12
let j = 11

(** Teste la Quinte flush. *)
[h 7;h 8; h 9;h 10; h j] |> showHand

(** Teste la quinte flush A 2 3 4 5. c'est le cas particulier
    de Sequence.*)
[h a;h 2; h 3;h 4; h 5] |> showHand
(** Teste la quinte flush 10 J Q K A. C'est l'autre extreme. *)
[h 10;h j; h q;h k; h a] |> showHand
(** Teste une main sans combinaison. *)
[s 5; h 3; c q; d 4; h 8] |> showHand
(** Teste une double paire. *)
[s 5; h 3; c 5; d 4; c 3] |> showHand
(** Teste As carte haute. *)
[s 9; h 10; c j; d q; h a] |> showHand
(** Teste un Carré. *)
[s 6; h 6; h j; d 6; c 6] |> showHand
(** Teste un Brelan. *)
[s j; d 3; h j; c q; d j] |> showHand
(** Teste un Full. *)
[s j; d 3; h j; c 3; d j] |> showHand
(** Teste une paire. *)
[s 5; h 3; c 5; d 4; c a] |> showHand
(** Teste une couleur. *)
[s 5; s 3; s 5; s 4; s a] |> showHand
(** Teste une suite. *)
[h 7;s 8; d 9;c 10; h j] |> showHand
