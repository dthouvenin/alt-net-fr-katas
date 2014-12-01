using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static private Random random = new Random(); 
        static void Center(int width, string text)
        {
            var pad = (width + text.Length) / 2;
            Console.WriteLine(text.PadLeft(pad));
        }

        static string BuildLine(int n)
        {
            var line = new char[n*2];
            for (int i = 0; i < n; i++)
            {
                line[i*2] = random.Next(4096) < 512 ? '°' : '^';
                line[i * 2 + 1] = ' ';
            }
            return new String(line);
        }

        static void Main(string[] args)
        {            
            Center(60, "*");
            for (int i = 2; i < 20; i++)
            {
                Center(60, BuildLine(i));
            }
            Center(60, "XXX");
            Center(60, "XXX");
            Center(60, "XXX");
            Console.ReadKey();
        }
    }
}
