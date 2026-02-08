using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Client
{
    public partial class Prijava : Form
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Partija));

        public Prijava()
        {
            InitializeComponent();
        }

        private void btnPrijava_Click(object sender, EventArgs e)
        {
           
            if (txtBoxIme.Text == "")
            {
                MessageBox.Show("Niste uneli ime!", "Doslo je do greske pri prijavi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                IPAddress tcpAddress = IPAddress.Any;
                int tcpPort=0;
                int dimenzija = 0;
                string ime = txtBoxIme.Text;
                int serverPort = 50001;
                IPAddress serverIP = IPAddress.Loopback;
                EndPoint serverEp = new IPEndPoint(serverIP, serverPort);

                Partija PoslataPartija = new Partija();
                Socket clientUdp = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                try
                {
                    byte[] buffer = new byte[1024];
                    buffer = Encoding.UTF8.GetBytes("PRIJAVA");
                    clientUdp.SendTo(buffer, serverEp);
                    int reclen = 0;
                    //Ceka poruku od servera ---> IP address and TCP port
                    while (reclen == 0)
                    {
                        byte[] bufferRec = new byte[1024];
                        reclen = clientUdp.ReceiveFrom(bufferRec, ref serverEp);
                        //Fetch buffer info
                        string tcpInfo = Encoding.UTF8.GetString(bufferRec);
                        string[] sliced = tcpInfo.Split(':');
                        string tcpA = sliced[0].Trim();
                        string tcpP = sliced[1].Trim();
                        string dim  = sliced[2].Trim();
                        tcpAddress = IPAddress.Parse(tcpA);
                        tcpPort = Int32.Parse(tcpP);
                        dimenzija = Int32.Parse(dim);
                    }

                    //Slanje imena
                    byte[] bufferSend = new byte[1024];
                    bufferSend = Encoding.UTF8.GetBytes(ime);
                    clientUdp.SendTo(bufferSend, serverEp);

                    //Fechovanje partije
                    while (true)
                    {
                        //Tu nam treba funkcija da znamo kolka da bude duzina buffera 
                        byte[] bufferlen = new byte[4];
                        //Samo postavlja u bufferLen duzinu-->prva stvar sto saljem je int-->duzina zato 4
                        readLength(clientUdp, bufferlen, 4);
                        int len = BitConverter.ToInt32(bufferlen, 0);
                        byte[] bufferRec = new byte[len];
                        //U bufferu ce biti podatak o partiji po duzini od len
                        readLength(clientUdp, bufferRec, len);

                        using (MemoryStream ms = new MemoryStream(bufferRec))
                        {
                            BinaryFormatter bf = new BinaryFormatter();
                            PoslataPartija = (Partija)bf.Deserialize(ms);
                        }
                        if (PoslataPartija != null)
                        {
                            break;
                        }

                    }

                    clientUdp.Close();
                    //Otvaranje cekaonice
                    Cekaonica forma = new Cekaonica();
                    forma.partija = PoslataPartija;
                    forma.tcpPort = tcpPort;
                    forma.tcpAddress = tcpAddress;
                    forma.Dimenzija = dimenzija;
                    forma.Show();
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Doslo je do greske pri prijavi");
                }
            }
        }
        private void readLength(Socket s, byte[] buf, int size)
        {
            int offset = 0;
            //U principu ocekujes neku duzinu i dok ne napunis bafer sa tom duzinom onda si u while-u
            while (offset < size)
            {
                int r = s.Receive(buf, size - offset, SocketFlags.None);
                offset += r;
            }
        }
    }
}


