using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Metier
{
    public class Carte
    {
        protected int _idCarte;
        protected string _couleur;
        protected  string _nomCarte;
        protected Bitmap _imageCarte;
        protected Bitmap _imageCarteMiniature;

        public Carte()
        {
            _idCarte = 0;
            _couleur = "";
            _nomCarte = "";
            _imageCarte = null;
            _imageCarteMiniature = null;
        }

        public Carte(int id, string couleur, string nom, Bitmap image, Bitmap imageMin)
        {
            _idCarte = id;
            _couleur = couleur;
            _nomCarte = nom;
            _imageCarte = image;
            _imageCarteMiniature = imageMin;
        }

        public int recuperer_idCarte()
        {
            return _idCarte;
        }

        public string afficher_nomCarte()
        {
            return _nomCarte;
        }

        public Bitmap recuperer_imageCarte()
        {
            return _imageCarte;
        }
        public Bitmap recuperer_imageMiniatureCarte()
        {
            return _imageCarteMiniature;
        }

    }
}
