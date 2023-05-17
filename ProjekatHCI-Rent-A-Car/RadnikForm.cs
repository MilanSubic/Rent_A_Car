using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProjekatHCI_Rent_A_Car
{
    public partial class RadnikForm : Form
    {
        public string userName;  
        public RadnikForm(string username)
        {
            InitializeComponent();
            this.label1.Text = username;
            userName = username;
           
        
        }

        private void responsibleForm()
        {
            this.panel2.Height = this.Height-120;
            this.dataGridView1.Height = this.panel2.Height - 45;
      
        }

        private void dataViewVozilaSetting()
        {

            DB_metode.vozila.RemoveAll(voz => voz.id_vozila != 0);
            dataGridView1.Rows.Clear();

            
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font(dataGridView1.Font, FontStyle.Bold);

       
    
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridView1.GridColor = Color.Black;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.HorizontalScrollingOffset = this.Width - 205;


            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].Name = "Proizvođač";
            dataGridView1.Columns[1].Name = "Model";
            dataGridView1.Columns[2].Name = "Broj mjesta";
            dataGridView1.Columns[3].Name = "Gorivo";
            dataGridView1.Columns[4].Name = "Prenos";
            dataGridView1.Columns[5].Name = "Zapremina prtljažnika";
            dataGridView1.Columns[6].Name = "Cijena";

          
            List<Vozilo> vozila=new List<Vozilo>();
            vozila = DB_metode.getVozila();

            for(int i=0;i<vozila.Count;i++)
            {
                String[] row = { vozila[i].proizvodjac, vozila[i].model, vozila[i].broj_mjesta.ToString(),vozila[i].gorivo, vozila[i].prijenos, vozila[i].zapremina_prtljaznika.ToString(), vozila[i].cijena.ToString() };
                dataGridView1.Rows.Add(row);
                

            }


      
        }

        public void dataViewRezervacijeSetting()  
        {
              
                DB_metode.rezervacije.RemoveAll(rez =>rez.id_rezervacije!=0);
                dataGridView1.Rows.Clear();
              

                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                    new Font(dataGridView1.Font, FontStyle.Bold);



                dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                dataGridView1.GridColor = Color.Black;
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.HorizontalScrollingOffset = this.Width - 205;


                dataGridView1.ColumnCount = 8;

                dataGridView1.Columns[0].Name = "Proizvođač";
                dataGridView1.Columns[1].Name = "Model";
                dataGridView1.Columns[2].Name = "Ime i prezime klijenta";
                dataGridView1.Columns[3].Name = "Klijentov telefon";
                dataGridView1.Columns[4].Name = "Početni datum rezervacije";
                dataGridView1.Columns[5].Name = "Završni datum rezervacije";
                dataGridView1.Columns[6].Name = "Status";
                dataGridView1.Columns[7].Name = "Cijena";






            List<Rezervacija> rezervacije = new List<Rezervacija>();
                rezervacije = DB_metode.getRezervacije();

            for (int i = 0; i < rezervacije.Count; i++)
                {
                    Vozilo vozilo=new Vozilo();
                    for (int j=0;j<DB_metode.vozila.Count;j++)
                    {
                        if(DB_metode.vozila[j].id_vozila==rezervacije[i].id_vozila)
                        {
                            vozilo = DB_metode.vozila[j];
                        }
                    
                    }
                    Osoba osoba = new Osoba();
                    DB_metode.osobe = DB_metode.getOsobe();
                    for (int k = 0; k < DB_metode.osobe.Count; k++)
                    {
                        if (DB_metode.osobe[k].JMB == rezervacije[i].osobaJMB)
                        {
                            osoba = DB_metode.osobe[k];
                        }

                    }
                    String[] row = { vozilo.proizvodjac, vozilo.model, osoba.ime + " " + osoba.prezime, osoba.telefon, String.Format("{0:d, MMM, yyyy}", rezervacije[i].datumOd), String.Format("{0:d, MMM, yyyy}", rezervacije[i].datumDo), rezervacije[i].status,(Convert.ToDouble(vozilo.cijena) * (rezervacije[i].datumDo.Date - rezervacije[i].datumOd.Date).TotalDays + vozilo.cijena).ToString() };
                        dataGridView1.Rows.Add(row);
         
                }


        }


        private void button5_Click(object sender, EventArgs e)  // logout button action
        {
            PocetnaForma pocetnaForma = new PocetnaForma();
            pocetnaForma.Show();
            this.Hide();
        }

        private void RadnikFormLoad(object sender, EventArgs e)  
        {
            responsibleForm();
            dataViewVozilaSetting();
            
        }

        private void button1_Click(object sender, EventArgs e)  //vozila button action
        {
            label3.Text = "Prikaz trenutno dostupnih vozila:";
            dataViewVozilaSetting();
            this.Show();
        }

        private void resizeForm(object sender, EventArgs e)
        {

            responsibleForm();
        }

        private void button2_Click(object sender, EventArgs e)  // rezervacijeButtonAction
        {
            label3.Text = "Prikaz trenutnih rezervacija:";
            dataViewRezervacijeSetting();
        }

        private void button3_Click(object sender, EventArgs e) //new reservation button
        {
            
            NewReservationForm newReservationForm = new NewReservationForm(userName);
            newReservationForm.Show();
        }
    }
}
