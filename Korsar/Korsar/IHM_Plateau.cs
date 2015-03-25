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
        Dictionary<string, Bitmap> _imagesCartes = new Dictionary<string, Bitmap>();
        

        public IHM_Plateau(Joueur j1, Joueur j2, Joueur j3, Joueur j4)
        {
            InitializeComponent();
            plateau = new Plateau(j1, j2, j3, j4);
            _mainImageJoueur = new Dictionary<int, PictureBox>();
            l_joueur1.Text = plateau.afficherNomJoueur(1);
            l_joueur2.Text = plateau.afficherNomJoueur(2);
            l_joueur3.Text = plateau.afficherNomJoueur(3);
            l_joueur4.Text = plateau.afficherNomJoueur(4);

            //Rajouter toutes les cartes ressources : 
            _imagesCartes.Add("carte_amiral", Properties.Resources.carte_amiral);
            _imagesCartes.Add("carte_capitaine_bleu", Properties.Resources.carte_capitaine_bleu);
            _imagesCartes.Add("carte_capitaine_jaune", Properties.Resources.carte_capitaine_jaune);
            _imagesCartes.Add("carte_capitaine_rouge", Properties.Resources.carte_capitaine_rouge);
            _imagesCartes.Add("carte_capitaine_vert", Properties.Resources.carte_capitaine_vert);
            _imagesCartes.Add("carte_marchand_2", Properties.Resources.carte_marchand_2);
            _imagesCartes.Add("carte_marchand_3", Properties.Resources.carte_marchand_3);
            _imagesCartes.Add("carte_marchand_4", Properties.Resources.carte_marchand_4);
            _imagesCartes.Add("carte_marchand_5", Properties.Resources.carte_marchand_5);
            _imagesCartes.Add("carte_marchand_6", Properties.Resources.carte_marchand_6);
            _imagesCartes.Add("carte_marchand_7", Properties.Resources.carte_marchand_7);
            _imagesCartes.Add("carte_marchand_8", Properties.Resources.carte_marchand_8);
            _imagesCartes.Add("carte_pirate_1_bleu", Properties.Resources.carte_pirate_1_bleu);
            _imagesCartes.Add("carte_pirate_2_bleu", Properties.Resources.carte_pirate_2_bleu);
            _imagesCartes.Add("carte_pirate_3_bleu", Properties.Resources.carte_pirate_3_bleu);
            _imagesCartes.Add("carte_pirate_4_bleu", Properties.Resources.carte_pirate_4_bleu);
            _imagesCartes.Add("carte_pirate_1_jaune", Properties.Resources.carte_pirate_1_jaune);
            _imagesCartes.Add("carte_pirate_2_jaune", Properties.Resources.carte_pirate_2_jaune);
            _imagesCartes.Add("carte_pirate_3_jaune", Properties.Resources.carte_pirate_3_jaune);
            _imagesCartes.Add("carte_pirate_4_jaune", Properties.Resources.carte_pirate_4_jaune);
            _imagesCartes.Add("carte_pirate_1_rouge", Properties.Resources.carte_pirate_1_rouge);
            _imagesCartes.Add("carte_pirate_2_rouge", Properties.Resources.carte_pirate_2_rouge);
            _imagesCartes.Add("carte_pirate_3_rouge", Properties.Resources.carte_pirate_3_rouge);
            _imagesCartes.Add("carte_pirate_4_rouge", Properties.Resources.carte_pirate_4_rouge);
            _imagesCartes.Add("carte_pirate_1_vert", Properties.Resources.carte_pirate_1_vert);
            _imagesCartes.Add("carte_pirate_2_vert", Properties.Resources.carte_pirate_2_vert);
            _imagesCartes.Add("carte_pirate_3_vert", Properties.Resources.carte_pirate_3_vert);
            _imagesCartes.Add("carte_pirate_4_vert", Properties.Resources.carte_pirate_4_vert);
            _imagesCartes.Add("dos", Properties.Resources.dos);

            l_tour.Text = "Tour : " + plateau.afficherTour();

            initialisationPlateau();
            this.chargementPlateau();
        }

        public void initialisationPlateau()
        {
            Joueur jonh;

            if (plateau.getJoueurs().TryGetValue(1, out jonh))
            {
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

        public void afficherMainJoueur(int idJoueur)
        {
            Joueur jonh = new Joueur();
            Bitmap temp;
            

            if (plateau.getJoueurs().TryGetValue(idJoueur, out jonh))
            {
                int i = 0;
                foreach (KeyValuePair<int, Carte> item in jonh.getMainJoueur())
                {

                    if (_imagesCartes.TryGetValue(item.Value.afficherNomCarte(), out temp))
                    {

                        PictureBox pb = new PictureBox();
                        pb.Image = temp;
                        
                        pb.Location = new System.Drawing.Point(_espacePopCarteLargeur + _décalageCarte, _espacePopCarteHauteur);
                        pb.BorderStyle = BorderStyle.FixedSingle;

                        _mainImageJoueur.Add(i, pb);

                        if(jonh.getNombreCartesEnMain() == (i+1))
                        {
                            pb.Size = new System.Drawing.Size(_tailleCarteLargeur, _tailleCarteHauteur);
                        }
                        else
                        {
                            if (jonh.getNombreCartesEnMain() <= 6)
                            {
                                _décalageCarte += _décalage_max;
                                pb.Size = new System.Drawing.Size(_tailleCarteLargeur, _tailleCarteHauteur);
                            }
                            else if (jonh.getNombreCartesEnMain() <= 11)
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

                        i++;
                    }

                    

                }


                foreach(KeyValuePair<int, PictureBox> item in _mainImageJoueur)
                {
                    Controls.Add(item.Value);
                    Controls.SetChildIndex(item.Value, i);
                    i--;
                    
                }
                
            }
            _décalageCarte = 0;
        }

        public void chargementPlateau()
        {
            changeImageEtape();
            Joueur jonh;

            l_tour.Text = "Tour : " + plateau.afficherTour();

            if (plateau.getJoueurs().TryGetValue(plateau.getEtape(), out jonh))
            {
                l_or.Text = "Or : " + jonh.getOr();
                afficherMainJoueur(jonh.getID());
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
            int nombreCartes = _mainImageJoueur.Count;

            foreach(KeyValuePair<int, PictureBox> item in _mainImageJoueur)
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
            plateau.etapeSuivante();
            this.chargementPlateau();
        }

        private void pb_pioche_Click(object sender, EventArgs e)
        {
            plateau.donnerCarteAJoueur(plateau.getEtape());
            this.nettoyerPlateau();
            this.chargementPlateau();
        }

    }
}
