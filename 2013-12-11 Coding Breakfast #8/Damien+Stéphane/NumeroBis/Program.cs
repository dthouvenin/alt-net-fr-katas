using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumeroBis
{
    class Program
    {
        private const string exitSentence = "Aucun. Tu peux disposer Numerobis";
        static void Main(string[] args)
        {
            var numerobis = new Scribe();
            while(true)
            {
                Console.WriteLine("Oh ma reine, quel nombre souhaites-tu traduire ?");
                var ceQueDitCleopatre = Console.ReadLine();
                if (string.Equals(exitSentence, ceQueDitCleopatre))
                {
                    Console.WriteLine("Bien ma reine. Je suis honoré de t'avoir servi.");
                    break;
                }
                if(string.IsNullOrWhiteSpace(ceQueDitCleopatre))
                {
                    Console.WriteLine("Ma reine ? Si je t'importune, il te suffis de me dire \"{0}\".", exitSentence);
                    continue;                                        
                }
                try
                {
                    var nombre = numerobis.CombienVaut(ceQueDitCleopatre);
                    Console.WriteLine("Très glorieuse reine, quand ces misérables romains écrivent {0} cela veut en réalité dire {1}", ceQueDitCleopatre, nombre);
                }
                catch(Exception e)
                {
                    Console.WriteLine("Désolé ma reine. Je ne peux te répondre. "+e.Message);
                }
            }
        }
    }
}
