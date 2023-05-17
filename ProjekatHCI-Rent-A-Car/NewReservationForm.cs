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
    public partial class NewReservationForm : Form
    {
        public static string username;
        public NewReservationForm(string userName)
        {
            InitializeComponent();
            username = userName;
        }

        private void button3_Click(object sender, EventArgs e)  //delete button action
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            checkBox1.Checked = false;
            comboBox1.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;

        }

        private void button2_Click(object sender, EventArgs e) //cancel button action
        {

            this.Hide();

        }

        private void NewReservationFormLoad(object sender, EventArgs e)
        {
            for (int i = 0; i < DB_metode.vozila.Count; i++)
            {
                comboBox1.Items.Add(DB_metode.vozila[i].proizvodjac + " --- " + DB_metode.vozila[i].model);
            }
        }

        private bool checkReservation(int id_vozila,DateTime datumOd,DateTime datumDo)
        {
            List<Rezervacija> rezervacijeZaIstoVozilo=new List<Rezervacija>();
            List<DateTime> zauzetiDatumi = new List<DateTime>();


            if (datumOd.Date <= datumDo.Date && datumOd.Date >= DateTime.Now.Date && datumDo.Date >= DateTime.Now.Date)
            {
                DB_metode.rezervacije.Clear();
                DB_metode.rezervacije = DB_metode.getRezervacije();
                for (int i = 0; i < DB_metode.rezervacije.Count; i++)
                {
                    if (DB_metode.rezervacije[i].id_vozila == id_vozila)
                    {
                        rezervacijeZaIstoVozilo.Add(DB_metode.rezervacije[i]);

                    }
                }

                for (int i = 0; i < rezervacijeZaIstoVozilo.Count; i++)
                {
                    DateTime date = new DateTime();
                    date = rezervacijeZaIstoVozilo[i].datumOd;
                    while (date.Date <= rezervacijeZaIstoVozilo[i].datumDo.Date)
                    {
                        zauzetiDatumi.Add(date.Date);
                        date = date.AddDays(1);

                    }


                }// dodani su zauzeti dani u zauzetiDatumi

                DateTime dateCheck = datumOd;
                while (dateCheck.Date <= datumDo.Date) //dan i vise
                {
                    if (!zauzetiDatumi.Contains(dateCheck.Date))
                    {

                        dateCheck = dateCheck.AddDays(1);

                        Console.WriteLine("slobodan");

                    }
                    else
                    {
                        //zauzeto bacace izuzetak da se prekine tok 
                        Console.WriteLine("zauzeto");
                        return false;

                    }


                }


                return true;

            }
            else
                return false;
          
        }

        private void button1_Click(object sender, EventArgs e) // confirm button action
        {
            Rezervacija rezervacija = new Rezervacija();
            Vozilo vozilo;
           
            Osoba osoba = new Osoba();

            osoba.JMB = textBox5.Text;
            osoba.ime = textBox1.Text;
            osoba.prezime = textBox2.Text;
            osoba.telefon = textBox3.Text;
            osoba.broj_vozacke = textBox4.Text;

            char[] separator = {' ','-','-','-',' ' };
            string[] parseCar = comboBox1.Text.Split(separator,2,StringSplitOptions.RemoveEmptyEntries);
            

            DateTime datumOd = dateTimePicker1.Value;
            DateTime datumDo = dateTimePicker2.Value;

            for (int i=0;i<DB_metode.vozila.Count;i++)
            {
              
                if (DB_metode.vozila[i].proizvodjac==parseCar[0] && DB_metode.vozila[i].model==parseCar[1])
                {
                   

                    vozilo = DB_metode.vozila[i];
                    if(checkReservation(vozilo.id_vozila,datumOd,datumDo))  // rezervacija za dan i vise staiti za false formu obavjestenja
                    {
                        Console.WriteLine("proslo");
                        if (checkBox1.Checked)
                        {
                            string radnikJMB="";
                            for (int j=0;j<DB_metode.listaZaposleni.Count;j++)
                            {
                                if(DB_metode.listaZaposleni[j].korisnicko_ime.Equals(username))
                                {
                                    radnikJMB = DB_metode.listaZaposleni[j].osoba_JMB;
                                    break;

                                }
                            }    
                            DB_metode.addClient(osoba.JMB, osoba.ime, osoba.prezime, osoba.telefon, osoba.broj_vozacke);
                            DB_metode.addBill(radnikJMB, vozilo, datumOd, datumDo);
                            DB_metode.racuni.Clear();
                            DB_metode.racuni = DB_metode.getRacune();
                            DB_metode.makeReservation(vozilo, datumOd, datumDo,osoba.JMB,DB_metode.racuni.Last<Racun>());
                            this.Hide();
                            

                        }
                        else
                        {
                            ObavjestenjeForm obavjestenjeForm = new ObavjestenjeForm("Rezervaciju nije moguće kreirati bez validne dozvole!", "");
                            obavjestenjeForm.Show();
                        }
                    }
                    else
                    {
                        ObavjestenjeForm obavjestenjeForm = new ObavjestenjeForm("Vozilo je zauzeto u datome terminu!","Izaberite drugo vozilo ili promjenite termin.");
                        obavjestenjeForm.Show();
                      
                        Console.WriteLine("Vozilo je zauzeto u tom terminu");
                    }
                    
                }
            }
          


          







        }

     
    }
}
