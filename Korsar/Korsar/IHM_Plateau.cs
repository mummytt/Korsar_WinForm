using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Metier;

namespace Korsar
{
    public partial class IHM_Plateau : Form
    {
        Plateau plateau;
        int _margeGauche_apparitionCarteMain = 200;
        int _margeHaut_apparitionCarteMain = 650;
        int _tailleCarte_largeur = 92;
        int _tailleCarte_hauteur = 135;
        int _tailleCarteMiniature_largeur = 28;
        int _espacement_cartes = 100;
        int _espacement_cartesMiniatures = 40;
        int _espacementActuel_cartes = 0;

        Dictionary<int, PictureBox> _mainImageJoueur;
        Dictionary<int, PictureBox> _imagesCartesMarchands_etape_1;
        Dictionary<int, PictureBox> _imagesCartesMarchands_etape_2;
        Dictionary<int, PictureBox> _imagesCartesMarchands_etape_3;
        Dictionary<int, PictureBox> _imagesCartesMarchands_etape_4;

        Dictionary<int, Label> _labelsJoueurs_etape_1;
        Dictionary<int, Label> _labelsJoueurs_etape_2;
        Dictionary<int, Label> _labelsJoueurs_etape_3;
        Dictionary<int, Label> _labelsJoueurs_etape_4;

        Dictionary<int, Label> _labelsAttaques_etape_1;
        Dictionary<int, Label> _labelsAttaques_etape_2;
        Dictionary<int, Label> _labelsAttaques_etape_3;
        Dictionary<int, Label> _labelsAttaques_etape_4;

        public IHM_Plateau(Joueur j1, Joueur j2, Joueur j3, Joueur j4)
        {
            InitializeComponent();
            plateau = new Plateau(j1, j2, j3, j4);
            _mainImageJoueur = new Dictionary<int, PictureBox>();

            _imagesCartesMarchands_etape_1 = new Dictionary<int, PictureBox>();
            _imagesCartesMarchands_etape_2 = new Dictionary<int, PictureBox>();
            _imagesCartesMarchands_etape_3 = new Dictionary<int, PictureBox>();
            _imagesCartesMarchands_etape_4 = new Dictionary<int, PictureBox>();

            _labelsJoueurs_etape_1 = new Dictionary<int, Label>();
            _labelsJoueurs_etape_2 = new Dictionary<int, Label>();
            _labelsJoueurs_etape_3 = new Dictionary<int, Label>();
            _labelsJoueurs_etape_4 = new Dictionary<int, Label>();

            _labelsAttaques_etape_1 = new Dictionary<int, Label>();
            _labelsAttaques_etape_2 = new Dictionary<int, Label>();
            _labelsAttaques_etape_3 = new Dictionary<int, Label>();
            _labelsAttaques_etape_4 = new Dictionary<int, Label>();

            l_joueur1.Text = plateau.recuperer_nomJoueur(1);
            l_joueur2.Text = plateau.recuperer_nomJoueur(2);
            l_joueur3.Text = plateau.recuperer_nomJoueur(3);
            l_joueur4.Text = plateau.recuperer_nomJoueur(4);

            initialisationPlateau();
            this.chargementPlateau();
        }

        public void initialisationPlateau()
        {
            plateau.donner_carteAJoueur(1);
            plateau.donner_carteAJoueur(1);
            plateau.donner_carteAJoueur(1);
            plateau.donner_carteAJoueur(1);
            plateau.donner_carteAJoueur(1);
            plateau.donner_carteAJoueur(1);

            plateau.donner_carteAJoueur(2);
            plateau.donner_carteAJoueur(2);
            plateau.donner_carteAJoueur(2);
            plateau.donner_carteAJoueur(2);
            plateau.donner_carteAJoueur(2);
            plateau.donner_carteAJoueur(2);

            plateau.donner_carteAJoueur(3);
            plateau.donner_carteAJoueur(3);
            plateau.donner_carteAJoueur(3);
            plateau.donner_carteAJoueur(3);
            plateau.donner_carteAJoueur(3);
            plateau.donner_carteAJoueur(3);

            plateau.donner_carteAJoueur(4);
            plateau.donner_carteAJoueur(4);
            plateau.donner_carteAJoueur(4);
            plateau.donner_carteAJoueur(4);
            plateau.donner_carteAJoueur(4);
            plateau.donner_carteAJoueur(4);

        }

