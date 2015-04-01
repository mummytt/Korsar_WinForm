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
        int _espacePopCarteLargeur = 200;
        int _espacePopCarteHauteur = 650;
        int _tailleCarteLargeur = 92;
        int _tailleCarteHauteur = 135;
        int _tailleCarteLargeurMin = 28;
        int _décalage_max = 100;
        int _décalage_min = 40;
        int _décalageCarte = 0;
        int _décalageCarteTapis = 0;
        int _décalageCarteTapisBas = 0;

        Dictionary<int, PictureBox> _mainImageJoueur;
        Dictionary<int, PictureBox> _imagesCartesMarchands_etape_1;
        Dictionary<int, PictureBox> _imagesCartesMarchands_etape_2;
        Dictionary<int, PictureBox> _imagesCartesMarchands_etape_3;
        Dictionary<int, PictureBox> _imagesCartesMarchands_etape_4;

        Dictionary<int, Label> _tapisLabelJoueur_etape_1;
        Dictionary<int, Label> _tapisLabelJoueur_etape_2;
        Dictionary<int, Label> _tapisLabelJoueur_etape_3;
        Dictionary<int, Label> _tapisLabelJoueur_etape_4;

        Dictionary<int, Label> _tapisLabelAttaques_etape_1;
        Dictionary<int, Label> _tapisLabelAttaques_etape_2;
        Dictionary<int, Label> _tapisLabelAttaques_etape_3;
        Dictionary<int, Label> _tapisLabelAttaques_etape_4;

        public IHM_Plateau(Joueur j1, Joueur j2, Joueur j3, Joueur j4)
        {
            InitializeComponent();
            plateau = new Plateau(j1, j2, j3, j4);
            _mainImageJoueur = new Dictionary<int, PictureBox>();

            _imagesCartesMarchands_etape_1 = new Dictionary<int, PictureBox>();
            _imagesCartesMarchands_etape_2 = new Dictionary<int, PictureBox>();
            _imagesCartesMarchands_etape_3 = new Dictionary<int, PictureBox>();
            _imagesCartesMarchands_etape_4 = new Dictionary<int, PictureBox>();

            _tapisLabelJoueur_etape_1 = new Dictionary<int, Label>();
            _tapisLabelJoueur_etape_2 = new Dictionary<int, Label>();
            _tapisLabelJoueur_etape_3 = new Dictionary<int, Label>();
            _tapisLabelJoueur_etape_4 = new Dictionary<int, Label>();

            _tapisLabelAttaques_etape_1 = new Dictionary<int, Label>();
            _tapisLabelAttaques_etape_2 = new Dictionary<int, Label>();
            _tapisLabelAttaques_etape_3 = new Dictionary<int, Label>();
            _tapisLabelAttaques_etape_4 = new Dictionary<int, Label>();

            l_joueur1.Text = plateau.getNomJoueur(1);
            l_joueur2.Text = plateau.getNomJoueur(2);
            l_joueur3.Text = plateau.getNomJoueur(3);
            l_joueur4.Text = plateau.getNomJoueur(4);

            initialisationPlateau();
            this.chargementPlateau();
        }

        public void initialisationPlateau()
        {
            plateau.setDonnerCarteAJoueur(1);
            plateau.setDonnerCarteAJoueur(1);
            plateau.setDonnerCarteAJoueur(1);
            plateau.setDonnerCarteAJoueur(1);
            plateau.setDonnerCarteAJoueur(1);
            plateau.setDonnerCarteAJoueur(1);

            plateau.setDonnerCarteAJoueur(2);
            plateau.setDonnerCarteAJoueur(2);
            plateau.setDonnerCarteAJoueur(2);
            plateau.setDonnerCarteAJoueur(2);
            plateau.setDonnerCarteAJoueur(2);
            plateau.setDonnerCarteAJoueur(2);

            plateau.setDonnerCarteAJoueur(3);
            plateau.setDonnerCarteAJoueur(3);
            plateau.setDonnerCarteAJoueur(3);
            plateau.setDonnerCarteAJoueur(3);
            plateau.setDonnerCarteAJoueur(3);
            plateau.setDonnerCarteAJoueur(3);

            plateau.setDonnerCarteAJoueur(4);
            plateau.setDonnerCarteAJoueur(4);
            plateau.setDonnerCarteAJoueur(4);
            plateau.setDonnerCarteAJoueur(4);
            plateau.setDonnerCarteAJoueur(4);
            plateau.setDonnerCarteAJoueur(4);
        }

        public void afficherMainJoueur()
        {
            Dictionary<int, Carte> cartes = plateau.getMainJoueurCurrent();
            int nbCarteMainJoueur = plateau.getNbCartesMainJoueurCurrent();
            int i = 0;

            foreach (Carte item in cartes.Values)
            {
                PictureBox pb = new PictureBox();
                pb.Location = new Point(_espacePopCarteLargeur + _décalageCarte, _espacePopCarteHauteur);
                pb.BorderStyle = BorderStyle.FixedSingle;
                pb.Tag = item.getIdCarte();
                pb.Click += new System.EventHandler(pb_carteMain_Click);

                if (nbCarteMainJoueur <= 9)
                {
                    pb.Image = item.getImageCarte();
                    _décalageCarte += _décalage_max;
                    pb.Size = new Size(_tailleCarteLargeur, _tailleCarteHauteur);
                }
                else
                {
                    pb.Image = item.getImageMinCarte();
                    _décalageCarte += _décalage_min;
                    pb.Size = new Size(_tailleCarteLargeurMin, _tailleCarteHauteur);
                }

                _mainImageJoueur.Add(i, pb);

                i++;
            }


            foreach (KeyValuePair<int, PictureBox> item in _mainImageJoueur)
            {
                Controls.Add(item.Value);
            }

            _décalageCarte = 0;
        }


        public void afficherTapis()
        {

            for (int i = 1; i <= 4; i++)
            {
                Dictionary<int, Carte> cartesTapis = plateau.getCartesTapis(i);
                Label[] lAttaque = new Label[4];
                int x = 0;
                _décalageCarteTapis = 0;

                foreach (var carte in cartesTapis)
                {

                    //MARCHAND
                    PictureBox pb = new PictureBox();
                    pb.BorderStyle = BorderStyle.FixedSingle;
                    pb.Tag = carte.Value.getIdCarte();
                    pb.Image = carte.Value.getImageMinCarte();
                    pb.Size = new Size(_tailleCarteLargeurMin, _tailleCarteHauteur);
                    pb.Click += new System.EventHandler(pb_carteMarchandTapis_Click);

                    Label labelJoueur = new Label();
                    labelJoueur.Text = plateau.getLabelJoueurCarteTapis(carte.Value.getIdCarte());
                    labelJoueur.Size = new Size(labelJoueur.Text.Length * 6 + 5, 13);

                    if (x >= 3)
                    {
                        pb.Location = new Point(_décalage_min + _décalageCarteTapisBas, 100 + _tailleCarteHauteur);
                        labelJoueur.Location = new Point(_décalage_min + _décalageCarteTapisBas, 80 + _tailleCarteHauteur);
                        _décalageCarteTapisBas += 2 * _décalage_min;
                    }
                    else
                    {
                        pb.Location = new Point(_décalage_min + _décalageCarteTapis, 50);
                        labelJoueur.Location = new Point(_décalage_min + _décalageCarteTapis, 30);
                        _décalageCarteTapis += 2 * _décalage_min;
                    }

                    x++;


                    //ATTAQUES

                    
                    
                    var attaquesJoueurs = plateau.getAttaquesJoueursCarte(carte.Value.getIdCarte());

                    if(attaquesJoueurs != null)
                    {
                        int j = 0;
                        foreach (var attaque in attaquesJoueurs)
                        {

                            if(attaque.Value != 0)
                            {
                                string couleur = plateau.getCouleurAttaquesJoueursCarte(carte.Value.getIdCarte(), attaque.Key);

                                if (couleur != "")
                                {

                                    lAttaque[j] = new Label();
                                    lAttaque[j].Text = attaque.Value.ToString();
                                    lAttaque[j].Size = new Size(29, 29);
                                    lAttaque[j].Padding = new Padding(8);

                                    if (attaque.Key == 1)
                                    {
                                        lAttaque[j].Location = new Point(pb.Location.X - _tailleCarteLargeurMin, 50);
                                    }
                                    else if (attaque.Key == 2)
                                    {
                                        lAttaque[j].Location = new Point(pb.Location.X + _tailleCarteLargeurMin, 50);
                                    }
                                    else if (attaque.Key == 3)
                                    {
                                        lAttaque[j].Location = new Point(pb.Location.X + _tailleCarteLargeurMin, _tailleCarteHauteur + 21);
                                    }
                                    else if (attaque.Key == 4)
                                    {
                                        lAttaque[j].Location = new Point(pb.Location.X - _tailleCarteLargeurMin, _tailleCarteHauteur + 21);
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

                    

                    //MARCHAND
                    if (i == 1)
                    {
                        pb.Name = "etape_1";
                        _imagesCartesMarchands_etape_1.Add(carte.Key, pb);
                        _tapisLabelJoueur_etape_1.Add(carte.Value.getIdCarte(), labelJoueur);

                        foreach(var item in lAttaque)
                        {
                            _tapisLabelAttaques_etape_1.Add(_tapisLabelAttaques_etape_1.Count + 1, item);
                        }
                        
                        
                    }
                    else if (i == 2)
                    {
                        pb.Name = "etape_2";
                        _imagesCartesMarchands_etape_2.Add(carte.Key, pb);
                        _tapisLabelJoueur_etape_2.Add(carte.Value.getIdCarte(), labelJoueur);

                        foreach (var item in lAttaque)
                        {
                            _tapisLabelAttaques_etape_2.Add(_tapisLabelAttaques_etape_2.Count + 1, item);
                        }
                    }
                    else if (i == 3)
                    {
                        pb.Name = "etape_3";
                        _imagesCartesMarchands_etape_3.Add(carte.Key, pb);
                        _tapisLabelJoueur_etape_3.Add(carte.Value.getIdCarte(), labelJoueur);

                        foreach (var item in lAttaque)
                        {
                            _tapisLabelAttaques_etape_3.Add(_tapisLabelAttaques_etape_3.Count + 1, item);
                        }
                    }
                    else
                    {
                        pb.Name = "etape_4";
                        _imagesCartesMarchands_etape_4.Add(carte.Key, pb);
                        _tapisLabelJoueur_etape_4.Add(carte.Value.getIdCarte(), labelJoueur);

                        foreach (var item in lAttaque)
                        {
                            _tapisLabelAttaques_etape_4.Add(_tapisLabelAttaques_etape_4.Count + 1, item);
                        }
                    }
                    

                }
               

                if (i == 1)
                {
                    foreach (var item in _imagesCartesMarchands_etape_1)
                    {
                        gb_etape_1.Controls.Add(item.Value);
                    }

                    foreach (var item in _tapisLabelJoueur_etape_1)
                    {
                        gb_etape_1.Controls.Add(item.Value);
                    }

                    foreach (var item in _tapisLabelAttaques_etape_1)
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

                    foreach (var item in _tapisLabelJoueur_etape_2)
                    {
                        gb_etape_2.Controls.Add(item.Value);
                    }

                    foreach (var item in _tapisLabelAttaques_etape_2)
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

                    foreach (var item in _tapisLabelJoueur_etape_3)
                    {
                        gb_etape_3.Controls.Add(item.Value);
                    }

                    foreach (var item in _tapisLabelAttaques_etape_3)
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

                    foreach (var item in _tapisLabelJoueur_etape_4)
                    {
                        gb_etape_4.Controls.Add(item.Value);
                    }

                    foreach (var item in _tapisLabelAttaques_etape_4)
                    {
                        gb_etape_4.Controls.Add(item.Value);
                    }
                }
            }
        }

        public void chargementPlateau()
        {
            l_tour.Text = "Tour : " + plateau.getTour();
            l_or.Text = "Or : " + plateau.getJoueurCurrent().getOr();
            afficherTapis();
            afficherMainJoueur();
            changeImageEtape();

            if (!plateau.getPeutPiocher_Pioche())
            {
                pb_pioche.Image = null;
            }

        }


        public void changeImageEtape()
        {
            int etape = plateau.getEtape();

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

            foreach (var item in _tapisLabelJoueur_etape_1)
            {
                gb_etape_1.Controls.Remove(item.Value);
            }

            foreach (var item in _imagesCartesMarchands_etape_2)
            {
                gb_etape_2.Controls.Remove(item.Value);
            }

            foreach (var item in _tapisLabelJoueur_etape_2)
            {
                gb_etape_2.Controls.Remove(item.Value);
            }

            foreach (var item in _imagesCartesMarchands_etape_3)
            {
                gb_etape_3.Controls.Remove(item.Value);
            }

            foreach (var item in _tapisLabelJoueur_etape_3)
            {
                gb_etape_3.Controls.Remove(item.Value);
            }

            foreach (var item in _imagesCartesMarchands_etape_4)
            {
                gb_etape_4.Controls.Remove(item.Value);
            }

            foreach (var item in _tapisLabelJoueur_etape_4)
            {
                gb_etape_4.Controls.Remove(item.Value);
            }

            foreach (var item in _tapisLabelAttaques_etape_1)
            {
                gb_etape_1.Controls.Remove(item.Value);
            }

            foreach (var item in _tapisLabelAttaques_etape_2)
            {
                gb_etape_2.Controls.Remove(item.Value);
            }

            foreach (var item in _tapisLabelAttaques_etape_3)
            {
                gb_etape_3.Controls.Remove(item.Value);
            }

            foreach (var item in _tapisLabelAttaques_etape_4)
            {
                gb_etape_4.Controls.Remove(item.Value);
            }

            

            _imagesCartesMarchands_etape_1 = new Dictionary<int, PictureBox>();
            _imagesCartesMarchands_etape_2 = new Dictionary<int, PictureBox>();
            _imagesCartesMarchands_etape_3 = new Dictionary<int, PictureBox>();
            _imagesCartesMarchands_etape_4 = new Dictionary<int, PictureBox>();

            _tapisLabelJoueur_etape_1 = new Dictionary<int, Label>();
            _tapisLabelJoueur_etape_2 = new Dictionary<int, Label>();
            _tapisLabelJoueur_etape_3 = new Dictionary<int, Label>();
            _tapisLabelJoueur_etape_4 = new Dictionary<int, Label>();

            _tapisLabelAttaques_etape_1 = new Dictionary<int, Label>();
            _tapisLabelAttaques_etape_2 = new Dictionary<int, Label>();
            _tapisLabelAttaques_etape_3 = new Dictionary<int, Label>();
            _tapisLabelAttaques_etape_4 = new Dictionary<int, Label>();
        }

        private void b_etape_Click(object sender, EventArgs e)
        {
            if (plateau.getVerifAPiocherCurrent() == true || plateau.getVerifAPoserUneCarteCurrent() == true)
            {
                if(plateau.getEstEnTrainDattaquer() == false)
                {
                    nettoyerPlateau();
                    plateau.setEtapeSuivante();
                    chargementPlateau();
                }
            }
           
        }
        
        private void pb_pioche_Click(object sender, EventArgs e)
        {
            if(plateau.getPeutPiocher_Pioche())
            {
                if (plateau.getVerifAPiocherCurrent() == false && plateau.getVerifAPoserUneCarteCurrent() == false)
                {
                    plateau.setDonnerCarteAJoueurCurrent();
                    this.nettoyerPlateau();
                    this.chargementPlateau();
                    plateau.setJoueurCurrentAPiocher(true);
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
                    carte = plateau.getCarteByID(idCarte);
                }

                if (carte != null)
                {
                    if (plateau.getVerifAPiocherCurrent() == false && plateau.getVerifAPoserUneCarteCurrent() == false)
                    {
                        plateau.poserUneCarte(carte);
                        nettoyerPlateau();
                        chargementPlateau();
                    }
                }
            }
        }


        private void pb_carteMarchandTapis_Click(object sender, EventArgs e)
        {
            if(plateau.getEstEnTrainDattaquer())
            {
                PictureBox pb = (PictureBox)sender;
                Carte marchandAttaque = plateau.getCarteByID((int)pb.Tag);
                CartePirate attaquant = (CartePirate)plateau.getPirateEnCours();

                plateau.ajoutAttaque(attaquant, marchandAttaque);

                if(plateau.verifAttaqueValide(attaquant.getCouleur(), marchandAttaque.getIdCarte()))
                {
                    plateau.setEstEnTrainDattaquer(false);
                    plateau.poserUneCarte(attaquant);
                    plateau.setAttaqueValide(false);

                    var mainJoueur_1 = plateau.getCartesTapis(1);
                    int maitre = plateau.maitreDeLaCarte((int)pb.Tag);

                    string noms = plateau.getNomsEgalite(marchandAttaque.getIdCarte());

                    if (maitre == plateau.getEtape() || noms.Contains(plateau.getNomJoueurCurrent()) == true)
                    {
                        if (pb.Name == "etape_2")
                        {
                            var mainJoueur_2 = plateau.getCartesTapis(2);
                            var recup = mainJoueur_2.First(x => x.Value.getIdCarte() == (int)pb.Tag);
                            mainJoueur_2.Remove(recup.Key);
                            mainJoueur_1.Add(recup.Key, recup.Value);
                            plateau.setCartesTapis(2, mainJoueur_2);
                            plateau.setCartesTapis(1, mainJoueur_1);

                        }
                        else if (pb.Name == "etape_3")
                        {
                            var mainJoueur_3 = plateau.getCartesTapis(3);
                            var recup = mainJoueur_3.First(x => x.Value.getIdCarte() == (int)pb.Tag);
                            mainJoueur_3.Remove(recup.Key);
                            mainJoueur_1.Add(recup.Key, recup.Value);
                            plateau.setCartesTapis(3, mainJoueur_3);
                            plateau.setCartesTapis(1, mainJoueur_1);
                        }
                        else if (pb.Name == "etape_4")
                        {
                            var mainJoueur_4 = plateau.getCartesTapis(4);
                            var recup = mainJoueur_4.First(x => x.Value.getIdCarte() == (int)pb.Tag);
                            mainJoueur_4.Remove(recup.Key);
                            mainJoueur_1.Add(recup.Key, recup.Value);
                            plateau.setCartesTapis(4, mainJoueur_4);
                            plateau.setCartesTapis(1, mainJoueur_1);
                        }
                    }

                    nettoyerPlateau();
                    chargementPlateau();
                }
                else
                {
                    plateau.setAttaqueInvalide();
                }



                
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                Console.WriteLine(plateau.getCouleurAttaquesJoueursCarte(marchandAttaque.getIdCarte(), plateau.getEtape()));
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                
            }
            
        }

    }
}
