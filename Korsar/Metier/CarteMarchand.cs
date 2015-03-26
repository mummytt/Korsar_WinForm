using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Metier
{
    public class CarteMarchand : Carte
    {
        private int _valeurOr;

        public CarteMarchand()
        {
            _idCarte = 0;
            _nomCarte = "";
            _couleur = "";
            _valeurOr = 0;
            _imageCarte = null;
        }

        public CarteMarchand(int id, string nom, int or, Bitmap image)
        {
            _idCarte = id;
            _nomCarte = nom;
            _valeurOr = or;
            _imageCarte = image;
        }
    }
}