        public void afficherMainJoueur()
        {
            Dictionary<int, Carte> cartes = plateau.recuperer_mainJoueurCourant();
            int nbCarteMainJoueur = plateau.recuperer_nombreCartesMainJoueurCourant();
            int i = 0;
            _espacementActuel_cartes = 0;

            foreach (Carte item in cartes.Values)
            {
                PictureBox pb = new PictureBox();
                pb.Location = new Point(_margeGauche_apparitionCarteMain + _espacementActuel_cartes, _margeHaut_apparitionCarteMain);
                pb.BorderStyle = BorderStyle.FixedSingle;
                pb.Tag = item.recuperer_idCarte();
                pb.Click += new System.EventHandler(pb_carteMain_Click);

                if (nbCarteMainJoueur <= 9)
                {
                    pb.Image = item.recuperer_imageCarte();
                    _espacementActuel_cartes += _espacement_cartes;
                    pb.Size = new Size(_tailleCarte_largeur, _tailleCarte_hauteur);
                }
                else
                {
                    pb.Image = item.recuperer_imageMiniatureCarte();
                    _espacementActuel_cartes += _espacement_cartesMiniatures;
                    pb.Size = new Size(_tailleCarteMiniature_largeur, _tailleCarte_hauteur);
                }

                _mainImageJoueur.Add(i, pb);

                i++;
            }


            foreach (KeyValuePair<int, PictureBox> item in _mainImageJoueur)
            {
                Controls.Add(item.Value);
            }
        }


