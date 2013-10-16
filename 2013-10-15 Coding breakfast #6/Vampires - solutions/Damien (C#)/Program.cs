using System;
using System.Collections.Generic;
using System.Linq;

namespace Vampires
{
    public struct Vampire
    {
        public Vampire(int a, int b, int v)
        {
            this.a = a;
            this.b = b;
            this.v = v;
        }
        public int a;
        public int b;
        public int v;
    }
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length<1)
                Error("Usage: Vampires n /* N: nombre pair de chiffres */");
            int nbDigits;
            if(!int.TryParse(args[0], out nbDigits))
                Error("Usage: Vampires n /* N: nombre pair de chiffres */");
            Info("Recherche des vampires à {0} chiffres", nbDigits);
            var vampires = LookForVampires(nbDigits/2)
                .ToLookup(res => res.v, res => string.Format("{0}x{1}", res.a, res.b));
            foreach(IGrouping<int, string> g in vampires)
                Info("{0} = {1}", g.Key, string.Join(" ou ", g));           
            Info("{0} nombres trouvés", vampires.Count);
            Console.ReadLine();
        }
        
        public static int Pow10(int n)
        {
            return n > 0 ? 10*Pow10(n - 1) : 1;
        }

        public static IEnumerable<int> Digits(int n)
        {
            do
            {
                yield return n%10;
            } while ((n = n/10) > 0);
        }

        public static int[] SortedDigits(int n)
        {
            var res = Digits(n).ToArray();
            Array.Sort(res);
            return res;
        }

        public static int[] SortedDigits(int a, int b)
        {
            var res = Digits(a).Concat(Digits(b)).ToArray();
            Array.Sort(res);
            return res;
        }

        static IEnumerable<Vampire> LookForVampires(int nbDigits)
        {
            var min = Pow10(nbDigits - 1);
            var max = 10*min;
            for (var a = min; a < max; a++)
            {
                for(var b = a; b<max; b++)
                {
                    if ((b % 10) == 0 && (a % 10) == 0)
                        continue;
                    var vampire = a * b;
                    var fragmentDigits = SortedDigits(a, b);
                    var vampireDigits = SortedDigits(vampire);
                    if (!fragmentDigits.SequenceEqual(vampireDigits))
                        continue;
                    yield return new Vampire(a, b, vampire);
                }
            }
        }

        #region utilitaires
        static void Info(string msgFmt, params object[] args)
        {
            Console.WriteLine(args.Length==0 ? msgFmt : string.Format(msgFmt, args));
        }

        static void Error(string msgFmt, params object[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red; 
            Info(msgFmt, args);
            Console.ResetColor();
        }
        #endregion
    }
}
