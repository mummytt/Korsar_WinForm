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
        private Dictionary<int, Carte> _cartesTapis;
        private int _tour;
        private int _etape;

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

            _cartesTapis = new Dictionary<int, Carte>();
            _deck = new Deck();
            _deck.melangerCartes();

            _tour = 1;
            _etape = 1;

        }

        public void setOrJoueur(int or, int idJoueur)
        {
            Joueur jonh = getJoueur(idJoueur); 
            jonh.setOr(or);
            _joueurs.Remove(idJoueur);
            _joueurs.Add(idJoueur, jonh);
        }

        public int getOrJoueurCurrent()
        {
            Joueur jonh = getJoueurCurrent(); ;

            return jonh.getOr();
        }


        public Dictionary<int, Joueur> getJoueurs()
        {
            return _joueurs;
        }

        public Joueur getJoueur(int id)
        {
            foreach (var joueur in _joueurs)
            {
                if (joueur.Key == id)
                {
                    return joueur.Value;
                }
            }

            return null;

        }

        public Joueur getJoueurCurrent()
        {
            foreach(var joueur in _joueurs)
            {
                if(joueur.Key == _etape)
                {
                    return joueur.Value;
                }
            }

            return null;
            
        }

        public void setEtapeSuivante()
        {
            _etape += 1;

            if (_etape > 4)
            {
                _etape = 1;
                _tour += 1;
            }

            setJoueurCurrentAPoserUneCarte(false);
            setJoueurCurrentAPiocher(false);

            Dictionary<int, Carte> newCartes = new Dictionary<int, Carte>();

            foreach (var carte in _cartesTapis)
            {
                if(carte.Key == 4)
                {
                    //Vérif bateau gagné ou pas
                    newCartes.Add(1, carte.Value);
                }
                else
                {
                    newCartes.Add(carte.Key + 1, carte.Value);
                }
                
            }

            _cartesTapis = newCartes;


        }

        public int getEtape()
        {
            return _etape;
        }

        public int getTour()
        {
            return _tour;
        }
        
        public string getNomJoueur(int idJoueur)
        {
            return getJoueur(idJoueur).getNom();
        }

        public void setDonnerCarteAJoueur(int idJoueur)
        {
            Joueur jonh = getJoueur(idJoueur); 
            Carte carte = _deck.piocher();
            jonh.ajouterMainJoueur(_deck.getIndex() - 1, carte);
            _joueurs.Remove(idJoueur);
            _joueurs.Add(idJoueur, jonh);
        }

        
        public void setDonnerCarteAJoueurCurrent()
        {
            Joueur jonh = getJoueurCurrent();
            Carte carte = _deck.piocher();
            jonh.ajouterMainJoueur(_deck.getIndex() - 1, carte);
            _joueurs.Remove(_etape);
            _joueurs.Add(_etape, jonh);
        }

        public bool getVerifierGainMarchant(int idJoueur)
        {
            return false;
        }

        

        public Dictionary<int, Carte> getMainJoueurCurrent()
        {
            Dictionary<int, Carte> main = new Dictionary<int,Carte>();
            Joueur jonh = getJoueurCurrent();
            main = jonh.getMainJoueur();

            return main;
        }

        public int getNbCartesMainJoueurCurrent()
        {
            int nbCartes = 0;
            Joueur jonh = getJoueurCurrent();
            nbCartes = jonh.getNombreCartesEnMain();

            return nbCartes;
        }


        public bool getVerifAPiocherCurrent()
        {
            Joueur jonh = getJoueur(_etape);

            return jonh.getAPiocher();
        }

        public bool getVerifAPoserUneCarteCurrent()
        {
            Joueur jonh = getJoueur(_etape);

            return jonh.getAPoserUneCarte();
        }

        public Carte getCarteByID(int idCarte)
        {
            return _deck.getCarteByID(idCarte);
        }


        public void poserUneCarte(Carte carte)
        {

            if (carte.GetType() == typeof(CarteMarchand))
            {
                poserUneCarteMarchand(carte);
            }
            else if (carte.GetType() == typeof(CarteAmiral))
            {
                Console.WriteLine("Carte amiral");
            }
            else if (carte.GetType() == typeof(CarteCapitaine))
            {
                Console.WriteLine("Carte capitaine");
            }
            else if (carte.GetType() == typeof(CartePirate))
            {
                Console.WriteLine("Carte pirate");
            }

            setJoueurCurrentAPoserUneCarte(true);
        }

        public void poserUneCarteMarchand(Carte carte)
        {
            Joueur jonh = getJoueurCurrent();
            jonh.poserCarteMarchand(carte);
            _joueurs.Remove(_etape);
            _joueurs.Add(_etape, jonh);

            _cartesTapis.Add(1, carte);
        }

        public Dictionary<int, Carte> getCartesTapis()
        {
            return _cartesTapis;
        }

        public void setJoueurCurrentAPiocher(bool value)
        {
            Joueur jonh = getJoueurCurrent();
            jonh.setAPiocher(value);
            _joueurs.Remove(_etape);
            _joueurs.Add(_etape, jonh);
        }

        public void setJoueurCurrentAPoserUneCarte(bool value)
        {
            Joueur jonh = getJoueurCurrent();
            jonh.setAPoserUneCarte(value);
            _joueurs.Remove(_etape);
            _joueurs.Add(_etape, jonh);
        }

    }
}
