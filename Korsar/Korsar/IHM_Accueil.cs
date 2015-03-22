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
    public partial class IHM_Accueil : Form
    {
        public IHM_Accueil()
        {
            InitializeComponent();
        }

        private void b_jouer_Click(object sender, EventArgs e)
        {
            IHM_InscriptionJoueur f2 = new IHM_InscriptionJoueur();
            this.Hide();
            f2.ShowDialog();
            this.Show();

            
        }
    }
}
