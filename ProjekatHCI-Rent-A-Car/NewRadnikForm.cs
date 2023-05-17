using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjekatHCI_Rent_A_Car
{
    public partial class NewRadnikForm : Form
    {
        public NewRadnikForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)  // confirm button new radnik
        {
            if(textBox1.Text!="" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text!="" && comboBox1.Text!="")
            {
                DB_metode.addClient(textBox5.Text, textBox1.Text, textBox2.Text, textBox3.Text, "");
                DB_metode.addZaposleni(Convert.ToDouble(textBox7.Text), textBox5.Text, textBox6.Text, textBox4.Text, comboBox1.Text);
                this.Hide();
            }
        }
    }
}
