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
            _idCarte = 0;
            _nomCarte = "";
            _couleur = "";
            _valeurAttaque = 0;
        }

        public CartePirate(int id, string nom, string couleur, int attaque)
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
