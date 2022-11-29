using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCaculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtBox_res_TextChanged(object sender, EventArgs e)
        {
            if (Char.IsDigit(txtBox_res.Text.All()))
            {

            }
        }

        private void btn_1_Click(object sender, EventArgs e)
        {

        }

        private void btn_2_Click(object sender, EventArgs e)
        {

        }
    }
}
