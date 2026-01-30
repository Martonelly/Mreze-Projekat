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
            this.openServer = new System.Windows.Forms.Button();
            this.IgracBox = new System.Windows.Forms.ComboBox();
            this.StartGameBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openServer
            // 
            this.openServer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
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
            this.IgracBox.FormattingEnabled = true;
            this.IgracBox.Location = new System.Drawing.Point(160, 388);
            this.IgracBox.Name = "IgracBox";
            this.IgracBox.Size = new System.Drawing.Size(121, 24);
            this.IgracBox.TabIndex = 1;
            this.IgracBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // StartGameBtn
            // 
            this.StartGameBtn.Location = new System.Drawing.Point(690, 371);
            this.StartGameBtn.Name = "StartGameBtn";
            this.StartGameBtn.Size = new System.Drawing.Size(98, 57);
            this.StartGameBtn.TabIndex = 2;
            this.StartGameBtn.Text = "Start Game";
            this.StartGameBtn.UseVisualStyleBackColor = true;
            this.StartGameBtn.Click += new System.EventHandler(this.StartGameBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.StartGameBtn);
            this.Controls.Add(this.IgracBox);
            this.Controls.Add(this.openServer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }



        #endregion

        private System.Windows.Forms.Button openServer;
        private System.Windows.Forms.ComboBox IgracBox;
        private System.Windows.Forms.Button StartGameBtn;
    }
}

