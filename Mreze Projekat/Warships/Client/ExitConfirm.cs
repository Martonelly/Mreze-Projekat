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
    public partial class ExitConfirm : Form
    {
        public ExitConfirm()
        {
            InitializeComponent();
        }

        private void btnDa_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnNe_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ExitConfirm_Load(object sender, EventArgs e)
        {
            label1.Focus();
        }
    }
}
