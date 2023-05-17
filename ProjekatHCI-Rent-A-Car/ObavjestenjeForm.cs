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
    public partial class ObavjestenjeForm : Form
    {
        public ObavjestenjeForm(string label_1,string label_2)
        {
            InitializeComponent();
            label1.Text = label_1;
            label2.Text = label_2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
