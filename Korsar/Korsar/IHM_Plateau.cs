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
        Dictionary<int, PictureBox> _mainImageJoueur;
        Dictionary<int, PictureBox> _tapisImage_etape_1;
        Dictionary<int, PictureBox> _tapisImage_etape_2;
        Dictionary<int, PictureBox> _tapisImage_etape_3;
        Dictionary<int, PictureBox> _tapisImage_etape_4;

        Dictionary<int, Label> _tapisLabelJoueur_etape_1;
        Dictionary<int, Label> _tapisLabelJoueur_etape_2;
        Dictionary<int, Label> _tapisLabelJoueur_etape_3;
        Dictionary<int, Label> _tapisLabelJoueur_etape_4;

        public IHM_Plateau(Joueur j1, Joueur j2, Joueur j3, Joueur j4)
        {
            InitializeComponent();
            plateau = new Plateau(j1, j2, j3, j4);
            _mainImageJoueur = new Dictionary<int, PictureBox>();
            _tapisImage_etape_1 = new Dictionary<int, PictureBox>();
            _tapisImage_etape_2 = new Dictionary<int, PictureBox>();
            _tapisImage_etape_3 = new Dictionary<int, PictureBox>();
            _tapisImage_etape_4 = new Dictionary<int, PictureBox>();
            _tapisLabelJoueur_etape_1 = new Dictionary<int, Label>();
            _tapisLabelJoueur_etape_2 = new Dictionary<int, Label>();
            _tapisLabelJoueur_etape_3 = new Dictionary<int, Label>();
            _tapisLabelJoueur_etape_4 = new Dictionary<int, Label>();

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

            for(int i = 1; i <= 4; i++)
            {
                Dictionary<int, Carte> cartesTapis = plateau.getCartesTapis(i);

                _décalageCarteTapis = 0;

                if(i == 1)
                {
                    foreach (var carte in cartesTapis)
                    {
                        PictureBox pb = new PictureBox();
                        pb.BorderStyle = BorderStyle.FixedSingle;
                        pb.Tag = carte.Value.getIdCarte();
                        pb.Image = carte.Value.getImageMinCarte();
                        pb.Size = new Size(_tailleCarteLargeurMin, _tailleCarteHauteur);
                        pb.Location = new Point(_décalage_min + _décalageCarteTapis, 50);
                        _tapisImage_etape_1.Add(carte.Key, pb);

                        Label labelJoueur = new Label();
                        labelJoueur.Text = plateau.getLabelJoueurCarteTapis(carte.Value.getIdCarte());
                        labelJoueur.Location = new Point(_décalage_min + _décalageCarteTapis, 30);
                        _tapisLabelJoueur_etape_1.Add(carte.Value.getIdCarte(), labelJoueur);

                        _décalageCarteTapis += 2 * _décalage_min;
                    }

                    foreach (var item in _tapisImage_etape_1)
                    {
                        gb_etape_1.Controls.Add(item.Value);
                    }

                    foreach (var item in _tapisLabelJoueur_etape_1)
                    {
                        gb_etape_1.Controls.Add(item.Value);
                    }

                }
                else if (i == 2)
                {
                    foreach (var carte in cartesTapis)
                    {
                        PictureBox pb = new PictureBox();
                        pb.BorderStyle = BorderStyle.FixedSingle;
                        pb.Tag = carte.Value.getIdCarte();
                        pb.Image = carte.Value.getImageMinCarte();
                        pb.Size = new Size(_tailleCarteLargeurMin, _tailleCarteHauteur);
                        pb.Location = new Point(_décalage_min + _décalageCarteTapis, 50);
                        _tapisImage_etape_2.Add(carte.Key, pb);

                        Label labelJoueur = new Label();
                        labelJoueur.Text = plateau.getLabelJoueurCarteTapis(carte.Value.getIdCarte());
                        labelJoueur.Location = new Point(_décalage_min + _décalageCarteTapis, 30);
                        _tapisLabelJoueur_etape_2.Add(carte.Key, labelJoueur);
                        _décalageCarteTapis += 2 * _décalage_min;
                    }

                    foreach (var item in _tapisImage_etape_2)
                    {
                        gb_etape_2.Controls.Add(item.Value);
                    }

                    foreach (var item in _tapisLabelJoueur_etape_2)
                    {
                        gb_etape_2.Controls.Add(item.Value);
                    }
                }
                else if (i == 3)
                {
                    foreach (var carte in cartesTapis)
                    {
                        PictureBox pb = new PictureBox();
                        pb.BorderStyle = BorderStyle.FixedSingle;
                        pb.Tag = carte.Value.getIdCarte();
                        pb.Image = carte.Value.getImageMinCarte();
                        pb.Size = new Size(_tailleCarteLargeurMin, _tailleCarteHauteur);
                        pb.Location = new Point(_décalage_min + _décalageCarteTapis, 50);
                        _tapisImage_etape_3.Add(carte.Key, pb);

                        Label labelJoueur = new Label();
                        labelJoueur.Text = plateau.getLabelJoueurCarteTapis(carte.Value.getIdCarte());
                        labelJoueur.Location = new Point(_décalage_min + _décalageCarteTapis, 30);
                        _tapisLabelJoueur_etape_3.Add(carte.Key, labelJoueur);
                        _décalageCarteTapis += 2 * _décalage_min;
                    }

                    foreach (var item in _tapisImage_etape_3)
                    {
                        gb_etape_3.Controls.Add(item.Value);
                    }

                    foreach (var item in _tapisLabelJoueur_etape_3)
                    {
                        gb_etape_3.Controls.Add(item.Value);
                    }
                }
                else
                {
                    foreach (var carte in cartesTapis)
                    {
                        PictureBox pb = new PictureBox();
                        pb.BorderStyle = BorderStyle.FixedSingle;
                        pb.Tag = carte.Value.getIdCarte();
                        pb.Image = carte.Value.getImageMinCarte();
                        pb.Size = new Size(_tailleCarteLargeurMin, _tailleCarteHauteur);
                        pb.Location = new Point(_décalage_min + _décalageCarteTapis, 50);
                        _tapisImage_etape_4.Add(carte.Key, pb);

                        Label labelJoueur = new Label();
                        labelJoueur.Text = plateau.getLabelJoueurCarteTapis(carte.Value.getIdCarte());
                        labelJoueur.Location = new Point(_décalage_min + _décalageCarteTapis, 30);
                        _tapisLabelJoueur_etape_4.Add(carte.Key, labelJoueur);
                        _décalageCarteTapis += 2 * _décalage_min;
                    }

                    foreach (var item in _tapisImage_etape_4)
                    {
                        gb_etape_4.Controls.Add(item.Value);
                    }

                    foreach (var item in _tapisLabelJoueur_etape_4)
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

            if(!plateau.getPeutPiocher())
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
            Dictionary<int, int> KeyMainImageJoueur = new Dictionary<int, int>();

            foreach (var item in _mainImageJoueur)
            {
                KeyMainImageJoueur.Add(item.Key, item.Key);
                Controls.Remove(item.Value);
            }

            foreach(var item in KeyMainImageJoueur)
            {
                _mainImageJoueur.Remove(item.Value);
            }



            Dictionary<int, int> KeyTapisImage;
            Dictionary<int, int> KeyLabelJoueur;

            KeyTapisImage = new Dictionary<int, int>();
            KeyLabelJoueur = new Dictionary<int, int>();

            foreach (var item in _tapisImage_etape_1)
            {
                KeyTapisImage.Add(item.Key, item.Key);
                gb_etape_1.Controls.Remove(item.Value);
            }

            foreach (var item in _tapisLabelJoueur_etape_1)
            {
                KeyLabelJoueur.Add(item.Key, item.Key);
                gb_etape_1.Controls.Remove(item.Value);
            }

            foreach (var item in KeyTapisImage)
            {
                _tapisImage_etape_1.Remove(item.Value);
            }

            foreach(var item in KeyLabelJoueur)
            {
                _tapisLabelJoueur_etape_1.Remove(item.Value);
            }

            KeyTapisImage = new Dictionary<int, int>();
            KeyLabelJoueur = new Dictionary<int, int>();

            foreach (var item in _tapisImage_etape_2)
            {
                KeyTapisImage.Add(item.Key, item.Key);
                gb_etape_2.Controls.Remove(item.Value);
            }

            foreach (var item in _tapisLabelJoueur_etape_2)
            {
                KeyLabelJoueur.Add(item.Key, item.Key);
                gb_etape_2.Controls.Remove(item.Value);
            }

            foreach (var item in KeyTapisImage)
            {
                _tapisImage_etape_2.Remove(item.Value);
            }

            foreach (var item in KeyLabelJoueur)
            {
                _tapisLabelJoueur_etape_2.Remove(item.Value);
            }

            KeyTapisImage = new Dictionary<int, int>();
            KeyLabelJoueur = new Dictionary<int, int>();

            foreach (var item in _tapisImage_etape_3)
            {
                KeyTapisImage.Add(item.Key, item.Key);
                gb_etape_3.Controls.Remove(item.Value);
            }

            foreach (var item in _tapisLabelJoueur_etape_3)
            {
                KeyLabelJoueur.Add(item.Key, item.Key);
                gb_etape_3.Controls.Remove(item.Value);
            }

            foreach (var item in KeyTapisImage)
            {
                _tapisImage_etape_3.Remove(item.Value);
            }

            foreach (var item in KeyLabelJoueur)
            {
                _tapisLabelJoueur_etape_3.Remove(item.Value);
            }

            KeyTapisImage = new Dictionary<int, int>();
            KeyLabelJoueur = new Dictionary<int, int>();

            foreach (var item in _tapisImage_etape_4)
            {
                KeyTapisImage.Add(item.Key, item.Key);
                gb_etape_4.Controls.Remove(item.Value);
            }

            foreach (var item in _tapisLabelJoueur_etape_4)
            {
                KeyLabelJoueur.Add(item.Key, item.Key);
                gb_etape_4.Controls.Remove(item.Value);
            }

            foreach (var item in KeyTapisImage)
            {
                _tapisImage_etape_4.Remove(item.Value);
            }

            foreach (var item in KeyLabelJoueur)
            {
                _tapisLabelJoueur_etape_4.Remove(item.Value);
            }

        }

        private void b_etape_Click(object sender, EventArgs e)
        {
            if (plateau.getVerifAPiocherCurrent() == true || plateau.getVerifAPoserUneCarteCurrent() == true)
            {
                nettoyerPlateau();
                plateau.setEtapeSuivante();
                chargementPlateau();

                //Correctif bug affichage nom
                nettoyerPlateau();
                chargementPlateau();
                
            }
           
        }
        
        private void pb_pioche_Click(object sender, EventArgs e)
        {
            if(plateau.getPeutPiocher())
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
            PictureBox pb = (PictureBox)sender;
            int idCarte = 0;
            Carte carte = null;

            if(int.TryParse(pb.Tag.ToString(), out idCarte))
            {
                carte = plateau.getCarteByID(idCarte);
            }

            if(carte != null)
            {
                if (plateau.getVerifAPiocherCurrent() == false && plateau.getVerifAPoserUneCarteCurrent() == false)
                {
                    plateau.poserUneCarte(carte);

                    nettoyerPlateau();
                    chargementPlateau();

                    //Correctif bug affichage nom
                    nettoyerPlateau();
                    chargementPlateau();
                }
            }
            
                
        }

    }
}
