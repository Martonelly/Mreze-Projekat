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
using System.Net;
using System.Net.Sockets;

namespace Client
{
    public partial class Cekaonica : Form
    {
        public Partija partija = new Partija();
        public int Dimenzija { get; set; } = 10;

        public Socket clientSocket;
        public string ServerPort { get; set; } = "PORT 1";
        //Moj deo mozda je los
        //public Socket client
        public IPAddress tcpAddress { get; set; }
        public int tcpPort { get; set; }

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
        }

        private void player1_Paint(object sender, PaintEventArgs e)
        {
            if (partija.Igraci[0].KorisnickoIme != "")
            {
                string text = partija.Igraci[0].KorisnickoIme;
                Font font = new Font("Pixelify Sans", 12, FontStyle.Bold);
                Color color = Color.FromArgb(138, 111, 48);
                PointF location = new PointF(8f, 10f);
                e.Graphics.DrawString(text, font, new SolidBrush(color), location);
            }
            else
            {
                player1.Hide();
            }
        }

        private void player2_Paint(object sender, PaintEventArgs e)
        {
            if (partija.Igraci.Count < 2)
            {
                player2.Hide();
                
            }
            else
            {
                string text = partija.Igraci[1].KorisnickoIme;
                Font font = new Font("Pixelify Sans", 12, FontStyle.Bold);
                Color color = Color.FromArgb(138, 111, 48);
                PointF location = new PointF(8f, 10f);
                e.Graphics.DrawString(text, font, new SolidBrush(color), location);
            }
        }

        private void player3_Paint(object sender, PaintEventArgs e)
        {
            if (partija.Igraci.Count < 3)
            {
                player3.Hide();
            }
            else
            {
                string text = partija.Igraci[2].KorisnickoIme;
                Font font = new Font("Pixelify Sans", 12, FontStyle.Bold);
                Color color = Color.FromArgb(138, 111, 48);
                PointF location = new PointF(8f, 10f);
                e.Graphics.DrawString(text, font, new SolidBrush(color), location);

            }
        }

        private void player4_Paint(object sender, PaintEventArgs e)
        {
            if (partija.Igraci.Count < 4)
            {
                player4.Hide();
            }
            else
            {
                string text = partija.Igraci[3].KorisnickoIme;
                Font font = new Font("Pixelify Sans", 12, FontStyle.Bold);
                Color color = Color.FromArgb(138, 111, 48);
                PointF location = new PointF(8f, 10f);
                e.Graphics.DrawString(text, font, new SolidBrush(color), location);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint tcpEP = new IPEndPoint(tcpAddress, tcpPort);
            clientSocket.Connect(tcpEP);
            byte[] data = new byte[1024];
            string poruka = "";
            //Pocetak igre ako server salje "Pocetak"
            while (true) {
                clientSocket.Receive(data);
                poruka = Encoding.UTF8.GetString(data);
                if (string.Compare(poruka, "Pocetak") == 0) {
                    IgraUToku forma = new IgraUToku();
                    forma.Dimenzija = Dimenzija;
                    forma.clientSocket = clientSocket;
                    forma.Show();
                    this.Close();
                    break;
                }
            }
            
        }
    }
}
