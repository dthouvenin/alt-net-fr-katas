using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NumeroBis
{
    public class Scribe
    {

        private int ValeurChiffre(char c)
        {
            switch (c)
            {
                case 'I':
                    return 1;
                case 'V':
                    return 5;
                case 'X':
                    return 10;
                case 'L':
                    return 50;
                case 'C':
                    return 100;
                case 'D':
                    return 500;
                case 'M':
                    return 1000;
            }
            throw new ArgumentOutOfRangeException("c", c, "Chiffre non reconnu");
        }

        public int CombienVaut(string nombreRomain)
        {
            var total = 0;
            var dernierChiffre = 0;
            var repetitions = 0;
            var maxSoustracteur = 100;
            for (int i = 0; i < nombreRomain.Length; i++)
            {
                var chiffre = ValeurChiffre(nombreRomain[i]);
                if (dernierChiffre == 0)
                {
                    total = dernierChiffre = chiffre;
                    continue;
                }
                if (chiffre == dernierChiffre)
                {
                    repetitions += 1;
                    if (repetitions >= 3 && chiffre<1000)
                        throw new ArgumentException("Ceci n'est pas un nombre Romain correct : un même chiffre ne peut pas être répété plus de 3 fois, sauf M");
                }
                else
                {
                    if (chiffre > dernierChiffre)
                    {
                        if (repetitions > 0)
                            throw new ArgumentException("Ceci n'est pas un nombre Romain correct: un même soustracteur ne peut être employé qu'une seule fois");
                        if (chiffre > 10*dernierChiffre)
                            throw new ArgumentException("Ceci n'est pas un nombre Romain correct: le soustracteur ne peut être que l'unité inférieure");
                        if(dernierChiffre > maxSoustracteur)
                            throw new ArgumentException("Ceci n'est pas un nombre Romain correct: après une soustraction, les chiffres ne peuvent qu'inférieurs d'un ordre");
                        total -= 2*dernierChiffre;
                        maxSoustracteur = dernierChiffre / 10;
                    }
                    repetitions = 0;
                }
                dernierChiffre = chiffre;
                total += chiffre;
            }
            return total;
        }
    }
}
