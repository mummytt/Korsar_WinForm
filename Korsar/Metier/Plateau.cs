using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Metier
{
    public class Plateau
    {
        private Deck _deck;
        private Dictionary<int, Joueur> _joueurs;
        private int _tour;
        private int _etape;
        private Dictionary<int, Carte> _mainJoueurEnCours;

       

        public Plateau(Joueur j1, Joueur j2, Joueur j3, Joueur j4)
        {
            _joueurs = new Dictionary<int, Joueur>();
            j1.setID(1);
            j2.setID(2); 
            j3.setID(3); 
            j4.setID(4);

            _joueurs.Add(1, j1);
            _joueurs.Add(2, j2);
            _joueurs.Add(3, j3);
            _joueurs.Add(4, j4);

            _deck = new Deck();
            _deck.melangerCartes();

            _tour = 1;
            _etape = 1;
            _mainJoueurEnCours = new Dictionary<int, Carte>(); 

        }

        public void ajouterOrJoueur(int or, int idJoueur)
        {
            Joueur jonh = new Joueur();

            if (_joueurs.TryGetValue(idJoueur, out jonh))
            {
                jonh.setOr(or);
            }

            _joueurs.Remove(idJoueur);
            _joueurs.Add(idJoueur, jonh);
        }

        public Dictionary<int, Joueur> getJoueurs()
        {
            return _joueurs;
        }

        public int afficherOrJoueur(int idJoueur)
        {
            Joueur jonh = new Joueur();

            if (_joueurs.TryGetValue(idJoueur, out jonh))
            {
                return jonh.getOr();
            }

            return 0;
        }

        public int afficherTour()
        {
            return _tour;
        }

        public void changeTour()
        {
            _tour += 1;
        }
        
        public string afficherNomJoueur(int idJoueur)
        {
            Joueur jonh = new Joueur();

            if (_joueurs.TryGetValue(idJoueur, out jonh))
            {
                return jonh.getNom();
            }

            return "";
        }

        public int getEtape()
        {
            return _etape;
        }

        public void donnerCarteAJoueur(int idJoueur)
        {
            Joueur jonh;

            if (_joueurs.TryGetValue(idJoueur, out jonh))
            {
                Carte carte = _deck.piocher();

                jonh.ajouterMainJoueur(_deck.getIndex() - 1, carte);

                _joueurs.Remove(idJoueur);
                _joueurs.Add(idJoueur, jonh);
            }
        }

        public bool verifierGainMarchant(int idJoueur)
        {
            return false;
        }

        public void etapeSuivante()
        {
            _etape += 1;

            if (_etape > 4)
            {
                _etape = 1;
            }

        }

        public Dictionary<int, Carte> getMainJoueur(int idJoueur)
        {
            Dictionary<int, Carte> main = new Dictionary<int,Carte>();

            Joueur jonh = new Joueur();

            if (_joueurs.TryGetValue(idJoueur, out jonh))
            {
                main = jonh.getMainJoueur();
            }

            return main;
        }

    }
}
