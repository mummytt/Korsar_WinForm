using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
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
            _imageCarte = null;
        }

        public CarteCapitaine(int id, string nom, string couleur, int attaque, Bitmap image)
        {
            _idCarte = id;
            _nomCarte = nom;
            _couleur = couleur;
            _valeurAttaque = attaque;
            _imageCarte = image;
        }

        public int getAttaque()
        {
            return _valeurAttaque;
        }
    }
}