        public void afficherTapis()
        {

            for (int i = 1; i <= 4; i++)
            {
                Dictionary<int, Carte> cartesTapis = plateau.recuperer_cartesTapis(i);
                Label[] lAttaque = new Label[4];
                int x = 0;
                _espacementActuel_cartes = 0;

                foreach (var carte in cartesTapis)
                {

                    //MARCHAND
                    PictureBox pb = new PictureBox();
                    pb.BorderStyle = BorderStyle.FixedSingle;
                    pb.Tag = carte.Value.recuperer_idCarte();
                    pb.Image = carte.Value.recuperer_imageMiniatureCarte();
                    pb.Size = new Size(_tailleCarteMiniature_largeur, _tailleCarte_hauteur);
                    pb.Click += new System.EventHandler(pb_carteMarchandTapis_Click);

                    Label labelJoueur = new Label();
                    labelJoueur.Text = plateau.recuperer_nomJoueur_carteTapis(carte.Value.recuperer_idCarte());
                    labelJoueur.Size = new Size(labelJoueur.Text.Length * 6 + 5, 13);

                    if (x >= 3)
                    {
                        if (_espacementActuel_cartes > _espacement_cartesMiniatures * 3)
                        {
                            _espacement_cartesMiniatures = 0;
                        }

                        pb.Location = new Point(_espacement_cartesMiniatures + _espacementActuel_cartes, 100 + _tailleCarte_hauteur);
                        labelJoueur.Location = new Point(_espacement_cartesMiniatures + _espacementActuel_cartes, 80 + _tailleCarte_hauteur);
                        _espacementActuel_cartes += 2 * _espacement_cartesMiniatures;
                    }
                    else
                    {
                        pb.Location = new Point(_espacement_cartesMiniatures + _espacementActuel_cartes, 50);
                        labelJoueur.Location = new Point(_espacement_cartesMiniatures + _espacementActuel_cartes, 30);
                        _espacementActuel_cartes += 2 * _espacement_cartesMiniatures;
                    }

                    x++;


                    //ATTAQUES
                    var attaquesJoueurs = plateau.recuperer_attaquesJoueursSurCarte(carte.Value.recuperer_idCarte());

                    if(attaquesJoueurs != null)
                    {
                        int j = 0;
                        foreach (var attaque in attaquesJoueurs)
                        {

                            if(attaque.Value != 0)
                            {
                                string couleur = plateau.recuperer_couleurAttaquesJoueurs_carte(carte.Value.recuperer_idCarte(), attaque.Key);

                                if (couleur != "")
                                {

                                    lAttaque[j] = new Label();
                                    lAttaque[j].Text = attaque.Value.ToString();

                                    if (attaque.Value >= 10)
                                    {
                                        lAttaque[j].Size = new Size(30, 30);
                                        lAttaque[j].Padding = new Padding(5, 7, 5, 5);
                                    }
                                    else
                                    {
                                        lAttaque[j].Size = new Size(29, 29);
                                        lAttaque[j].Padding = new Padding(8);
                                    }
                                    

                                    if (attaque.Key == 1)
                                    {
                                        lAttaque[j].Location = new Point(pb.Location.X - _tailleCarteMiniature_largeur, 50);
                                    }
                                    else if (attaque.Key == 2)
                                    {
                                        lAttaque[j].Location = new Point(pb.Location.X + _tailleCarteMiniature_largeur, 50);
                                    }
                                    else if (attaque.Key == 3)
                                    {
                                        lAttaque[j].Location = new Point(pb.Location.X + _tailleCarteMiniature_largeur, _tailleCarte_hauteur + 21);
                                    }
                                    else if (attaque.Key == 4)
                                    {
                                        lAttaque[j].Location = new Point(pb.Location.X - _tailleCarteMiniature_largeur, _tailleCarte_hauteur + 21);
                                    }

                                    if (couleur == "rouge")
                                    {
                                        lAttaque[j].Image = Properties.Resources.attaque_rouge;
                                    }
                                    else if (couleur == "bleu")
                                    {
                                        lAttaque[j].Image = Properties.Resources.attaque_bleu;
                                    }
                                    else if (couleur == "vert")
                                    {
                                        lAttaque[j].Image = Properties.Resources.attaque_vert;
                                    }
                                    else if (couleur == "jaune")
                                    {
                                        lAttaque[j].Image = Properties.Resources.attaque_jaune;
                                    }

                                }
                                j++;

                            }
                            
                        }

                    }

                    
                    if (i == 1)
                    {
                        pb.Name = "etape_1";
                        _imagesCartesMarchands_etape_1.Add(carte.Key, pb);
                        _labelsJoueurs_etape_1.Add(carte.Value.recuperer_idCarte(), labelJoueur);

                        foreach(var item in lAttaque)
                        {
                            _labelsAttaques_etape_1.Add(_labelsAttaques_etape_1.Count + 1, item);
                        }
                        
                        
                    }
                    else if (i == 2)
                    {
                        pb.Name = "etape_2";
                        _imagesCartesMarchands_etape_2.Add(carte.Key, pb);
                        _labelsJoueurs_etape_2.Add(carte.Value.recuperer_idCarte(), labelJoueur);

                        foreach (var item in lAttaque)
                        {
                            _labelsAttaques_etape_2.Add(_labelsAttaques_etape_2.Count + 1, item);
                        }
                    }
                    else if (i == 3)
                    {
                        pb.Name = "etape_3";
                        _imagesCartesMarchands_etape_3.Add(carte.Key, pb);
                        _labelsJoueurs_etape_3.Add(carte.Value.recuperer_idCarte(), labelJoueur);

                        foreach (var item in lAttaque)
                        {
                            _labelsAttaques_etape_3.Add(_labelsAttaques_etape_3.Count + 1, item);
                        }
                    }
                    else
                    {
                        pb.Name = "etape_4";
                        _imagesCartesMarchands_etape_4.Add(carte.Key, pb);
                        _labelsJoueurs_etape_4.Add(carte.Value.recuperer_idCarte(), labelJoueur);

                        foreach (var item in lAttaque)
                        {
                            _labelsAttaques_etape_4.Add(_labelsAttaques_etape_4.Count + 1, item);
                        }
                    }
                    

                }
               

                if (i == 1)
                {
                    foreach (var item in _imagesCartesMarchands_etape_1)
                    {
                        gb_etape_1.Controls.Add(item.Value);
                    }

                    foreach (var item in _labelsJoueurs_etape_1)
                    {
                        gb_etape_1.Controls.Add(item.Value);
                    }

                    foreach (var item in _labelsAttaques_etape_1)
                    {
                        gb_etape_1.Controls.Add(item.Value);
                    }

                    

                    
                }
                else if (i == 2)
                {
                    foreach (var item in _imagesCartesMarchands_etape_2)
                    {
                        gb_etape_2.Controls.Add(item.Value);
                    }

                    foreach (var item in _labelsJoueurs_etape_2)
                    {
                        gb_etape_2.Controls.Add(item.Value);
                    }

                    foreach (var item in _labelsAttaques_etape_2)
                    {
                        gb_etape_2.Controls.Add(item.Value);
                    }
                }
                else if (i == 3)
                {
                    foreach (var item in _imagesCartesMarchands_etape_3)
                    {
                        gb_etape_3.Controls.Add(item.Value);
                    }

                    foreach (var item in _labelsJoueurs_etape_3)
                    {
                        gb_etape_3.Controls.Add(item.Value);
                    }

                    foreach (var item in _labelsAttaques_etape_3)
                    {
                        gb_etape_3.Controls.Add(item.Value);
                    }
                }
                else
                {
                    foreach (var item in _imagesCartesMarchands_etape_4)
                    {
                        gb_etape_4.Controls.Add(item.Value);
                    }

                    foreach (var item in _labelsJoueurs_etape_4)
                    {
                        gb_etape_4.Controls.Add(item.Value);
                    }

                    foreach (var item in _labelsAttaques_etape_4)
                    {
                        gb_etape_4.Controls.Add(item.Value);
                    }
                }
            }
        }

