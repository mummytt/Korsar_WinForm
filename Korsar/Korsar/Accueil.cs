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
    public partial class Accueil : Form
    {
        public Accueil()
        {
            InitializeComponent();
        }

        private void b_jouer_Click(object sender, EventArgs e)
        {
            Inscription f2 = new Inscription();
            this.Hide();
            f2.ShowDialog();
            this.Show();

            
        }
    }
}
