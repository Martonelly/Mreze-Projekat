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
            this.DimenzijeBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            // DimenzijeBox
            // 
            this.DimenzijeBox.Location = new System.Drawing.Point(345, 388);
            this.DimenzijeBox.Name = "DimenzijeBox";
            this.DimenzijeBox.Size = new System.Drawing.Size(100, 22);
            this.DimenzijeBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(346, 369);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Dimenzije(6-10)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DimenzijeBox);
            this.Controls.Add(this.IgracBox);
            this.Controls.Add(this.openServer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.Button openServer;
        private System.Windows.Forms.ComboBox IgracBox;
        private System.Windows.Forms.TextBox DimenzijeBox;
        private System.Windows.Forms.Label label1;
    }
}

