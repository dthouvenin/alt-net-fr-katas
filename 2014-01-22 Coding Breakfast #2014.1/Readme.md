Coding breakfast #2014.1 "La main heureuse"
--

Vous vous êtes pris de passion pour le poker mais, trop impulsif, vous voulez développer un petit programme pour vous aider à miser. Les règles du Poker (variante « Texas Hold’em ») sont les suivantes (simplifiées) : Le jeu se joue avec un jeu de 52 cartes. L’as peut compter comme As ou comme 1. Chaque joueur reçoit 2 cartes et mise, puis on dévoile 3 cartes au milieu de la table ( « flop »); celles-ci sont communes à tous les joueurs. Après un nouveau tour de mises le donneur dévoile une quatrième carte ( « turn ») et après un troisième tour de mise une cinquième et dernière carte (« the river »)avant le tour de mises finales. Au total, les joueurs qui vont jusqu’au bout misent donc quatre fois. Les derniers joueurs en lice présentent leur meilleure main de 5 cartes choisies parmi les 5 publiques et leur 2 privées.
Les cartes ont une valeur (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, Valet, Dame, Roi, As) et une couleur (Pique ♠, Cœur♥, Carreau♦, Trefle♣). Les combinaisons sont, par ordre décroissant de force : 
•	La quinte flush : 5 cartes de même couleur et dont les valeurs se suivent. Ex : 7♥, 8♥, 9♥, 10♥, V♥
•	Le carré : 4 cartes de même valeur + une carte quelconque. Ex : 7♥, 7♦, 7♠, 7♣, D♥
•	Le full : 3 cartes de même valeur et 2 autres cartes de même valeur. Ex : 7♦, 7♠, 7♣, D♥, D♠
•	La couleur : 5 cartes de valeur quelconque mais de même couleur. Ex : 2♥, 4♥, V♥, R♥, 7♥
•	La suite : 5 cartes dont les valeurs se suivent, et de couleurs différentes. . Ex : 7♦, 8♠, 9♣, 10♥, V♠
•	Le brelan : 3 cartes de même valeur et 2 autres cartes quelconques. Ex : 7♦, 7♠, 7♣, 4♥, D♠
•	La double paire: 2 couples de cartes de même valeur et 1 carte quelconque. Ex : 7♦, 7♠, V♣, V♥, 5♠
•	La paire: 2 cartes de même valeur et 3 cartes quelconques. Ex : 7♦, 7♠, 2♣, 8♥, D♠
•	La carte haute : 5 cartes ne formant aucune des combinaisons ci-dessus. Ex : 2♦, 4♠, 5♣, 8♥, D♠
Les mains sont nommées par la combinaison et la valeur de la plus haute carte de la série la plus longue (puis celle de la série courte pour le full ou la double paire). Dans les exemples ci-dessus : quinte flush au valet de cœur, carré de 7, full de 7 par les dames, couleur au roi de cœur, suite au valet, brelan de 7, double paire de valets par les 7, paire de 7, dame.
Exercices :
1.	Nommer une main 
2.	Comparer deux mains
3.	Au dernier tour (« river »), identifier, parmi n joueurs, celui qui peut proposer la meilleure main en combinant ses 2 cartes privées avec les 5 cartes publiques
4.	Au deuxième (« flop ») et troisième (« turn ») tours, identifier ma meilleure main 
5.	Au troisième tour (« turn » : 2 cartes privées et 4 cartes publiques) calculer mes chances d’améliorer ma main au dernier tour. (cf. rappel de math ci-dessous)
6.	Idem au 2ème tour

