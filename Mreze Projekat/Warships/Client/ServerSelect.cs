using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public Socket clientSocket;
        //ObservableCollection ServerPlayers = 
        //ObservableCollection ServerActive =-

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
            //Client udp soket 
            int serverPort = 50001;
            IPAddress serverIP = IPAddress.Loopback;
            IPEndPoint serverEp = new IPEndPoint(serverIP, serverPort);
            Socket clientUdp = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            int flag = 0;
            Partija PoslataPartija = null;
            try
            {
                #region Prijava i tcp Povezanje
                //Prijava na server
                byte[] buffer = new byte[1024];
                buffer = Encoding.UTF8.GetBytes("PRIJAVA");
                clientUdp.SendTo(buffer, serverEp);
                //MessageBox.Show($"UDP prijava gotova");
                //Cekanje poslte poruke o IP i portu
                byte[] tcpBuffer = new byte[1024];
                EndPoint recEP = new IPEndPoint(IPAddress.Any, 0);
                int n = clientUdp.ReceiveFrom(tcpBuffer, ref recEP);
                string tcpInfo = Encoding.UTF8.GetString(tcpBuffer, 0, n);
                //MessageBox.Show($"Greska je sa{tcpInfo}");
                string[] sliced = tcpInfo.Split(':');

                string tcpAdress = sliced[0].Trim();
                string tcpPort = sliced[1].Trim();

                IPAddress tcpA = IPAddress.Parse(tcpAdress);
                int tcpP = Int32.Parse(tcpPort);

                //Sada mozemo tcp socket da kreiramo gde cemo povezati na posltae informacije
                 clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint tcpEP = new IPEndPoint(tcpA, tcpP);
                clientSocket.Connect(tcpEP);
                #endregion
                #region Server Pocinje sa igrom
                while (true) {
                    byte[] bufferRec = new byte[1024];
                    int recLen = clientSocket.Receive(bufferRec);
                    if (recLen == 0) {
                        MessageBox.Show("Server uspostavlja konekciju!");
                        break;
                    }
                    if (Encoding.UTF8.GetString(bufferRec, 0, recLen) == "Pocni") {
                        MessageBox.Show("Server je spreman, pocinje igra!");
                        flag = 1;
                        break;
                    }

                
                }
                #endregion
                
                //Treba poslati podatke o sebi
                #region Igrac salje serveru userName i dobije nazad podatke o ostalima
                byte[] podaciZaCekaonicu = new byte[1024];
                podaciZaCekaonicu = Encoding.UTF8.GetBytes(Ime);
                clientSocket.Send(podaciZaCekaonicu);

                
                while (true)
                {
                    //Tu nam treba funkcija da znamo kolka da bude duzina buffera 
                    byte[] bufferlen = new byte[4];
                    //Samo postavlja u bufferLen duzinu-->prva stvar sto saljem je int-->duzina zato 4
                    readLength(clientSocket, bufferlen, 4);
                    int len = BitConverter.ToInt32(bufferlen, 0);
                    byte[] bufferRec = new byte[len];
                    //U bufferu ce biti podatak o partiji po duzini od len
                    readLength(clientSocket, bufferRec, len);

                    using (MemoryStream ms = new MemoryStream(bufferRec))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        PoslataPartija = (Partija)bf.Deserialize(ms);
                    }
                    if (PoslataPartija != null) {
                        break;
                    }

                }
                //Sad bi on trebao da dobije nazad klasu ugraca sa imenima
                #endregion
                clientUdp.Close();
                clientSocket.Close();
            }
            catch (Exception ex) { 
                MessageBox.Show($"Exception je: {ex}");
            }
            if (flag==1)
            {
                MessageBox.Show($"Parija je: {PoslataPartija.ToString()}");
                Cekaonica forma = new Cekaonica();
                forma.igraci = PoslataPartija.Igraci;
                forma.Show();
                this.Close();
            }
        }

        private void readLength(Socket s, byte[] buf, int size) {
            int offset = 0;
            //U principu ocekujes neku duzinu i dok ne napunis bafer sa tom duzinom onda si u while-u
            while (offset < size) {
               int r =  s.Receive(buf, size - offset, SocketFlags.None);
                offset += r;
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Prijava na taj server
        }

        private void pictureBoxServer2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxServer_Click(object sender, EventArgs e)
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
