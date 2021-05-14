using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double value = 0;
        double valueM = 0;
        bool operandPerformed = false;
        string opr = "";
        private void button_click(object sender, EventArgs e)
        {
            if (txtResult.Text == "0" || operandPerformed)
                txtResult.Clear();

            Button button = (Button)sender;
            if (button.Text == ",")
            {

                if (!txtResult.Text.Contains(","))
                    txtResult.Text = txtResult.Text + button.Text;

            }
            else txtResult.Text = txtResult.Text + button.Text;

            operandPerformed = false;

        }

        private void bNumCE_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
        }

        private void bNumC_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
            lblResult.Text = "";
            value = 0;
            opr = "";
        }

        private void OperandEvent(object sender, EventArgs e)
        {
            operandPerformed = true;
            Button button = (Button)sender;
            string newOperand = button.Text;
            lblResult.Text = lblResult.Text + " " + txtResult.Text + " " + newOperand;

            switch (opr)
            {
                case "+": txtResult.Text = (value + double.Parse(txtResult.Text)).ToString(); break;
                case "-": txtResult.Text = (value - double.Parse(txtResult.Text)).ToString(); break;
                case "X": txtResult.Text = (value * double.Parse(txtResult.Text)).ToString(); break;
                case "/": txtResult.Text = (value / double.Parse(txtResult.Text)).ToString(); break;
                default: break;
            }

            value = double.Parse(txtResult.Text);
            opr = newOperand;
        }

        private void bNumEqual_Click(object sender, EventArgs e)
        {
            lblResult.Text = "";
            operandPerformed = true;

            switch (opr)
            {
                case "+": txtResult.Text = (value + double.Parse(txtResult.Text)).ToString(); break;
                case "-": txtResult.Text = (value - double.Parse(txtResult.Text)).ToString(); break;
                case "X": txtResult.Text = (value * double.Parse(txtResult.Text)).ToString(); break;
                case "/":

                    if (txtResult.Text == "0")
                    {
                        txtResult.Text = "Не се дели на 0";
                    }

                    else txtResult.Text = (value / double.Parse(txtResult.Text)).ToString();
                    break;

                default: break;

            }

            value = 0;
            opr = "";

        }
        private void OperationMemoryPlus(object sender, EventArgs e)
        {
            valueM += double.Parse(txtResult.Text);
            btnMC.Enabled = true;
            btnMR.Enabled = true;
        }

        private void OperationMemoryClear(object sender, EventArgs e)
        {
            valueM = 0;
            btnMC.Enabled = false;
            btnMR.Enabled = false;
        }

        private void OperationMemoryResult(object sender, EventArgs e)
        {
            txtResult.Text = valueM.ToString();
        }

        private void OperandReverse(object sender, EventArgs e)
        {
            if (!txtResult.Text.Contains('-'))
            {
                txtResult.Text = "-" + txtResult.Text;
            }
            else
            {
                txtResult.Text = txtResult.Text.Trim('-');
            }

        }

        private void Root(object sender, EventArgs e)
        {
            value = double.Parse(txtResult.Text);
            txtResult.Text = Math.Sqrt(value).ToString();
        }

        private void textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnMMinus_Click(object sender, EventArgs e)
        {
            valueM -= double.Parse(txtResult.Text);
            btnMC.Enabled = true;
            btnMR.Enabled = true;

        }
    }
}
