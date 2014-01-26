using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numerobis
{
    public class Scribe
    {
        string InvalidSequenceErrorMessage = "Invalid Sequence!";
        
        public int XXX(string RomainNumber)
        {
            Validate(RomainNumber);
            int ArabicNumber = Translate(RomainNumber);
            Verify(ArabicNumber, RomainNumber);
            return ArabicNumber;
        }

        void Validate(string RomainNumber)
        {
            // Verification avant traitement => characteres interdits, etc...
            //throw new ArgumentException("This number is not a valid romain number!");
        }

        int Translate(string RomainNumber)
        {
            int sum = 0;
            int previous = 0;
            int occurence = 1;
            List<string> ForbiddenValues = new List<string>();

            for (int i = RomainNumber.Length; i > 0; i--)
            {
                if (ForbiddenValues.Contains(RomainNumber[i - 1].ToString()))
                    throw new ArgumentException(InvalidSequenceErrorMessage);

                int number = Resolve(RomainNumber[i - 1].ToString());

                // si le rapport entre le precedent chiffre et celui la n'est pas entre 5 et 10
                // la sequence n'est pas valide!
                if (previous / number > 10)
                    throw new ArgumentException(InvalidSequenceErrorMessage);

                if (previous > number)
                {
                    sum -= number;
                    occurence = 1;
                    // une fois utilisé pour une soustraction il devient un chiffre non valide
                    ForbiddenValues.Add(RomainNumber[i - 1].ToString());
                }
                else if (previous == number)
                {
                    sum += number;
                    occurence++;
                }
                else
                {
                    sum += number;
                    occurence = 1;
                }

                // si le même chiffre est présent 4 fois de suite la aussi il y a erreur
                if (occurence > 3)
                    throw new ArgumentException(InvalidSequenceErrorMessage);

                previous = number;
            }
            return sum;
        }

        int Resolve(string c)
        {
            return (int)Enum.Parse(typeof(Numerobis.NumerobisUtil.RomainNumbers), c);
        }

        void Verify(int ArabicNumber, string RomainNumber)
        {
            string My = ArabicNumber.ToString();
            string RetranslatedValue = string.Empty;
            // Reconvertion en chiffres romains pour vérifier
            for (int i = My.Length, j = 1; i > 0; i--, j++)
            {
                int number = int.Parse(My[i - 1].ToString());
                if (number != 0)
                {
                    // represente le format a traduire A, AA, BA, etc...
                    string local = Enum.GetName(typeof(NumerobisUtil.RomainFormat), number);
                    // la lettre A represente les chiffres 1, 10, 100 et 1000
                    string A = Enum.GetName(typeof(NumerobisUtil.RomainSequenceA), j);
                    if (A != null)
                        local = local.Replace('A', A[0]);
                    // la lettre B represente les chiffres 5, 50 et 500
                    string B = Enum.GetName(typeof(NumerobisUtil.RomainSequenceB), j);
                    if (B != null)
                        local = local.Replace('B', B[0]);
                    // la lettre C étant éguale à 100 et la lettre D à 500 alors E est la prochaine lettre vacante
                    // la lettre E est la representation d'un chiffre de la dizaine supérieur
                    string C = Enum.GetName(typeof(NumerobisUtil.RomainSequenceA), j + 1);
                    if (C != null)
                        local = local.Replace('E', C[0]);
                    RetranslatedValue = local + RetranslatedValue;
                }
            }
            if (!RetranslatedValue.Equals(RomainNumber))
                throw new ArgumentException(InvalidSequenceErrorMessage);
        }
    }
}
