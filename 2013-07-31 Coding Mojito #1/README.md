Coding Mojito #1 : Sujets divers
================

Cette rencontre, organisée sous un format différent des précédentes, a été l'occasion de beaucoup plus discuter, mais tout de même de coder pour certains d'entre nous !

Plusieurs sujets étaient proposés, dont les sujets déjà traités par le passé, pour ceux qui n'avaient pas pu participer.

Le sujet qui a remporté le plus de succès est celui de la Skyline, dont le principe est d'obtenir, à partir d'une liste d'immeubles, le tracé de la ligne d'horizon.


Skyline (la ligne d'horizon) 
--
Vous êtes chargé de concevoir un programme d'aide aux architectes dans l'élaboration de la ligne d'horizon d'une ville, étant donnés les emplacements des bâtiments dans la ville. La difficulté est l’élimination des lignes cachées.

Tous les bâtiments sont de forme rectangulaire et ils partagent un fond commun (la ville où ils sont construits est très plate). La ville est également considérée en deux dimensions. Un bâtiment est spécifié par un triplet (Li, Hi, Ri) où Li et Ri sont les coordonnées gauche et droite, respectivement, du bâtiment i et Hi est la hauteur du bâtiment. 

Dans le schéma ci-dessous les bâtiments sont indiqués sur la gauche avec les triplets (1,11,5), (2,6,7), (3,13,9), (12,7,16), (14,3,25 ), (19,18,22), (23,13,29), (24,4,28)

La ligne d'horizon, à droite, est représentée par la séquence: (1, 11, 3, 13, 9, 0, 12, 7, 16, 3, 19, 18, 22, 3, 23, 13, 29, 0)
![illustration](https://github.com/dthouvenin/alt-net-fr-katas/raw/master/2013-07-31%20Coding%20Mojito%20%231/skyline-kata.png) 

**Entrée**

Le programme prend en entrée une séquence de triplets de construction. Les bâtiments sont triés par ordre croissant de leur coordonnée gauche (le premier triplet est le bâtiment avec la plus petite coordonnée Li).

**Sortie**

Le programme produit une séquence de vecteur, alternativement horizontaux (vecteurs impairs) et verticaux (vecteurs pairs). Le point de départ est le point gauche, bas de la ligne d’horizon. Le traçage de la ligne d’horizon se termine par un vecteur nul.

Exemple d'entrée : 

    1 11 5
    2 6 7
    3 13 9
    12 7 16
    14 3 25
    19 18 22
    23 13 29
    24 4 28
    
Exemple de sortie : `1 11 3 13 9 0 12 7 16 3 19 18 22 3 23 13 29 0`
