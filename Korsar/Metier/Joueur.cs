using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Joueur
    {
        private int _id;
        private string _nom;
        private int _nbCartesEnMain;
        private int _or;
        private bool _aPiocher;
        private bool _aPoserUneCarte;
        private Dictionary<int, Carte> _cartesEnMain;
        
        public Joueur()
        {
            _id = 0;
            _nom = "";
            _nbCartesEnMain = 0;
            _or = 0;
            _cartesEnMain = new Dictionary<int, Carte>();
            _aPiocher = false;
            _aPoserUneCarte = false;
        }

        public Joueur(int id, string nom)
        {
            _id = id;
            _nom = nom;
            _nbCartesEnMain = 0;
            _or = 0;
            _cartesEnMain = new Dictionary<int, Carte>();
            _aPiocher = false;
            _aPoserUneCarte = false;
        }

        public int getOr()
        {
            CartePirate e = new CartePirate();
            
            return _or;
        }
        
        public int getID()
        {
            return _id;
        }

        public void setID(int id)
        {
            _id = id;
        }

        public void setAjoutOr(int or)
        {
            _or += or;
        }

        public string getNom()
        {
            return _nom;
        }

        public Dictionary<int, Carte> getMainJoueur()
        {
            return _cartesEnMain;
        }

        public void setMainJoueur(Dictionary<int, Carte> main)
        {
            _cartesEnMain = main;
        }

        public void ajouterMainJoueur(int index, Carte carte)
        {
            _cartesEnMain.Add(index, carte);
            _nbCartesEnMain += 1;
        }

        public void poserCarte(Carte carte)
        {
            _nbCartesEnMain -= 1;

            var recup = _cartesEnMain.First(x => x.Value.getIdCarte() == carte.getIdCarte());
            _cartesEnMain.Remove(recup.Key);
        }

        

        public int getNombreCartesEnMain()
        {
            return _nbCartesEnMain;
        }


        public bool verifNomJoueur(string nom)
        {

            if (nom.Length < 20 && nom.Length>0)
            {
                _nom = nom.ToUpper();
                return true;
            }

            return false;
        }

        public bool getAPiocher()
        {
            return _aPiocher;
        }

        public void setAPiocher(bool value)
        {
            _aPiocher = value;
        }

        public bool getAPoserUneCarte()
        {
            return _aPoserUneCarte;
        }

        public void setAPoserUneCarte(bool value)
        {
            _aPoserUneCarte = value;
        }

    }
}
