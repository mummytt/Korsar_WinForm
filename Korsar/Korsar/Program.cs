using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Metier;

namespace Korsar
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Joueur j1, j2, j3, j4;
            j1 = new Joueur(1, "Duff");
            j2 = new Joueur(2, "Bertrand");
            j3 = new Joueur(3, "Said");
            j4 = new Joueur(4, "Vincent");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new IHM_Plateau(j1, j2, j3, j4));
        }
    }
}
