using System;
using System.Collections.Generic;
using System.Drawing;
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
        private bool _attaqueValide;
        private bool _aPoserMarchand;

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
            _aPoserMarchand = false;
            _attaqueValide = false;

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

            Dictionary<int, Carte> temp = new Dictionary<int, Carte>();

            foreach(var item in _cartesMarchandsTapis_etape_4)
            {
                if(maitreDeLaCarte(item.Value.getIdCarte()) == -1)
                {
                    temp.Add(item.Key, item.Value);
                }
            }

            if(temp.Count != 0)
            {
                _cartesMarchandsTapis_etape_1 = new Dictionary<int, Carte>();

                foreach(var item in temp)
                {
                    _cartesMarchandsTapis_etape_4.Remove(item.Key);
                    _cartesMarchandsTapis_etape_1.Add(item.Key, item.Value);

                    if(_attaquesEnCours.Count != 0)
                    {

                        foreach(var item2 in _attaquesEnCours)
                        {
                            if(item.Value == item2.Value)
                            {
                                _cartesPiratesTapis_etape_1 = new Dictionary<int, Carte>();
                                _cartesPiratesTapis_etape_1.Add(_cartesPiratesTapis_etape_1.Count + 1, item2.Key);
                            }
                        }
                    }
                }

                Dictionary<Carte, Carte> KeyAttaqueSuppr = new Dictionary<Carte, Carte>();

                foreach(var item in _cartesMarchandsTapis_etape_4)
                {
                    foreach(var item2 in _attaquesEnCours)
                    {
                        if(item.Value == item2.Value)
                        {
                            KeyAttaqueSuppr.Add(item2.Key, item2.Key);
                        }
                    }
                }

                foreach(var item in KeyAttaqueSuppr)
                {
                    _attaquesEnCours.Remove(item.Key);
                }

            }
            
            //Donner l'or du bateau au joueur
            foreach (var item in _cartesMarchandsTapis_etape_4)
            {
                CarteMarchand carteM = (CarteMarchand)item.Value;
                if(maitreDeLaCarte(item.Value.getIdCarte()) > 0)
                {
                    setAjoutOrJoueur(carteM.getOr(), maitreDeLaCarte(item.Value.getIdCarte()));
                }
                else if (maitreDeLaCarte(item.Value.getIdCarte()) == 0)
                {
                    setAjoutOrJoueur(carteM.getOr(), _etape);
                }
                
            }

            _cartesMarchandsTapis_etape_4 = _cartesMarchandsTapis_etape_3;
            _cartesMarchandsTapis_etape_3 = _cartesMarchandsTapis_etape_2;
            
            
            _cartesPiratesTapis_etape_4 = _cartesPiratesTapis_etape_3;
            _cartesPiratesTapis_etape_3 = _cartesPiratesTapis_etape_2;
            

            if (temp.Count == 0)
            {
                _cartesMarchandsTapis_etape_2 = _cartesMarchandsTapis_etape_1;
                _cartesPiratesTapis_etape_2 = _cartesPiratesTapis_etape_1;
                _cartesMarchandsTapis_etape_1 = new Dictionary<int, Carte>();
                _cartesPiratesTapis_etape_1 = new Dictionary<int, Carte>();
            }
            else
            {
                _cartesMarchandsTapis_etape_2 = new Dictionary<int, Carte>();
                _cartesPiratesTapis_etape_2 = new Dictionary<int, Carte>();
            }

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
                _aPoserMarchand = true;
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
                if (_cartesMarchandsTapis_etape_1.Count != 0 || _cartesMarchandsTapis_etape_2.Count != 0 || _cartesMarchandsTapis_etape_3.Count != 0 || _cartesMarchandsTapis_etape_4.Count != 0)
                {
                    if(_attaqueValide != true)
                    {
                        _cartesPiratesTapis_etape_1.Add(_cartesPiratesTapis_etape_1.Count + 1, carte);
                        _idCartesPirates_idJoueurs.Add(carte.getIdCarte(), _etape);
                        _estEnTrainDAttaquer = true;
                    }
                }
            }


            if (_aPoserMarchand || _attaqueValide)
            {
                Joueur jonh = getJoueurCurrent();
                jonh.poserCarte(carte);
                setJoueurCurrentAPoserUneCarte(true);
                _aPoserMarchand = false;
                _attaqueValide = false;

                Dictionary<int, Carte> newCartesEnMain = new Dictionary<int, Carte>();

                foreach (var carteMain in jonh.getMainJoueur())
                {
                    newCartesEnMain.Add(carteMain.Key, carteMain.Value);
                }

                jonh.setMainJoueur(newCartesEnMain);
            }
            
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
            Dictionary<int, int> attaques_joueurs = getAttaquesJoueursCarte(IDCarte);
            if (attaques_joueurs == null)
            {
                var recup = _idCartesMarchands_idJoueurs.First(x => x.Key == IDCarte);
                return getNomJoueur(recup.Value);
            }

            int verifEgalite = maitreDeLaCarte(IDCarte);

            if(verifEgalite == -1)
            {
                return "Egalité";
            }

            return getNomJoueur(verifEgalite);
        }

        public string getNomsEgalite(int IDCarte)
        {
            Dictionary<int, int> attaques_joueurs = getAttaquesJoueursCarte(IDCarte);

            if (attaques_joueurs != null)
            {
                var attaque_J1 = attaques_joueurs.Where(x => x.Key == 1);
                var attaque_J2 = attaques_joueurs.Where(x => x.Key == 2);
                var attaque_J3 = attaques_joueurs.Where(x => x.Key == 3);
                var attaque_J4 = attaques_joueurs.Where(x => x.Key == 4);

                int max_J1 = 0;
                int max_J2 = 0;
                int max_J3 = 0;
                int max_J4 = 0;

                foreach(var attaque in attaque_J1)
                {
                    if(attaque.Value > max_J1)
                    {
                        max_J1 = attaque.Value;
                    }
                }

                foreach(var attaque in attaque_J2)
                {
                    if(attaque.Value > max_J2)
                    {
                        max_J2 = attaque.Value;
                    }
                }

                foreach(var attaque in attaque_J3)
                {
                    if(attaque.Value > max_J3)
                    {
                        max_J3 = attaque.Value;
                    }
                }

                foreach(var attaque in attaque_J4)
                {
                    if(attaque.Value > max_J4)
                    {
                        max_J4 = attaque.Value;
                    }
                }

                string nom = "";

                if (max_J1 == max_J2 && max_J2 > max_J3 && max_J2 > max_J4 && max_J1 > 0)
                {
                    nom = getNomJoueur(1) + " - " + getNomJoueur(2);
                }
                else if (max_J1 == max_J3 && max_J3 > max_J2 && max_J3 > max_J4 && max_J1 > 0)
                {
                    nom = getNomJoueur(1) + " - " + getNomJoueur(3);
                }
                else if (max_J1 == max_J4 && max_J4 > max_J2 && max_J4 > max_J3 && max_J1 > 0)
                {
                    nom = getNomJoueur(1) + " - " + getNomJoueur(4);
                }
                else if (max_J2 == max_J3 && max_J2 > max_J1 && max_J2 > max_J4 && max_J2 > 0)
                {
                    nom = getNomJoueur(2) + " - " + getNomJoueur(3);
                }
                else if (max_J3 == max_J4 && max_J3 > max_J2 && max_J3 > max_J1 && max_J3 > 0)
                {
                    nom = getNomJoueur(3) + " - " + getNomJoueur(4);
                }
                else if (max_J1 == max_J2 && max_J2 == max_J3 && max_J1 > max_J4 && max_J1 > 0)
                {
                    nom = getNomJoueur(1) + " - " + getNomJoueur(2) + " - " + getNomJoueur(3);
                }
                else if (max_J1 == max_J2 && max_J2 == max_J4 && max_J1 > max_J3 && max_J1 > 0)
                {
                    nom = getNomJoueur(1) + " - " + getNomJoueur(2) + " - " + getNomJoueur(4);
                }
                else if (max_J1 == max_J3 && max_J3 == max_J4 && max_J1 > max_J2 && max_J1 > 0)
                {
                    nom = getNomJoueur(1) + " - " + getNomJoueur(3) + " - " + getNomJoueur(4);
                }
                else if (max_J2 == max_J3 && max_J3 == max_J4 && max_J2 > max_J1 && max_J1 > 2)
                {
                    nom = getNomJoueur(2) + " - " + getNomJoueur(3) + " - " + getNomJoueur(4);
                }
                else if (max_J1 == max_J2 && max_J2 == max_J3 && max_J3 == max_J4 && max_J1 > 0)
                {
                    nom = getNomJoueur(1) + " - " + getNomJoueur(2) + " - " + getNomJoueur(3) + " - " + getNomJoueur(4);
                }


                return nom;
            }

            return "";
        }

        public int maitreDeLaCarte(int IDCarte)
        {
            Dictionary<int, int> attaques_joueurs = getAttaquesJoueursCarte(IDCarte);

            if(attaques_joueurs != null)
            {
                var attaque_J1 = attaques_joueurs.Where(x => x.Key == 1);
                var attaque_J2 = attaques_joueurs.Where(x => x.Key == 2);
                var attaque_J3 = attaques_joueurs.Where(x => x.Key == 3);
                var attaque_J4 = attaques_joueurs.Where(x => x.Key == 4);

                int max_J1 = 0;
                int max_J2 = 0;
                int max_J3 = 0;
                int max_J4 = 0;

                foreach (var attaque in attaque_J1)
                {
                    if (attaque.Value > max_J1)
                    {
                        max_J1 = attaque.Value;
                    }
                }

                foreach (var attaque in attaque_J2)
                {
                    if (attaque.Value > max_J2)
                    {
                        max_J2 = attaque.Value;
                    }
                }

                foreach (var attaque in attaque_J3)
                {
                    if (attaque.Value > max_J3)
                    {
                        max_J3 = attaque.Value;
                    }
                }

                foreach (var attaque in attaque_J4)
                {
                    if (attaque.Value > max_J4)
                    {
                        max_J4 = attaque.Value;
                    }
                }

                if (max_J1 > max_J2 && max_J1 > max_J3 && max_J1 > max_J4)
                {
                    return 1;
                }
                else if (max_J2 > max_J3 && max_J2 > max_J4 && max_J2 > max_J1)
                {
                    return 2;
                }
                else if (max_J3 > max_J4 && max_J3 > max_J1 && max_J3 > max_J2)
                {
                    return 3;
                }
                else if (max_J4 > max_J1 && max_J4 > max_J2 && max_J4 > max_J3)
                {
                    return 4;
                }

                if ((max_J1 == max_J2 && max_J1 > max_J3 && max_J1 > max_J4) || (max_J1 == max_J3 && max_J1 > max_J2 && max_J1 > max_J4) || (max_J1 == max_J4 && max_J1 > max_J2 && max_J1 > max_J3) || (max_J2 == max_J3 && max_J2 > max_J1 && max_J2 > max_J4) || (max_J2 == max_J4 && max_J2 > max_J1 && max_J2 > max_J3) || (max_J3 == max_J4 && max_J3 > max_J1 && max_J3 > max_J2) || (max_J1 == max_J2 && max_J1 == max_J3 && max_J3 > max_J4) || (max_J1 == max_J2 && max_J1 == max_J4 && max_J4 > max_J3) || (max_J1 == max_J3 && max_J1 == max_J4 && max_J3 > max_J2) || (max_J2 == max_J3 && max_J2 == max_J4 && max_J2 > max_J1) || (max_J1 == max_J2 && max_J2 == max_J3 && max_J3 == max_J4 && max_J1 > 0))
                {
                    return -1;
                }
            }
            

            return 0;
        }

        public Dictionary<int, int> getAttaquesJoueursCarte(int IDCarte)
        {
            Dictionary<CartePirate, int> possesseurCartePirate = new Dictionary<CartePirate, int>();
            var recupPirates = _attaquesEnCours.Where(x => x.Value.getIdCarte() == IDCarte);
            int attaque_J1 = 0;
            int attaque_J2 = 0;
            int attaque_J3 = 0;
            int attaque_J4 = 0;

            foreach (var attaque in recupPirates)
            {
                var recupAttaquant = _idCartesPirates_idJoueurs.First(x => x.Key == attaque.Key.getIdCarte());
                possesseurCartePirate.Add((CartePirate)attaque.Key, recupAttaquant.Value);
            }

            foreach(var item in possesseurCartePirate)
            {
                if(item.Value == 1)
                {
                    attaque_J1 += item.Key.getAttaque();
                }
                else if (item.Value == 2)
                {
                    attaque_J2 += item.Key.getAttaque();
                }
                else if (item.Value == 3)
                {
                    attaque_J3 += item.Key.getAttaque();
                }
                else
                {
                    attaque_J4 += item.Key.getAttaque();
                }
            }

            if(attaque_J1 != 0 || attaque_J2 != 0 || attaque_J3 != 0 || attaque_J4 != 0)
            {
                Dictionary<int, int> idJoueur_pointsAttaque = new Dictionary<int,int>();
                idJoueur_pointsAttaque.Add(1, attaque_J1);
                idJoueur_pointsAttaque.Add(2, attaque_J2);
                idJoueur_pointsAttaque.Add(3, attaque_J3);
                idJoueur_pointsAttaque.Add(4, attaque_J4);
                return idJoueur_pointsAttaque;
            }
                
            return null;
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


        public void setAPoserMarchand(bool value)
        {
            _aPoserMarchand = value;
        }

        public void ajoutAttaque(Carte cartePirate, Carte carteMarchand)
        {
            _attaquesEnCours.Add(cartePirate, carteMarchand);
        }

        public void setAttaqueValide(bool value)
        {
            _attaqueValide = value;
        }

        public string getCouleurAttaquesJoueursCarte(int IDCarte, int idJoueur)
        {
            if(_idCartesPirates_idJoueurs.Count != 0)
            {
                try
                {
                    var temp = _idCartesPirates_idJoueurs.First(x => x.Value == idJoueur);
                    var temp2 = _attaquesEnCours.Where(x => x.Value.getIdCarte() == IDCarte);

                    foreach (var item in temp2)
                    {
                        if (item.Key.getIdCarte() == temp.Key)
                        {
                            CartePirate carte = (CartePirate)item.Key;
                            return carte.getCouleur();
                        }
                    }
                }
                catch(Exception e)
                {
                    return "";
                }
                
                
            }
            
            return "";
        }

        public bool verifAttaqueValide(string couleur, int IDCarte)
        {
            string couleurEnCours = "";
            string color_2 = "";
            string color_3 = "";
            string color_4 = "";

            if(_etape == 1)
            {
                couleurEnCours = getCouleurAttaquesJoueursCarte(IDCarte, 1);
                color_2 = getCouleurAttaquesJoueursCarte(IDCarte, 2);
                color_3 = getCouleurAttaquesJoueursCarte(IDCarte, 3);
                color_4 = getCouleurAttaquesJoueursCarte(IDCarte, 4);
            }
            else if (_etape == 2)
            {
                couleurEnCours = getCouleurAttaquesJoueursCarte(IDCarte, 2);
                color_2 = getCouleurAttaquesJoueursCarte(IDCarte, 1);
                color_3 = getCouleurAttaquesJoueursCarte(IDCarte, 3);
                color_4 = getCouleurAttaquesJoueursCarte(IDCarte, 4);
            }
            else if (_etape == 3)
            {
                couleurEnCours = getCouleurAttaquesJoueursCarte(IDCarte, 3);
                color_2 = getCouleurAttaquesJoueursCarte(IDCarte, 1);
                color_3 = getCouleurAttaquesJoueursCarte(IDCarte, 2);
                color_4 = getCouleurAttaquesJoueursCarte(IDCarte, 4);
            }
            else
            {
                couleurEnCours = getCouleurAttaquesJoueursCarte(IDCarte, 4);
                color_2 = getCouleurAttaquesJoueursCarte(IDCarte, 1);
                color_3 = getCouleurAttaquesJoueursCarte(IDCarte, 2);
                color_4 = getCouleurAttaquesJoueursCarte(IDCarte, 3);
            }

            if (couleurEnCours == couleur && couleurEnCours != color_2 && couleurEnCours != color_3 && couleurEnCours != color_4)
            {
                _attaqueValide = true;
                return true;
            }

            return false;
        }

        public Carte getPirateEnCours()
        {
            if (_cartesPiratesTapis_etape_1.Count != 0)
            {
                Carte cartePirate;
                if (_cartesPiratesTapis_etape_1.TryGetValue(_cartesPiratesTapis_etape_1.Count, out cartePirate))
                {
                    return cartePirate;
                }
            }

            return null;
        }

        public void setAttaqueInvalide()
        {
            if (_cartesPiratesTapis_etape_1.Count != 0)
            {
                var temp = _cartesPiratesTapis_etape_1.First(x => x.Key == _cartesPiratesTapis_etape_1.Count);

                _cartesPiratesTapis_etape_1.Remove(temp.Key);
                _attaquesEnCours.Remove(temp.Value);
                _idCartesPirates_idJoueurs.Remove(temp.Value.getIdCarte());
                _estEnTrainDAttaquer = false;
                _attaqueValide = false;
            }

        }

    }
}
