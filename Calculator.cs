using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Linq.Expressions;

namespace Calculator
{
    public partial class Calculator : Form
    {
        char decimalSeperator;
        double numOne = 0;
        double numTwo = 0;
        string operation;
        bool scifiMode = false;
        const int widthSmall = 419;
        const int widthLarge = 676;

        public Calculator()
        {
            InitializeComponent();
            InitializeCalculator();
        }

        private void InitializeCalculator()
        {
            decimalSeperator = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            this.BackColor = Color.LightGray;
            this.Width = widthSmall;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen; 

            Display.Font = new Font("Roboto", 22f);
            Display.Text = "0";
            Display.TabStop = false;

            string buttonName = null;
            Button button = null;
            for(int i = 0; i < 10; i++)
            {
                buttonName = "button" + i;
                button = (Button)this.Controls[buttonName];
                button.Text = i.ToString();
                button.BackColor = Color.Gray;
                button.Font = new Font("Roboto", 22f);
            } 
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (Display.Text == "0")
            {
                Display.Text = button.Text;
            }
            else
            {
                Display.Text += button.Text;
            }
        }

        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            bool weHaveDot = Display.Text.Contains(decimalSeperator);
            if (!weHaveDot)
            {
                if (Display.Text == string.Empty)
                {
                    Display.Text += "0" + decimalSeperator;
                }
                else
                {
                    Display.Text += decimalSeperator;
                }
            }
        }
        private void ButtonBackspace_Click(object sender, EventArgs e)
        {
            string s = Display.Text;
            if (s.Length > 1)
            {
                if ((s.Contains("-") == true) && (s.Length == 2))
                {
                    s = "0";
                }
                else
                {
                    s = s.Substring(0, (s.Length - 1));
                }
            }
            else
            {
                s = "0";
            }
            Display.Text = s;
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
            double number = Convert.ToDouble(Display.Text);
            number *= -1;
            Display.Text = number.ToString();
        }

        private void Operation_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            numOne = Convert.ToDouble(Display.Text);

            if(button.Text == "√")
            {
                Display.Text = Math.Sqrt(numOne).ToString();
                return;
            }

            Display.Text = string.Empty;
            operation = button.Text;
        }

        private void buttonResult_Click(object sender, EventArgs e)
        {
            double result = 0;
            numTwo = Convert.ToDouble(Display.Text);
            if(operation == "+")
            {
                result = numOne + numTwo;
            }
            else if(operation == "-")
            {
                result = numOne - numTwo;
            }
            else if(operation == "*")
            {
                result = numOne * numTwo;
            }
            else if(operation == "/")
            {
                result = numOne / numTwo;
            }
            else if (operation == "x^")
            {
                result = Math.Pow(numOne, numTwo);
            }

            Display.Text = result.ToString();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Display.Text = "0";
            numOne = 0;
            numTwo = 0;
        }

        private void buttonSciFi_Click(object sender, EventArgs e)
        {
            if (scifiMode)
            {
                this.Width = widthSmall;
            }
            else
            {
                this.Width = widthLarge;
            }
            scifiMode = !scifiMode;
        }
    }
}
