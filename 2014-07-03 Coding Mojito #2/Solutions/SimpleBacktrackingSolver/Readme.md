#Solution à base de backtracking

Cette première solution construit un arbre. 

Quand on arrive dans une case suite à un mouvement, on construit l'état de la nouvelle cellule, en commençant par explorer toutes les directions pour savoir lesquelles sont ouvertes ou pas. On enregistre également la direction de la cellule d'où on est venu pour pouvoir revenir en arrière si besoin.

Ensuite à chaque tour, s'il y a un chemin libre, on le prend, sinon on revient en arrière.

Cette solution fonctionne sur tous les labyrinthes mais stocke beaucoup plus d'état que nécessaire.
