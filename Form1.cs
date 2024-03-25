using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_Bai4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string result = "";
        string num = "";     
        string num_hex = "";
        string num_bin = "";
        string num_dec = "";
        ComboBox Origin_num = new ComboBox();
        ComboBox Destinate_num = new ComboBox();
        Regex regex_hex = new Regex("^[0-9A-Fa-f]+$");
        Regex regex_bin = new Regex("^[0-1]+$");


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Origin_num = (ComboBox)sender;           
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Destinate_num = (ComboBox)sender;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(Origin_num.Text == "Decimal")
                {
                    int midle = int.Parse(textBox1.Text);
                    num_bin = Convert.ToString(midle, 2);
                    num_hex = Convert.ToString(midle, 16);
                    num_dec = textBox1.Text;
                }
                else if(Origin_num.Text == "Binary")
                {
                    int midle = int.Parse(textBox1.Text);
                    if (!regex_bin.IsMatch(textBox1.Text))
                    {
                        MessageBox.Show("Invalid Binary Number");
                        return;
                    }
                    else
                    {
                        num_bin = textBox1.Text;
                        num_dec = Convert.ToString(midle, 10);
                        num_hex = Convert.ToString(midle, 16);
                    }
                }
                else
                {
                    string midle = textBox1.Text;
                    if (!regex_hex.IsMatch(midle))
                    {
                        MessageBox.Show("Invalid Hex Number");
                    }
                    else
                    {
                        num_bin = Convert.ToString(Convert.ToInt32(midle, 16),2);
                        num_dec = Convert.ToString(Convert.ToInt32(midle, 16),10);
                        num_hex = textBox1.Text;
                    }
                }
                if(Destinate_num.Text == "Decimal")
                {
                    Result.Text = num_dec;
                }
                else if(Destinate_num.Text == "Binary")
                {
                    Result.Text = num_bin;
                }
                else
                {
                    Result.Text = num_hex;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Out_Click(object sender, EventArgs e)
        {
            Result.Text = "";
            textBox1.Text = "";
            comboBox1.Text = "Decimal";
            comboBox2.Text = "Binary";
        }
    }
}
