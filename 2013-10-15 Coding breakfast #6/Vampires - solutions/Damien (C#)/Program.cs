using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vampires
{
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
            var nbVampires = LookForVampires2(nbDigits/2);
            Info("{0} nombres trouvés", nbVampires);
            Console.ReadLine();
        }

        static int LookForVampires1(int nbDigits)
        {
            var min = (Int32) Math.Pow(10, nbDigits-1);
            var max = (Int32)Math.Pow(10, nbDigits);
            var results = 0;
            for (var a = min; a < max; a++)
            {
                int remainder;
                var b = Math.DivRem(max*a, a - 1, out remainder);
                if (remainder != 0)
                    continue;
                if(b >= max || (b%10) == 0)
                    continue;
                Info("{2} = {0}x{1}", a, b, a*b);
                results++;
            }
            return results;
        }

        static int LookForVampires2(int nbDigits)
        {
            var min = (Int32)Math.Pow(10, nbDigits - 1);
            var max = (Int32)Math.Pow(10, nbDigits);
            var results = 0;
            for (var a = min; a < max; a++)
            {
                for(var b = a; b<max; b++)
                {
                    if ((b % 10) == 0 && (a % 10) == 0)
                        continue;
                    var fragmentDigits = new int[nbDigits * 2];
                    var vampireDigits = new int[nbDigits * 2];
                    var vampire = a*b;
                    fragmentDigits[0] = a / min;
                    fragmentDigits[1] = a % min;
                    fragmentDigits[2] = b / min;
                    fragmentDigits[3] = b % min;
                    var vampireHigh = vampire / max;
                    var vampireLow = vampire % max;
                    vampireDigits[0] = vampireHigh / min;
                    vampireDigits[1] = vampireHigh % min;
                    vampireDigits[2] = vampireLow / min;
                    vampireDigits[3] = vampireLow % min;
                    Array.Sort(fragmentDigits);
                    Array.Sort(vampireDigits);                    
                    if (!fragmentDigits.SequenceEqual(vampireDigits))
                        continue;
                    Info("{2} = {0}x{1}", a, b, vampire);
                    results++;
                }
            }
            return results;
        }

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

    }
}
