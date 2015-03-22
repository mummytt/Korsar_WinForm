using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class CartePirate : Carte
    {
        private int _valeurAttaque;

        public CartePirate()
        {
            _IDCarte = 0;
            _NomCarte = "";
            _Couleur = "";
            _valeurAttaque = 0;
        }

        public CartePirate(int id, string nom, string couleur, int attaque)
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