        public void chargementPlateau()
        {
            l_tour.Text = "Tour : " + plateau.recuperer_tour();
            l_or.Text = "Or : " + plateau.recupererJoueurCourant().recuperer_Or();
            afficherTapis();
            afficherMainJoueur();
            changeImageEtape();

            if (!plateau.recuperer_piochePossible())
            {
                pb_pioche.Image = null;
            }

        }


        public void changeImageEtape()
        {
            int etape = plateau.recuperer_etape();

            if (etape == 1)
            {
                pb_joueur4.Image = Korsar.Properties.Resources.joueur;
                pb_joueur1.Image = Korsar.Properties.Resources.joueurActif;
            }
            else if (etape == 2)
            {
                pb_joueur1.Image = Korsar.Properties.Resources.joueur;
                pb_joueur2.Image = Korsar.Properties.Resources.joueurActif;
            }
            else if (etape == 3)
            {
                pb_joueur2.Image = Korsar.Properties.Resources.joueur;
                pb_joueur3.Image = Korsar.Properties.Resources.joueurActif;
            }
            else if (etape == 4)
            {
                pb_joueur3.Image = Korsar.Properties.Resources.joueur;
                pb_joueur4.Image = Korsar.Properties.Resources.joueurActif;
            }
        }

        public void nettoyerPlateau()
        {

            foreach (var item in _mainImageJoueur)
            {
                Controls.Remove(item.Value);
            }

            _mainImageJoueur = new Dictionary<int, PictureBox>();


            foreach (var item in _imagesCartesMarchands_etape_1)
            {
                gb_etape_1.Controls.Remove(item.Value);
            }

            foreach (var item in _labelsJoueurs_etape_1)
            {
                gb_etape_1.Controls.Remove(item.Value);
            }

            foreach (var item in _imagesCartesMarchands_etape_2)
            {
                gb_etape_2.Controls.Remove(item.Value);
            }

            foreach (var item in _labelsJoueurs_etape_2)
            {
                gb_etape_2.Controls.Remove(item.Value);
            }

            foreach (var item in _imagesCartesMarchands_etape_3)
            {
                gb_etape_3.Controls.Remove(item.Value);
            }

            foreach (var item in _labelsJoueurs_etape_3)
            {
                gb_etape_3.Controls.Remove(item.Value);
            }

            foreach (var item in _imagesCartesMarchands_etape_4)
            {
                gb_etape_4.Controls.Remove(item.Value);
            }

            foreach (var item in _labelsJoueurs_etape_4)
            {
                gb_etape_4.Controls.Remove(item.Value);
            }

            foreach (var item in _labelsAttaques_etape_1)
            {
                gb_etape_1.Controls.Remove(item.Value);
            }

            foreach (var item in _labelsAttaques_etape_2)
            {
                gb_etape_2.Controls.Remove(item.Value);
            }

            foreach (var item in _labelsAttaques_etape_3)
            {
                gb_etape_3.Controls.Remove(item.Value);
            }

            foreach (var item in _labelsAttaques_etape_4)
            {
                gb_etape_4.Controls.Remove(item.Value);
            }

            

            _imagesCartesMarchands_etape_1 = new Dictionary<int, PictureBox>();
            _imagesCartesMarchands_etape_2 = new Dictionary<int, PictureBox>();
            _imagesCartesMarchands_etape_3 = new Dictionary<int, PictureBox>();
            _imagesCartesMarchands_etape_4 = new Dictionary<int, PictureBox>();

            _labelsJoueurs_etape_1 = new Dictionary<int, Label>();
            _labelsJoueurs_etape_2 = new Dictionary<int, Label>();
            _labelsJoueurs_etape_3 = new Dictionary<int, Label>();
            _labelsJoueurs_etape_4 = new Dictionary<int, Label>();

            _labelsAttaques_etape_1 = new Dictionary<int, Label>();
            _labelsAttaques_etape_2 = new Dictionary<int, Label>();
            _labelsAttaques_etape_3 = new Dictionary<int, Label>();
            _labelsAttaques_etape_4 = new Dictionary<int, Label>();
        }

