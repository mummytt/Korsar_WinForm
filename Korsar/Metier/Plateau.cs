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
        private Dictionary<int, Carte> _cartesMarchandsTapis_etape_1;
        private Dictionary<int, Carte> _cartesMarchandsTapis_etape_2;
        private Dictionary<int, Carte> _cartesMarchandsTapis_etape_3;
        private Dictionary<int, Carte> _cartesMarchandsTapis_etape_4;

        private Dictionary<int, Carte> _cartesPiratesTapis_etape_1;
        private Dictionary<int, Carte> _cartesPiratesTapis_etape_2;
        private Dictionary<int, Carte> _cartesPiratesTapis_etape_3;
        private Dictionary<int, Carte> _cartesPiratesTapis_etape_4;


        private Dictionary<Carte, Carte> _attaquesEnCours;

        private Dictionary<int, int> _idCartesMarchands_idJoueurs;
        private Dictionary<int, int> _idCartesPirates_idJoueurs;

        private bool _estEnTrainDAttaquer;

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

            _cartesMarchandsTapis_etape_1 = new Dictionary<int, Carte>();
            _cartesMarchandsTapis_etape_2 = new Dictionary<int, Carte>();
            _cartesMarchandsTapis_etape_3 = new Dictionary<int, Carte>();
            _cartesMarchandsTapis_etape_4 = new Dictionary<int, Carte>();

            _cartesPiratesTapis_etape_1 = new Dictionary<int, Carte>();
            _cartesPiratesTapis_etape_2 = new Dictionary<int, Carte>();
            _cartesPiratesTapis_etape_3 = new Dictionary<int, Carte>();
            _cartesPiratesTapis_etape_4 = new Dictionary<int, Carte>();

            _attaquesEnCours = new Dictionary<Carte, Carte>();

            _idCartesMarchands_idJoueurs = new Dictionary<int, int>();
            _idCartesPirates_idJoueurs = new Dictionary<int, int>();

            _estEnTrainDAttaquer = false;

            _deck = new Deck();
            _deck.melangerCartes();

            _tour = 1;
            _etape = 1;

        }

        public void setAjoutOrJoueur(int or, int idJoueur)
        {
            Joueur jonh = getJoueur(idJoueur);
            jonh.setAjoutOr(or);
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

            //Donner l'or du bateau au joueur
            foreach (var item in _cartesMarchandsTapis_etape_4)
            {
                CarteMarchand carteM = (CarteMarchand)item.Value;
                var idJoueur = _idCartesMarchands_idJoueurs.First(x => x.Key == carteM.getIdCarte());
                setAjoutOrJoueur(carteM.getOr(), idJoueur.Value);
            }

            _cartesMarchandsTapis_etape_4 = _cartesMarchandsTapis_etape_3;
            _cartesMarchandsTapis_etape_3 = _cartesMarchandsTapis_etape_2;
            _cartesMarchandsTapis_etape_2 = _cartesMarchandsTapis_etape_1;
            _cartesMarchandsTapis_etape_1 = new Dictionary<int, Carte>();

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
                _cartesMarchandsTapis_etape_1.Add(_cartesMarchandsTapis_etape_1.Count + 1, carte);
                _idCartesMarchands_idJoueurs.Add(carte.getIdCarte(), _etape);
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
                _cartesPiratesTapis_etape_1.Add(_cartesMarchandsTapis_etape_1.Count + 1, carte);
                _idCartesPirates_idJoueurs.Add(carte.getIdCarte(), _etape);
                _estEnTrainDAttaquer = true;
            }

            Joueur jonh = getJoueurCurrent();
            jonh.poserCarte(carte);
            setJoueurCurrentAPoserUneCarte(true);
            Dictionary<int, Carte> newCartesEnMain = new Dictionary<int, Carte>();

            foreach (var carteMain in jonh.getMainJoueur())
            {
                newCartesEnMain.Add(carteMain.Key, carteMain.Value);
            }

            jonh.setMainJoueur(newCartesEnMain);
        }
        

        public Dictionary<int, Carte> getCartesTapis(int etape)
        {
            if(etape == 1)
            {
                return _cartesMarchandsTapis_etape_1;
            }
            else if (etape == 2)
            {
                return _cartesMarchandsTapis_etape_2;
            }
            else if (etape == 3)
            {
                return _cartesMarchandsTapis_etape_3;
            }
            else
            {
                return _cartesMarchandsTapis_etape_4;
            }
            
        }

        public void setCartesTapis(int etape, Dictionary<int, Carte> main)
        {
            if (etape == 1)
            {
                _cartesMarchandsTapis_etape_1 = main;
            }
            else if (etape == 2)
            {
                _cartesMarchandsTapis_etape_2 = main;
            }
            else if (etape == 3)
            {
                _cartesMarchandsTapis_etape_3 = main;
            }
            else
            {
                _cartesMarchandsTapis_etape_4 = main;
            }

        }

        public string getLabelJoueurCarteTapis(int IDCarte)
        {

            //_attaquesEnCours (IDPirate, IDMarchand)
            //tous les pirates pour le marchand X
            var recupPirate = _attaquesEnCours.Where(x => x.Value.getIdCarte() == IDCarte);
            Dictionary<int, CartePirate> possesseurCartePirate = new Dictionary<int, CartePirate>();
            

            if(recupPirate == null)
            {
                var recup = _idCartesMarchands_idJoueurs.First(x => x.Key == IDCarte);
                return getNomJoueur(recup.Value);
            }
            else
            {
                //tous les pirates pour le marchand x
                foreach(var attaque in recupPirate)
                {
                    //pour un pirate, on recupere son attaquant
                    var recupAttaquant = _idCartesPirates_idJoueurs.First(x => x.Key == attaque.Key.getIdCarte());

                    //ID Joueur, CartePirate pour un marchand
                    possesseurCartePirate.Add(recupAttaquant.Key, (CartePirate)attaque.Key);
                }

                int attaque_J1 = 0;
                int attaque_J2 = 0;
                int attaque_J3 = 0;
                int attaque_J4 = 0;

                foreach(var item in possesseurCartePirate)
                {
                    if(item.Key == 1)
                    {
                        attaque_J1 += item.Value.getAttaque();
                    }
                    else if (item.Key == 2)
                    {
                        attaque_J2 += item.Value.getAttaque();
                    }
                    else if (item.Key == 3)
                    {
                        attaque_J3 += item.Value.getAttaque();
                    }
                    else
                    {
                        attaque_J4 += item.Value.getAttaque();
                    }


                }


                return "";
            }

            
            
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

        public bool getPeutPiocher_Pioche()
        {
            if(_deck.getNombreCartes() != 0)
            {
                return true;
            }

            return false;
        }

        public bool getEstEnTrainDattaquer()
        {
            return _estEnTrainDAttaquer;
        }

        public void setEstEnTrainDattaquer(bool value)
        {
            _estEnTrainDAttaquer = value;
        }

        public void ajoutAttaque(Carte carte)
        {
            var pirate = _cartesPiratesTapis_etape_1.First(x => x.Key == _cartesPiratesTapis_etape_1.Count);
            _attaquesEnCours.Add(pirate.Value, carte);
        }

    }
}
