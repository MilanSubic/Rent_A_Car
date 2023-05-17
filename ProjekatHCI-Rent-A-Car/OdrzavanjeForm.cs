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
    public partial class OdrzavanjeForm : Form
    {
        public OdrzavanjeForm()
        {
            InitializeComponent();
        }

        private void OdrzavanjeForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < DB_metode.vozila.Count; i++)
            {
                comboBox1.Items.Add(DB_metode.vozila[i].proizvodjac + " --- " + DB_metode.vozila[i].model);
            }
        }

        private void button2_Click(object sender, EventArgs e) // cancel button
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e) //confirm button
        {
            char[] separator = { ' ', '-', '-', '-', ' ' };
            string[] parseCar = comboBox1.Text.Split(separator, 2, StringSplitOptions.RemoveEmptyEntries);
            Vozilo vozilo = new Vozilo();

            for (int i = 0; i < DB_metode.vozila.Count; i++)
            {

                if (DB_metode.vozila[i].proizvodjac == parseCar[0] && DB_metode.vozila[i].model == parseCar[1])
                {

                    dataGridView1.Rows.Clear();
                    vozilo = DB_metode.vozila[i];

                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                        new Font(dataGridView1.Font, FontStyle.Bold);

                    dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                    dataGridView1.GridColor = Color.Black;
                    dataGridView1.RowHeadersVisible = false;

                    dataGridView1.ColumnCount = 3;

                    dataGridView1.Columns[0].Name = "Opis kvara";
                    dataGridView1.Columns[1].Name = "Cijena popravke";
                    dataGridView1.Columns[2].Name = "Datum popravke";


                    DB_metode.kvarovi.Clear();
                    DB_metode.kvarovi = DB_metode.getKvarove();
                    for(int j=0;j<DB_metode.kvarovi.Count;j++)
                    {
                        if(DB_metode.kvarovi[j].id_vozila==vozilo.id_vozila)
                        {
                            String[] row = { DB_metode.kvarovi[j].opis, DB_metode.kvarovi[j].cijena.ToString(),DB_metode.kvarovi[j].datum_popravke.ToString()};
                            dataGridView1.Rows.Add(row);
                        }
                    }
                }
            }
        }
    }
}