        private void b_etape_Click(object sender, EventArgs e)
        {
            if (plateau.verifier_APiocherCourant() == true || plateau.verifier_aPoserUneCarteCourant() == true)
            {
                if(plateau.recuperer_estEnTrainDattaquer() == false)
                {
                    nettoyerPlateau();
                    plateau.charger_etapeSuivante();
                    chargementPlateau();
                }
            }
           
        }
        
        private void pb_pioche_Click(object sender, EventArgs e)
        {
            if(plateau.recuperer_piochePossible())
            {
                if (plateau.verifier_APiocherCourant() == false && plateau.verifier_aPoserUneCarteCourant() == false)
                {
                    plateau.donner_carteAJoueurCourant();
                    this.nettoyerPlateau();
                    this.chargementPlateau();
                    plateau.modifier_aPiocher_joueurCourant(true);
                }
            }
        }


        private void pb_carteMain_Click(object sender, EventArgs e)
        {
            if (_imagesCartesMarchands_etape_1.Count < 6)
            {
                PictureBox pb = (PictureBox)sender;
                int idCarte = 0;
                Carte carte = null;

                if (int.TryParse(pb.Tag.ToString(), out idCarte))
                {
                    carte = plateau.recuperer_carte_parID(idCarte);
                }

                if (carte != null)
                {
                    if (plateau.verifier_APiocherCourant() == false && plateau.verifier_aPoserUneCarteCourant() == false)
                    {
                        plateau.poser_carte(carte);
                        nettoyerPlateau();
                        chargementPlateau();
                    }
                }
            }
        }


        private void pb_carteMarchandTapis_Click(object sender, EventArgs e)
        {
            if(plateau.recuperer_estEnTrainDattaquer())
            {
                PictureBox pb = (PictureBox)sender;
                Carte marchandAttaque = plateau.recuperer_carte_parID((int)pb.Tag);
                CartePirate attaquant = (CartePirate)plateau.recuperer_pirateEnCours();

                plateau.ajout_attaque(attaquant, marchandAttaque);

                if(plateau.verifier_attaqueValide(attaquant.recuperer_couleur(), marchandAttaque.recuperer_idCarte()))
                {
                    plateau.modifier_estEnTrainDattaquer(false);
                    plateau.poser_carte(attaquant);
                    plateau.modifier_attaqueValide(false);

                    var mainJoueur_1 = plateau.recuperer_cartesTapis(1);
                    int maitre = plateau.maitreDeLaCarte((int)pb.Tag);

                    string noms = plateau.recuperer_nomsJoueurs_EgaliteAttaqueCarte(marchandAttaque.recuperer_idCarte());

                    if (maitre == plateau.recuperer_etape() || noms.Contains(plateau.recuperer_nomJoueurCourant()) == true)
                    {
                        if (pb.Name == "etape_2")
                        {
                            var mainJoueur_2 = plateau.recuperer_cartesTapis(2);
                            var recup = mainJoueur_2.First(x => x.Value.recuperer_idCarte() == (int)pb.Tag);
                            mainJoueur_2.Remove(recup.Key);
                            mainJoueur_1.Add(recup.Key, recup.Value);
                            plateau.modifier_cartesTapis(2, mainJoueur_2);
                            plateau.modifier_cartesTapis(1, mainJoueur_1);

                        }
                        else if (pb.Name == "etape_3")
                        {
                            var mainJoueur_3 = plateau.recuperer_cartesTapis(3);
                            var recup = mainJoueur_3.First(x => x.Value.recuperer_idCarte() == (int)pb.Tag);
                            mainJoueur_3.Remove(recup.Key);
                            mainJoueur_1.Add(recup.Key, recup.Value);
                            plateau.modifier_cartesTapis(3, mainJoueur_3);
                            plateau.modifier_cartesTapis(1, mainJoueur_1);
                        }
                        else if (pb.Name == "etape_4")
                        {
                            var mainJoueur_4 = plateau.recuperer_cartesTapis(4);
                            var recup = mainJoueur_4.First(x => x.Value.recuperer_idCarte() == (int)pb.Tag);
                            mainJoueur_4.Remove(recup.Key);
                            mainJoueur_1.Add(recup.Key, recup.Value);
                            plateau.modifier_cartesTapis(4, mainJoueur_4);
                            plateau.modifier_cartesTapis(1, mainJoueur_1);
                        }
                    }

                    nettoyerPlateau();
                    chargementPlateau();
                }
                else
                {
                    plateau.modifier_AttaqueInvalide();
                }
                
            }
            
        }

    }
}
