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
            _idCarte = 0;
            _nomCarte = "";
            _couleur = "";
            _valeurAttaque = 0;
        }

        public CarteCapitaine(int id, string nom, string couleur, int attaque)
        {
            _idCarte = id;
            _nomCarte = nom;
            _couleur = couleur;
            _valeurAttaque = attaque;
        }

        public int getAttaque()
        {
            return _valeurAttaque;
        }
    }
}
