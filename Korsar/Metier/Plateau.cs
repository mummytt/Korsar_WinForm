using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Metier
{
    public class Plateau
    {
        public Deck _Deck { get; set; }
        public Dictionary<int, Joueur> _Joueurs { get; set; }
        public int _Tour { get; set; }
        public int _Etape { get; set; }
        public Dictionary<int, Carte> _MainJoueurEnCours { get; set; }

        public Plateau(Joueur j1, Joueur j2, Joueur j3, Joueur j4)
        {
            _Joueurs = new Dictionary<int, Joueur>();
            _Joueurs.Add(1, j1);
            _Joueurs.Add(2, j2);
            _Joueurs.Add(3, j3);
            _Joueurs.Add(4, j4);

            _Deck = new Deck();
            _Tour = 1;
            _Etape = 1;
            _MainJoueurEnCours = new Dictionary<int, Carte>(); 

        }

        public void ajouterOrJoueur(int or, int idJoueur)
        {

        }

        public int afficherOrJoueur(int idJoueur)
        {
            return 0;
        }

        public int afficherTour()
        {
            return _Tour;
        }

        public void changeTour()
        {
            _Tour += 1;
        }
        
        public string afficherNomJoueur(int idJoueur)
        {
            return "";
        }

        public void donnerCarteAJoueur(int idJoueur, int idCarte)
        {

        }

        public bool verifierGainMarchant(int idJoueur)
        {
            return false;
        }

        public void etapeSuivante()
        {
            _Etape += 1;
        }

        public Dictionary<int, Carte> getMainJoueur(int idJoueur)
        {
            Dictionary<int, Carte> main = new Dictionary<int,Carte>();

            return main;
        }

    }
}
