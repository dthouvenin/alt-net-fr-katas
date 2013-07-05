Solution C# 1 (Damien)
================

J'ai adopté une approche assez rustique, plutôt centrée sur les tests que sur la performance.

J'ai commencé par faire les méthodes d'encodage d'un mot, puis d'une phrase (en extrayant les mots par une regex).

Ensuite j'ai créé une interface de dictionnaire qui permet d'enregistrer plusieurs couples de clé-mot et de retrouver toutes les propositions de mots correspondants à la clé.
Comme mon objectif n'était pas la perf, je ne me suis pas trop cassé sur l'implémentation et j'ai utilisé une Hashtable avec des StringCollection. 

J'ai injecté ce dico dans le décodeur pour proposer un décodage de mot, puis de phrase qui remplace un mot réduit par son original quand il n'y a pas d'ambiguïté, ou par la liste des possibilités quand il y en a plusieurs.

Pour finir, j'ai fait deux tests qui sont plutôt des démos en utilisant le dictionnaire d'Ubuntu.

Ainsi *"dns ct exmpl il y a bcp d mts ambgs"*

Devient *"(danois danoise dans dansa danse dense donnais donnes donneuse dons douanes doyennes doyens dunes) 
(cet cette cita cite coite cota cote coteau cotte couette couteau coyote ct cuit cuite cuti) exemple il (y youyou) (a ai aie au) beaucoup (de dieu do du due duo) 
(mates matois matoise mats mets mettais mettes meutes miettes mites miteuse mitose moites motos mots mottes mouettes muets muettes mutais mutes) (ambages ambigus)"*

Comme le suggère Yann, pour aller plus loin il faudrait utiliser la fréquence des couples de mots pour désambiguiser : *"il y a"* est plus fréquent que *"il youyou au"* .

Mais ça sera pour une autre fois, peut-être ?

N'hésitez pas à forker et proposer des évolutions :-) 