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
        private Dictionary<int, Carte> _cartesTapis_etape_1;
        private Dictionary<int, Carte> _cartesTapis_etape_2;
        private Dictionary<int, Carte> _cartesTapis_etape_3;
        private Dictionary<int, Carte> _cartesTapis_etape_4;

        private Dictionary<int, int> _labelsJoueurs_etape_1;
        private Dictionary<int, int> _labelsJoueurs_etape_2;
        private Dictionary<int, int> _labelsJoueurs_etape_3;
        private Dictionary<int, int> _labelsJoueurs_etape_4;
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

            _cartesTapis_etape_1 = new Dictionary<int, Carte>();
            _cartesTapis_etape_2 = new Dictionary<int, Carte>();
            _cartesTapis_etape_3 = new Dictionary<int, Carte>();
            _cartesTapis_etape_4 = new Dictionary<int, Carte>();

            _labelsJoueurs_etape_1 = new Dictionary<int, int>();
            _labelsJoueurs_etape_2 = new Dictionary<int, int>();
            _labelsJoueurs_etape_3 = new Dictionary<int, int>();
            _labelsJoueurs_etape_4 = new Dictionary<int, int>();

            _deck = new Deck();
            _deck.melangerCartes();

            _tour = 1;
            _etape = 1;

        }

        public void setOrJoueur(int or, int idJoueur)
        {
            Joueur jonh = getJoueur(idJoueur); 
            jonh.setOr(or);
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

            Dictionary<int, Carte> newCartes_1 = new Dictionary<int, Carte>();
            Dictionary<int, Carte> newCartes_2 = new Dictionary<int, Carte>();
            Dictionary<int, Carte> newCartes_3 = new Dictionary<int, Carte>();
            Dictionary<int, Carte> newCartes_4 = new Dictionary<int, Carte>();

            foreach (var carte in _cartesTapis_etape_1)
            {
                newCartes_2.Add(carte.Key, carte.Value);
            }

            foreach (var carte in _cartesTapis_etape_2)
            {
                newCartes_3.Add(carte.Key, carte.Value);
            }

            foreach (var carte in _cartesTapis_etape_3)
            {
                newCartes_4.Add(carte.Key, carte.Value);
            }

            foreach (var carte in _cartesTapis_etape_4)
            {
                //newCartes_1.Add(carte.Key, carte.Value);

                foreach (var item in _labelsJoueurs_etape_4)
                {
                    if (item.Key == carte.Value.getIdCarte())
                    {
                        CarteMarchand carteM = (CarteMarchand)carte.Value;
                        setOrJoueur(carteM.getOr(), item.Value);
                    }
                }
            }

            _cartesTapis_etape_1 = newCartes_1;
            _cartesTapis_etape_2 = newCartes_2;
            _cartesTapis_etape_3 = newCartes_3;
            _cartesTapis_etape_4 = newCartes_4;


            Dictionary<int, int> newLabels_1 = new Dictionary<int, int>();
            Dictionary<int, int> newLabels_2 = new Dictionary<int, int>();
            Dictionary<int, int> newLabels_3 = new Dictionary<int, int>();
            Dictionary<int, int> newLabels_4 = new Dictionary<int, int>();

            foreach (var label in _labelsJoueurs_etape_1)
            {
                newLabels_2.Add(label.Key, label.Value);
            }

            foreach (var label in _labelsJoueurs_etape_2)
            {
                newLabels_3.Add(label.Key, label.Value);
            }

            foreach (var label in _labelsJoueurs_etape_3)
            {
                newLabels_4.Add(label.Key, label.Value);
            }

            foreach (var label in _labelsJoueurs_etape_4)
            {
                //newLabels_1.Add(label.Key, label.Value);
            }

            _labelsJoueurs_etape_1 = newLabels_1;
            _labelsJoueurs_etape_2 = newLabels_2;
            _labelsJoueurs_etape_3 = newLabels_3;
            _labelsJoueurs_etape_4 = newLabels_4;

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

        public string getNomJoueurCurrent()
        {
            return getJoueur(_etape).getNom();
        }

        public void setDonnerCarteAJoueur(int idJoueur)
        {
            Joueur jonh = getJoueur(idJoueur);
            Carte carte = _deck.piocher();
            jonh.ajouterMainJoueur(_deck.getIndex() - 1, carte);
        }

        
        public void setDonnerCarteAJoueurCurrent()
        {
            Joueur jonh = getJoueurCurrent();
            Carte carte = _deck.piocher();
            jonh.ajouterMainJoueur(_deck.getIndex() - 1, carte);
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
                _cartesTapis_etape_1.Add(_cartesTapis_etape_1.Count + 1, carte);
                _labelsJoueurs_etape_1.Add(carte.getIdCarte(), _etape);
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

            Joueur jonh = getJoueurCurrent();
            Dictionary<int, Carte> newCartesEnMain = new Dictionary<int, Carte>();

            foreach (var carteMain in jonh.getMainJoueur())
            {
                newCartesEnMain.Add(carteMain.Key, carteMain.Value);
            }

            jonh.setMainJoueur(newCartesEnMain);
        }

        public void poserUneCarteMarchand(Carte carte)
        {
            Joueur jonh = getJoueurCurrent();
            jonh.poserCarteMarchand(carte);
        }

        public Dictionary<int, Carte> getCartesTapis(int etape)
        {
            if(etape == 1)
            {
                return _cartesTapis_etape_1;
            }
            else if (etape == 2)
            {
                return _cartesTapis_etape_2;
            }
            else if (etape == 3)
            {
                return _cartesTapis_etape_3;
            }
            else
            {
                return _cartesTapis_etape_4;
            }
            
        }

        public string getLabelJoueurCarteTapis(int IDCarte)
        {
            string nom = "";

            foreach(var label in _labelsJoueurs_etape_1)
            {
                if(label.Key == IDCarte)
                {
                    return getNomJoueur(label.Value);
                }
            }

            foreach (var label in _labelsJoueurs_etape_2)
            {
                if (label.Key == IDCarte)
                {
                    return getNomJoueur(label.Value);
                }
            }

            foreach (var label in _labelsJoueurs_etape_3)
            {
                if (label.Key == IDCarte)
                {
                    return getNomJoueur(label.Value);
                }
            }

            foreach (var label in _labelsJoueurs_etape_4)
            {
                if (label.Key == IDCarte)
                {
                    return getNomJoueur(label.Value);
                }
            }

            return nom;
        }

        public void setJoueurCurrentAPiocher(bool value)
        {
            Joueur jonh = getJoueurCurrent();
            jonh.setAPiocher(value);
        }

        public void setJoueurCurrentAPoserUneCarte(bool value)
        {
            Joueur jonh = getJoueurCurrent();
            jonh.setAPoserUneCarte(value);
        }

        public bool getPeutPiocher()
        {
            if(_deck.getNombreCartes() != 0)
            {
                return true;
            }

            return false;
        }

    }
}
