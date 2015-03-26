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
        int _espacePopCarteHauteur = 500;
        int _tailleCarteLargeur = 92;
        int _tailleCarteHauteur = 180;
        int _décalage_max = 100;
        int _décalage_mid = 50;
        int _décalage_min = 25;
        int _décalageCarte = 0;
        Dictionary<int, PictureBox> _mainImageJoueur;

        public IHM_Plateau(Joueur j1, Joueur j2, Joueur j3, Joueur j4)
        {
            InitializeComponent();
            plateau = new Plateau(j1, j2, j3, j4);
            _mainImageJoueur = new Dictionary<int, PictureBox>();
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
                pb.Location = new System.Drawing.Point(_espacePopCarteLargeur + _décalageCarte, _espacePopCarteHauteur);
                pb.BorderStyle = BorderStyle.FixedSingle;
                pb.Click += new System.EventHandler(pb_carteMain_Click);
                pb.Image = item.getImageCarte();

                if (nbCarteMainJoueur == (i + 1))
                {
                    pb.Size = new System.Drawing.Size(_tailleCarteLargeur, _tailleCarteHauteur);
                }
                else
                {
                    if (nbCarteMainJoueur <= 6)
                    {
                        _décalageCarte += _décalage_max;
                        pb.Size = new System.Drawing.Size(_tailleCarteLargeur, _tailleCarteHauteur);
                    }
                    else if (nbCarteMainJoueur <= 11)
                    {
                        _décalageCarte += _décalage_mid;
                        pb.Size = new System.Drawing.Size(_tailleCarteLargeur - _décalage_mid + 9, _tailleCarteHauteur);
                    }
                    else
                    {
                        _décalageCarte += _décalage_min;
                        pb.Size = new System.Drawing.Size(25, _tailleCarteHauteur);
                    }

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

        public void chargementPlateau()
        {

            l_tour.Text = "Tour : " + plateau.getTour();
            l_or.Text = "Or : " + plateau.getOrJoueurCurrent();
            afficherMainJoueur();
            changeImageEtape();

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
            int nombreCartes = _mainImageJoueur.Count;

            foreach (KeyValuePair<int, PictureBox> item in _mainImageJoueur)
            {
                Controls.Remove(item.Value);
            }

            for (int i = 0; i < nombreCartes; i++)
            {
                _mainImageJoueur.Remove(i);
            }
        }

        private void b_etape_Click(object sender, EventArgs e)
        {
            this.nettoyerPlateau();
            plateau.setEtapeSuivante();
            this.chargementPlateau();
        }

        private void pb_pioche_Click(object sender, EventArgs e)
        {

            if (plateau.getVerifAPiocherCurrent() == false)
            {
                plateau.setDonnerCarteAJoueurCurrent();
                this.nettoyerPlateau();
                this.chargementPlateau();
                plateau.setAPiocherCurrent(true);
            }

        }


        private void pb_carteMain_Click(object sender, EventArgs e)
        {
            
        }

    }
}
