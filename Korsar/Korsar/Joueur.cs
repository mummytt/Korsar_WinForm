using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korsar
{
    public class Joueur
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public int NbCartesEnMain { get; set; }
        public int Or { get; set; }
        

        public bool verifNomJoueur(string nom)
        {

            if (nom.Length < 20 && nom.Length>0)
            {
                Nom = nom.ToUpper();
                return true;
            }

            return false;
        }

    }
}
