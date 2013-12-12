using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numerobis
{
    public class Scribe
    {
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
                    throw new ArgumentException("Sequence not valid!");

                int number = Resolve(RomainNumber[i - 1].ToString());

                // si le rapport entre le precedent chiffre et celui la n'est pas entre 5 et 10
                // la sequence n'est pas valide!
                if (previous / number > 10)
                    throw new ArgumentException("Sequence not valid!");

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
                    throw new ArgumentException("Sequence not valid!");

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
            // Reconvertion en chiffres romains pour vérifier
            //throw new ArgumentException("An error occured while translating number");
        }
    }
}
