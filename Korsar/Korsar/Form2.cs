﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Korsar
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool jeton = false;

            Joueur j1 = new Joueur();
            Joueur j2 = new Joueur();
            Joueur j3 = new Joueur();
            Joueur j4 = new Joueur();


            string nj1 = tb_joueur1.Text;
            string nj2 = tb_joueur2.Text;
            string nj3 = tb_joueur3.Text;
            string nj4 = tb_joueur4.Text;

            string error = "Le nom dépasse 20 carac";

            if(!j1.verifNomJoueur(nj1))
            {
                l_error1.Text = error;
                jeton = true;
            }
            else
            {
                l_error1.Text = "";
            }
            
            if (!j2.verifNomJoueur(nj2))
            {
                l_error2.Text = error;
                jeton = true;
            }
            else
            {
                l_error2.Text = "";
            }
                
            if (!j3.verifNomJoueur(nj3))
            {
                l_error3.Text = error;
            }
            else
            {
                l_error3.Text = "";
            }
                
            if (!j4.verifNomJoueur(nj4))
            {
                l_error4.Text = error;
                jeton = true;
            }
            else
            {
                l_error4.Text = "";
            }
                

            if(!jeton)
            {
                Form3 f3 = new Form3(j1, j2, j3, j4);
                this.Hide();
                f3.ShowDialog();
                this.Show();
            }
        }
           

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
