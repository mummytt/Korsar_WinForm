﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Metier
{
    public class CarteAmiral : Carte
    {
        private int _valeurAttaque;

        public CarteAmiral()
        {
            _idCarte = 0;
            _nomCarte = "";
            _couleur = "";
            _valeurAttaque = 0;
            _imageCarte = null;
        }

        public CarteAmiral(int id, string nom, int attaque, Bitmap image, Bitmap imageMin)
        {
            _idCarte = id;
            _nomCarte = nom;
            _valeurAttaque = attaque;
            _imageCarte = image;
            _imageCarteMin = imageMin;
        }

        public int getAttaque()
        {
            return _valeurAttaque;
        }
    }
}
