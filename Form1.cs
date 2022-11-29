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
            // var btnList = new List<Button> { btn_0, btn_1, btn_2, btn_3, btn_4, btn_5, btn_6, btn_7, btn_8, btn_9 };
        }

        float res = 0;
        private void txtBox_res_TextChanged(object sender, EventArgs e)
        {
            if (txtBox_res.Text == string.Empty)
            {
                txtBox_res.Text = 0.ToString();
            }
            else if (txtBox_res.Text.All(Char.IsDigit) || e.ToString() == ".")
            {
                res = (float)Convert.ToDouble(txtBox_res.Text);
            }
            /*else
            {
                txtBox_res.Text = res.ToString();
            }*/
        }

        private void btnNum_Click(object sender, EventArgs e)
        {
            txtBox_res.Text += (sender as Button).Text;
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            previousOperation = Operation.None;
            txtBox_res.Clear();
        }
        
        private void PerformCalculation(Operation previousOperation)
        {
            List<double> lstNums = new List<double>();
            switch (previousOperation)
            {
                case Operation.Add:
                    lstNums = txtBox_res.Text.Split('+').Select(double.Parse).ToList();
                    txtBox_res.Text = (lstNums[0] + lstNums[1]).ToString();
                    break;
                case Operation.Sub:
                    lstNums = txtBox_res.Text.Split('-').Select(double.Parse).ToList();
                    txtBox_res.Text = (lstNums[0] - lstNums[1]).ToString();
                    break;
                case Operation.Mul:
                    lstNums = txtBox_res.Text.Split('*').Select(double.Parse).ToList();
                    txtBox_res.Text = (lstNums[0] * lstNums[1]).ToString();
                    break;
                case Operation.Div:
                    try
                    {
                        lstNums = txtBox_res.Text.Split('/').Select(double.Parse).ToList();
                        txtBox_res.Text = (lstNums[0] / lstNums[1]).ToString();
                    }
                    catch (DivideByZeroException)
                    {
                        txtBox_res.Text = "34404";
                    }
                    break;
                default:
                    break;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (previousOperation != Operation.None)
                PerformCalculation(previousOperation);
            previousOperation = Operation.Add;
            txtBox_res.Text += (sender as Button).Text;
        }

        private void btn_sub_Click(object sender, EventArgs e)
        {
            if (previousOperation != Operation.None)
                PerformCalculation(previousOperation);
            previousOperation = Operation.Sub;
            txtBox_res.Text += (sender as Button).Text;
        }

        private void btn_mult_Click(object sender, EventArgs e)
        {
            if (previousOperation != Operation.None)
                PerformCalculation(previousOperation);
            previousOperation = Operation.Mul;
            txtBox_res.Text += (sender as Button).Text;
        }

        private void btn_div_Click(object sender, EventArgs e)
        {
            if (previousOperation != Operation.None)
                PerformCalculation(previousOperation);
            previousOperation = Operation.Div;
            txtBox_res.Text += (sender as Button).Text;
        }

        enum Operation
        {
            Add,
            Sub,
            Mul,
            Div,
            None
        }
        static Operation previousOperation = Operation.None;

        private void btn_equal_Click(object sender, EventArgs e)
        {
            if (previousOperation == Operation.None)
                return;
            else
                PerformCalculation(previousOperation);
        }
    }
}
