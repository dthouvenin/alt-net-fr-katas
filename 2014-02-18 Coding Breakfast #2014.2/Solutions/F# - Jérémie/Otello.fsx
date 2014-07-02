(**# Otello
*Version F# par Jérémie Chassaing / thinkbeforecoding*

## Dans les grandes lignes

L'algorithme part des cases de la couleur du joueur, et avance dans chaque direction pour chercher
une case vide n'ayant que des cases de la couleur adverse la séparant de la couleur du joueur.

La solution retenue n'est probablement pas optimale, mais a l'avantage d'être assez simple.

Le temps de calcul augmente quand on approche de la fin, mais vu la taille du plateau, ca ne pose
pas vraiment de problème.


## Modèle

Le contenu des cases est représenté par le type Color: *)
type Color = White | Black | Empty

(** le plateau est alors un tableau de tableau de 8 * 8 *)
type Board = Color array array

(** Nous utiliserons le type ``position`` pour localiser les cases du plateau  *)
type Position = Position of int * int

(** et le type ``Vector`` pour indiquer une direction *)
type Vector = Vector of int * int
    with
    static member (*) (v: Vector, i: int) =
            match v with
            | Vector(x,y) -> Vector (x*i, y*i)
    static member (+) (p: Position, v: Vector)=
            match p,v with
            | Position(x,y), Vector(vx,vy) -> Position(x + vx, y + vy)

(** les operateurs vector * int et position + vector simplifient le code un peu plus loin. *)

(**## Construction du plateau 
Rien de bien compliqué ici, on construit un tableau de départ:
*)

let board =
 let w, b, e = White, Black, Empty
 [| [| e; e; e; e; e; e; e; e |]
    [| e; e; e; e; e; e; e; e |]
    [| e; e; e; e; e; e; e; e |]
    [| e; e; e; w; b; e; e; e |]
    [| e; e; e; b; w; e; e; e |]
    [| e; e; e; e; e; e; e; e |]
    [| e; e; e; e; e; e; e; e |]
    [| e; e; e; e; e; e; e; e |] |]

(**## getCell 
 Cette fonction retourne simplement le contenu de la cellule en x y 
*)
let getCell x y board = 
    let row = Array.get board y
    Array.get row x

(**## inBoard 
 Cette fonction teste si la position est dans les limites du plateau
*)
let inBoard (Position(x,y)) =
    x >= 0 && x < 8 && y >= 0 && y < 8
(** Elle est accompagnée d'un active pattern qui indique si la position est dans le plateau *)
let (|InBoard|_|) p = if inBoard p then Some() else None

(**## find 
La fonction ``find`` retourne toutes les cases de la couleur ``color``.
*)

let find color board =
    seq {
        for y in [0..7] do
        for x in [0..7] do
        match board |> getCell x y with
        | c when c = color -> yield Position (x,y)
        | _ -> () }

(**## swap
La fonction ``swap`` retourne la couleur oposée
*)
let swap = function White -> Black | Black -> White | Empty -> Empty 

(**## isPlayable
C'est le coeur de l'algorithme.

On part de la position ``start`` selon la direction ``vector`` un vecteur unitaire. 
*)
let isPlayable  (start: Position) (vector: Vector) playerColor board  =
(** on trouve la couleur de l'adversaire *)
    let otherColor = swap playerColor
(** L'active pattern ``Cell`` donne la couleur à la position donnée *)
    let (|Cell|) (Position(x,y)) = 
         getCell x y board
(** La fonction récursive maintient la distance ``length`` du point de départ. Une longueur de 1 n'est pas
suffisante puisque qu'il faut au moins un pion de l'adversaire entre le point de départ et la case à jouer.
*)
    let rec loop length =
        let pos = start + vector * length 
        match pos with
        | InBoard & Cell c when c = otherColor -> loop (length + 1)
        | InBoard & Cell Empty  when length > 1 -> Some pos
        | _ -> None
    loop 1

(** On construit ici les 8 vecteurs de directions *)
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

(**## playableCells 
Cette fonction agence les différentes parties pour retourner la solution complète :
*)
let playableCells color board =
    seq {
        for p in board |> find color do
        for v in vectors do
        match isPlayable p v color board with
        | Some solution -> yield solution
        | None -> ()}
