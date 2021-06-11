using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicCalculator
{
    public partial class basicCalculator : Form
    {
        double resultValue = 0;
        string text = "";
        bool isPerformed = false;
        public basicCalculator()
        {
            InitializeComponent();
        }

        private void numbersClick(object sender, EventArgs e)
        {
            if ((resultTxt.Text == "0") || (isPerformed))
            {
                resultTxt.Clear();
            }
            isPerformed = false;
            Button button = (Button)sender;
            if (button.Text == ",")
            {
                if (!resultTxt.Text.Contains(","))
                {
                    resultTxt.Text = resultTxt.Text + button.Text;
                }
            }
            else
            {
                resultTxt.Text = resultTxt.Text + button.Text;
            }
        }

        private void OperatorClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (resultTxt.Text.EndsWith("*")|| resultTxt.Text.EndsWith("+")|| resultTxt.Text.EndsWith("-")|| resultTxt.Text.EndsWith("/"))
            {
                return;
            }
            else
            {
                if (resultValue != 0)
                {
                    //resultBtn.PerformClick();      Problem var.helli?
                    text = button.Text;
                    resultTxt.Text += text;
                    labelOperation.Text = resultValue + " " + text;
                    isPerformed = true;
                }
                else
                {
                    text = button.Text;
                    resultValue = double.Parse(resultTxt.Text);
                    resultTxt.Text += text;
                    labelOperation.Text = resultValue + " " + text;
                    isPerformed = true;
                }
            }
            
        }

        private void percentBtn_Click(object sender, EventArgs e)
        {
            if (resultTxt.Text.Length > 0)
            {
                resultTxt.Text = resultTxt.Text.Remove(resultTxt.Text.Length - 1, 1);
            }
        }

        private void singleClearBtn_Click(object sender, EventArgs e)
        {
            resultTxt.Text = "0";
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            resultTxt.Text = "0";
            resultValue = 0;
        }

        private void resultBtn_Click(object sender, EventArgs e)
        {
                switch (text)
                {
                    case "+":
                        resultTxt.Text = (resultValue + double.Parse(resultTxt.Text)).ToString();
                        resultValue = 0;
                        break;
                    case "-":
                        resultTxt.Text = (resultValue - double.Parse(resultTxt.Text)).ToString();
                        resultValue = 0;
                        break;
                    case "*":
                        resultTxt.Text = (resultValue * double.Parse(resultTxt.Text)).ToString();
                        resultValue = 0;
                        break;
                    case "/":
                        if (resultTxt.Text!="0")
                        {
                            resultTxt.Text = (resultValue / double.Parse(resultTxt.Text)).ToString();
                            resultValue = 0;
                        }
                        else
                        {
                            MessageBox.Show("Cannot devide by zero");
                        }
                        break;
                }
                resultValue = double.Parse(resultTxt.Text);
                labelOperation.Text = "";
        }

        private void plusMinusBtn_Click(object sender, EventArgs e)
        {

            if ((double.Parse(resultTxt.Text)) >= 0)
            {
                resultTxt.Text = (System.Math.Abs(double.Parse(resultTxt.Text)) * (-1)).ToString();
            }
            else
            {
                resultTxt.Text = (System.Math.Abs(double.Parse(resultTxt.Text)) * (1)).ToString();
            }
        }
    }
}
