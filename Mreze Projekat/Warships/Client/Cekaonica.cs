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
    public partial class Cekaonica : Form
    {
        public List<Igrac> igraci = new List<Igrac>();
        public int Dimenzija { get; set; } = 10;
        public string ServerPort { get; set; } = "PORT 1";

        public Igrac noviIgrac = new Igrac();
        public Cekaonica()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void Cekaonica_Load(object sender, EventArgs e)
        {
            lblMatrica.Text += Dimenzija.ToString() + "x" + Dimenzija.ToString();
            lblServer.Text += ServerPort;
            for(int i = 0; i < 4; i++)
            {
                igraci.Add(new Igrac());
            }
            igraci[0] = noviIgrac;
        }

        private void player1_Paint(object sender, PaintEventArgs e)
        {
            if (igraci[0].KorisnickoIme != "")
            {
                string text = igraci[0].KorisnickoIme;
                Font font = new Font("Pixelify Sans", 12, FontStyle.Bold);
                Color color = Color.FromArgb(138, 111, 48);
                PointF location = new PointF(8f, 10f);
                e.Graphics.DrawString(text, font, new SolidBrush(color), location);
            }
            else
            {
                string text = "Ceka se igrac...";
                Font font = new Font("Pixelify Sans", 12, FontStyle.Bold);
                Color color = Color.FromArgb(138, 111, 48);
                PointF location = new PointF(8f, 10f);
                e.Graphics.DrawString(text, font, new SolidBrush(color), location);
            }
        }

        private void player2_Paint(object sender, PaintEventArgs e)
        {
            if (igraci[1].KorisnickoIme != "")
            {
                string text = igraci[1].KorisnickoIme;
                Font font = new Font("Pixelify Sans", 12, FontStyle.Bold);
                Color color = Color.FromArgb(138, 111, 48);
                PointF location = new PointF(8f, 10f);
                e.Graphics.DrawString(text, font, new SolidBrush(color), location);
            }
            else
            {
                string text = "Ceka se igrac...";
                Font font = new Font("Pixelify Sans", 12, FontStyle.Bold);
                Color color = Color.FromArgb(138, 111, 48);
                PointF location = new PointF(8f, 10f);
                e.Graphics.DrawString(text, font, new SolidBrush(color), location);
            }
        }

        private void player3_Paint(object sender, PaintEventArgs e)
        {
            if (igraci[2].KorisnickoIme != "")
            {
                string text = igraci[2].KorisnickoIme;
                Font font = new Font("Pixelify Sans", 12, FontStyle.Bold);
                Color color = Color.FromArgb(138, 111, 48);
                PointF location = new PointF(8f, 10f);
                e.Graphics.DrawString(text, font, new SolidBrush(color), location);
            }
            else
            {
                string text = "Ceka se igrac...";
                Font font = new Font("Pixelify Sans", 12, FontStyle.Bold);
                Color color = Color.FromArgb(138, 111, 48);
                PointF location = new PointF(8f, 10f);
                e.Graphics.DrawString(text, font, new SolidBrush(color), location);
            }
        }

        private void player4_Paint(object sender, PaintEventArgs e)
        {
            if (igraci[3].KorisnickoIme != "")
            {
                string text = igraci[3].KorisnickoIme;
                Font font = new Font("Pixelify Sans", 12, FontStyle.Bold);
                Color color = Color.FromArgb(138, 111, 48);
                PointF location = new PointF(8f, 10f);
                e.Graphics.DrawString(text, font, new SolidBrush(color), location);
            }
            else
            {
                string text = "Ceka se igrac...";
                Font font = new Font("Pixelify Sans", 12, FontStyle.Bold);
                Color color = Color.FromArgb(138, 111, 48);
                PointF location = new PointF(8f, 10f);
                e.Graphics.DrawString(text, font, new SolidBrush(color), location);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //OVO SE BRISE, TRENUTNO SAMO ZA TEST
            IgraUToku forma = new IgraUToku();
            forma.Dimenzija = Dimenzija;
            forma.Show();
            this.Close();
        }
    }
}
