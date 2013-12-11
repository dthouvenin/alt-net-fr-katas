[Coding breakfast][1] de Décembre 2013 (#8) : Numerobis
================
Vous êtes le scribe de Cléopâtre, votre job est de traduire les comptes des romains en chiffres arabes. 

Comme vous êtes un peu flemmard, vous décidez d’écrire un programme pour faire le boulot à votre place.

Rappel : les chiffres romains sont I, V, X, L, C, D, M correspondant à 1, 5, 10, 50, 100, 500, 1000. [D'après [Wikipedia][2]:] La numérotation a été normalisée dans l’usage actuel et repose sur quatre principes :

- Toute lettre placée à la droite d’une autre figurant une valeur supérieure ou égale à la sienne s’ajoute à celle-ci.
- Toute lettre d’unité placée immédiatement à la gauche d’une lettre plus forte qu’elle, indique que le nombre qui lui correspond doit être retranché au nombre qui suit.
- Les valeurs sont groupées en ordre décroissant, sauf pour les valeurs à retrancher selon la règle précédente.
- La même lettre ne peut pas être employée quatre fois consécutivement sauf M.

Jeu de test : 

- I 	->	1
- X	->	10
- II	->	2
- VII	->	7
- XIX	->	19
- XLVIII	->	48
- CDIV	->	404
- MCMLXXIV	->	1974
- VX	 -> Erreur
- IXIV	->	Erreur
- IIII  ->  Erreur


[1]: http://www.meetup.com/altnetfr/events/153471712/
[2]: http://fr.wikipedia.org/wiki/Num%C3%A9ration_romaine