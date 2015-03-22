using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Joueur
    {
        public int _ID { get; set; }
        public string _Nom { get; set; }
        public int _NbCartesEnMain { get; set; }
        public int _Or { get; set; }
        public Dictionary<int, Carte> _CartesEnMain { get; set; }
        
        public Joueur()
        {
            _ID = 0;
            _Nom = "";
            _NbCartesEnMain = 0;
            _Or = 0;
            _CartesEnMain = new Dictionary<int, Carte>();
        }

        public Joueur(int id, string nom)
        {
            _ID = id;
            _Nom = nom;
            _NbCartesEnMain = 0;
            _Or = 0;
            _CartesEnMain = new Dictionary<int, Carte>();
        }

        public int getOr()
        {
            CartePirate e = new CartePirate();
            
            return _Or;
        }

        public void setOr(int or)
        {
            _Or += or;
        }

        public Dictionary<int, Carte> getMainJoueur()
        {
            return _CartesEnMain;
        }

        public void ajouterMainJoueur(Carte carte)
        {
            _CartesEnMain.Add(carte._IDCarte, carte);
        }

        public CarteMarchand poserCarteMarchand(int idCarte)
        {
            return new CarteMarchand();
        }

        public CartePirate poserCartePirate(int idCarte)
        {
            return new CartePirate();
        }

        public CarteCapitaine poserCarteCapitaine(int idCarte)
        {
            return new CarteCapitaine();
        }

        public CarteAmiral poserCarteAmiral(int idCarte)
        {
            return new CarteAmiral();
        }

        public Carte poserCarte(int idCarte)
        {
            return new Carte();
        }
        




        public bool verifNomJoueur(string nom)
        {

            if (nom.Length < 20 && nom.Length>0)
            {
                _Nom = nom.ToUpper();
                return true;
            }

            return false;
        }

    }
}
