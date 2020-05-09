using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
            InitializeCalculator();
        }

        private void InitializeCalculator()
        {
            this.BackColor = Color.LightGray;
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
            bool weHaveDot = Display.Text.Contains(".");
            if (!weHaveDot)
            {
                if (Display.Text == string.Empty)
                {
                    Display.Text += "0.";
                }
                else
                {
                    Display.Text += ".";
                }
            }
        }
        private void ButtonBackspace_Click(object sender, EventArgs e)
        {
            string s = Display.Text;
            if (s.Length > 1)
            {
                s = s.Substring(0, s.Length - 1);
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
            Display.Text = Convert.ToString(number);
        }
    }
}
