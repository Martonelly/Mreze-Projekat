using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

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
        string bombardovanjeText = "";
        string porukaZaSlanje = "";
        int timerCounter = 0;
        int cekanje = 0;

        private readonly object _lock = new object();

        private CancellationTokenSource _cts;
        private Task _serverTask;

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
                clientAccepted.Blocking = false;
                lock (_lock) klijenti.Add(clientAccepted);
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
           // MessageBox.Show("Igra je zapocela!");
            serverTcp.Blocking = false;
            _cts = new CancellationTokenSource();
            _serverTask = Task.Run(() => ServerLoop(_cts.Token));
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
            while (0 != pomocniSoketi.Count() && flag == 0) {
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
                MessageBox.Show("Igra se zaustavlja");
                foreach (Socket s in klijenti)
                {
                    s.Close();
                    serverTcp.Close();
                }
            }
            else {
                cekanje = 0;
                MessageBox.Show("Igra se nastavlja");
                pocniIgru();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Samo testiranje da li dobro radi slanje poruka
            SendToClients(porukaZaSlanje);
            porukaZaSlanje = "";
            SendDataToClients();
        }
        #region TCP Logika
        private void ServerLoop(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                Socket listener = serverTcp;
                if (listener == null)
                {
                    Thread.Sleep(50);
                    continue;
                }

                List<Socket> readList = new List<Socket>();
                lock (_lock)
                {
                    readList.Add(listener);
                    readList.AddRange(klijenti);
                }

                try
                {
                    // 200ms timeout (microseconds)
                    Socket.Select(readList, null, null, 200000);
                }
                catch
                {
                    continue;
                }

                for (int i = 0; i < readList.Count; i++)
                {
                    if (token.IsCancellationRequested) break;

                    Socket s = readList[i];
                    if (s == listener)
                        AcceptClient(listener);
                    else
                        ReceiveFromClient(s);
                }
                try {
                    int aktiv_cnt=partija.Igraci.Count();
                    foreach (Igrac i in partija.Igraci) {
                        if (i.Aktivan)
                        {

                        }
                        else { 
                            aktiv_cnt--;
                        }
                    }
                    if (aktiv_cnt == 1 && cekanje ==0) {
                        cekanje = 1;
                        endGame();
                    }
                } catch{ 
                }
            }
        }

        private void AcceptClient(Socket listener)
        {
            try
            {
                Socket client = listener.Accept();
                client.Blocking = false;

                lock (_lock) klijenti.Add(client);

            }
            catch (SocketException)
            {
                // ignore (non-blocking accept race)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Accept error: " + ex.Message);
            }
        }
        private void ReceiveFromClient(Socket client)
        {
            byte[] buf = new byte[4096];

            try
            {
                // proverava da li je klijent poslao nesto
                int n = client.Receive(buf);
                if (n == 0)
                {
                    RemoveClient(client, "Disconnected");
                    return;
                }
                //ako jeste, onda se taj tekst smesta u string
                string text = Encoding.UTF8.GetString(buf, 0, n);
                Igrac primljeniPodaci;
                try
                {
                    //proverava se da li su poslati podaci, odnosno stanje matrice igraca
                    using (MemoryStream ms = new MemoryStream(buf))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        primljeniPodaci = (Igrac)bf.Deserialize(ms);
                    }
                    if (primljeniPodaci != null)
                    {
                        //ako jeste, na serveru se ispisuje poruka da je igrac poslao podatke, i azurira se njegova matrica
                        partija.AzurirajIgraca(primljeniPodaci.IdIgraca, primljeniPodaci);
                        rTBInfo.Invoke(new MethodInvoker(delegate { rTBInfo.Text += "\n" + "Igrac " + primljeniPodaci.KorisnickoIme + " je poslao svoju tablu"; }));
                    }
                }
                catch
                {
                    //Tu se proverava da li je stigla poruka za disconnect
                    if (text.Substring(0, 1) == "[")
                    {
                        //Ako jeste, onda se ispisuje odgovarajuca poruka svim igracima, i uklanja se igrac
                        rTBInfo.Invoke(new MethodInvoker(delegate { rTBInfo.Text += "\n" + text; }));
                        string[] id = text.Split(':');
                        int idIgraca = int.Parse(id[1].Trim());
                        partija.ObrisiIgraca(idIgraca);
                        porukaZaSlanje = "Igrac " + partija.PronadjiIgracaPoId(idIgraca).KorisnickoIme + " se odjavio";
                        SendToClients(porukaZaSlanje);
                        SendDataToClients();
                    }
                    else
                    {
                        //Ako nije, onda je stigla poruka o bombardovanju
                        rTBInfo.Invoke(new MethodInvoker(delegate { rTBInfo.Text += "\n" + text; }));

                        //Samo loma parsiranja poruke
                        string[] imena = text.Split('-');
                        string igrac1 = imena[0].Trim();
                        string[] imeIPolje = imena[1].Split(':');
                        string igrac21 = imeIPolje[0].Trim();
                        string igrac2 = igrac21.Substring(1, igrac21.Length - 1);
                        string polje = imeIPolje[1].Trim();
                        string prethodnaPoruka = text;
                        //Funkcija koja vraca stringove POGODIO/PROMASIO
                        string rezultat = VratiInfo(igrac1, igrac2, polje);
                        porukaZaSlanje = (text + ", " + rezultat).Trim();
                        //zatim se posalje klijentima poruka
                        SendToClients(porukaZaSlanje);

                        //Kao azuriranje igraca, i slanje povratnih informacija, mada, ne radi
                        Igrac i = partija.PronadjiIgracaPoImenu(igrac1);
                        if (i.BrojPromasaja == brojPromasaja)
                        {
                            i.Aktivan = false;
                            partija.AzurirajIgraca(i.IdIgraca, i);
                            porukaZaSlanje = "Igrac " + i.KorisnickoIme + " je ispao, promasio je " + brojPromasaja + " puta!";
                            SendToClients("Igrac " + i.KorisnickoIme + " je ispao, promasio je " + brojPromasaja + " puta!");
                        }

                        //isto tako, samo provere da li nesto dodatno treba da se radi
                        Igrac i2 = partija.PronadjiIgracaPoImenu(igrac2);
                        if (i2.SumirajBrodove() == 0)
                        {
                            i2.Aktivan = false;
                            partija.AzurirajIgraca(i2.IdIgraca, i2);
                            porukaZaSlanje = "Igrac " + i2.KorisnickoIme + " je ispao!";
                            SendToClients("Igrac " + i2.KorisnickoIme + " je ispao!");
                        }
                        
                    }
                    
                }

                SendDataToClients();

            }
            catch (SocketException ex)
            {
                RemoveClient(client, "SocketException: " + ex.SocketErrorCode);
            }
            catch (Exception ex)
            {
                RemoveClient(client, "Error: " + ex.Message);
            }
        }
        // Dodato novo
        private void SendFramedData(Socket client, byte[] data)
        {
            try
            {
                //Konvertuje duzinu poruke prvo duzinu poruke a posle toga ide data
                byte[] length = BitConverter.GetBytes(data.Length);
                client.Send(length);
                client.Send(data);
            }
            catch
            {
            }
        }
        private void SendToClient(Socket client, string msg)
        {
            try
            {
                // Slanje prvog karaktera T za text
                byte[] data = Encoding.UTF8.GetBytes(msg);
                byte[] buffer = new byte[1 + data.Length];
                buffer[0] = (byte)'T';
                Array.Copy(data, 0, buffer, 1, data.Length);
                SendFramedData(client, buffer);
            }
            catch
            {
                MessageBox.Show("Greska pri slanju informacija!");
            }
        }

        private void SendDataToClient(Socket client, Partija partija)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(ms, partija);
                    byte[] data = ms.ToArray();
                    // Ako salje partiju, onda je P prvo slovo
                    byte[] buffer = new byte[1 + data.Length];
                    buffer[0] = (byte)'P';
                    // kopira upsi od 1 pozicije u buffer datau(data se upisuje od 0)
                    Array.Copy(data, 0, buffer, 1, data.Length);
                    SendFramedData(client, buffer);
                }
            }
            catch
            {
                MessageBox.Show("Greska pri slanju informacija!");
            }
        }
        
        private void SendToClients(string msg)
        {
            //Funkcija koja sluzi samo za ispis u textboxu igraca
            foreach(Socket s in klijenti)
                SendToClient(s, msg);
        }
        private void SendDataToClients()
        {
            //Funkcija koja salje podatke o partiji svim klijentima
            foreach (Socket s in klijenti)
            {
                SendDataToClient(s, partija);
            }
        }
      

        private void RemoveClient(Socket client, string reason)
        {
            bool removed = false;
            lock (_lock)
            {
                removed = klijenti.Remove(client);
            }

            SafeClose(client);
        }

        private static void SafeClose(Socket s)
        {
            if (s == null) return;
            try { s.Shutdown(SocketShutdown.Both); } catch { }
            try { s.Close(); } catch { }
        }

        protected override void OnClosed(EventArgs e)
        {
            StopServer();
            base.OnClosed(e);
        }

        private void StopServer()
        {
            try
            {
                if (_cts != null) _cts.Cancel();

                lock (_lock)
                {
                    for (int i = 0; i < klijenti.Count; i++)
                        SafeClose(klijenti[i]);
                    klijenti.Clear();
                }

                SafeClose(serverTcp);
                serverTcp = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Stop error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SendDataToClients();
        }
        #endregion
        #region Logika igrice

        //Vrati info uzima kao parametre ime 1. i 2. igraca, i polje koje je bombardovano
        private string VratiInfo(string igrac1, string igrac2, string polje)
        {
            //ne pitaj zasto sam obrnuo
            Igrac i = partija.PronadjiIgracaPoImenu(igrac2);
            Igrac i2 = partija.PronadjiIgracaPoImenu(igrac1);
            //trazi se polje po nazivu, i dobija se njegov tip
            string p = i.pronadjiPolje(polje);
            //ako je oooo, onda znaci da nije bilo nista na njemu, i racuna se kao promasaj
            if (p == "oooo")
            {
                //azuriranje tog polja, i vraca string Promasio
                i.AzurirajPoljePoImenu(polje, "xxxx");
                partija.AzurirajIgraca(i.IdIgraca, i);
                i2.BrojPromasaja++;
                partija.AzurirajIgraca(i2.IdIgraca, i2);
                return "PROMASIO";
            }  
            else if(p != "xxxx" || p[3] == 'x')
            {
                //ako nije vec gadjano polje, a ima nesto na njemu, azurira se matrica, i smanjuje broj promasaja;
                string novoPolje = p.Substring(0, 3);
                novoPolje += 'x';
                i.AzurirajPoljePoImenu(polje, novoPolje);
                partija.AzurirajIgraca(i.IdIgraca, i);
                if(Potopljen(igrac2, polje))
                {
                    i2.BrojPromasaja = 0;
                    partija.AzurirajIgraca(i2.IdIgraca, i2);
                    return "POTOPIO";
                }
                else
                {
                    i2.BrojPromasaja = 0;
                    partija.AzurirajIgraca(i2.IdIgraca, i2);
                    return "POGODIO";
                }
            }
            //Ako je gadjao vec pogodjeno mesto, onda se to racuna kao promasaj
            i2.BrojPromasaja++;
            partija.AzurirajIgraca(i2.IdIgraca, i2);
            return "PROMASIO";
        }

        //logika za proveru da li je potopljen ceo brod, ili je samo njegov deo pogodjen
        private bool Potopljen(string igrac2, string polje)
        {
            Igrac i = partija.PronadjiIgracaPoImenu(igrac2);
            string p = i.pronadjiPolje(polje);
            int size = Convert.ToInt32(p[0]);
            int counter = size;
            foreach(Polje pl in i.Tabla.Polja)
            {
                if (pl.Tip[0] == p[0] && pl.Tip[3] == 'x')
                    counter--;
            }
            if(counter == 0)
            {
                i.Brodovi[size - 1] = 0;
                partija.AzurirajIgraca(i.IdIgraca, i);
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        private void endGame() {
            //MessageBox.Show("Kraj igre!");
            /*
            List<Socket> snapshot;
            lock (_lock) {
                snapshot = new List<Socket>(klijenti);
            }
            foreach (Socket s in snapshot)
            {
                try
                {
                    s.Blocking = true;
                    s.SendTimeout = 3000;
                    // Koristimo isti framing protokol kao SendToClient
                    byte[] msgBytes = Encoding.UTF8.GetBytes(porukaZaSlanje);
                    byte[] payload = new byte[1 + msgBytes.Length];
                    payload[0] = (byte)'T';
                    Array.Copy(msgBytes, 0, payload, 1, msgBytes.Length);

                    byte[] lengthPrefix = BitConverter.GetBytes(payload.Length);
                    byte[] fullMessage = new byte[lengthPrefix.Length + payload.Length];
                    Array.Copy(lengthPrefix, 0, fullMessage, 0, lengthPrefix.Length);
                    Array.Copy(payload, 0, fullMessage, lengthPrefix.Length, payload.Length);

                    s.Send(fullMessage);
                }
                catch { }
            }
            Thread.Sleep(10000);
            */
            string name = "";
            foreach (Igrac i in partija.Igraci) {
                if (i.Aktivan == true) {
                    name = i.KorisnickoIme;
                }
            }
            rTBInfo.Invoke(new MethodInvoker(delegate { rTBInfo.Text += "\n" + "Igrac " + name + " pobedio"; }));
            StopServer();
        }
        }
}
