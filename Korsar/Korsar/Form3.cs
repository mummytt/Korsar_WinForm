using System;
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
    public partial class Form3 : Form
    {
        Joueur joueur1, joueur2, joueur3, joueur4;

        public Form3(Joueur j1, Joueur j2, Joueur j3, Joueur j4)
        {
            InitializeComponent();

            joueur1 = j1;
            joueur2 = j2;
            joueur3 = j3;
            joueur4 = j4;

            l_joueur1.Text = joueur1.Nom;
            l_joueur2.Text = joueur2.Nom;
            l_joueur3.Text = joueur3.Nom;
            l_joueur4.Text = joueur4.Nom;
        }
    }
}
