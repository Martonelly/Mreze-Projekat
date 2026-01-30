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

namespace Server
{
    public partial class Form1 : Form
    {
        public Partija partija = new Partija();
        public int IzabranPort = 50001;
        public int tcpPort = 60001;
        public int brojIgraca = 0;
        public List<Socket> klijenti = new List<Socket>();
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
            List<EndPoint> prijavljeniIgraci = new List<EndPoint>();
            byte[] recBuffer = new byte[1024];
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
            foreach (IPAddress address in addresses) {
                if (address.AddressFamily == AddressFamily.InterNetwork) { 
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
                string hostInfo = selectedAdress + ":" + tcpPort;
                byte[] response = Encoding.UTF8.GetBytes(hostInfo);
                udpPrijava.SendTo(response, ep);
            }
            

            //Slanje igracima tcp, ocekuje se sada konekcija igraca
            Socket serverTcp = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint serverTcpEp = new IPEndPoint(selectedAdress, tcpPort);
            serverTcp.Bind(serverTcpEp);
            serverTcp.Listen(brojIgraca);
            //Ovo za blocking moram jos da proucim 
            //serverTcp.Blocking = false;
            

            //Addovanje u list klijenta 
            prijavaCnt = 0;
            while (prijavaCnt < brojIgraca)
            {
                Socket clientAccepted = serverTcp.Accept();
                IPEndPoint klijentEP = clientAccepted.RemoteEndPoint as IPEndPoint;
                MessageBox.Show($"Prijavoi se klijent sa: {klijentEP}");
                klijenti.Add(clientAccepted);
                prijavaCnt++;
            }

            serverTcp.Close();
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
            if (brojIgraca < klijenti.Count()) {
                MessageBox.Show("Nema dovoljno igraca za pratiju!");
            }
            #region Pocetak igre plus punjenje pratije
            string pocetak = "Pocni";
            byte[] data = new byte[1024];
            data = Encoding.UTF8.GetBytes(pocetak);
            //Oni su sa ovim lockom radili iskreno ne znam sto al ajde i ja cu ovako 
            List<Socket> snapshot;
            lock (_lock) snapshot = new List<Socket>(klijenti);
            for (int i = 0; i < snapshot.Count; i++) { 
                Socket s = snapshot[i];
                try {
                    s.Send(data);
                }
                catch (Exception ex) {
                    MessageBox.Show($"Greska pre inicijalizacije igre{ex}");
                }
            }

            //Mozda tu ubacim load svega sto mi klijenti pisu o svojim imenom itd
            //Uradim neku listu igraca --> prosledim nazad kod klijenta on to otpakuje pa napravi po tome sebi form
            
            for (int i = 0; i < snapshot.Count; i++)
            {
                Socket s = snapshot[i];
                try
                {
                    s.Receive(data);
                    string poruka = Encoding.UTF8.GetString(data);
                    string ime = poruka;
                    int idIgraca = (s.RemoteEndPoint as IPEndPoint).Port;
                    Igrac igrac = new Igrac(idIgraca, ime);
                    partija.Igraci.Add(igrac);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Greska pre inicijalizacije igre{ex}");
                }
            }
            #endregion
            //Posle ovoga bi trebali da imamo u partiji igrace sa imenom plus sa id u obliku porta 
            posaljiKlijentuIgrace();
            //Ovo ce da-->hvata klijentove Pocetno pozicije
            inicijalizacija();

        }
        private void posaljiKlijentuIgrace(){
            List<Socket> snapshot;
            lock (_lock) snapshot = new List<Socket>(klijenti);
            byte[] data = new byte[4096];
            byte[] dataLength;
            for (int i = 0; i < snapshot.Count; i++)
            {
                Socket s = snapshot[i];
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
                    s.Send(dataLength);
                    s.Send(data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Greska pre slanju podataka{ex}");
                }
            }
        }
        private void inicijalizacija(){

            int postavljnaPolja = 0;
            //while (postavljnaPolja < klijenti.Count()) { 
                
            //}
        }
    }
}
