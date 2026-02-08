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
using System.Runtime.InteropServices;

namespace Server
{
    public partial class Form1 : Form
    {
        public Partija partija = new Partija();
        public int IzabranPort = 50001;
        public int tcpPort = 60001;
        public int dimezija = 0;
        public int brojIgraca = 0;
        public List<Socket> klijenti = new List<Socket>();
        public Socket serverTcp;
        List<EndPoint> prijavljeniIgraci = new List<EndPoint>();
        public int brojPromasaja = 0;

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
            dimezija = getDimenzija();
            brojPromasaja = Convert.ToInt32(numericUpDown1.Value);
            int prijavaCnt = 0;
            //Otvaranje soketa za prijavu na specifican port sa bilo koje adrese 
            Socket udpPrijava = new Socket(AddressFamily.InterNetwork, SocketType.Dgram ,ProtocolType.Udp);
            IPEndPoint serverUdpEp = new IPEndPoint(IPAddress.Any, IzabranPort);
            udpPrijava.Bind(serverUdpEp);

            #region Prijava
            //Prijava treba da bude otvorena dok se ne napuni broj igraca
            byte[] recBuffer = new byte[1024];
            //Skupljanje EP igraca 
            while (prijavaCnt < brojIgraca) {
                EndPoint EP = new IPEndPoint(IPAddress.Any, 0);
                int recivedBytes = udpPrijava.ReceiveFrom(recBuffer, ref EP);
                prijavljeniIgraci.Add(EP);
                prijavaCnt++;
            }

            #region Dobavljane host informacije
            //Slanje klientu informacije o sebi --> uspostavljanje TCP veze
            string HostInfo = Dns.GetHostName();
            IPAddress[] addresses = Dns.GetHostAddresses(HostInfo);
            IPAddress selectedAdress = null;
            foreach (IPAddress address in addresses)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    selectedAdress = address; break;
                }
            }
            if (selectedAdress == null)
            {
                MessageBox.Show($"ERROR SERVER DOESNT HAVE INTERNETNETWORK");
            }
            #endregion

            //slanje addrese i porta svakom od klijenata(udp)
            foreach (EndPoint ep in prijavljeniIgraci)
            {
                string hostInfo = selectedAdress + ":" + tcpPort + ":" + dimezija + ":" + brojPromasaja;
                byte[] response = Encoding.UTF8.GetBytes(hostInfo);
                udpPrijava.SendTo(response, ep);
            }

            //Addovanje u list klijenta, inicijalizacija partije
            prijavaCnt = 0;
            byte[] receiver = new byte[1024];
            Random rand = new Random();
            //Adovanje igraca u partiju, try je ako nista ne unesu u polje za playere
            try
            {
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

                byte[] data = new byte[4096];
                byte[] dataLength;
                //Prijavnljenim igracima saljemo partiju (udp)
                foreach (EndPoint ep in prijavljeniIgraci)
                {
                    try
                    {
                        //Pretvara partiju u bajtove i salje
                        using (MemoryStream ms = new MemoryStream())
                        {
                            BinaryFormatter bf = new BinaryFormatter();
                            bf.Serialize(ms, partija);
                            data = ms.ToArray();
                            dataLength = BitConverter.GetBytes(data.Length);
                        }
                        //Posaljem prvo duzinu da bih zano kako dalje
                        udpPrijava.SendTo(dataLength, ep);
                        udpPrijava.SendTo(data, ep);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Greska pre slanju podataka{ex}");
                    }
                }
            }
            catch (Exception ex) { 
                    
            }

            #endregion
            udpPrijava.Close();

            #region Cekaonica
            // Slanje igracima tcp, ocekuje se sada konekcija igraca
            serverTcp = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint serverTcpEp = new IPEndPoint(selectedAdress, tcpPort);
            serverTcp.Bind(serverTcpEp);
            serverTcp.Listen(brojIgraca);
            
            prijavaCnt = 0;
            string pocni = "Pocetak";
            byte[] pocniData = new byte[4096];
            //Addovanje u list klijenta 
            while (prijavaCnt < brojIgraca)
            {
                Socket clientAccepted = serverTcp.Accept();
                klijenti.Add(clientAccepted);
                prijavaCnt++;
            }
            //Slanje svakome poruku, kada dobiju poruku pocinje igra
            foreach (Socket s in klijenti) {
                pocniData = Encoding.UTF8.GetBytes(pocni);
                s.Send(pocniData);
            }
            #endregion
            pocniIgru();
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
        private void pocniIgru() {
            MessageBox.Show("Igra je zapocela!");
            //Tu onda dolazi primanje matrice + inicijalizacija
            //Plus odvijanje igre
            //Posle kraja igre se poziva funkcija igrajPonovo()
        }
        private int getDimenzija() {
            int d=0;
            try
            {
                if(DimenzijeBox.Text != "")
                {
                    string dim = DimenzijeBox.Text;
                    d = Int32.Parse(dim);
                    if (d < 6 || d > 10)
                    {
                        MessageBox.Show("Moguce dimenzije su od 6 do 10, odaberite ponovo");
                    }
                }
                else
                {
                    MessageBox.Show("Polje za dimenzije je prazno");
                }
            }
            catch (Exception e) {
                MessageBox.Show($"Greska kod fechovanja dimenzija! {e}");
            }
            return d;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void igrajPonovo() {
            List<Socket> pomocniSoketi = klijenti;
            byte[] data = new byte[4096];
            int flag = 0;
            while (0 == pomocniSoketi.Count() && flag == 0) {
                foreach (Socket s in pomocniSoketi) {
                    s.Receive(data);
                    string poruka = Encoding.UTF8.GetString(data);
                    //Taj klijent zeli da igra onda ga izbacimo iz liste
                    //Klijent kada stisne na "Play again dugme" --> posalje poruku "Igram"
                    if (string.Compare(poruka, "Igram") == 0)
                    {
                        pomocniSoketi.Remove(s);
                    }
                    //Kada klijent klikne na exit dugme
                    else if (string.Compare(poruka, "Ne Igram") == 0) {
                        flag = 1;
                        break;
                    }
                }
            }
            if (flag == 1)
            {
                //Zatvaraju se uticnice
                foreach (Socket s in klijenti)
                {
                    s.Close();
                    serverTcp.Close();
                }
            }
            else {
                pocniIgru();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string pocni = "Bombardovanje pocelo";
            byte[] pocniData = new byte[4096];
            foreach (Socket s in klijenti)
            {
                pocniData = Encoding.UTF8.GetBytes(pocni);
                s.Send(pocniData);
            }
        }
    }
}
