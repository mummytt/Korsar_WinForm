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
            j1.modifier_ID(1);
            j2.modifier_ID(2); 
            j3.modifier_ID(3); 
            j4.modifier_ID(4);

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
            _deck.melanger_cartes();

            _tour = 1;
            _etape = 1;

        }

        public void ajout_orJoueur(int or, int idJoueur)
        {
            Joueur jonh = recuperer_joueur(idJoueur);
            jonh.ajout_or(or);
        }

        public int recuperer_orJoueurCourant()
        {
            Joueur jonh = recupererJoueurCourant(); ;

            return jonh.recuperer_Or();
        }


        public Dictionary<int, Joueur> recuperer_joueurs()
        {
            return _joueurs;
        }

        public Joueur recuperer_joueur(int id)
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

        public Joueur recupererJoueurCourant()
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

        public void modifier_etapeSuivante()
        {
            _etape += 1;

            if (_etape > 4)
            {
                _etape = 1;
                _tour += 1;
            }

            modifier_aPoserUneCarte_joueurCourant(false);
            modifier_aPiocher_joueurCourant(false);

            Dictionary<int, Carte> temp = new Dictionary<int, Carte>();

            foreach(var item in _cartesMarchandsTapis_etape_4)
            {
                if(maitreDeLaCarte(item.Value.recuperer_idCarte()) == -1)
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
                Dictionary<int, int> KeyAttaqueSuppr2 = new Dictionary<int, int>();

                foreach(var item in _cartesMarchandsTapis_etape_4)
                {
                    foreach(var item2 in _attaquesEnCours)
                    {
                        if(item.Value == item2.Value)
                        {
                            KeyAttaqueSuppr.Add(item2.Key, item2.Key);
                        }

                        foreach (var item3 in _idCartesPirates_idJoueurs)
                        {
                            if (item2.Key.recuperer_idCarte() == item3.Key)
                            {
                                KeyAttaqueSuppr2.Add(item3.Key, item3.Key);
                            }
                        }
                    }

                    
                }

                foreach(var item in KeyAttaqueSuppr)
                {
                    _attaquesEnCours.Remove(item.Key);
                }

                foreach (var item in KeyAttaqueSuppr2)
                {
                    _idCartesPirates_idJoueurs.Remove(item.Key);
                }

            }
            
            //Donner l'or du bateau au joueur
            foreach (var item in _cartesMarchandsTapis_etape_4)
            {
                CarteMarchand carteM = (CarteMarchand)item.Value;
                if(maitreDeLaCarte(item.Value.recuperer_idCarte()) > 0)
                {
                    ajout_orJoueur(carteM.recuperer_or(), maitreDeLaCarte(item.Value.recuperer_idCarte()));
                }
                else if (maitreDeLaCarte(item.Value.recuperer_idCarte()) == 0)
                {
                    ajout_orJoueur(carteM.recuperer_or(), _etape);
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

        public int recuperer_etape()
        {
            return _etape;
        }

        public int recuperer_tour()
        {
            return _tour;
        }
        
        public string recuperer_nomJoueur(int idJoueur)
        {
            return recuperer_joueur(idJoueur).recuperer_nom();
        }

        public string recuperer_nomJoueurCourant()
        {
            return recuperer_joueur(_etape).recuperer_nom();
        }

        public void donner_carteAJoueur(int idJoueur)
        {
            Joueur jonh = recuperer_joueur(idJoueur);
            Carte carte = _deck.piocher();
            jonh.ajouter_mainJoueur(_deck.recuperer_increment_deck() - 1, carte);
        }

        
        public void donner_carteAJoueurCourant()
        {
            Joueur jonh = recupererJoueurCourant();
            Carte carte = _deck.piocher();
            jonh.ajouter_mainJoueur(_deck.recuperer_increment_deck() - 1, carte);
        }

        public bool verifier_gainMarchand(int idJoueur)
        {
            return false;
        }

        

        public Dictionary<int, Carte> recuperer_mainJoueurCourant()
        {
            Dictionary<int, Carte> main = new Dictionary<int,Carte>();
            Joueur jonh = recupererJoueurCourant();
            main = jonh.recuperer_mainJoueur();

            return main;
        }

        public int recuperer_nombreCartesMainJoueurCourant()
        {
            int nbCartes = 0;
            Joueur jonh = recupererJoueurCourant();
            nbCartes = jonh.recuperer_nombreCartesEnMain();

            return nbCartes;
        }


        public bool verifier_APiocherCourant()
        {
            Joueur jonh = recuperer_joueur(_etape);

            return jonh.verifier_aPiocher();
        }

        public bool verifier_aPoserUneCarteCourant()
        {
            Joueur jonh = recuperer_joueur(_etape);

            return jonh.recuperer_aPoserUneCarte();
        }

        public Carte recuperer_carte_parID(int idCarte)
        {
            return _deck.recuperer_carte_parID_deckBase(idCarte);
        }


        public void poser_carte(Carte carte)
        {
            if (carte.GetType() == typeof(CarteMarchand))
            {
                _cartesMarchandsTapis_etape_1.Add(_cartesMarchandsTapis_etape_1.Count + 1, carte);
                _idCartesMarchands_idJoueurs.Add(carte.recuperer_idCarte(), _etape);
                _aPoserMarchand = true;
                _estEnTrainDAttaquer = false;
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
                        _idCartesPirates_idJoueurs.Add(carte.recuperer_idCarte(), _etape);
                        _estEnTrainDAttaquer = true;
                    }
                }
            }


            if (_aPoserMarchand || _attaqueValide)
            {
                Joueur jonh = recupererJoueurCourant();
                jonh.poserCarte(carte);
                modifier_aPoserUneCarte_joueurCourant(true);
                _aPoserMarchand = false;
                _attaqueValide = false;

                Dictionary<int, Carte> newCartesEnMain = new Dictionary<int, Carte>();

                foreach (var carteMain in jonh.recuperer_mainJoueur())
                {
                    newCartesEnMain.Add(carteMain.Key, carteMain.Value);
                }

                jonh.modifier_mainJoueur(newCartesEnMain);
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

        public void modifier_cartesTapis(int etape, Dictionary<int, Carte> main)
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

        public string recuperer_labelJoueur_carteTapis(int IDCarte)
        {
            Dictionary<int, int> attaques_joueurs = recuperer_attaquesJoueursSurCarte(IDCarte);
            if (attaques_joueurs == null)
            {
                var recup = _idCartesMarchands_idJoueurs.First(x => x.Key == IDCarte);
                return recuperer_nomJoueur(recup.Value);
            }

            int verifEgalite = maitreDeLaCarte(IDCarte);

            if(verifEgalite == -1)
            {
                return "Egalité";
            }

            return recuperer_nomJoueur(verifEgalite);
        }

        public string recuperer_nomsJoueurs_EgaliteAttaqueCarte(int IDCarte)
        {
            Dictionary<int, int> attaques_joueurs = recuperer_attaquesJoueursSurCarte(IDCarte);

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

                if (max_J1 == max_J2 && max_J1 > max_J3 && max_J1 > max_J4 && max_J1 > 0)
                {
                    nom = recuperer_nomJoueur(1) + " - " + recuperer_nomJoueur(2);
                }
                else if (max_J1 == max_J3 && max_J1 > max_J2 && max_J1 > max_J4 && max_J1 > 0)
                {
                    nom = recuperer_nomJoueur(1) + " - " + recuperer_nomJoueur(3);
                }
                else if (max_J1 == max_J4 && max_J1 > max_J2 && max_J1 > max_J3 && max_J1 > 0)
                {
                    nom = recuperer_nomJoueur(1) + " - " + recuperer_nomJoueur(4);
                }
                else if (max_J2 == max_J3 && max_J2 > max_J1 && max_J2 > max_J4 && max_J2 > 0)
                {
                    nom = recuperer_nomJoueur(2) + " - " + recuperer_nomJoueur(3);
                }
                else if (max_J3 == max_J4 && max_J3 > max_J2 && max_J3 > max_J1 && max_J3 > 0)
                {
                    nom = recuperer_nomJoueur(3) + " - " + recuperer_nomJoueur(4);
                }
                else if (max_J1 == max_J2 && max_J1 == max_J3 && max_J1 > max_J4 && max_J1 > 0)
                {
                    nom = recuperer_nomJoueur(1) + " - " + recuperer_nomJoueur(2) + " - " + recuperer_nomJoueur(3);
                }
                else if (max_J1 == max_J2 && max_J1 == max_J4 && max_J1 > max_J3 && max_J1 > 0)
                {
                    nom = recuperer_nomJoueur(1) + " - " + recuperer_nomJoueur(2) + " - " + recuperer_nomJoueur(4);
                }
                else if (max_J1 == max_J3 && max_J1 == max_J4 && max_J1 > max_J2 && max_J1 > 0)
                {
                    nom = recuperer_nomJoueur(1) + " - " + recuperer_nomJoueur(3) + " - " + recuperer_nomJoueur(4);
                }
                else if (max_J2 == max_J3 && max_J2 == max_J4 && max_J2 > max_J1 && max_J2 > 0)
                {
                    nom = recuperer_nomJoueur(2) + " - " + recuperer_nomJoueur(3) + " - " + recuperer_nomJoueur(4);
                }
                else if (max_J1 == max_J2 && max_J1 == max_J3 && max_J1 == max_J4 && max_J1 > 0)
                {
                    nom = recuperer_nomJoueur(1) + " - " + recuperer_nomJoueur(2) + " - " + recuperer_nomJoueur(3) + " - " + recuperer_nomJoueur(4);
                }


                return nom;
            }

            return "";
        }

        public int maitreDeLaCarte(int IDCarte)
        {
            Dictionary<int, int> attaques_joueurs = recuperer_attaquesJoueursSurCarte(IDCarte);

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

        public Dictionary<int, int> recuperer_attaquesJoueursSurCarte(int IDCarte)
        {
            Dictionary<CartePirate, int> possesseurCartePirate = new Dictionary<CartePirate, int>();
            var recupPirates = _attaquesEnCours.Where(x => x.Value.recuperer_idCarte() == IDCarte);
            int attaque_J1 = 0;
            int attaque_J2 = 0;
            int attaque_J3 = 0;
            int attaque_J4 = 0;

            foreach (var attaque in recupPirates)
            {
                var recupAttaquant = _idCartesPirates_idJoueurs.First(x => x.Key == attaque.Key.recuperer_idCarte());
                possesseurCartePirate.Add((CartePirate)attaque.Key, recupAttaquant.Value);
            }

            foreach(var item in possesseurCartePirate)
            {
                if(item.Value == 1)
                {
                    attaque_J1 += item.Key.recuperer_attaque();
                }
                else if (item.Value == 2)
                {
                    attaque_J2 += item.Key.recuperer_attaque();
                }
                else if (item.Value == 3)
                {
                    attaque_J3 += item.Key.recuperer_attaque();
                }
                else
                {
                    attaque_J4 += item.Key.recuperer_attaque();
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

        public void modifier_aPiocher_joueurCourant(bool value)
        {
            Joueur jonh = recupererJoueurCourant();
            jonh.modifier_aPiocher(value);
        }

        public void modifier_aPoserUneCarte_joueurCourant(bool value)
        {
            Joueur jonh = recupererJoueurCourant();
            jonh.modifier_aPoserUneCarte(value);
        }

        public bool recuperer_piochePossible()
        {
            if(_deck.recuperer_nombre_cartes_deckPioche() != 0)
            {
                return true;
            }

            return false;
        }

        public bool recuperer_estEnTrainDattaquer()
        {
            return _estEnTrainDAttaquer;
        }


        public void modifier_estEnTrainDattaquer(bool value)
        {
            _estEnTrainDAttaquer = value;
        }


        public void modifier_aPoserMarchand(bool value)
        {
            _aPoserMarchand = value;
        }

        public void ajout_attaque(Carte cartePirate, Carte carteMarchand)
        {
            _attaquesEnCours.Add(cartePirate, carteMarchand);
        }

        public void modifier_attaqueValide(bool value)
        {
            _attaqueValide = value;
        }

        public string recuperer_couleurAttaquesJoueurs_carte(int IDCarte, int idJoueur)
        {
            if(_idCartesPirates_idJoueurs.Count != 0)
            {
                try
                {
                    var temp = _idCartesPirates_idJoueurs.Where(x => x.Value == idJoueur);
                    var temp2 = _attaquesEnCours.Where(x => x.Value.recuperer_idCarte() == IDCarte);

                    foreach(var item1 in temp)
                    {
                        foreach (var item2 in temp2)
                        {
                            if (item2.Key.recuperer_idCarte() == item1.Key)
                            {
                                CartePirate carte = (CartePirate)item2.Key;
                                return carte.recuperer_couleur();
                            }
                        }
                    }
                    
                }
                catch(Exception e)
                {
                    Console.WriteLine("Exception dans getCouleurAttaquesJoueursCarte : " + e.ToString());
                    return "";
                }
                
                
            }
            
            return "";
        }

        public bool verifier_attaqueValide(string couleur, int IDCarte)
        {
            string couleurEnCours = "";
            string color_2 = "";
            string color_3 = "";
            string color_4 = "";

            if(_etape == 1)
            {
                couleurEnCours = recuperer_couleurAttaquesJoueurs_carte(IDCarte, 1);
                color_2 = recuperer_couleurAttaquesJoueurs_carte(IDCarte, 2);
                color_3 = recuperer_couleurAttaquesJoueurs_carte(IDCarte, 3);
                color_4 = recuperer_couleurAttaquesJoueurs_carte(IDCarte, 4);
            }
            else if (_etape == 2)
            {
                couleurEnCours = recuperer_couleurAttaquesJoueurs_carte(IDCarte, 2);
                color_2 = recuperer_couleurAttaquesJoueurs_carte(IDCarte, 1);
                color_3 = recuperer_couleurAttaquesJoueurs_carte(IDCarte, 3);
                color_4 = recuperer_couleurAttaquesJoueurs_carte(IDCarte, 4);
            }
            else if (_etape == 3)
            {
                couleurEnCours = recuperer_couleurAttaquesJoueurs_carte(IDCarte, 3);
                color_2 = recuperer_couleurAttaquesJoueurs_carte(IDCarte, 1);
                color_3 = recuperer_couleurAttaquesJoueurs_carte(IDCarte, 2);
                color_4 = recuperer_couleurAttaquesJoueurs_carte(IDCarte, 4);
            }
            else
            {
                couleurEnCours = recuperer_couleurAttaquesJoueurs_carte(IDCarte, 4);
                color_2 = recuperer_couleurAttaquesJoueurs_carte(IDCarte, 1);
                color_3 = recuperer_couleurAttaquesJoueurs_carte(IDCarte, 2);
                color_4 = recuperer_couleurAttaquesJoueurs_carte(IDCarte, 3);
            }

            if (couleurEnCours == couleur && couleurEnCours != color_2 && couleurEnCours != color_3 && couleurEnCours != color_4)
            {
                _attaqueValide = true;
                return true;
            }

            return false;
        }

        public Carte recuperer_pirateEnCours()
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

        public void modifier_AttaqueInvalide()
        {
            if (_cartesPiratesTapis_etape_1.Count != 0)
            {
                var temp = _cartesPiratesTapis_etape_1.First(x => x.Key == _cartesPiratesTapis_etape_1.Count);

                _cartesPiratesTapis_etape_1.Remove(temp.Key);
                _attaquesEnCours.Remove(temp.Value);
                _idCartesPirates_idJoueurs.Remove(temp.Value.recuperer_idCarte());
                _estEnTrainDAttaquer = false;
                _attaqueValide = false;
            }

        }

    }
}
