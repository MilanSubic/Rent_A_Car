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
    public partial class PocetnaForma : Form
    {
        public PocetnaForma()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)    // login action
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            Console.WriteLine(username + " " + password);
            List<Zaposleni> listaZaposlenih = new List<Zaposleni>();
            listaZaposlenih = DB_metode.getZaposlene();
            for(int i=0;i<listaZaposlenih.Count;i++)
            {
                if(listaZaposlenih[i].korisnicko_ime==username && listaZaposlenih[i].lozinka==password)
                {
                    Console.WriteLine("Uspjesno logovanje" + "  " + listaZaposlenih[i].tip_zaposlenog);
                    if(listaZaposlenih[i].tip_zaposlenog=="menadzer")
                    {
                        MenadzerForm menadzerForm = new MenadzerForm(username);
                        menadzerForm.Show();
                        this.Hide();
                        break;
                    }
                    else
                    {
                        RadnikForm radnikForm = new RadnikForm(username);
                        radnikForm.Show();
                        this.Hide();
                        break;
                    }
                }
            }
          
           
            textBox1.Text = "";
            textBox2.Text = "";
            label5.Text = "Pogrešni podaci prijava nije moguća!";
          
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
