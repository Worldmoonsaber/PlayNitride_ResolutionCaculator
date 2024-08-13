using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormResolCalibrator
{
    public partial class FormParam : Form
    {
        public FormParam()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbThreholdValue_Click(object sender, EventArgs e)
        {

        }

        private void trbThreshold_Scroll(object sender, EventArgs e)
        {
            lbThreholdValue.Text = trbThreshold.Value.ToString();
        }
    }
}
