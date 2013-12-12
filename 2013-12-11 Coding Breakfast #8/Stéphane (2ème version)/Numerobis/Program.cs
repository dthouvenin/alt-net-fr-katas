using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numerobis
{
    class Program
    {
        private static string Command = string.Empty;
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine();
                    Console.Write("Enter a romain number :  ");

                    Command = Console.ReadLine();
                    // Command de sortie
                    if (Command.ToLower() == "exit")
                        break;
                    // Traitement de la valeur donner
                    Scribe scrib = new Scribe();
                    int ArabicNumber = scrib.XXX(Command);

                    Console.WriteLine();
                    Console.WriteLine("The traduction of : {0} is {1}", Command, ArabicNumber);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
