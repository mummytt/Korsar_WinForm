using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Carte
    {
        public int _IDCarte { get; set; }
        public string _Couleur { get; set; }
        public string _NomCarte { get; set; }

        public Carte()
        {
            _IDCarte = 0;
            _Couleur = "";
            _NomCarte = "";
        }

        public Carte(int id, string couleur, string nom)
        {
            _IDCarte = id;
            _Couleur = couleur;
            _NomCarte = nom;
        }

        public string afficherNomCarte()
        {
            return _NomCarte;
        }
    }
}
