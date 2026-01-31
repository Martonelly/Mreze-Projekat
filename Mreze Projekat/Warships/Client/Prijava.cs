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
            if(txtBoxIme.Text == "")
            {
                MessageBox.Show("Niste uneli ime!", "Doslo je do greske pri prijavi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string ime = txtBoxIme.Text;
                int serverPort = 50001;
                IPAddress serverIP = IPAddress.Loopback;
                EndPoint serverEp = new IPEndPoint(serverIP, serverPort);
                int flag = 0;
                Partija PoslataPartija = new Partija();
                Socket clientUdp = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                try
                {
                    byte[] buffer = new byte[1024];
                    buffer = Encoding.UTF8.GetBytes("PRIJAVA");
                    clientUdp.SendTo(buffer, serverEp);
                    MessageBox.Show("Prijavljeni ste na server, cekaju se ostali igraci!");
                    int reclen = 0;
                    while (reclen == 0)
                    {
                        byte[] bufferRec = new byte[1024];
                        reclen = clientUdp.ReceiveFrom(bufferRec, ref serverEp);
                        if (Encoding.UTF8.GetString(bufferRec, 0, reclen) == "Pocni")
                        {
                            MessageBox.Show("Server je spreman, pocinje igra!");
                            flag = 1;
                            break;
                        }
                    }

                    byte[] podaciZaCekaonicu = new byte[1024];
                    podaciZaCekaonicu = Encoding.UTF8.GetBytes(ime);
                    clientUdp.SendTo(podaciZaCekaonicu, serverEp);
                    int receivedBytes = 0;
                    while (receivedBytes == 0)
                    {
                        byte[] bufferRec = new byte[10000];
                        receivedBytes = clientUdp.ReceiveFrom(bufferRec, ref serverEp);
                        string poruka = Encoding.UTF8.GetString(bufferRec, 0, receivedBytes);
                        if (poruka != "")
                        {
                            using (StringReader reader = new StringReader(poruka))
                            {
                                // Deserialize the XML back into a Person object
                                PoslataPartija = (Partija)serializer.Deserialize(reader);
                            }

                        }
                    }
                    clientUdp.Close();
                    MessageBox.Show($"Partija je pocela");
                    Cekaonica forma = new Cekaonica();
                    forma.partija = PoslataPartija;
                    forma.Show();
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Doslo je do greske pri prijavi");
                }
            }
        }
    }
}
