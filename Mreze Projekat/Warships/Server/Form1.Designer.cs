namespace Server
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openServer = new System.Windows.Forms.Button();
            this.IgracBox = new System.Windows.Forms.ComboBox();
            this.DimenzijeBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.rTBInfo = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // openServer
            // 
            this.openServer.BackgroundImage = global::Server.Properties.Resources.button;
            this.openServer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.openServer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.openServer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(111)))), ((int)(((byte)(48)))));
            this.openServer.Location = new System.Drawing.Point(12, 371);
            this.openServer.Name = "openServer";
            this.openServer.Size = new System.Drawing.Size(113, 57);
            this.openServer.TabIndex = 0;
            this.openServer.Text = "Start Server";
            this.openServer.UseVisualStyleBackColor = true;
            this.openServer.Click += new System.EventHandler(this.button1_Click);
            // 
            // IgracBox
            // 
            this.IgracBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            this.IgracBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.IgracBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(111)))), ((int)(((byte)(48)))));
            this.IgracBox.FormattingEnabled = true;
            this.IgracBox.Location = new System.Drawing.Point(160, 388);
            this.IgracBox.Name = "IgracBox";
            this.IgracBox.Size = new System.Drawing.Size(121, 24);
            this.IgracBox.TabIndex = 1;
            this.IgracBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // DimenzijeBox
            // 
            this.DimenzijeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            this.DimenzijeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DimenzijeBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(111)))), ((int)(((byte)(48)))));
            this.DimenzijeBox.Location = new System.Drawing.Point(345, 388);
            this.DimenzijeBox.Name = "DimenzijeBox";
            this.DimenzijeBox.Size = new System.Drawing.Size(100, 22);
            this.DimenzijeBox.TabIndex = 3;
            this.DimenzijeBox.Text = "10";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(111)))), ((int)(((byte)(48)))));
            this.label1.Location = new System.Drawing.Point(346, 369);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Dimenzije(6-10)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(111)))), ((int)(((byte)(48)))));
            this.label2.Location = new System.Drawing.Point(486, 369);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Broj uzastopnih promasaja";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            this.numericUpDown1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(111)))), ((int)(((byte)(48)))));
            this.numericUpDown1.Location = new System.Drawing.Point(489, 387);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(55, 22);
            this.numericUpDown1.TabIndex = 6;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // rTBInfo
            // 
            this.rTBInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            this.rTBInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rTBInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(111)))), ((int)(((byte)(48)))));
            this.rTBInfo.Location = new System.Drawing.Point(13, 13);
            this.rTBInfo.Name = "rTBInfo";
            this.rTBInfo.Size = new System.Drawing.Size(731, 336);
            this.rTBInfo.TabIndex = 9;
            this.rTBInfo.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Server.Properties.Resources.sand_tile_lighter;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rTBInfo);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DimenzijeBox);
            this.Controls.Add(this.IgracBox);
            this.Controls.Add(this.openServer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(818, 497);
            this.MinimumSize = new System.Drawing.Size(818, 497);
            this.Name = "Form1";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.Button openServer;
        private System.Windows.Forms.ComboBox IgracBox;
        private System.Windows.Forms.TextBox DimenzijeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.RichTextBox rTBInfo;
    }
}

