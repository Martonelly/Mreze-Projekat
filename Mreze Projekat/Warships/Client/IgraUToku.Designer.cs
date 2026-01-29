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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IgraUToku));
            this.btnExit = new System.Windows.Forms.Button();
            this.lblEnemy = new System.Windows.Forms.Label();
            this.lblYou = new System.Windows.Forms.Label();
            this.playerHolder = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.player1 = new System.Windows.Forms.PictureBox();
            this.player2 = new System.Windows.Forms.PictureBox();
            this.player3 = new System.Windows.Forms.PictureBox();
            this.player4 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.playerHolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player4)).BeginInit();
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
            this.lblEnemy.Location = new System.Drawing.Point(680, 12);
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
            this.lblYou.Location = new System.Drawing.Point(680, 533);
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
            this.playerHolder.Size = new System.Drawing.Size(486, 969);
            this.playerHolder.TabIndex = 3;
            this.playerHolder.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(680, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(480, 440);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(680, 593);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(480, 440);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // player1
            // 
            this.player1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.player1.BackgroundImage = global::Client.Properties.Resources.sand_tile_lighter;
            this.player1.Location = new System.Drawing.Point(1458, 128);
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
            this.player2.Location = new System.Drawing.Point(1458, 365);
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
            this.player3.Location = new System.Drawing.Point(1458, 609);
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
            this.player4.Location = new System.Drawing.Point(1458, 853);
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
            this.label2.Size = new System.Drawing.Size(293, 41);
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
            // IgraUToku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client.Properties.Resources.sand_tile_lighter;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.player4);
            this.Controls.Add(this.player3);
            this.Controls.Add(this.player2);
            this.Controls.Add(this.player1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblEnemy;
        private System.Windows.Forms.Label lblYou;
        private System.Windows.Forms.PictureBox playerHolder;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox player1;
        private System.Windows.Forms.PictureBox player2;
        private System.Windows.Forms.PictureBox player3;
        private System.Windows.Forms.PictureBox player4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}