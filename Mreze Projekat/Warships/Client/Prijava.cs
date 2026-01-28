using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Prijava : Form
    {
        public Prijava()
        {
            InitializeComponent();
        }

        private void btnPrijava_Click(object sender, EventArgs e)
        {
            if(txtBoxIme.Text == "")
            {
                MessageBox.Show("Niste uneli ime!", "Doslo je do greske pri prijavi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string ime = txtBoxIme.Text;
                ServerSelect forma = new ServerSelect();
                forma.Ime = ime;
                forma.Show();
                this.Close();
            }
        }
    }
}
