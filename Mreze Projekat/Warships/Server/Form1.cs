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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Xml;
using System.Xml.Serialization;

namespace Server
{
    public partial class Form1 : Form
    {
        public Partija partija = new Partija();
        public int IzabranPort = 50001;
        public int tcpPort = 60001;
        public int brojIgraca = 0;
        public List<Socket> klijenti = new List<Socket>();
        List<EndPoint> prijavljeniIgraci = new List<EndPoint>();
        XmlSerializer serializer = new XmlSerializer(typeof(Partija));
        private readonly object _lock = new object();
        public Form1()
        {
            InitializeComponent();
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            //Mora se ako ocu da resetujem igru, mozda ne traze tacno ovo, ali mozes startovati opet igru 
            partija.Igraci.Clear();
            klijenti.Clear();
            int prijavaCnt = 0;
            //Otvaranje soketa za prijavu na specifican port sa bilo koje adrese 
            Socket udpPrijava = new Socket(AddressFamily.InterNetwork, SocketType.Dgram ,ProtocolType.Udp);
            IPEndPoint serverUdpEp = new IPEndPoint(IPAddress.Any, IzabranPort);
            udpPrijava.Bind(serverUdpEp);

            //Prijava treba da bude otvorena dok se ne napuni broj igraca
            //Recive byte gde prima poruke od strane igraca-->"PRIJAVA"
            //Skupljanje EP igraca 
            byte[] recBuffer = new byte[1024];
            while (prijavaCnt < brojIgraca) {
                EndPoint EP = new IPEndPoint(IPAddress.Any, 0);
                int recivedBytes = udpPrijava.ReceiveFrom(recBuffer, ref EP);
                prijavljeniIgraci.Add(EP);
                prijavaCnt++;
            }
            
            #region Dobavljane host informacije
            //Slanje klientu informacije o sebi --> uspostavljanje TCP veze
            #endregion
            //slanje addrese i porta svakom od klijenata(udp)
            foreach (EndPoint ep in prijavljeniIgraci)
            {
                string pocetak = "Pocni";
                byte[] data = new byte[1024];
                data = Encoding.UTF8.GetBytes(pocetak);
                //Oni su sa ovim lockom radili iskreno ne znam sto al ajde i ja cu ovako 
                udpPrijava.SendTo(data, ep);
            }
            //Ovo za blocking moram jos da proucim 
            //serverTcp.Blocking = false;
            

            //Addovanje u list klijenta 
            prijavaCnt = 0;
            byte[] receiver = new byte[1024];
            Random rand = new Random();
            while (true)
            {
                    EndPoint EP = prijavljeniIgraci[prijavaCnt];
                    int recivedBytes = udpPrijava.ReceiveFrom(receiver, ref EP);
                    string ime = Encoding.UTF8.GetString(receiver, 0, recivedBytes);
                    if (ime != "")
                    {
                        partija.Igraci.Add(new Igrac(rand.Next(1000, 9999), ime));
                    }
                prijavaCnt++;
                if (prijavaCnt == brojIgraca)
                    break;
            }

            foreach (EndPoint ep in prijavljeniIgraci)
            {
                using(StringWriter sw = new StringWriter())
                {
                    serializer.Serialize(sw, partija);
                    string podaci = sw.ToString();

                    byte[] data = new byte[10000];
                    data = Encoding.UTF8.GetBytes(podaci);
                    udpPrijava.SendTo(data, ep);
                }
            }

            udpPrijava.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int broj = IgracBox.SelectedIndex;
            brojIgraca = broj+1;
        }

        //Nema sanse da radim nesto fancy za dizajn to ostavljam tebi <3
        private void Form1_Load(object sender, EventArgs e)
        {
            IgracBox.Items.Add("1 Players");
            IgracBox.Items.Add("2 Players");
            IgracBox.Items.Add("3 Players");
            IgracBox.Items.Add("4 Players");
        }

        private void StartGameBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
