namespace Client
{
    partial class Cekaonica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cekaonica));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblIgraci = new System.Windows.Forms.Label();
            this.lblServer = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMatrica = new System.Windows.Forms.Label();
            this.player1 = new System.Windows.Forms.PictureBox();
            this.player2 = new System.Windows.Forms.PictureBox();
            this.player3 = new System.Windows.Forms.PictureBox();
            this.player4 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player4)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Client.Properties.Resources.sand_tile_darker;
            this.pictureBox1.Location = new System.Drawing.Point(199, 86);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(199, 307);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = global::Client.Properties.Resources.rotate;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Location = new System.Drawing.Point(366, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(32, 32);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblIgraci
            // 
            this.lblIgraci.AutoSize = true;
            this.lblIgraci.BackColor = System.Drawing.Color.Transparent;
            this.lblIgraci.Font = new System.Drawing.Font("Pixelify Sans", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIgraci.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(111)))), ((int)(((byte)(48)))));
            this.lblIgraci.Location = new System.Drawing.Point(195, 61);
            this.lblIgraci.Name = "lblIgraci";
            this.lblIgraci.Size = new System.Drawing.Size(189, 22);
            this.lblIgraci.TabIndex = 2;
            this.lblIgraci.Text = "PRIJAVLJENI IGRACI";
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.BackColor = System.Drawing.Color.Transparent;
            this.lblServer.Font = new System.Drawing.Font("Pixelify Sans", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(111)))), ((int)(((byte)(48)))));
            this.lblServer.Location = new System.Drawing.Point(12, 12);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(159, 40);
            this.lblServer.TabIndex = 3;
            this.lblServer.Text = "SERVER : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Pixelify Sans SemiBold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(111)))), ((int)(((byte)(48)))));
            this.label1.Location = new System.Drawing.Point(13, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Informacije o partiji";
            // 
            // lblMatrica
            // 
            this.lblMatrica.AutoSize = true;
            this.lblMatrica.BackColor = System.Drawing.Color.Transparent;
            this.lblMatrica.Font = new System.Drawing.Font("Pixelify Sans SemiBold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatrica.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(111)))), ((int)(((byte)(48)))));
            this.lblMatrica.Location = new System.Drawing.Point(16, 125);
            this.lblMatrica.Name = "lblMatrica";
            this.lblMatrica.Size = new System.Drawing.Size(71, 16);
            this.lblMatrica.TabIndex = 5;
            this.lblMatrica.Text = "Matrica : ";
            // 
            // player1
            // 
            this.player1.BackgroundImage = global::Client.Properties.Resources.sand_tile_lighter;
            this.player1.Location = new System.Drawing.Point(210, 102);
            this.player1.Name = "player1";
            this.player1.Size = new System.Drawing.Size(176, 50);
            this.player1.TabIndex = 6;
            this.player1.TabStop = false;
            this.player1.Paint += new System.Windows.Forms.PaintEventHandler(this.player1_Paint);
            // 
            // player2
            // 
            this.player2.BackgroundImage = global::Client.Properties.Resources.sand_tile_lighter;
            this.player2.Location = new System.Drawing.Point(210, 176);
            this.player2.Name = "player2";
            this.player2.Size = new System.Drawing.Size(176, 50);
            this.player2.TabIndex = 7;
            this.player2.TabStop = false;
            this.player2.Paint += new System.Windows.Forms.PaintEventHandler(this.player2_Paint);
            // 
            // player3
            // 
            this.player3.BackgroundImage = global::Client.Properties.Resources.sand_tile_lighter;
            this.player3.Location = new System.Drawing.Point(210, 250);
            this.player3.Name = "player3";
            this.player3.Size = new System.Drawing.Size(176, 50);
            this.player3.TabIndex = 8;
            this.player3.TabStop = false;
            this.player3.Paint += new System.Windows.Forms.PaintEventHandler(this.player3_Paint);
            // 
            // player4
            // 
            this.player4.BackgroundImage = global::Client.Properties.Resources.sand_tile_lighter;
            this.player4.Location = new System.Drawing.Point(210, 324);
            this.player4.Name = "player4";
            this.player4.Size = new System.Drawing.Size(176, 50);
            this.player4.TabIndex = 9;
            this.player4.TabStop = false;
            this.player4.Paint += new System.Windows.Forms.PaintEventHandler(this.player4_Paint);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(34, 324);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "START";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Cekaonica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client.Properties.Resources.sand_tile;
            this.ClientSize = new System.Drawing.Size(410, 402);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.player4);
            this.Controls.Add(this.player3);
            this.Controls.Add(this.player2);
            this.Controls.Add(this.player1);
            this.Controls.Add(this.lblMatrica);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.lblIgraci);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Cekaonica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cekaonica";
            this.Load += new System.EventHandler(this.Cekaonica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblIgraci;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMatrica;
        private System.Windows.Forms.PictureBox player1;
        private System.Windows.Forms.PictureBox player2;
        private System.Windows.Forms.PictureBox player3;
        private System.Windows.Forms.PictureBox player4;
        private System.Windows.Forms.Button button1;
    }
}