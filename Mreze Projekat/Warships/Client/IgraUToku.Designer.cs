namespace Client
{
    partial class IgraUToku
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IgraUToku));
            this.btnExit = new System.Windows.Forms.Button();
            this.lblEnemy = new System.Windows.Forms.Label();
            this.lblYou = new System.Windows.Forms.Label();
            this.playerHolder = new System.Windows.Forms.PictureBox();
            this.player1 = new System.Windows.Forms.PictureBox();
            this.player2 = new System.Windows.Forms.PictureBox();
            this.player3 = new System.Windows.Forms.PictureBox();
            this.player4 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rTBUpdates = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.boat5x1 = new System.Windows.Forms.PictureBox();
            this.boat4x1 = new System.Windows.Forms.PictureBox();
            this.boat3x1 = new System.Windows.Forms.PictureBox();
            this.boat2x1 = new System.Windows.Forms.PictureBox();
            this.boat1x1 = new System.Windows.Forms.PictureBox();
            this.tB5x1 = new System.Windows.Forms.TextBox();
            this.tB4x1 = new System.Windows.Forms.TextBox();
            this.tB3x1 = new System.Windows.Forms.TextBox();
            this.tB2x1 = new System.Windows.Forms.TextBox();
            this.tB1x1 = new System.Windows.Forms.TextBox();
            this.selectedBoat = new System.Windows.Forms.PictureBox();
            this.lblSelectedBoat = new System.Windows.Forms.Label();
            this.lblFaze = new System.Windows.Forms.Label();
            this.lblVreme = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.timerVreme = new System.Windows.Forms.Timer(this.components);
            this.btnBomb = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.playerHolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boat5x1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boat4x1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boat3x1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boat2x1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boat1x1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedBoat)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackgroundImage = global::Client.Properties.Resources.exit;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExit.Location = new System.Drawing.Point(1828, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 80);
            this.btnExit.TabIndex = 0;
            this.btnExit.TabStop = false;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblEnemy
            // 
            this.lblEnemy.AutoSize = true;
            this.lblEnemy.BackColor = System.Drawing.Color.Transparent;
            this.lblEnemy.Font = new System.Drawing.Font("Pixelify Sans", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnemy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(111)))), ((int)(((byte)(48)))));
            this.lblEnemy.Location = new System.Drawing.Point(521, 14);
            this.lblEnemy.Name = "lblEnemy";
            this.lblEnemy.Size = new System.Drawing.Size(214, 57);
            this.lblEnemy.TabIndex = 1;
            this.lblEnemy.Text = "\'S TABLA";
            this.lblEnemy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblYou
            // 
            this.lblYou.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblYou.AutoSize = true;
            this.lblYou.BackColor = System.Drawing.Color.Transparent;
            this.lblYou.Font = new System.Drawing.Font("Pixelify Sans", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYou.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(111)))), ((int)(((byte)(48)))));
            this.lblYou.Location = new System.Drawing.Point(521, 519);
            this.lblYou.Name = "lblYou";
            this.lblYou.Size = new System.Drawing.Size(283, 57);
            this.lblYou.TabIndex = 2;
            this.lblYou.Text = "VASA TABLA";
            this.lblYou.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playerHolder
            // 
            this.playerHolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playerHolder.BackgroundImage = global::Client.Properties.Resources.sand_tile_darker;
            this.playerHolder.Location = new System.Drawing.Point(1421, 99);
            this.playerHolder.Name = "playerHolder";
            this.playerHolder.Size = new System.Drawing.Size(486, 944);
            this.playerHolder.TabIndex = 3;
            this.playerHolder.TabStop = false;
            // 
            // player1
            // 
            this.player1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.player1.BackgroundImage = global::Client.Properties.Resources.sand_tile_lighter;
            this.player1.Location = new System.Drawing.Point(1458, 115);
            this.player1.Name = "player1";
            this.player1.Size = new System.Drawing.Size(418, 180);
            this.player1.TabIndex = 6;
            this.player1.TabStop = false;
            this.player1.Click += new System.EventHandler(this.player1_Click);
            this.player1.Paint += new System.Windows.Forms.PaintEventHandler(this.player1_Paint);
            // 
            // player2
            // 
            this.player2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.player2.BackgroundImage = global::Client.Properties.Resources.sand_tile_lighter;
            this.player2.Location = new System.Drawing.Point(1458, 352);
            this.player2.Name = "player2";
            this.player2.Size = new System.Drawing.Size(418, 180);
            this.player2.TabIndex = 7;
            this.player2.TabStop = false;
            this.player2.Click += new System.EventHandler(this.player2_Click);
            this.player2.Paint += new System.Windows.Forms.PaintEventHandler(this.player2_Paint);
            // 
            // player3
            // 
            this.player3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.player3.BackgroundImage = global::Client.Properties.Resources.sand_tile_lighter;
            this.player3.Location = new System.Drawing.Point(1458, 596);
            this.player3.Name = "player3";
            this.player3.Size = new System.Drawing.Size(418, 180);
            this.player3.TabIndex = 8;
            this.player3.TabStop = false;
            this.player3.Click += new System.EventHandler(this.player3_Click);
            this.player3.Paint += new System.Windows.Forms.PaintEventHandler(this.player3_Paint);
            // 
            // player4
            // 
            this.player4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.player4.BackgroundImage = global::Client.Properties.Resources.sand_tile_lighter;
            this.player4.Location = new System.Drawing.Point(1458, 840);
            this.player4.Name = "player4";
            this.player4.Size = new System.Drawing.Size(418, 180);
            this.player4.TabIndex = 9;
            this.player4.TabStop = false;
            this.player4.Click += new System.EventHandler(this.player4_Click);
            this.player4.Paint += new System.Windows.Forms.PaintEventHandler(this.player4_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Pixelify Sans", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(111)))), ((int)(((byte)(48)))));
            this.label1.Location = new System.Drawing.Point(1479, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 57);
            this.label1.TabIndex = 10;
            this.label1.Text = "Player 1";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Pixelify Sans", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(111)))), ((int)(((byte)(48)))));
            this.label2.Location = new System.Drawing.Point(1482, 236);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(289, 40);
            this.label2.TabIndex = 11;
            this.label2.Text = "Ostalo brodova :";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Pixelify Sans", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(141)))), ((int)(((byte)(88)))));
            this.label3.Location = new System.Drawing.Point(1479, 425);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(316, 57);
            this.label3.TabIndex = 12;
            this.label3.Text = "Nema igraca";
            this.label3.Visible = false;
            // 
            // rTBUpdates
            // 
            this.rTBUpdates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rTBUpdates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            this.rTBUpdates.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rTBUpdates.CausesValidation = false;
            this.rTBUpdates.Font = new System.Drawing.Font("Pixelify Sans", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTBUpdates.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(111)))), ((int)(((byte)(48)))));
            this.rTBUpdates.Location = new System.Drawing.Point(1091, 99);
            this.rTBUpdates.Name = "rTBUpdates";
            this.rTBUpdates.ReadOnly = true;
            this.rTBUpdates.Size = new System.Drawing.Size(324, 383);
            this.rTBUpdates.TabIndex = 13;
            this.rTBUpdates.TabStop = false;
            this.rTBUpdates.Text = "";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Pixelify Sans", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(111)))), ((int)(((byte)(48)))));
            this.label4.Location = new System.Drawing.Point(1081, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(224, 57);
            this.label4.TabIndex = 14;
            this.label4.Text = "Updates";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // boat5x1
            // 
            this.boat5x1.BackColor = System.Drawing.Color.Transparent;
            this.boat5x1.BackgroundImage = global::Client.Properties.Resources._5x1_boat_horizontal;
            this.boat5x1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.boat5x1.Location = new System.Drawing.Point(44, 228);
            this.boat5x1.Name = "boat5x1";
            this.boat5x1.Size = new System.Drawing.Size(240, 48);
            this.boat5x1.TabIndex = 15;
            this.boat5x1.TabStop = false;
            this.boat5x1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.boat5x1_MouseDown);
            // 
            // boat4x1
            // 
            this.boat4x1.BackColor = System.Drawing.Color.Transparent;
            this.boat4x1.BackgroundImage = global::Client.Properties.Resources._4x1_boat_horizontal;
            this.boat4x1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.boat4x1.Location = new System.Drawing.Point(72, 497);
            this.boat4x1.Name = "boat4x1";
            this.boat4x1.Size = new System.Drawing.Size(192, 48);
            this.boat4x1.TabIndex = 16;
            this.boat4x1.TabStop = false;
            this.boat4x1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.boat4x1_MouseDown);
            // 
            // boat3x1
            // 
            this.boat3x1.BackColor = System.Drawing.Color.Transparent;
            this.boat3x1.BackgroundImage = global::Client.Properties.Resources._3x1_boat_horizontal;
            this.boat3x1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.boat3x1.Location = new System.Drawing.Point(92, 690);
            this.boat3x1.Name = "boat3x1";
            this.boat3x1.Size = new System.Drawing.Size(144, 48);
            this.boat3x1.TabIndex = 17;
            this.boat3x1.TabStop = false;
            this.boat3x1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.boat3x1_MouseDown);
            // 
            // boat2x1
            // 
            this.boat2x1.BackColor = System.Drawing.Color.Transparent;
            this.boat2x1.BackgroundImage = global::Client.Properties.Resources._2x1_boat_horizontal;
            this.boat2x1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.boat2x1.Location = new System.Drawing.Point(116, 853);
            this.boat2x1.Name = "boat2x1";
            this.boat2x1.Size = new System.Drawing.Size(96, 48);
            this.boat2x1.TabIndex = 18;
            this.boat2x1.TabStop = false;
            this.boat2x1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.boat2x1_MouseDown);
            // 
            // boat1x1
            // 
            this.boat1x1.BackColor = System.Drawing.Color.Transparent;
            this.boat1x1.BackgroundImage = global::Client.Properties.Resources._1x1_boat_horizontal;
            this.boat1x1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.boat1x1.Location = new System.Drawing.Point(140, 975);
            this.boat1x1.Name = "boat1x1";
            this.boat1x1.Size = new System.Drawing.Size(48, 48);
            this.boat1x1.TabIndex = 19;
            this.boat1x1.TabStop = false;
            this.boat1x1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.boat1x1_MouseDown);
            // 
            // tB5x1
            // 
            this.tB5x1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            this.tB5x1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tB5x1.CausesValidation = false;
            this.tB5x1.Font = new System.Drawing.Font("Pixelify Sans", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tB5x1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(111)))), ((int)(((byte)(48)))));
            this.tB5x1.Location = new System.Drawing.Point(332, 228);
            this.tB5x1.Multiline = true;
            this.tB5x1.Name = "tB5x1";
            this.tB5x1.ReadOnly = true;
            this.tB5x1.Size = new System.Drawing.Size(48, 48);
            this.tB5x1.TabIndex = 20;
            this.tB5x1.TabStop = false;
            this.tB5x1.Text = "1";
            this.tB5x1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tB4x1
            // 
            this.tB4x1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            this.tB4x1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tB4x1.CausesValidation = false;
            this.tB4x1.Font = new System.Drawing.Font("Pixelify Sans", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tB4x1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(111)))), ((int)(((byte)(48)))));
            this.tB4x1.Location = new System.Drawing.Point(332, 497);
            this.tB4x1.Multiline = true;
            this.tB4x1.Name = "tB4x1";
            this.tB4x1.ReadOnly = true;
            this.tB4x1.Size = new System.Drawing.Size(48, 48);
            this.tB4x1.TabIndex = 21;
            this.tB4x1.TabStop = false;
            this.tB4x1.Text = "1";
            this.tB4x1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tB3x1
            // 
            this.tB3x1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            this.tB3x1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tB3x1.CausesValidation = false;
            this.tB3x1.Font = new System.Drawing.Font("Pixelify Sans", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tB3x1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(111)))), ((int)(((byte)(48)))));
            this.tB3x1.Location = new System.Drawing.Point(332, 690);
            this.tB3x1.Multiline = true;
            this.tB3x1.Name = "tB3x1";
            this.tB3x1.ReadOnly = true;
            this.tB3x1.Size = new System.Drawing.Size(48, 48);
            this.tB3x1.TabIndex = 22;
            this.tB3x1.TabStop = false;
            this.tB3x1.Text = "1";
            this.tB3x1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tB2x1
            // 
            this.tB2x1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            this.tB2x1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tB2x1.CausesValidation = false;
            this.tB2x1.Font = new System.Drawing.Font("Pixelify Sans", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tB2x1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(111)))), ((int)(((byte)(48)))));
            this.tB2x1.Location = new System.Drawing.Point(332, 853);
            this.tB2x1.Multiline = true;
            this.tB2x1.Name = "tB2x1";
            this.tB2x1.ReadOnly = true;
            this.tB2x1.Size = new System.Drawing.Size(48, 48);
            this.tB2x1.TabIndex = 23;
            this.tB2x1.TabStop = false;
            this.tB2x1.Text = "1";
            this.tB2x1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tB1x1
            // 
            this.tB1x1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            this.tB1x1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tB1x1.CausesValidation = false;
            this.tB1x1.Font = new System.Drawing.Font("Pixelify Sans", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tB1x1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(111)))), ((int)(((byte)(48)))));
            this.tB1x1.Location = new System.Drawing.Point(332, 975);
            this.tB1x1.Multiline = true;
            this.tB1x1.Name = "tB1x1";
            this.tB1x1.ReadOnly = true;
            this.tB1x1.Size = new System.Drawing.Size(48, 48);
            this.tB1x1.TabIndex = 24;
            this.tB1x1.TabStop = false;
            this.tB1x1.Text = "1";
            this.tB1x1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // selectedBoat
            // 
            this.selectedBoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedBoat.BackColor = System.Drawing.Color.Transparent;
            this.selectedBoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.selectedBoat.Location = new System.Drawing.Point(935, 563);
            this.selectedBoat.Name = "selectedBoat";
            this.selectedBoat.Size = new System.Drawing.Size(480, 480);
            this.selectedBoat.TabIndex = 25;
            this.selectedBoat.TabStop = false;
            // 
            // lblSelectedBoat
            // 
            this.lblSelectedBoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedBoat.AutoSize = true;
            this.lblSelectedBoat.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectedBoat.Font = new System.Drawing.Font("Pixelify Sans", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedBoat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(111)))), ((int)(((byte)(48)))));
            this.lblSelectedBoat.Location = new System.Drawing.Point(928, 523);
            this.lblSelectedBoat.Name = "lblSelectedBoat";
            this.lblSelectedBoat.Size = new System.Drawing.Size(248, 37);
            this.lblSelectedBoat.TabIndex = 26;
            this.lblSelectedBoat.Text = "Selected boat : ";
            // 
            // lblFaze
            // 
            this.lblFaze.AutoSize = true;
            this.lblFaze.BackColor = System.Drawing.Color.Transparent;
            this.lblFaze.Font = new System.Drawing.Font("Pixelify Sans", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFaze.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(111)))), ((int)(((byte)(48)))));
            this.lblFaze.Location = new System.Drawing.Point(12, 14);
            this.lblFaze.Name = "lblFaze";
            this.lblFaze.Size = new System.Drawing.Size(436, 57);
            this.lblFaze.TabIndex = 28;
            this.lblFaze.Text = "FAZA : PLANIRANJE";
            this.lblFaze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVreme
            // 
            this.lblVreme.AutoSize = true;
            this.lblVreme.BackColor = System.Drawing.Color.Transparent;
            this.lblVreme.Font = new System.Drawing.Font("Pixelify Sans", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVreme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(111)))), ((int)(((byte)(48)))));
            this.lblVreme.Location = new System.Drawing.Point(14, 71);
            this.lblVreme.Name = "lblVreme";
            this.lblVreme.Size = new System.Drawing.Size(153, 45);
            this.lblVreme.TabIndex = 29;
            this.lblVreme.Text = "VREME :";
            this.lblVreme.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.BackColor = System.Drawing.Color.Transparent;
            this.lblTimer.Font = new System.Drawing.Font("Pixelify Sans", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(111)))), ((int)(((byte)(48)))));
            this.lblTimer.Location = new System.Drawing.Point(173, 71);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(117, 45);
            this.lblTimer.TabIndex = 30;
            this.lblTimer.Text = "00:00";
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerVreme
            // 
            this.timerVreme.Enabled = true;
            this.timerVreme.Interval = 1000;
            this.timerVreme.Tick += new System.EventHandler(this.timerVreme_Tick);
            // 
            // btnBomb
            // 
            this.btnBomb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBomb.BackgroundImage = global::Client.Properties.Resources.bomb;
            this.btnBomb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBomb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBomb.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBomb.Location = new System.Drawing.Point(989, 99);
            this.btnBomb.Name = "btnBomb";
            this.btnBomb.Size = new System.Drawing.Size(96, 96);
            this.btnBomb.TabIndex = 33;
            this.btnBomb.UseVisualStyleBackColor = true;
            this.btnBomb.Click += new System.EventHandler(this.btnBomb_Click);
            // 
            // IgraUToku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client.Properties.Resources.sand_tile_lighter;
            this.ClientSize = new System.Drawing.Size(1920, 1055);
            this.Controls.Add(this.btnBomb);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.lblVreme);
            this.Controls.Add(this.lblFaze);
            this.Controls.Add(this.lblSelectedBoat);
            this.Controls.Add(this.selectedBoat);
            this.Controls.Add(this.tB1x1);
            this.Controls.Add(this.tB2x1);
            this.Controls.Add(this.tB3x1);
            this.Controls.Add(this.tB4x1);
            this.Controls.Add(this.tB5x1);
            this.Controls.Add(this.boat1x1);
            this.Controls.Add(this.boat2x1);
            this.Controls.Add(this.boat3x1);
            this.Controls.Add(this.boat4x1);
            this.Controls.Add(this.boat5x1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rTBUpdates);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.player4);
            this.Controls.Add(this.player3);
            this.Controls.Add(this.player2);
            this.Controls.Add(this.player1);
            this.Controls.Add(this.playerHolder);
            this.Controls.Add(this.lblYou);
            this.Controls.Add(this.lblEnemy);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IgraUToku";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IgraUToku";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.IgraUToku_Load);
            ((System.ComponentModel.ISupportInitialize)(this.playerHolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boat5x1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boat4x1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boat3x1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boat2x1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boat1x1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedBoat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblEnemy;
        private System.Windows.Forms.Label lblYou;
        private System.Windows.Forms.PictureBox playerHolder;
        private System.Windows.Forms.PictureBox player1;
        private System.Windows.Forms.PictureBox player2;
        private System.Windows.Forms.PictureBox player3;
        private System.Windows.Forms.PictureBox player4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rTBUpdates;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox boat5x1;
        private System.Windows.Forms.PictureBox boat4x1;
        private System.Windows.Forms.PictureBox boat3x1;
        private System.Windows.Forms.PictureBox boat2x1;
        private System.Windows.Forms.PictureBox boat1x1;
        private System.Windows.Forms.TextBox tB5x1;
        private System.Windows.Forms.TextBox tB4x1;
        private System.Windows.Forms.TextBox tB3x1;
        private System.Windows.Forms.TextBox tB2x1;
        private System.Windows.Forms.TextBox tB1x1;
        private System.Windows.Forms.PictureBox selectedBoat;
        private System.Windows.Forms.Label lblSelectedBoat;
        private System.Windows.Forms.Label lblFaze;
        private System.Windows.Forms.Label lblVreme;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Timer timerVreme;
        private System.Windows.Forms.Button btnBomb;
    }
}