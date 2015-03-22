using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class CarteCapitaine : Carte
    {
        private int _valeurAttaque;

        public CarteCapitaine()
        {
            _IDCarte = 0;
            _NomCarte = "";
            _Couleur = "";
            _valeurAttaque = 0;
        }

        public CarteCapitaine(int id, string nom, string couleur, int attaque)
        {
            _IDCarte = id;
            _NomCarte = nom;
            _Couleur = couleur;
            _valeurAttaque = attaque;
        }

        public int getAttaque()
        {
            return _valeurAttaque;
        }
    }
}
