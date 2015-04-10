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
        private int _nombreCartesEnMain;
        private int _or;
        private bool _aPiocher;
        private bool _aPoserUneCarte;
        private Dictionary<int, Carte> _cartesEnMain;
        
        public Joueur()
        {
            _id = 0;
            _nom = "";
            _nombreCartesEnMain = 0;
            _or = 0;
            _cartesEnMain = new Dictionary<int, Carte>();
            _aPiocher = false;
            _aPoserUneCarte = false;
        }

        public Joueur(int id, string nom)
        {
            _id = id;
            _nom = nom;
            _nombreCartesEnMain = 0;
            _or = 0;
            _cartesEnMain = new Dictionary<int, Carte>();
            _aPiocher = false;
            _aPoserUneCarte = false;
        }

        public int recuperer_Or()
        {
            CartePirate e = new CartePirate();
            
            return _or;
        }
        
        public int recuperer_ID()
        {
            return _id;
        }

        public void modifier_ID(int id)
        {
            _id = id;
        }

        public void ajout_or(int or)
        {
            _or += or;
        }

        public string recuperer_nom()
        {
            return _nom;
        }

        public Dictionary<int, Carte> recuperer_mainJoueur()
        {
            return _cartesEnMain;
        }

        public void modifier_mainJoueur(Dictionary<int, Carte> main)
        {
            _cartesEnMain = main;
        }

        public void ajouter_mainJoueur(int index, Carte carte)
        {
            _cartesEnMain.Add(index, carte);
            _nombreCartesEnMain += 1;
        }

        public void poserCarte(Carte carte)
        {
            _nombreCartesEnMain -= 1;

            var recup = _cartesEnMain.First(x => x.Value.recuperer_idCarte() == carte.recuperer_idCarte());
            _cartesEnMain.Remove(recup.Key);
        }
        
        public int recuperer_nombreCartesEnMain()
        {
            return _nombreCartesEnMain;
        }


        public bool verifier_nomJoueur(string nom)
        {

            if (nom.Length < 20 && nom.Length>0)
            {
                _nom = nom.ToUpper();
                return true;
            }

            return false;
        }

        public bool verifier_aPiocher()
        {
            return _aPiocher;
        }

        public void modifier_aPiocher(bool value)
        {
            _aPiocher = value;
        }

        public bool recuperer_aPoserUneCarte()
        {
            return _aPoserUneCarte;
        }

        public void modifier_aPoserUneCarte(bool value)
        {
            _aPoserUneCarte = value;
        }

    }
}
