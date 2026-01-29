using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace Client
{
    public partial class ServerSelect : Form
    {
        public string Ime {  get; set; }
        public bool Server1Active { get; set; } = true;
        public bool Server2Active { get; set; }
        public bool Server3Active { get; set; }
        public bool Server4Active { get; set; }

        public int Server1Players { get; set; } = 2;
        public int Server2Players { get; set; }
        public int Server3Players { get; set; }
        public int Server4Players { get; set; }

        public ServerSelect()
        {
            InitializeComponent();
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            ///PORT
            string text = "Server 1 PORT";
            Font font = new Font("Pixelify Sans", 12, FontStyle.Bold);
            Color color = Color.FromArgb(138, 111, 48);
            PointF location = new PointF(10f, 10f);
            e.Graphics.DrawString(text, font, new SolidBrush(color), location);

            string text2 = Server1Players.ToString() + "/4";
            Font font2 = new Font("Pixelify Sans", 12, FontStyle.Bold);
            Color color2 = Color.FromArgb(138, 111, 48);
            PointF location2 = new PointF(10f, 23f);
            e.Graphics.DrawString(text2, font2, new SolidBrush(color2), location2);

            //Dodatno - ako je server aktivan
            if (Server1Active)
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.LawnGreen), 145f, 15f, 10f, 10f);
            }
            else
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.Red), 145f, 15f, 10f, 10f);
            }
        }

        private void ServerSelect_Load(object sender, EventArgs e)
        {
            lblIme.Text += Ime;
        }

        private void btnPrijava_Click(object sender, EventArgs e)
        {
            /*
              Potreban kod za prijavu na server
                    tipa if connected
                        otvori sledecu formu i zatvori ovu
                    else
                        izbaci poruku o gresci
             */

            //this.Close();
            /*Server1Active = !Server1Active;
            Server1Players++;*/
            Cekaonica forma = new Cekaonica();
            Random rng = new Random();
            int IdIgraca = rng.Next(1000, 9999);
            forma.noviIgrac = new Igrac(IdIgraca, Ime);
            forma.Show();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Prijava na taj server
        }

        private void pictureBoxServer2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxServer3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxServer4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxServer2_Paint(object sender, PaintEventArgs e)
        {
            ///PORT
            string text = "Server 2 PORT";
            Font font = new Font("Pixelify Sans", 12, FontStyle.Bold);
            Color color = Color.FromArgb(138, 111, 48);
            PointF location = new PointF(10f, 10f);

            string text2 = Server2Players.ToString() + "/4";
            Font font2 = new Font("Pixelify Sans", 12, FontStyle.Bold);
            Color color2 = Color.FromArgb(138, 111, 48);
            PointF location2 = new PointF(10f, 23f);
            e.Graphics.DrawString(text2, font2, new SolidBrush(color2), location2);

            //Dodatno - ako je server aktivan
            if (Server2Active)
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.LawnGreen), 145f, 15f, 10f, 10f);
            }
            else
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.Red), 145f, 15f, 10f, 10f);
            }

            // Draw the string
            e.Graphics.DrawString(text, font, new SolidBrush(color), location);
        }

        private void pictureBoxServer3_Paint(object sender, PaintEventArgs e)
        {
            ///PORT
            string text = "Server 3 PORT";
            Font font = new Font("Pixelify Sans", 12, FontStyle.Bold);
            Color color = Color.FromArgb(138, 111, 48);
            PointF location = new PointF(10f, 10f);

            string text2 = Server3Players.ToString() + "/4";
            Font font2 = new Font("Pixelify Sans", 12, FontStyle.Bold);
            Color color2 = Color.FromArgb(138, 111, 48);
            PointF location2 = new PointF(10f, 23f);
            e.Graphics.DrawString(text2, font2, new SolidBrush(color2), location2);

            //Dodatno - ako je server aktivan
            if (Server3Active)
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.LawnGreen), 145f, 15f, 10f, 10f);
            }
            else
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.Red), 145f, 15f, 10f, 10f);
            }

            // Draw the string
            e.Graphics.DrawString(text, font, new SolidBrush(color), location);
        }

        private void pictureBoxServer4_Paint(object sender, PaintEventArgs e)
        {
            ///PORT
            string text = "Server 4 PORT";
            Font font = new Font("Pixelify Sans", 12, FontStyle.Bold);
            Color color = Color.FromArgb(138, 111, 48);
            PointF location = new PointF(10f, 10f);

            string text2 = Server4Players.ToString() + "/4";
            Font font2 = new Font("Pixelify Sans", 12, FontStyle.Bold);
            Color color2 = Color.FromArgb(138, 111, 48);
            PointF location2 = new PointF(10f, 23f);
            e.Graphics.DrawString(text2, font2, new SolidBrush(color2), location2);

            //Dodatno - ako je server aktivan
            if (Server4Active)
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.LawnGreen), 145f, 15f, 10f, 10f);
            }
            else
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.Red), 145f, 15f, 10f, 10f);
            }

            // Draw the string
            e.Graphics.DrawString(text, font, new SolidBrush(color), location);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
