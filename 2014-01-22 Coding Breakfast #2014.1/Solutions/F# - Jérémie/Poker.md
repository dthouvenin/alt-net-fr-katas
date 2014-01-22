# F# Poker Kata par Jérémie, Thomas et Damien 
*j'espere que je ne me trompe pas dans les prénoms...*

## Overview

On représente les valeurs des cartes de 2 à 14 comme ceci :
```
  2  3  4  5  6  7  8  9 10  J  Q  K  A
  2  3  4  5  6  7  8  9 10 11 12 13 14
```
L'as vaut 14 pour simplifier la plupart des cas, on a juste un cas particulier pour la suite.
 
Les couleurs sont représentée par une discriminated union:
```
 type Color = 
    | Spade
    | Heart
    | Club
    | Diamond
```

Une carte est simplement un tuple couleur, value:
```
type Card =
   | Card of Color * int
```

Les actives patterns Ace, King, Queen, Jack permettent d'utiliser les noms dans
les patterns matching au lieu des valeurs 14 11 12 et 13.

Let pattern matchings Color et Value matchent n'importe quelle carte et en donne la couleur ou la valeur.

Une main est une suite de carte.

## HandColor
L'active pattern HandColor indique si on a une couleur, et laquelle.

Il trouve la couleur de la première carte et vérifie recursivement que toutes les autre ont la même couleur.

Il retourne alors la couleur de la première carte.

## Sequence
L'active pattern Sequence indique si on a une suite, et quelle est la plus haute carte.

Il fonctionne sur une main classée de la plus petite à la plus grande value.

Il prend la valeur de la première (plus petite) carte, et vérifie recursivement que la carte suivante à la valeur
de la précédente +1. Arrivé au bout, il sort la valeur de la dernière (plus forte) carte.

Le cas particulier de la suite A 2 3 4 5 est assuré par une condition de sortie supplémentaire :
```
   | [Value(Ace)] when previous = 5 -> Some(5)
```
Le pattern en est là quand il a trouvé 2 3 4 5. Si la dernière carte est un as, on est en presence d'une suite à 5.

## Quinte Flush
La quinte flush indique si on a un couleur et une suite.

## groupCards
Pour les autres mains, on utilise la fonction groupCars qui return une liste de paires (value,count) classée 
par count décroissant.

De cette facon, un carré matchera (v,4)::_ où v est la valeur du carré, un full (b,3)::(p,2)::_ ou b est le brelan
et p la pair, une double pair sera (p1,2) :: (p2,2) :: _

Chaque figure est représentée par un active pattern.

## showHand
la fonctin showHand prend un main, la classe, et match avec les active patterns de chaque figure pour afficher
le résultat.

Les fonction svalue et scolor sont utilisée pour le pretty print, avec les noms de cartes et les caractères unicodes
pour les couleurs.

## Examples

Les examples utilisent les fonction h,s,c et d pour Hear, Spade, Club et Diamond. Elles prennent une valeur et 
constuisent une carte de la couleur donnée.

Les valeurs a, k, q, j représentent les valeurs de l'as (14), roi (13), reine (12) et valet (11).






 
