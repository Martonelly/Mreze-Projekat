namespace Client
{
    partial class Prijava
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Prijava));
            this.btnPotvrda = new System.Windows.Forms.Button();
            this.txtBoxIme = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPotvrda
            // 
            this.btnPotvrda.BackgroundImage = global::Client.Properties.Resources.button;
            this.btnPotvrda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPotvrda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPotvrda.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPotvrda.Font = new System.Drawing.Font("Pixelify Sans", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPotvrda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(111)))), ((int)(((byte)(48)))));
            this.btnPotvrda.Location = new System.Drawing.Point(122, 137);
            this.btnPotvrda.Name = "btnPotvrda";
            this.btnPotvrda.Size = new System.Drawing.Size(302, 55);
            this.btnPotvrda.TabIndex = 0;
            this.btnPotvrda.TabStop = false;
            this.btnPotvrda.Text = "POTVRDI";
            this.btnPotvrda.UseVisualStyleBackColor = true;
            this.btnPotvrda.Click += new System.EventHandler(this.btnPrijava_Click);
            // 
            // txtBoxIme
            // 
            this.txtBoxIme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(190)))), ((int)(((byte)(117)))));
            this.txtBoxIme.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxIme.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBoxIme.Font = new System.Drawing.Font("Pixelify Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxIme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(111)))), ((int)(((byte)(48)))));
            this.txtBoxIme.Location = new System.Drawing.Point(122, 61);
            this.txtBoxIme.Name = "txtBoxIme";
            this.txtBoxIme.Size = new System.Drawing.Size(302, 21);
            this.txtBoxIme.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Pixelify Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(111)))), ((int)(((byte)(48)))));
            this.label1.Location = new System.Drawing.Point(118, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Unesite vase ime : ";
            // 
            // Prijava
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client.Properties.Resources.sand_tile;
            this.ClientSize = new System.Drawing.Size(541, 204);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxIme);
            this.Controls.Add(this.btnPotvrda);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(559, 251);
            this.MinimumSize = new System.Drawing.Size(559, 251);
            this.Name = "Prijava";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prijava";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPotvrda;
        private System.Windows.Forms.TextBox txtBoxIme;
        private System.Windows.Forms.Label label1;
    }
}