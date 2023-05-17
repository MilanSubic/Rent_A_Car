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
    public partial class RadniciForm : Form
    {
        public RadniciForm()
        {
            InitializeComponent();
        }

        private void RadniciForm_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font(dataGridView1.Font, FontStyle.Bold);

            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridView1.GridColor = Color.Black;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.ColumnCount = 6;

            dataGridView1.Columns[0].Name = "Ime";
            dataGridView1.Columns[1].Name = "Prezime";
            dataGridView1.Columns[2].Name = "Telefon";
            dataGridView1.Columns[3].Name = "Datum zaposlenja";
            dataGridView1.Columns[4].Name = "Plata";
            dataGridView1.Columns[5].Name = "Tip zaposlenog";


            DB_metode.listaZaposleni.Clear();
            DB_metode.listaZaposleni = DB_metode.getZaposlene();
            DB_metode.osobe.Clear();
            DB_metode.osobe = DB_metode.getOsobe();
            Osoba osoba = new Osoba();
            for(int i=0;i<DB_metode.listaZaposleni.Count;i++)
            {
                for(int j=0;j<DB_metode.osobe.Count;j++)
                {
                    if(DB_metode.listaZaposleni[i].osoba_JMB==DB_metode.osobe[j].JMB)
                    {
                        osoba = DB_metode.osobe[j];
                        String[] row = { osoba.ime, osoba.prezime, osoba.telefon, String.Format("{0:d, MMM, yyyy}", DB_metode.listaZaposleni[i].datum_zaposlenja),DB_metode.listaZaposleni[i].plata.ToString(), DB_metode.listaZaposleni[i].tip_zaposlenog };    
                        dataGridView1.Rows.Add(row);
                    }
                }
            }

           
        }

        private void button2_Click(object sender, EventArgs e) // delete radnik button 
        {
            string ime, prezime, telefon;
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                ime = Convert.ToString(selectedRow.Cells["Ime"].Value);
                prezime = Convert.ToString(selectedRow.Cells["Prezime"].Value);
                telefon = Convert.ToString(selectedRow.Cells["Telefon"].Value);



                DB_metode.osobe.Clear();
                DB_metode.osobe = DB_metode.getOsobe();
                Osoba osoba = new Osoba();
                for (int i = 0; i < DB_metode.osobe.Count; i++)
                {
                    if (DB_metode.osobe[i].ime.Equals(ime) && DB_metode.osobe[i].prezime.Equals(prezime) && DB_metode.osobe[i].telefon.Equals(telefon))
                    {
                        osoba = DB_metode.osobe[i];
                        DB_metode.deleteZaposleni(osoba.JMB);
                        DB_metode.deleteOsoba(osoba.JMB);
                        this.Hide();
                    }
                }

            }

        }

        private void button1_Click(object sender, EventArgs e) // open form for adding new radnik
        {
            NewRadnikForm newRadnikForm = new NewRadnikForm();
            newRadnikForm.Show();
            this.Hide();
        }
    }
}
