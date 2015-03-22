using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class CarteAmiral : Carte
    {
        private int _valeurAttaque;

        public CarteAmiral()
        {
            _IDCarte = 0;
            _NomCarte = "";
            _Couleur = "";
            _valeurAttaque = 0;
        }

        public CarteAmiral(int id, string nom, int attaque)
        {
            _IDCarte = id;
            _NomCarte = nom;
            _valeurAttaque = attaque;
        }

        public int getAttaque()
        {
            return _valeurAttaque;
        }
    }
}
