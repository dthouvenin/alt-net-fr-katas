using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Mazes.Runner
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main(string[] commandLineArguments)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string builderPath = commandLineArguments.Length > 0 ? commandLineArguments[0] : null;
            string solverPath = commandLineArguments.Length > 1 ? commandLineArguments[1] : null;

            Application.Run(new MainForm(builderPath, solverPath));
        }
    }
}
