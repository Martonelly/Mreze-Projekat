namespace Client
{
    partial class ExitConfirm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExitConfirm));
            this.label1 = new System.Windows.Forms.Label();
            this.btnDa = new System.Windows.Forms.Button();
            this.btnNe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Pixelify Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(111)))), ((int)(((byte)(48)))));
            this.label1.Location = new System.Drawing.Point(52, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(416, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "DA LI STE SIGURNI DA ZELITE DA IZADJETE?\r\n";
            // 
            // btnDa
            // 
            this.btnDa.BackgroundImage = global::Client.Properties.Resources.button;
            this.btnDa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDa.Location = new System.Drawing.Point(31, 62);
            this.btnDa.Name = "btnDa";
            this.btnDa.Size = new System.Drawing.Size(211, 53);
            this.btnDa.TabIndex = 1;
            this.btnDa.TabStop = false;
            this.btnDa.Text = "DA";
            this.btnDa.UseVisualStyleBackColor = true;
            this.btnDa.Click += new System.EventHandler(this.btnDa_Click);
            // 
            // btnNe
            // 
            this.btnNe.BackgroundImage = global::Client.Properties.Resources.button;
            this.btnNe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNe.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNe.Location = new System.Drawing.Point(288, 62);
            this.btnNe.Name = "btnNe";
            this.btnNe.Size = new System.Drawing.Size(211, 53);
            this.btnNe.TabIndex = 2;
            this.btnNe.TabStop = false;
            this.btnNe.Text = "NE";
            this.btnNe.UseVisualStyleBackColor = true;
            this.btnNe.Click += new System.EventHandler(this.btnNe_Click);
            // 
            // ExitConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client.Properties.Resources.sand_tile;
            this.ClientSize = new System.Drawing.Size(533, 145);
            this.Controls.Add(this.btnNe);
            this.Controls.Add(this.btnDa);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExitConfirm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ExitConfirm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDa;
        private System.Windows.Forms.Button btnNe;
    }
}