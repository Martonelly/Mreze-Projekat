using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class IgraUToku : Form
    {
        public List<PictureBox> pictureBoxes = new List<PictureBox>();
        public List<PictureBox> enemyPictureBoxes = new List<PictureBox>();
        int brojBrodova { get; set; }

        Partija partija = new Partija();
        public int Dimenzija { get; set; }
        int selected = 0;
        public IgraUToku()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ExitConfirm forma = new ExitConfirm();
            DialogResult izlaz = forma.ShowDialog();
            if(izlaz == DialogResult.OK)
            {
                this.Close();
            }

        }

        private void IgraUToku_Load(object sender, EventArgs e)
        {
            CreateImages(Dimenzija, 'e');
            CreateImages(Dimenzija, 'y');
            partija.Igraci.Add(new Igrac(123, "Durao"));
            partija.Igraci.Add(new Igrac(456, "Martonelly"));
            partija.Igraci.Add(new Igrac());
            partija.Igraci.Add(new Igrac());

        }

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
                    if(which == 'y')
                    {
                        pictureBox.Location = new Point(lblYou.Location.X + j * 32, (dimenzija + 5) * 32 + 12 + (i - 64) * 32);
                    }
                    else
                    {
                        pictureBox.Location = new Point(lblEnemy.Location.X + j * 32, 64 + (i - 64) * 32);
                    }
                    pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
                    string name;
                    if(which == 'y')
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
                    pictureBox.MouseDown += new MouseEventHandler(ImageClick);
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
                MessageBox.Show(pictureBox.Name);
                /*char startRow;
                int startCol;
                int checker1 = Convert.ToInt32(pictureBox.Name[pictureBox.Name.Length - 1]) - 48;
                int checker2 = Convert.ToInt32(pictureBox.Name[pictureBox.Name.Length - 2]) - 48;
                if (checker2 == 1 && checker1 == 0)
                {
                    startRow = pictureBox.Name[pictureBox.Name.Length - 3];
                    placeShip(selected, startRow, 10);
                }
                else
                {
                    startRow = pictureBox.Name[pictureBox.Name.Length - 2];
                    startCol = Convert.ToInt32(pictureBox.Name[pictureBox.Name.Length - 1]) - 48;
                    placeShip(selected, startRow, startCol);
                }*/

            }
        }

        private void placeShip(int selected, char startRow, int startColumn)
        {
            
        }
        #endregion

        #region Prikaz drugih matrica
        private void player1_Click(object sender, EventArgs e)
        {

        }

        private void player2_Click(object sender, EventArgs e)
        {

        }

        private void player3_Click(object sender, EventArgs e)
        {

        }

        private void player4_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Prikaz imena na listi igraca
        private void player1_Paint(object sender, PaintEventArgs e)
        {
            if (partija.Igraci[0].KorisnickoIme != "")
            {
                string text = partija.Igraci[0].KorisnickoIme;
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
            else
            {
                string text = "Nema igraca";
                Font font = new Font("Pixelify Sans", 28, FontStyle.Bold);
                Color color = Color.FromArgb(168, 141, 88);
                PointF location = new PointF(21f, 55f);
                e.Graphics.DrawString(text, font, new SolidBrush(color), location);
            }
        }

        private void player2_Paint(object sender, PaintEventArgs e)
        {
            if (partija.Igraci[1].KorisnickoIme != "")
            {
                string text = partija.Igraci[1].KorisnickoIme;
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
            else
            {
                string text = "Nema igraca";
                Font font = new Font("Pixelify Sans", 28, FontStyle.Bold);
                Color color = Color.FromArgb(168, 141, 88);
                PointF location = new PointF(21f, 55f);
                e.Graphics.DrawString(text, font, new SolidBrush(color), location);
            }
        }

        private void player3_Paint(object sender, PaintEventArgs e)
        {
            if (partija.Igraci[2].KorisnickoIme != "")
            {
                string text = partija.Igraci[2].KorisnickoIme;
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
            else
            {
                string text = "Nema igraca";
                Font font = new Font("Pixelify Sans", 28, FontStyle.Bold);
                Color color = Color.FromArgb(168, 141, 88);
                PointF location = new PointF(21f, 55f);
                e.Graphics.DrawString(text, font, new SolidBrush(color), location);
            }
        }

        private void player4_Paint(object sender, PaintEventArgs e)
        {
            if (partija.Igraci[3].KorisnickoIme != "")
            {
                string text = partija.Igraci[3].KorisnickoIme;
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
            else
            {
                string text = "Nema igraca";
                Font font = new Font("Pixelify Sans", 28, FontStyle.Bold);
                Color color = Color.FromArgb(168, 141, 88);
                PointF location = new PointF(21f, 55f);
                e.Graphics.DrawString(text, font, new SolidBrush(color), location);
            }
        }
        #endregion
    }
}
