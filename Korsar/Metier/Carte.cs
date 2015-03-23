using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Carte
    {
        protected int _idCarte;
        protected string _couleur;
        protected  string _nomCarte;

        public Carte()
        {
            _idCarte = 0;
            _couleur = "";
            _nomCarte = "";
        }

        public Carte(int id, string couleur, string nom)
        {
            _idCarte = id;
            _couleur = couleur;
            _nomCarte = nom;
        }

        public int getIdCarte()
        {
            return _idCarte;
        }

        public string afficherNomCarte()
        {
            return _nomCarte;
        }
    }
}
