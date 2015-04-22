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
        bool gagne = false;

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


            //-----------------------------------------TEST------------------------------------------------
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

            plateau.donner_carteAJoueur(3);
            plateau.donner_carteAJoueur(3);
            plateau.donner_carteAJoueur(3);
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
                    labelJoueur.Size = new Size(labelJoueur.Text.Length * 10 + 5, 13);

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

                    if (attaquesJoueurs != null)
                    {
                        int j = 0;
                        foreach (var attaque in attaquesJoueurs)
                        {
                            if (attaque.Value != 0)
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
                                        if (attaque.Value >= 50)
                                        {
                                            lAttaque[j].Image = Properties.Resources.attaque_capitaine_rouge;
                                            lAttaque[j].Text = "";
                                        }
                                        else
                                        {
                                            lAttaque[j].Image = Properties.Resources.attaque_rouge;
                                        }
                                    }
                                    else if (couleur == "bleu")
                                    {
                                        if (attaque.Value >= 50)
                                        {
                                            lAttaque[j].Image = Properties.Resources.attaque_capitaine_bleu;
                                            lAttaque[j].Text = "";
                                        }
                                        else
                                        {
                                            lAttaque[j].Image = Properties.Resources.attaque_bleu;
                                        }
                                    }
                                    else if (couleur == "vert")
                                    {
                                        if (attaque.Value >= 50)
                                        {
                                            lAttaque[j].Image = Properties.Resources.attaque_capitaine_vert;
                                            lAttaque[j].Text = "";
                                        }
                                        else
                                        {
                                            lAttaque[j].Image = Properties.Resources.attaque_vert;
                                        }
                                    }
                                    else if (couleur == "jaune")
                                    {
                                        if (attaque.Value >= 50)
                                        {
                                            lAttaque[j].Image = Properties.Resources.attaque_capitaine_jaune;
                                            lAttaque[j].Text = "";
                                        }
                                        else
                                        {
                                            lAttaque[j].Image = Properties.Resources.attaque_jaune;
                                        }
                                    }
                                    else if (couleur == "blanc")
                                    {
                                        lAttaque[j].Image = Properties.Resources.attaque_amiral;
                                        lAttaque[j].Text = "";
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

                        foreach (var item in lAttaque)
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
            l_or_joueur_1.Text = "Or : " + plateau.recuperer_joueur(1).recuperer_Or();
            l_or_joueur_2.Text = "Or : " + plateau.recuperer_joueur(2).recuperer_Or();
            l_or_joueur_3.Text = "Or : " + plateau.recuperer_joueur(3).recuperer_Or();
            l_or_joueur_4.Text = "Or : " + plateau.recuperer_joueur(4).recuperer_Or();
            afficherTapis();
            afficherMainJoueur();
            changeImageEtape();

            if (!plateau.recuperer_piochePossible())
            {
                pb_pioche.Image = null;
            }

            if (gagne)
            {
                Label texteGagne = new Label();
                texteGagne.Size = new System.Drawing.Size(200, 20);
                texteGagne.Location = new Point(520, 230);
                texteGagne.Text = plateau.recuperer_joueurGagnant().recuperer_nom() + " a gagné la partie avec " + plateau.recuperer_joueurGagnant().recuperer_Or() + " pièces d'or.";
                texteGagne.ForeColor = Color.Black;
                texteGagne.BackColor = Color.White;


                Image imageGagne = Properties.Resources.gagne;
                PictureBox gagner = new PictureBox();
                gagner.Location = new Point(500, 250);
                gagner.BorderStyle = BorderStyle.FixedSingle;
                gagner.Image = imageGagne;
                gagner.Size = new Size(imageGagne.Width, imageGagne.Height);

                Controls.Add(gagner);
                Controls.Add(texteGagne);
                Controls.SetChildIndex(gagner, 1);
                Controls.SetChildIndex(texteGagne, 1);
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

            foreach (var item in _imagesCartesMarchands_etape_1)
            {
                gb_etape_1.Controls.Remove(item.Value);
            }

            foreach (var item in _imagesCartesMarchands_etape_2)
            {
                gb_etape_2.Controls.Remove(item.Value);
            }

            foreach (var item in _imagesCartesMarchands_etape_3)
            {
                gb_etape_3.Controls.Remove(item.Value);
            }

            foreach (var item in _imagesCartesMarchands_etape_4)
            {
                gb_etape_4.Controls.Remove(item.Value);
            }

            foreach (var item in _labelsJoueurs_etape_1)
            {
                gb_etape_1.Controls.Remove(item.Value);
            }

            foreach (var item in _labelsJoueurs_etape_2)
            {
                gb_etape_2.Controls.Remove(item.Value);
            }

            foreach (var item in _labelsJoueurs_etape_3)
            {
                gb_etape_3.Controls.Remove(item.Value);
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
        }

        private void b_etape_Click(object sender, EventArgs e)
        {
            bool jeton = false;

            if (!gagne)
            {
                if(plateau.recuperer_piochePossible() == false)
                {
                    var mainJoueur = plateau.recuperer_mainJoueurCourant();
                    
                    foreach(var item in mainJoueur)
                    {
                        if(item.Value.afficher_nomCarte().Contains("marchand"))
                        {
                            jeton = true;
                        }
                    }
                }

                if (jeton != true || plateau.verifier_APiocherCourant() == true || plateau.verifier_aPoserUneCarteCourant() == true)
                {
                    if (plateau.recuperer_estEnTrainDattaquer() == false)
                    {
                        nettoyerPlateau();
                        plateau.charger_etapeSuivante();
                        chargementPlateau();
                    }
                }
            }

        }

        private void pb_pioche_Click(object sender, EventArgs e)
        {
            if (plateau.recuperer_piochePossible())
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

            if (plateau.verifier_APiocherCourant() == false && plateau.verifier_aPoserUneCarteCourant() == false)
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
                    plateau.poser_carte(carte);

                    gagne = plateau.verifier_gagne();

                    nettoyerPlateau();
                    chargementPlateau();
                }
            }

        }


        private void pb_carteMarchandTapis_Click(object sender, EventArgs e)
        {
            if (plateau.recuperer_estEnTrainDattaquer())
            {
                PictureBox pb = (PictureBox)sender;
                Carte marchandAttaque = plateau.recuperer_carte_parID((int)pb.Tag);
                Carte attaque = plateau.recuperer_attaquesEnCours();

                if (attaque != null)
                {
                    if (attaque.afficher_nomCarte().Contains("pirate"))
                    {
                        CartePirate attaquantPirate = (CartePirate)attaque;

                        plateau.ajouter_attaque(attaquantPirate, marchandAttaque);

                        if (plateau.verifier_attaqueValide(attaquantPirate.recuperer_couleur(), marchandAttaque.recuperer_idCarte()))
                        {
                            plateau.poser_carte(attaquantPirate);
                        }

                    }
                    else if (attaque.afficher_nomCarte().Contains("capitaine"))
                    {
                        CarteCapitaine attaquantCapitaine = (CarteCapitaine)attaque;
                        plateau.ajouter_attaque(attaquantCapitaine, marchandAttaque);

                        if (plateau.verifier_attaqueValide(attaquantCapitaine.recuperer_couleur(), marchandAttaque.recuperer_idCarte()))
                        {
                            plateau.poser_carte(attaquantCapitaine);
                        }

                    }
                    else if (attaque.afficher_nomCarte().Contains("amiral"))
                    {
                        CarteAmiral attaquantAmiral = (CarteAmiral)attaque;
                        plateau.ajouter_attaque(attaquantAmiral, marchandAttaque);

                        if (plateau.verifier_attaqueValide(attaquantAmiral.recuperer_couleur(), marchandAttaque.recuperer_idCarte()))
                        {
                            plateau.poser_carte(attaquantAmiral);
                        }

                    }
                }


                plateau.modifier_estEnTrainDattaquer(false);
                plateau.modifier_attaqueValide(false);

                var cartesTapis1 = plateau.recuperer_cartesTapis(1);
                int maitre = plateau.maitreDeLaCarte((int)pb.Tag);

                if (maitre == plateau.recuperer_etape() || maitre == -1)
                {
                    gagne = plateau.verifier_gagne();

                    if (pb.Name == "etape_2")
                    {
                        var cartesTapis2 = plateau.recuperer_cartesTapis(2);
                        var recup = cartesTapis2.First(x => x.Value.recuperer_idCarte() == (int)pb.Tag);
                        cartesTapis2.Remove(recup.Key);
                        cartesTapis1.Add(cartesTapis1.Count + 1, recup.Value);
                        plateau.modifier_cartesTapis(2, cartesTapis2);
                        plateau.modifier_cartesTapis(1, cartesTapis1);
                    }
                    else if (pb.Name == "etape_3")
                    {
                        var cartesTapis3 = plateau.recuperer_cartesTapis(3);
                        var recup = cartesTapis3.First(x => x.Value.recuperer_idCarte() == (int)pb.Tag);
                        cartesTapis3.Remove(recup.Key);
                        cartesTapis1.Add(cartesTapis1.Count + 1, recup.Value);
                        plateau.modifier_cartesTapis(3, cartesTapis3);
                        plateau.modifier_cartesTapis(1, cartesTapis1);
                    }
                    else if (pb.Name == "etape_4")
                    {
                        var cartesTapis4 = plateau.recuperer_cartesTapis(4);
                        var recup = cartesTapis4.First(x => x.Value.recuperer_idCarte() == (int)pb.Tag);
                        cartesTapis4.Remove(recup.Key);
                        cartesTapis1.Add(cartesTapis1.Count + 1, recup.Value);
                        plateau.modifier_cartesTapis(4 , cartesTapis4);
                        plateau.modifier_cartesTapis(1, cartesTapis1);
                    }
                }

                nettoyerPlateau();
                chargementPlateau();

            }

        }

    }
}
