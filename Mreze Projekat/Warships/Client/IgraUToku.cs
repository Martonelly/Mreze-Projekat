using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Client
{
    public partial class IgraUToku : Form
    {
        public List<PictureBox> pictureBoxes = new List<PictureBox>();
        public List<PictureBox> enemyPictureBoxes = new List<PictureBox>();

        int preostaloVreme = 90;

        private int[] rotated = { 0, 0, 0, 0, 0 };
        int selectedShip = 0;
        public int Dimenzija { get; set; }
        int brojBrodova { get; set; } = 5;
        int setUp = 0;
        string izabranoPolje;

        public Partija partija = new Partija();
        public Igrac igrac;
        Igrac aktivanProtivnik = new Igrac();
        string bombardovao = "";
        public bool endFlag = false;

        public Socket clientSocket { get; set; }
        private CancellationTokenSource _cts;
        private Task _rxTask;

        public IgraUToku()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ExitConfirm forma = new ExitConfirm();
            DialogResult izlaz = forma.ShowDialog();
            if (izlaz == DialogResult.OK)
            {
                Disconnect();
                this.Close();
            }

        }

        private void IgraUToku_Load(object sender, EventArgs e)
        {
            CreateImages(Dimenzija, 'e');
            CreateImages(Dimenzija, 'y');
            timerVreme.Start();
            MessageBox.Show(clientSocket.LocalEndPoint.ToString());
            //Kreiranje cancellation tokena za komunikaciju
            try
            {
                _cts = new CancellationTokenSource();
                _rxTask = Task.Run(() => ReceiveLoop(_cts.Token));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Doslo je do greske pri komunikaciji sa serverom! ");
                Disconnect();
            }
        }
        //Nije bitno za funkcionalnost servera
        #region Kreiranje slika i logika iza prikazivanja tabele
        private void CreateImages(int dimenzija, char which)
        {
            char toWhichChar = ' ';
            switch (dimenzija)
            {
                case 6:
                    toWhichChar = 'G';
                    break;
                case 7:
                    toWhichChar = 'H';
                    break;
                case 8:
                    toWhichChar = 'I';
                    break;
                case 9:
                    toWhichChar = 'J';
                    break;
                case 10:
                    toWhichChar = 'K';
                    break;
                default:
                    toWhichChar = 'K';
                    break;
            }
            for (char i = '@'; i < toWhichChar; i++)
            {
                for (int j = 0; j < dimenzija + 1; j++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Size = new Size(32, 32);
                    if (which == 'y')
                    {
                        pictureBox.Location = new Point(lblYou.Location.X + j * 32, (dimenzija + 5 + (10 - dimenzija)) * 32 + 12 + (i - 64) * 32);
                        pictureBox.MouseDown += new MouseEventHandler(ImageClick);
                        if (i != '@' && j != 0)
                            igrac.Tabla.Polja.Add(new Polje(i + j.ToString(), "oooo"));

                    }
                    else
                    {
                        pictureBox.Location = new Point(lblEnemy.Location.X + j * 32, 64 + (i - 64) * 32);
                        pictureBox.MouseDown += new MouseEventHandler(EnemyImageClick);
                    }
                    pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
                    string name;
                    if (which == 'y')
                    {
                        name = "yourPictureBox";
                    }
                    else
                    {
                        name = "enemyPictureBox";
                    }

                    if (i == '@' && j == 0)
                    {
                        if (which == 'y')
                        {
                            pictureBox.Name = "yourPictureBoxCoconut" + i + j.ToString();
                        }
                        else
                        {
                            pictureBox.Name = "EnemyPictureBoxCoconut" + i + j.ToString();
                        }
                        pictureBox.BackgroundImage = Properties.Resources.coconut;
                    }
                    else if (i == '@')
                    {
                        pictureBox.Name = name + i + j.ToString();
                        switch (j)
                        {
                            case 1:
                                pictureBox.BackgroundImage = Properties.Resources._1_tile;
                                break;
                            case 2:
                                pictureBox.BackgroundImage = Properties.Resources._2_tile;
                                break;
                            case 3:
                                pictureBox.BackgroundImage = Properties.Resources._3_tile;
                                break;
                            case 4:
                                pictureBox.BackgroundImage = Properties.Resources._4_tile;
                                break;
                            case 5:
                                pictureBox.BackgroundImage = Properties.Resources._5_tile;
                                break;
                            case 6:
                                pictureBox.BackgroundImage = Properties.Resources._6_tile;
                                break;
                            case 7:
                                pictureBox.BackgroundImage = Properties.Resources._7_tile;
                                break;
                            case 8:
                                pictureBox.BackgroundImage = Properties.Resources._8_tile;
                                break;
                            case 9:
                                pictureBox.BackgroundImage = Properties.Resources._9_tile;
                                break;
                            case 10:
                                pictureBox.BackgroundImage = Properties.Resources._10_tile;
                                break;
                        }
                    }
                    else if (j == 0)
                    {
                        pictureBox.Name = name + i + j;
                        switch (i)
                        {
                            case 'A':
                                pictureBox.BackgroundImage = Properties.Resources.a_tile;
                                break;
                            case 'B':
                                pictureBox.BackgroundImage = Properties.Resources.b_tile;
                                break;
                            case 'C':
                                pictureBox.BackgroundImage = Properties.Resources.c_tile;
                                break;
                            case 'D':
                                pictureBox.BackgroundImage = Properties.Resources.d_tile;
                                break;
                            case 'E':
                                pictureBox.BackgroundImage = Properties.Resources.e_tile;
                                break;
                            case 'F':
                                pictureBox.BackgroundImage = Properties.Resources.f_tile;
                                break;
                            case 'G':
                                pictureBox.BackgroundImage = Properties.Resources.g_tile;
                                break;
                            case 'H':
                                pictureBox.BackgroundImage = Properties.Resources.h_tile;
                                break;
                            case 'I':
                                pictureBox.BackgroundImage = Properties.Resources.i_tile;
                                break;
                            case 'J':
                                pictureBox.BackgroundImage = Properties.Resources.j_tile;
                                break;
                        }
                    }
                    else
                    {
                        pictureBox.Name = name + i + j.ToString();
                        pictureBox.BackgroundImage = Properties.Resources.tile;
                    }
                    pictureBox.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                    if (which == 'y')
                    {
                        pictureBoxes.Add(pictureBox);
                    }
                    else
                    {
                        enemyPictureBoxes.Add(pictureBox);
                    }
                    this.Controls.Add(pictureBox);
                }
            }
        }

        private void ImageClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox pictureBox = (PictureBox)sender;
                string[] delovi = pictureBox.Name.Split('x');
                string naziv = delovi[1];
                char startRow;
                int startCol;
                int checker1 = Convert.ToInt32(pictureBox.Name[pictureBox.Name.Length - 1]) - 48;
                int checker2 = Convert.ToInt32(pictureBox.Name[pictureBox.Name.Length - 2]) - 48;
                if (checker2 == 1 && checker1 == 0)
                {
                    startRow = pictureBox.Name[pictureBox.Name.Length - 3];
                    placeShip(selectedShip, startRow, 10);
                }
                else
                {
                    startRow = pictureBox.Name[pictureBox.Name.Length - 2];
                    startCol = Convert.ToInt32(pictureBox.Name[pictureBox.Name.Length - 1]) - 48;
                    placeShip(selectedShip, startRow, startCol);
                }

            }
        }

        private void EnemyImageClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox pictureBox = (PictureBox)sender;
                char startRow;
                int startCol;
                int checker1 = Convert.ToInt32(pictureBox.Name[pictureBox.Name.Length - 1]) - 48;
                int checker2 = Convert.ToInt32(pictureBox.Name[pictureBox.Name.Length - 2]) - 48;
                if (checker2 == 1 && checker1 == 0)
                {
                    startRow = pictureBox.Name[pictureBox.Name.Length - 3];
                    izabranoPolje = startRow + "10";
                }
                else
                {
                    startRow = pictureBox.Name[pictureBox.Name.Length - 2];
                    startCol = Convert.ToInt32(pictureBox.Name[pictureBox.Name.Length - 1]) - 48;
                    izabranoPolje = startRow + startCol.ToString();
                }
            }
        }

        private void placeShip(int selected, char startRow, int startColumn)
        {
            if (startRow == '@' || startColumn == 0)
            {
                MessageBox.Show("To polje ne moze biti odabrano! ");
            }
            else
            {
                switch (selected)
                {
                    case 1:
                        if (rotated[0] == 0)
                        {
                            if (CheckPlacement(startRow, startColumn, 1, rotated[0]))
                            {
                                selected = 0;
                                Controls.Find("yourPictureBox" + startRow + startColumn, true)[0].BackgroundImage = Properties.Resources._1x1_boat_horizontal_part1;
                                AzurirajTabelu(startRow, startColumn, 1, rotated[0]);
                                tB1x1.Text = "0";
                            }
                            else
                            {
                                MessageBox.Show("Taj brodic ne mozete postaviti tu");
                            }

                        }
                        else if (rotated[0] == 1)
                        {
                            if (CheckPlacement(startRow, startColumn, 1, rotated[0]))
                            {
                                selected = 0;
                                Controls.Find("yourPictureBox" + startRow + startColumn, true)[0].BackgroundImage = Properties.Resources._1x1_boat_vertical_part1;
                                AzurirajTabelu(startRow, startColumn, 1, rotated[0]);
                                tB1x1.Text = "0";
                            }
                            else
                            {
                                MessageBox.Show("Taj brodic ne mozete postaviti tu");
                            }
                        }
                        break;

                    case 2:
                        if (rotated[1] == 0)
                        {
                            if (startColumn - 1 >= 1 && CheckPlacement(startRow, startColumn, 2, rotated[1]))
                            {
                                selected = 0;
                                Controls.Find("yourPictureBox" + startRow + startColumn, true)[0].BackgroundImage = Properties.Resources._2x1_boat_horizontal_part1;
                                Controls.Find("yourPictureBox" + startRow + (startColumn - 1), true)[0].BackgroundImage = Properties.Resources._2x1_boat_horizontal_part2;
                                AzurirajTabelu(startRow, startColumn, 2, rotated[1]);
                                tB2x1.Text = "0";
                            }
                            else
                            {
                                MessageBox.Show("Nemate dovoljno mesta!");
                            }
                        }
                        else if (rotated[1] == 1)
                        {
                            char row1 = startRow;
                            char row2 = (char)(startRow - 1);
                            if (row2 >= 'A' && CheckPlacement(startRow, startColumn, 2, rotated[1]))
                            {
                                selected = 0;
                                Controls.Find("yourPictureBox" + row1 + startColumn, true)[0].BackgroundImage = Properties.Resources._2x1_boat_vertical_part1;
                                Controls.Find("yourPictureBox" + row2 + startColumn, true)[0].BackgroundImage = Properties.Resources._2x1_boat_vertical_part2;
                                AzurirajTabelu(startRow, startColumn, 2, rotated[1]);
                                tB2x1.Text = "0";
                            }
                            else
                            {
                                MessageBox.Show("Nemate dovoljno mesta!");
                            }
                        }
                        break;

                    case 3:
                        if (rotated[2] == 0)
                        {
                            if (startColumn - 2 >= 1 && CheckPlacement(startRow, startColumn, 3, rotated[2]))
                            {
                                selected = 0;
                                Controls.Find("yourPictureBox" + startRow + startColumn, true)[0].BackgroundImage = Properties.Resources._3x1_boat_horizontal_part1;
                                Controls.Find("yourPictureBox" + startRow + (startColumn - 1), true)[0].BackgroundImage = Properties.Resources._3x1_boat_horizontal_part2;
                                Controls.Find("yourPictureBox" + startRow + (startColumn - 2), true)[0].BackgroundImage = Properties.Resources._3x1_boat_horizontal_part3;
                                AzurirajTabelu(startRow, startColumn, 3, rotated[2]);
                                tB3x1.Text = "0";
                            }
                            else
                            {
                                MessageBox.Show("Nemate dovoljno mesta!");
                            }
                        }
                        else if (rotated[2] == 1)
                        {
                            char row1 = startRow;
                            char row2 = (char)(startRow - 1);
                            char row3 = (char)(startRow - 2);
                            if (row3 >= 'A' && CheckPlacement(startRow, startColumn, 3, rotated[2]))
                            {
                                selected = 0;
                                Controls.Find("yourPictureBox" + row1 + startColumn, true)[0].BackgroundImage = Properties.Resources._3x1_boat_vertical_part1;
                                Controls.Find("yourPictureBox" + row2 + startColumn, true)[0].BackgroundImage = Properties.Resources._3x1_boat_vertical_part2;
                                Controls.Find("yourPictureBox" + row3 + startColumn, true)[0].BackgroundImage = Properties.Resources._3x1_boat_vertical_part3;
                                AzurirajTabelu(startRow, startColumn, 3, rotated[2]);
                                tB3x1.Text = "0";
                            }
                            else
                            {
                                MessageBox.Show("Nemate dovoljno mesta!");
                            }
                        }
                        break;

                    case 4:
                        if (rotated[3] == 0)
                        {
                            if (startColumn - 3 >= 1 && CheckPlacement(startRow, startColumn, 4, rotated[3]))
                            {
                                selected = 0;
                                Controls.Find("yourPictureBox" + startRow + startColumn, true)[0].BackgroundImage = Properties.Resources._4x1_boat_horizontal_part1;
                                Controls.Find("yourPictureBox" + startRow + (startColumn - 1), true)[0].BackgroundImage = Properties.Resources._4x1_boat_horizontal_part2;
                                Controls.Find("yourPictureBox" + startRow + (startColumn - 2), true)[0].BackgroundImage = Properties.Resources._4x1_boat_horizontal_part3;
                                Controls.Find("yourPictureBox" + startRow + (startColumn - 3), true)[0].BackgroundImage = Properties.Resources._4x1_boat_horizontal_part4;
                                AzurirajTabelu(startRow, startColumn, 4, rotated[3]);
                                tB4x1.Text = "0";
                            }
                            else
                            {
                                MessageBox.Show("Nemate dovoljno mesta!");
                            }
                        }
                        else if (rotated[3] == 1)
                        {
                            char row1 = startRow;
                            char row2 = (char)(startRow - 1);
                            char row3 = (char)(startRow - 2);
                            char row4 = (char)(startRow - 3);
                            if (row4 >= 'A' && CheckPlacement(startRow, startColumn, 4, rotated[3]))
                            {
                                selected = 0;
                                Controls.Find("yourPictureBox" + row1 + startColumn, true)[0].BackgroundImage = Properties.Resources._4x1_boat_vertical_part1;
                                Controls.Find("yourPictureBox" + row2 + startColumn, true)[0].BackgroundImage = Properties.Resources._4x1_boat_vertical_part2;
                                Controls.Find("yourPictureBox" + row3 + startColumn, true)[0].BackgroundImage = Properties.Resources._4x1_boat_vertical_part3;
                                Controls.Find("yourPictureBox" + row4 + startColumn, true)[0].BackgroundImage = Properties.Resources._4x1_boat_vertical_part4;
                                AzurirajTabelu(startRow, startColumn, 4, rotated[3]);
                                tB4x1.Text = "0";
                            }
                            else
                            {
                                MessageBox.Show("Nemate dovoljno mesta!");
                            }
                        }
                        break;

                    case 5:
                        if (rotated[4] == 0)
                        {
                            if (startColumn - 4 >= 1 && CheckPlacement(startRow, startColumn, 5, rotated[4]))
                            {
                                selected = 0;
                                Controls.Find("yourPictureBox" + startRow + startColumn, true)[0].BackgroundImage = Properties.Resources._5x1_boat_horizontal_part1;
                                Controls.Find("yourPictureBox" + startRow + (startColumn - 1), true)[0].BackgroundImage = Properties.Resources._5x1_boat_horizontal_part2;
                                Controls.Find("yourPictureBox" + startRow + (startColumn - 2), true)[0].BackgroundImage = Properties.Resources._5x1_boat_horizontal_part3;
                                Controls.Find("yourPictureBox" + startRow + (startColumn - 3), true)[0].BackgroundImage = Properties.Resources._5x1_boat_horizontal_part4;
                                Controls.Find("yourPictureBox" + startRow + (startColumn - 4), true)[0].BackgroundImage = Properties.Resources._5x1_boat_horizontal_part5;
                                AzurirajTabelu(startRow, startColumn, 5, rotated[4]);
                                tB5x1.Text = "0";
                            }
                            else
                            {
                                MessageBox.Show("Nemate dovoljno mesta!");
                            }
                        }
                        else if (rotated[4] == 1)
                        {
                            char row1 = startRow;
                            char row2 = (char)(startRow - 1);
                            char row3 = (char)(startRow - 2);
                            char row4 = (char)(startRow - 3);
                            char row5 = (char)(startRow - 4);
                            if (row5 >= 'A' && CheckPlacement(startRow, startColumn, 5, rotated[4]))
                            {
                                selected = 0;
                                Controls.Find("yourPictureBox" + row1 + startColumn, true)[0].BackgroundImage = Properties.Resources._5x1_boat_vertical_part1;
                                Controls.Find("yourPictureBox" + row2 + startColumn, true)[0].BackgroundImage = Properties.Resources._5x1_boat_vertical_part2;
                                Controls.Find("yourPictureBox" + row3 + startColumn, true)[0].BackgroundImage = Properties.Resources._5x1_boat_vertical_part3;
                                Controls.Find("yourPictureBox" + row4 + startColumn, true)[0].BackgroundImage = Properties.Resources._5x1_boat_vertical_part4;
                                Controls.Find("yourPictureBox" + row5 + startColumn, true)[0].BackgroundImage = Properties.Resources._5x1_boat_vertical_part5;
                                AzurirajTabelu(startRow, startColumn, 5, rotated[4]);
                                tB5x1.Text = "0";
                            }
                            else
                            {
                                MessageBox.Show("Nemate dovoljno mesta!");
                            }
                        }
                        break;

                    default:
                        MessageBox.Show("Niste odabrali brodic", "Nije odabran brodic", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        break;
                }
                selectedBoat.BackgroundImage = null;
                selectedShip = 0;
            }
        }

        private bool CheckPlacement(char startRow, int startColumn, int size, int rotation)
        {
            if (rotation == 0)
            {
                for (int i = startColumn; i >= startColumn - size + 1; i--)
                {
                    string pictureBoxName = startRow + i.ToString();
                    if (igrac.pronadjiPolje(pictureBoxName) != "oooo")
                        return false;

                }
            }
            else
            {
                for (char i = startRow; i >= startRow - size + 1; i--)
                {
                    string pictureBoxName = i + startColumn.ToString();
                    if (igrac.pronadjiPolje(pictureBoxName) != "oooo")
                        return false;
                }
            }
            return true;
        }

        private void AzurirajTabelu(char startRow, int startColumn, int size, int rotation)
        {
            if (rotation == 0)
            {
                int part = 1;
                for (int i = startColumn; i >= startColumn - size + 1; i--)
                {
                    string pictureBoxName = startRow + i.ToString();
                    string tip = size.ToString() + part.ToString() + "ho";
                    igrac.AzurirajPoljePoImenu(pictureBoxName, tip);
                    part++;
                }
            }
            else
            {
                int part = 1;
                for (char i = startRow; i >= startRow - size + 1; i--)
                {
                    string pictureBoxName = i + startColumn.ToString();
                    string tip = size.ToString() + part.ToString() + "vo";
                    igrac.AzurirajPoljePoImenu(pictureBoxName, tip);
                    part++;
                }
            }
        }

        private void AzurirajTabeluNeprijatelja(Igrac neprijatelj)
        {
            foreach (Polje p in neprijatelj.Tabla.Polja)
            {
                PictureBox slika = (PictureBox)Controls.Find("enemyPictureBox" + p.Naziv, true)[0];
                if (p.Tip[3] == 'x')
                {
                    ZameniSliku(slika, p.Tip);
                }
                else
                {
                    ZameniSliku(slika, "oooo");
                }


            }
        }

        private void AzurirajSvojuTabelu()
        {
            foreach (Polje p in igrac.Tabla.Polja)
            {
                PictureBox slika = (PictureBox)Controls.Find("yourPictureBox" + p.Naziv, true)[0];
                ZameniSliku(slika, p.Tip);
            }
        }

        private void ZameniSliku(PictureBox picture, string tip)
        {
            switch (tip)
            {
                case "oooo":
                    picture.BackgroundImage = Properties.Resources.tile;
                    break;
                case "xxxx":
                    picture.BackgroundImage = Properties.Resources.explosion;
                    break;
                case "11ho":
                    picture.BackgroundImage = Properties.Resources._1x1_boat_horizontal_part1;
                    break;
                case "11hx":
                    picture.BackgroundImage = Properties.Resources._1x1_boat_horizontal_part1_destroyed;
                    break;
                case "11vo":
                    picture.BackgroundImage = Properties.Resources._1x1_boat_vertical_part1;
                    break;
                case "11vx":
                    picture.BackgroundImage = Properties.Resources._1x1_boat_vertical_part1_destroyed;
                    break;
                case "21ho":
                    picture.BackgroundImage = Properties.Resources._2x1_boat_horizontal_part1;
                    break;
                case "22ho":
                    picture.BackgroundImage = Properties.Resources._2x1_boat_horizontal_part2;
                    break;
                case "21hx":
                    picture.BackgroundImage = Properties.Resources._2x1_boat_horizontal_part1_destroyed;
                    break;
                case "22hx":
                    picture.BackgroundImage = Properties.Resources._2x1_boat_horizontal_part2_destroyed;
                    break;
                case "21vo":
                    picture.BackgroundImage = Properties.Resources._2x1_boat_vertical_part1;
                    break;
                case "22vo":
                    picture.BackgroundImage = Properties.Resources._2x1_boat_vertical_part2;
                    break;
                case "21vx":
                    picture.BackgroundImage = Properties.Resources._2x1_boat_vertical_part1_destroyed;
                    break;
                case "22vx":
                    picture.BackgroundImage = Properties.Resources._2x1_boat_vertical_part2_destroyed;
                    break;
                case "31ho":
                    picture.BackgroundImage = Properties.Resources._3x1_boat_horizontal_part1;
                    break;
                case "32ho":
                    picture.BackgroundImage = Properties.Resources._3x1_boat_horizontal_part2;
                    break;
                case "33ho":
                    picture.BackgroundImage = Properties.Resources._3x1_boat_horizontal_part3;
                    break;
                case "31hx":
                    picture.BackgroundImage = Properties.Resources._3x1_boat_horizontal_part1_destroyed;
                    break;
                case "32hx":
                    picture.BackgroundImage = Properties.Resources._3x1_boat_horizontal_part2_destroyed;
                    break;
                case "33hx":
                    picture.BackgroundImage = Properties.Resources._3x1_boat_horizontal_part3_destroyed;
                    break;
                case "31vo":
                    picture.BackgroundImage = Properties.Resources._3x1_boat_vertical_part1;
                    break;
                case "32vo":
                    picture.BackgroundImage = Properties.Resources._3x1_boat_vertical_part2;
                    break;
                case "33vo":
                    picture.BackgroundImage = Properties.Resources._3x1_boat_vertical_part3;
                    break;
                case "31vx":
                    picture.BackgroundImage = Properties.Resources._3x1_boat_vertical_part1_destroyed;
                    break;
                case "32vx":
                    picture.BackgroundImage = Properties.Resources._3x1_boat_vertical_part2_destroyed;
                    break;
                case "33vx":
                    picture.BackgroundImage = Properties.Resources._3x1_boat_vertical_part3_destroyed;
                    break;
                case "41ho":
                    picture.BackgroundImage = Properties.Resources._4x1_boat_horizontal_part1;
                    break;
                case "42ho":
                    picture.BackgroundImage = Properties.Resources._4x1_boat_horizontal_part2;
                    break;
                case "43ho":
                    picture.BackgroundImage = Properties.Resources._4x1_boat_horizontal_part3;
                    break;
                case "44ho":
                    picture.BackgroundImage = Properties.Resources._4x1_boat_horizontal_part4;
                    break;
                case "41hx":
                    picture.BackgroundImage = Properties.Resources._4x1_boat_horizontal_part1_destroyed;
                    break;
                case "42hx":
                    picture.BackgroundImage = Properties.Resources._4x1_boat_horizontal_part2_destroyed;
                    break;
                case "43hx":
                    picture.BackgroundImage = Properties.Resources._4x1_boat_horizontal_part3_destroyed;
                    break;
                case "44hx":
                    picture.BackgroundImage = Properties.Resources._4x1_boat_horizontal_part4_destroyed;
                    break;
                case "41vo":
                    picture.BackgroundImage = Properties.Resources._4x1_boat_vertical_part1;
                    break;
                case "42vo":
                    picture.BackgroundImage = Properties.Resources._4x1_boat_vertical_part2;
                    break;
                case "43vo":
                    picture.BackgroundImage = Properties.Resources._4x1_boat_vertical_part3;
                    break;
                case "44vo":
                    picture.BackgroundImage = Properties.Resources._4x1_boat_vertical_part4;
                    break;
                case "41vx":
                    picture.BackgroundImage = Properties.Resources._4x1_boat_vertical_part1_destroyed;
                    break;
                case "42vx":
                    picture.BackgroundImage = Properties.Resources._4x1_boat_vertical_part2_destroyed;
                    break;
                case "43vx":
                    picture.BackgroundImage = Properties.Resources._4x1_boat_vertical_part3_destroyed;
                    break;
                case "44vx":
                    picture.BackgroundImage = Properties.Resources._4x1_boat_vertical_part4_destroyed;
                    break;
                case "51ho":
                    picture.BackgroundImage = Properties.Resources._5x1_boat_horizontal_part1;
                    break;
                case "52ho":
                    picture.BackgroundImage = Properties.Resources._5x1_boat_horizontal_part2;
                    break;
                case "53ho":
                    picture.BackgroundImage = Properties.Resources._5x1_boat_horizontal_part3;
                    break;
                case "54ho":
                    picture.BackgroundImage = Properties.Resources._5x1_boat_horizontal_part4;
                    break;
                case "55ho":
                    picture.BackgroundImage = Properties.Resources._5x1_boat_horizontal_part5;
                    break;
                case "51hx":
                    picture.BackgroundImage = Properties.Resources._5x1_boat_horizontal_part1_destroyed;
                    break;
                case "52hx":
                    picture.BackgroundImage = Properties.Resources._5x1_boat_horizontal_part2_destroyed;
                    break;
                case "53hx":
                    picture.BackgroundImage = Properties.Resources._5x1_boat_horizontal_part3_destroyed;
                    break;
                case "54hx":
                    picture.BackgroundImage = Properties.Resources._5x1_boat_horizontal_part4_destroyed;
                    break;
                case "55hx":
                    picture.BackgroundImage = Properties.Resources._5x1_boat_horizontal_part5_destroyed;
                    break;
                case "51vo":
                    picture.BackgroundImage = Properties.Resources._5x1_boat_vertical_part1;
                    break;
                case "52vo":
                    picture.BackgroundImage = Properties.Resources._5x1_boat_vertical_part2;
                    break;
                case "53vo":
                    picture.BackgroundImage = Properties.Resources._5x1_boat_vertical_part3;
                    break;
                case "54vo":
                    picture.BackgroundImage = Properties.Resources._5x1_boat_vertical_part4;
                    break;
                case "55vo":
                    picture.BackgroundImage = Properties.Resources._5x1_boat_vertical_part5;
                    break;
                case "51vx":
                    picture.BackgroundImage = Properties.Resources._5x1_boat_vertical_part1_destroyed;
                    break;
                case "52vx":
                    picture.BackgroundImage = Properties.Resources._5x1_boat_vertical_part2_destroyed;
                    break;
                case "53vx":
                    picture.BackgroundImage = Properties.Resources._5x1_boat_vertical_part3_destroyed;
                    break;
                case "54vx":
                    picture.BackgroundImage = Properties.Resources._5x1_boat_vertical_part4_destroyed;
                    break;
                case "55vx":
                    picture.BackgroundImage = Properties.Resources._5x1_boat_vertical_part5_destroyed;
                    break;
            }
        }
        #endregion

        //Ovaj tu deo nije bitan za funkcionalnost
        #region Prikaz drugih matrica
        private void player1_Click(object sender, EventArgs e)
        {
            if (partija.Igraci[0].IdIgraca != igrac.IdIgraca)
            {
                AzurirajTabeluNeprijatelja(partija.Igraci[0]);
                lblEnemy.Text = partija.Igraci[0].KorisnickoIme + "'s TABLA";
                aktivanProtivnik = partija.Igraci[0];
            }
        }

        private void player2_Click(object sender, EventArgs e)
        {
            if (partija.Igraci.Count < 2)
            {

            }
            else
            {
                if (partija.Igraci[1].IdIgraca != igrac.IdIgraca)
                {
                    AzurirajTabeluNeprijatelja(partija.Igraci[1]);
                    lblEnemy.Text = partija.Igraci[1].KorisnickoIme + "'s TABLA";
                    aktivanProtivnik = partija.Igraci[1];
                }
            }
        }

        private void player3_Click(object sender, EventArgs e)
        {
            if (partija.Igraci.Count < 3)
            {

            }
            else
            {
                if (partija.Igraci[2].IdIgraca != igrac.IdIgraca)
                {
                    AzurirajTabeluNeprijatelja(partija.Igraci[2]);
                    lblEnemy.Text = partija.Igraci[2].KorisnickoIme + "'s TABLA";
                    aktivanProtivnik = partija.Igraci[2];
                }
            }
        }

        private void player4_Click(object sender, EventArgs e)
        {
            if (partija.Igraci.Count < 4)
            {

            }
            else
            {
                if (partija.Igraci[3].IdIgraca != igrac.IdIgraca)
                {
                    AzurirajTabeluNeprijatelja(partija.Igraci[3]);
                    lblEnemy.Text = partija.Igraci[3].KorisnickoIme + "'s TABLA";
                    aktivanProtivnik = partija.Igraci[3];
                }
            }
        }

        #endregion

        //Ni ovaj

        #region Prikaz imena na listi igraca
        private void player1_Paint(object sender, PaintEventArgs e)
        {
            if (partija.Igraci.Count < 1)
            {
                string text = "Nema igraca";
                Font font = new Font("Pixelify Sans", 28, FontStyle.Bold);
                Color color = Color.FromArgb(168, 141, 88);
                PointF location = new PointF(21f, 55f);
                e.Graphics.DrawString(text, font, new SolidBrush(color), location);
            }
            else
            {
                string text = partija.Igraci[0].KorisnickoIme;
                if (partija.Igraci[0].Aktivan == false)
                    text =  partija.Igraci[0].KorisnickoIme + "\nIspao";
                Font font = new Font("Pixelify Sans", 28, FontStyle.Bold);
                Color color = Color.FromArgb(138, 111, 48);
                PointF location = new PointF(21f, 35f);
                e.Graphics.DrawString(text, font, new SolidBrush(color), location);

                string text2 = "Ostalo brodova : " + partija.Igraci[0].SumirajBrodove() + "/" + brojBrodova.ToString();
                Font font2 = new Font("Pixelify Sans", 20, FontStyle.Bold);
                Color color2 = Color.FromArgb(138, 111, 48);
                PointF location2 = new PointF(24f, 108f);
                e.Graphics.DrawString(text2, font2, new SolidBrush(color2), location2);
            }
        }

        private void player2_Paint(object sender, PaintEventArgs e)
        {
            if (partija.Igraci.Count < 2)
            {
                string text = "Nema igraca";
                Font font = new Font("Pixelify Sans", 28, FontStyle.Bold);
                Color color = Color.FromArgb(168, 141, 88);
                PointF location = new PointF(21f, 55f);
                e.Graphics.DrawString(text, font, new SolidBrush(color), location);
            }
            else
            {
                string text = partija.Igraci[1].KorisnickoIme;
                if (partija.Igraci[1].Aktivan == false)
                    text = partija.Igraci[1].KorisnickoIme + "\nIspao";
                Font font = new Font("Pixelify Sans", 28, FontStyle.Bold);
                Color color = Color.FromArgb(138, 111, 48);
                PointF location = new PointF(21f, 35f);
                e.Graphics.DrawString(text, font, new SolidBrush(color), location);

                string text2 = "Ostalo brodova : " + partija.Igraci[1].SumirajBrodove() + "/" + brojBrodova.ToString();
                Font font2 = new Font("Pixelify Sans", 20, FontStyle.Bold);
                Color color2 = Color.FromArgb(138, 111, 48);
                PointF location2 = new PointF(24f, 108f);
                e.Graphics.DrawString(text2, font2, new SolidBrush(color2), location2);
            }
        }

        private void player3_Paint(object sender, PaintEventArgs e)
        {
            if (partija.Igraci.Count < 3)
            {
                string text = "Nema igraca";
                Font font = new Font("Pixelify Sans", 28, FontStyle.Bold);
                Color color = Color.FromArgb(168, 141, 88);
                PointF location = new PointF(21f, 55f);
                e.Graphics.DrawString(text, font, new SolidBrush(color), location);
            }
            else
            {
                string text = partija.Igraci[2].KorisnickoIme;
                if (partija.Igraci[2].Aktivan == false)
                    text = partija.Igraci[2].KorisnickoIme + "\nIspao";
                Font font = new Font("Pixelify Sans", 28, FontStyle.Bold);
                Color color = Color.FromArgb(138, 111, 48);
                PointF location = new PointF(21f, 35f);
                e.Graphics.DrawString(text, font, new SolidBrush(color), location);

                string text2 = "Ostalo brodova : " + partija.Igraci[2].SumirajBrodove() + "/" + brojBrodova.ToString();
                Font font2 = new Font("Pixelify Sans", 20, FontStyle.Bold);
                Color color2 = Color.FromArgb(138, 111, 48);
                PointF location2 = new PointF(24f, 108f);
                e.Graphics.DrawString(text2, font2, new SolidBrush(color2), location2);
            }
        }

        private void player4_Paint(object sender, PaintEventArgs e)
        {
            if (partija.Igraci.Count < 4)
            {
                string text = "Nema igraca";
                Font font = new Font("Pixelify Sans", 28, FontStyle.Bold);
                Color color = Color.FromArgb(168, 141, 88);
                PointF location = new PointF(21f, 55f);
                e.Graphics.DrawString(text, font, new SolidBrush(color), location);
            }
            else
            {
                string text = partija.Igraci[3].KorisnickoIme;
                if (partija.Igraci[3].Aktivan == false)
                    text = partija.Igraci[3].KorisnickoIme + "\nIspao";
                Font font = new Font("Pixelify Sans", 28, FontStyle.Bold);
                Color color = Color.FromArgb(138, 111, 48);
                PointF location = new PointF(21f, 35f);
                e.Graphics.DrawString(text, font, new SolidBrush(color), location);

                string text2 = "Ostalo brodova : " + partija.Igraci[3].SumirajBrodove() + "/" + brojBrodova.ToString();
                Font font2 = new Font("Pixelify Sans", 20, FontStyle.Bold);
                Color color2 = Color.FromArgb(138, 111, 48);
                PointF location2 = new PointF(24f, 108f);
                e.Graphics.DrawString(text2, font2, new SolidBrush(color2), location2);
            }
        }
        #endregion

        //Kao ni ovaj

        #region Rotiranje brodica
        private void boat1x1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (rotated[0] == 0)
                {
                    boat1x1.BackgroundImage = Properties.Resources._1x1_boat_vertical;
                    rotated[0] = 1;
                }
                else if (rotated[0] == 1)
                {
                    boat1x1.BackgroundImage = Properties.Resources._1x1_boat_horizontal;
                    rotated[0] = 0;
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (tB1x1.Text == "1")
                {
                    selectedShip = 1;
                    changePicture();
                }
                else
                {
                    MessageBox.Show("Ovaj brod ste vec postavili");
                }
            }
        }

        private void boat2x1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int posX = boat2x1.Location.X;
                int posY = boat2x1.Location.Y;
                int sizeX = boat2x1.Size.Width;
                int sizeY = boat2x1.Size.Height;
                int razlika = (Math.Abs(sizeX - sizeY) / 2) + 1;
                if (rotated[1] == 0)
                {
                    boat2x1.BackgroundImage = Properties.Resources._2x1_boat_vertical;
                    boat2x1.Location = new Point(posX + razlika, posY - razlika);
                    rotated[1] = 1;
                }
                else if (rotated[1] == 1)
                {
                    boat2x1.BackgroundImage = Properties.Resources._2x1_boat_horizontal;
                    boat2x1.Location = new Point(posX - razlika, posY + razlika);
                    rotated[1] = 0;
                }
                boat2x1.Size = new Size(sizeY, sizeX);
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (tB2x1.Text == "1")
                {
                    selectedShip = 2;
                    changePicture();
                }
                else
                {
                    MessageBox.Show("Ovaj brod ste vec postavili");
                }
            }
        }

        private void boat3x1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int posX = boat3x1.Location.X;
                int posY = boat3x1.Location.Y;
                int sizeX = boat3x1.Size.Width;
                int sizeY = boat3x1.Size.Height;
                int razlika = (Math.Abs(sizeX - sizeY) / 2) + 1;
                if (rotated[2] == 0)
                {
                    boat3x1.BackgroundImage = Properties.Resources._3x1_boat_vertical;
                    boat3x1.Location = new Point(posX + razlika, posY - razlika);
                    rotated[2] = 1;
                }
                else if (rotated[2] == 1)
                {
                    boat3x1.BackgroundImage = Properties.Resources._3x1_boat_horizontal;
                    boat3x1.Location = new Point(posX - razlika, posY + razlika);
                    rotated[2] = 0;
                }
                boat3x1.Size = new Size(sizeY, sizeX);
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (tB3x1.Text == "1")
                {
                    selectedShip = 3;
                    changePicture();
                }
                else
                {
                    MessageBox.Show("Ovaj brod ste vec postavili");
                }
            }
        }

        private void boat4x1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int posX = boat4x1.Location.X;
                int posY = boat4x1.Location.Y;
                int sizeX = boat4x1.Size.Width;
                int sizeY = boat4x1.Size.Height;
                int razlika = (Math.Abs(sizeX - sizeY) / 2) + 1;
                if (rotated[3] == 0)
                {
                    boat4x1.BackgroundImage = Properties.Resources._4x1_boat_vertical;
                    boat4x1.Location = new Point(posX + razlika, posY - razlika);
                    rotated[3] = 1;
                }
                else if (rotated[3] == 1)
                {
                    boat4x1.BackgroundImage = Properties.Resources._4x1_boat_horizontal;
                    boat4x1.Location = new Point(posX - razlika, posY + razlika);
                    rotated[3] = 0;
                }
                boat4x1.Size = new Size(sizeY, sizeX);
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (tB4x1.Text == "1")
                {
                    selectedShip = 4;
                    changePicture();
                }
                else
                {
                    MessageBox.Show("Ovaj brod ste vec postavili");
                }
            }
        }

        private void boat5x1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int posX = boat5x1.Location.X;
                int posY = boat5x1.Location.Y;
                int sizeX = boat5x1.Size.Width;
                int sizeY = boat5x1.Size.Height;
                int razlika = (Math.Abs(sizeX - sizeY) / 2) + 1;
                if (rotated[4] == 0)
                {
                    boat5x1.BackgroundImage = Properties.Resources._5x1_boat_vertical;
                    boat5x1.Location = new Point(posX + razlika, posY - razlika);
                    rotated[4] = 1;
                }
                else if (rotated[4] == 1)
                {
                    boat5x1.BackgroundImage = Properties.Resources._5x1_boat_horizontal;
                    boat5x1.Location = new Point(posX - razlika, posY + razlika);
                    rotated[4] = 0;
                }
                boat5x1.Size = new Size(sizeY, sizeX);
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (tB5x1.Text == "1")
                {
                    selectedShip = 5;
                    changePicture();
                }
                else
                {
                    MessageBox.Show("Ovaj brod ste vec postavili");
                }
            }
        }

        private void changePicture()
        {
            switch (selectedShip)
            {
                case 1:
                    if (rotated[0] == 0)
                    {
                        selectedBoat.BackgroundImage = Properties.Resources._1x1_boat_horizontal;
                    }
                    else if (rotated[0] == 1)
                    {
                        selectedBoat.BackgroundImage = Properties.Resources._1x1_boat_vertical;
                    }
                    break;

                case 2:
                    if (rotated[1] == 0)
                    {
                        selectedBoat.BackgroundImage = Properties.Resources._2x1_boat_horizontal;
                    }
                    else if (rotated[1] == 1)
                    {
                        selectedBoat.BackgroundImage = Properties.Resources._2x1_boat_vertical;
                    }
                    break;

                case 3:
                    if (rotated[2] == 0)
                    {
                        selectedBoat.BackgroundImage = Properties.Resources._3x1_boat_horizontal;
                    }
                    else if (rotated[2] == 1)
                    {
                        selectedBoat.BackgroundImage = Properties.Resources._3x1_boat_vertical;
                    }
                    break;

                case 4:
                    if (rotated[3] == 0)
                    {
                        selectedBoat.BackgroundImage = Properties.Resources._4x1_boat_horizontal;
                    }
                    else if (rotated[3] == 1)
                    {
                        selectedBoat.BackgroundImage = Properties.Resources._4x1_boat_vertical;
                    }
                    break;

                case 5:
                    if (rotated[4] == 0)
                    {
                        selectedBoat.BackgroundImage = Properties.Resources._5x1_boat_horizontal;
                    }
                    else if (rotated[4] == 1)
                    {
                        selectedBoat.BackgroundImage = Properties.Resources._5x1_boat_vertical;
                    }
                    break;
            }
        }
        #endregion

        #region Timer
        private void timerVreme_Tick(object sender, EventArgs e)
        {
            //Samo logika za tajmer, gde se salju podaci kad istekne vreme
            int brodovi = Convert.ToInt32(tB1x1.Text) + Convert.ToInt32(tB2x1.Text) + Convert.ToInt32(tB3x1.Text) + Convert.ToInt32(tB4x1.Text) + Convert.ToInt32(tB5x1.Text);
            if (preostaloVreme == -1 && brodovi != 0)
            {
                preostaloVreme = 60;
                igrac.Aktivan = false;
                btnBomb.Enabled = false;
                lblFaze.Text = "FAZA : BOMBE!";
                SendPlayerData();
                MessageBox.Show("Vreme je isteklo, a niste postavili dovoljno brodova, ispali ste iz igre!");
            }
            else if (preostaloVreme == -1 && brodovi == 0)
            {
                if(setUp == 0)
                {
                    SendPlayerData();
                    lblFaze.Text = "FAZA : BOMBE!";
                    //
                    preostaloVreme = 60;
                    setUp = 1;
                }
                else
                {
                    if(bombardovao == "")
                    {
                        preostaloVreme = 60;
                        igrac.Aktivan = false;
                        btnBomb.Enabled = false;
                        SendPlayerData();
                        MessageBox.Show("Vreme je isteklo, a niste nikoga bombardovali, ispali ste iz igre!");
                    }
                    else
                    {
                        preostaloVreme = 60;
                        bombardovao = "";
                        btnBomb.Enabled = true;
                    }

                }
                
            }
            if (preostaloVreme >= 60)
            {
                if (preostaloVreme - 60 < 10)
                    lblTimer.Text = "01:0" + (preostaloVreme - 60).ToString();
                else
                    lblTimer.Text = "01:" + (preostaloVreme - 60).ToString();

            }
            else
            {
                if (preostaloVreme < 10)
                    lblTimer.Text = "00:0" + preostaloVreme.ToString();
                else
                    lblTimer.Text = "00:" + preostaloVreme.ToString();
            }
            preostaloVreme--;
        }
        #endregion

        private byte[] ReceiveExact(Socket s, int count)
        {
            byte[] buffer = new byte[count];
            int received = 0;
            //Znaci ovo samo se zadrzava dok ne stigne cela poruka 
            while (received < count)
            {
                int n = s.Receive(buffer, received, count - received, SocketFlags.None);
                if (n == 0) return null; 
                received += n;
            }
            return buffer;
        }
        #region TCP Komunikacija
        private void ReceiveLoop(CancellationToken token)
        {
            byte[] buf = new byte[4096];

            while (!token.IsCancellationRequested)
            {
                Socket s = clientSocket;
                if (s == null) break;
                string text= "";
                try
                {   
                        //Lenfth je 4 (int duzin paketa)
                        byte[] lenBuf = ReceiveExact(s, 4);
                        if (lenBuf == null)
                        {
                            MessageBox.Show("Server je zatvorio konekciju.");
                            Disconnect();
                            this.Invoke(new MethodInvoker(delegate { this.Close(); }));
                            break;
                        }
                        int length = BitConverter.ToInt32(lenBuf, 0);

                        //podaci su duzina lengtha
                        byte[] data = ReceiveExact(s, length);
                        if (data == null) break;

                        //Prvi karakter je tip 
                        byte msgType = data[0];
                        //Ako je text 
                        if (msgType == (byte)'T')
                        {
                            
                            text = Encoding.UTF8.GetString(data, 1, data.Length - 1);
                            rTBUpdates.Invoke(new MethodInvoker(delegate { rTBUpdates.Text += "\n" + text; }));
                            if (string.Compare(text, "Igra se zavrsila dali zelite da igrate opet? pritisni dugme") == 0) {
                                Disconnect();
                            }
                        }
                        //Ako je partija 
                        else if (msgType == (byte)'P')
                        {
                      
                            using (MemoryStream ms = new MemoryStream(data, 1, data.Length - 1))
                            {
                                BinaryFormatter bf = new BinaryFormatter();
                                Partija primljeniPodaci = (Partija)bf.Deserialize(ms);
                                
                                if (primljeniPodaci != null)
                                {
                                    //Unbox partije plus display obe matrive 
                                    partija = primljeniPodaci;
                                    this.Invoke(new MethodInvoker(delegate
                                    {
                                        //Svoja matrica
                                        foreach (Igrac i in partija.Igraci)
                                        {
                                            if (i.IdIgraca == igrac.IdIgraca)
                                            {
                                                igrac = i;
                                                break;
                                            }
                                        }
                                        AzurirajSvojuTabelu();
                                        //protivnicka matrica 
                                        if (aktivanProtivnik != null && aktivanProtivnik.KorisnickoIme != "")
                                        {
                                            foreach (Igrac i in partija.Igraci)
                                            {
                                                if (i.IdIgraca == aktivanProtivnik.IdIgraca)
                                                {
                                                    aktivanProtivnik = i;
                                                    AzurirajTabeluNeprijatelja(aktivanProtivnik);
                                                    break;
                                                }
                                            }
                                        }
                                        this.Refresh();
                                    }));
                                }
                            }
                        }
                    }
                catch (SocketException ex)
                {
                    if (!token.IsCancellationRequested)
                        MessageBox.Show("SocketException: " + ex.SocketErrorCode);
                    break;
                }
                catch (Exception ex)
                {
                    if (!token.IsCancellationRequested)
                        MessageBox.Show("Receive error: " + ex.Message);
                    break;
                }
            }
        }
        //Logika za odjavu
        private void Disconnect()
        {
            try
            {
                string msg = "[Diskonektovan : " + igrac.IdIgraca + " : " + igrac.KorisnickoIme + "]";
                byte[] data = Encoding.UTF8.GetBytes(msg);
                clientSocket.Send(data);
                if (_cts != null) _cts.Cancel();

                if (clientSocket != null)
                {
                    try { clientSocket.Shutdown(SocketShutdown.Both); } catch { }
                    try { clientSocket.Close(); } catch { }
                }
                clientSocket = null;


                MessageBox.Show("Diskonektovan.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Disconnect error: " + ex.Message);
            }
        }
        //Sluzi za slanje poruke o bombardovanju
        private void SendCurrentMessage()
        {
            if (clientSocket == null) return;

            if (bombardovao.Length == 0) return;

            try
            {
                byte[] data = Encoding.UTF8.GetBytes(bombardovao);
                clientSocket.Send(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Send failed: " + ex.Message);
                Disconnect();
            }
        }

        private void SendPlayerData()
        {
            if (clientSocket == null) return;

            byte[] data = new byte[4096];
            try
            {
                //Pretvara partiju u bajtove i salje
                using (MemoryStream ms = new MemoryStream())
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(ms, igrac);
                    data = ms.ToArray();
                }
                //Posaljem prvo duzinu da bih zano kako dalje
                clientSocket.Send(data);
            }
            catch
            {
                MessageBox.Show("Greska pri slanju informacija!");
            }
        }


        #endregion
        //Logika za bombardovanje, proverava da li je selektovan igrac i njegovo polje, ako jeste, onda se salje poruka serveru
        private void btnBomb_Click(object sender, EventArgs e)
        {
            if(setUp == 0)
            {
                MessageBox.Show("Jos je faza planiranja, ne mozete da bombardujete druge!");
            }
            else
            {
                if (aktivanProtivnik.KorisnickoIme == "" || izabranoPolje == "")
                {
                    MessageBox.Show("Niste odabrali igraca/polje!");
                }
                else
                {
                    bombardovao = igrac.KorisnickoIme + "->" + aktivanProtivnik.KorisnickoIme + ":" + izabranoPolje;
                    SendCurrentMessage();
                    btnBomb.Enabled = false;
                }
            }
        }

        private void odustaniBtn_Click(object sender, EventArgs e)
        {
           /* //Slanje poruke da odustaje 
            if (endFlag && clientSocket.Connected == true) {
                try
                {
                    string text = "Ne Igram";
                    byte[] bytes = new byte[4096];
                    bytes = Encoding.UTF8.GetBytes(text);
                    clientSocket.Send(bytes);
                }catch {
                    MessageBox.Show("Server je vec zatvorio konekciju");
                }
            }*/
        }

        private void igrajPonovoBtn_Click(object sender, EventArgs e)
        {
            /*
            //Slanje poruke da je sve ok 
            if (endFlag && clientSocket.Connected == true)
            {
                try
                {
                    string text = "Igram";
                    byte[] bytes = new byte[4096];
                    bytes = Encoding.UTF8.GetBytes(text);
                    clientSocket.Send(bytes);
                }
                catch
                {
                    MessageBox.Show("Server je vec zatvorio konekciju");
                }*/
            //}
        }
    }
}
