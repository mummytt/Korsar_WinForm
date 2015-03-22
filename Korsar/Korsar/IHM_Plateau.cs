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

        
        Dictionary<string, Bitmap> _imagesCartes = new Dictionary<string, Bitmap>();
        

        public IHM_Plateau(Joueur j1, Joueur j2, Joueur j3, Joueur j4)
        {
            InitializeComponent();
            plateau = new Plateau(j1, j2, j3, j4);
            
            l_joueur1.Text = plateau.afficherNomJoueur(1);
            l_joueur2.Text = plateau.afficherNomJoueur(2);
            l_joueur3.Text = plateau.afficherNomJoueur(3);
            l_joueur4.Text = plateau.afficherNomJoueur(4);

            //Rajouter toutes les cartes ressources : 
            _imagesCartes.Add("carte_marchand_2", Properties.Resources.carte_marchand_2);

            l_tour.Text = "Tour : " + plateau.afficherTour();

            initialisationPlateau();
        }

        public void initialisationPlateau()
        {
            changeImageEtape();

            Joueur jonh;

            if (plateau._Joueurs.TryGetValue(1, out jonh))
            {
                l_or.Text = "Or : " + jonh.getOr();

                plateau.donnerCarteAJoueur(1);
                plateau.donnerCarteAJoueur(1);
                plateau.donnerCarteAJoueur(1);
                plateau.donnerCarteAJoueur(1);
                plateau.donnerCarteAJoueur(1);
                plateau.donnerCarteAJoueur(1);

                plateau.donnerCarteAJoueur(2);
                plateau.donnerCarteAJoueur(2);
                plateau.donnerCarteAJoueur(2);
                plateau.donnerCarteAJoueur(2);
                plateau.donnerCarteAJoueur(2);
                plateau.donnerCarteAJoueur(2);

                plateau.donnerCarteAJoueur(3);
                plateau.donnerCarteAJoueur(3);
                plateau.donnerCarteAJoueur(3);
                plateau.donnerCarteAJoueur(3);
                plateau.donnerCarteAJoueur(3);
                plateau.donnerCarteAJoueur(3);

                plateau.donnerCarteAJoueur(4);
                plateau.donnerCarteAJoueur(4);
                plateau.donnerCarteAJoueur(4);
                plateau.donnerCarteAJoueur(4);
                plateau.donnerCarteAJoueur(4);
                plateau.donnerCarteAJoueur(4);

                
                


            }
        }

        public void ajouterCarteEcran(string nomCarte)
        {
            PictureBox pb = new PictureBox();
            
            pb.Image = Properties.Resources.;
            pb.Location = new System.Drawing.Point(_espacePopCarteLargeur, _espacePopCarteHauteur);
            pb.Size = new System.Drawing.Size(_tailleCarteLargeur, _tailleCarteHauteur);
            Controls.Add(pb);
        }

        public void ChargementPlateau()
        {
            changeImageEtape();
            Joueur jonh;

            if (plateau._Joueurs.TryGetValue(plateau.getEtape(), out jonh))
            {
                l_or.Text = "Or : " + jonh.getOr();
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

        private void b_etape_Click(object sender, EventArgs e)
        {
            plateau.etapeSuivante();
            ChargementPlateau();
        }



    }
}
