Solutions Damien (en C#)
--

J'ai choisi de traiter le sujet comme on l'avait fait pour le morpion : en partant du plus petit sous-ensemble du problème puis en complexifiant progressivement le problème en ajoutant des cas de test, et en refactorant la solution au fil de l'eau.

Après quelques passes de refactoring, je me suis dit que c'était dommage de ne pas avoir conservé l'historique et je l'ai donc recréé artificiellement. Par contre j'ai un peu eu la flemme de re-séparer chaque cas de test individuellement. Du coup les itérations 2, 3 et 4 embarquent plusieurs cas de test en même temps, mais une même génération de modélisation.

A partir de l'itération 5 j'ai dupliqué le code à chaque cas de test, on est donc vraiment en pas à pas.

Dans le temps imparti je ne suis pas allé jusqu'au bout. De plus je suis dans une impasse liée à ma modélisation. Je dois donc maintenant faire un retour arrière.

Je continue plus tard ... 