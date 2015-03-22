using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class CarteMarchand : Carte
    {
        private int _valeurOr;

        public CarteMarchand()
        {
            _IDCarte = 0;
            _NomCarte = "";
            _Couleur = "";
            _valeurOr = 0;
        }

        public CarteMarchand(int id, string nom, int or)
        {
            _IDCarte = id;
            _NomCarte = nom;
            _valeurOr = or;
        }
    }
}
