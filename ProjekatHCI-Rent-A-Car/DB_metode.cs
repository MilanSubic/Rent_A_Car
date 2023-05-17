using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProjekatHCI_Rent_A_Car
{
    class DB_metode
    {
        private static readonly string connectionString = "Server=localhost;Port=3306;Database=projektni_diagram;UserId=root;Password=root;";

        static public List<Vozilo> vozila = new List<Vozilo>();
        static public List<Zaposleni> listaZaposleni = new List<Zaposleni>();
        static public List<Osoba> osobe = new List<Osoba>();
        static public List<Rezervacija> rezervacije = new List<Rezervacija>();
        static public List<Racun> racuni = new List<Racun>();
        static public List<Kvar> kvarovi = new List<Kvar>();
        public static List<Osoba> getOsobe()
        {
           
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM projektni_diagram.osoba";
            MySqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Osoba osoba = new Osoba();
                osoba.JMB = reader.GetString(0);
                osoba.ime = reader.GetString(1);
                osoba.prezime = reader.GetString(2);
                osoba.telefon = reader.GetString(3);
                
                osobe.Add(osoba);

            }
            return osobe;
        }

        public static List<Zaposleni> getZaposlene()
        {
           
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM projektni_diagram.zaposleni";
            MySqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Zaposleni zaposleni = new Zaposleni();
               
                zaposleni.datum_zaposlenja = reader.GetDateTime(0);
                zaposleni.plata = reader.GetDouble(1);
                zaposleni.osoba_JMB = reader.GetString(2);
                zaposleni.korisnicko_ime = reader.GetString(3);
                zaposleni.lozinka = reader.GetString(4);
                zaposleni.tip_zaposlenog = reader.GetString(5);

                listaZaposleni.Add(zaposleni);
            }

            return listaZaposleni;

        }


        public static List<Vozilo> getVozila()
        {
           
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM projektni_diagram.vozilo";
            MySqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Vozilo vozilo = new Vozilo();
                vozilo.id_vozila = reader.GetInt32(0);
                vozilo.proizvodjac = reader.GetString(1);
                vozilo.model = reader.GetString(2);
                vozilo.broj_mjesta = reader.GetInt32(3);
                vozilo.gorivo = reader.GetString(4);
                vozilo.prijenos = reader.GetString(5);
                vozilo.zapremina_prtljaznika = reader.GetInt32(6);
                vozilo.cijena = reader.GetDouble(7);
                vozila.Add(vozilo);
            }
            return vozila;
        }


        public static List<Racun> getRacune()
        {

            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM projektni_diagram.racun";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Racun racun = new Racun();
                racun.id_racuna = reader.GetInt32(0);
                racun.vrijeme_izdavanja = reader.GetDateTime(1);
                racun.iznos = reader.GetDouble(2);
                racun.radnikJMB = reader.GetString(3);
                racuni.Add(racun);
            }
            return racuni;
        }
        public static List<Rezervacija> getRezervacije()
        {
            
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM projektni_diagram.rezervacija";
            MySqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Rezervacija rezervacija = new Rezervacija();

                rezervacija.id_rezervacije = reader.GetInt32(0);
                rezervacija.datumOd = reader.GetDateTime(1);
                rezervacija.datumDo = reader.GetDateTime(2);
                rezervacija.status = reader.GetString(3);
                rezervacija.id_vozila = reader.GetInt32(5);
                if(!reader.IsDBNull(6))
                    rezervacija.id_racuna = reader.GetInt32(6);
               rezervacija.osobaJMB = reader.GetString(7);

             
                rezervacije.Add(rezervacija);
            }

            return rezervacije;
        }

        public static List<Kvar> getKvarove()
        {

            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM projektni_diagram.kvar";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Kvar kvar = new Kvar();
                kvar.id_vozila = reader.GetInt32(1);
                kvar.opis = reader.GetString(2);
                kvar.cijena = reader.GetDouble(3);
                kvar.datum_popravke = reader.GetDateTime(4);
               
                kvarovi.Add(kvar);
            }
            return kvarovi;
        }
        public static void makeReservation(Vozilo vozilo,DateTime datum_od,DateTime datum_do,string osobaJMB, Racun racun)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO projektni_diagram.rezervacija (DATUM_OD,DATUM_DO,STATUS,VOZILO_ID_VOZILA,RACUN_ID_RACUNA,OSOBA_JMB) VALUES (@datum_od,@datum_do,@status,@id_vozila,@id_racuna,@osobaJMB)";
            cmd.Parameters.AddWithValue("@datum_od", datum_od);
            cmd.Parameters.AddWithValue("@datum_do", datum_do);
            cmd.Parameters.AddWithValue("@status", "odobreno");
            cmd.Parameters.AddWithValue("@id_vozila", vozilo.id_vozila);
            cmd.Parameters.AddWithValue("@id_racuna", racun.id_racuna);
            cmd.Parameters.AddWithValue("@osobaJMB", osobaJMB);
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public static void addClient(string jmb,string ime,string prezime,string telefon,string broj_vozacke)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO projektni_diagram.osoba (JMB,IME,PREZIME,TELEFON,BROJ_VOZACKE) VALUES (@jmb,@ime,@prezime,@telefon,@broj_vozacke)";
            cmd.Parameters.AddWithValue("@jmb", jmb);
            cmd.Parameters.AddWithValue("@ime", ime);
            cmd.Parameters.AddWithValue("@prezime", prezime);
            cmd.Parameters.AddWithValue("@telefon", telefon);
            cmd.Parameters.AddWithValue("@broj_vozacke", broj_vozacke);
            cmd.ExecuteNonQuery();
            conn.Close();


        }

        public static void addBill(string radnikJMB,Vozilo vozilo,DateTime datumOd,DateTime datumDo)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO projektni_diagram.racun (VRIJEME_IZDAVANJA,IZNOS,ZAPOSLENI_OSOBA_JMB) VALUES (@vrijeme_izdavanja,@iznos,@radnikJMB)";
            cmd.Parameters.AddWithValue("@vrijeme_izdavanja",DateTime.Now);
            cmd.Parameters.AddWithValue("@iznos", (Convert.ToDouble(vozilo.cijena) * (datumDo.Date - datumOd.Date).TotalDays+vozilo.cijena));
            cmd.Parameters.AddWithValue("@radnikJMB", radnikJMB);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void addZaposleni(double plata, string osoba_jmb, string korisnicko_ime, string lozinka, string tip_zaposlenog)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO projektni_diagram.zaposleni (DATUM_ZAPOSLENJA,PLATA,OSOBA_JMB,KORISNICKO_IME,LOZINKA,TIP_ZAPOSLENOG) VALUES (@datum_zaposlenja,@plata,@osoba_jmb,@korisnicko_ime,@lozinka,@tip_zaposlenog)";
            cmd.Parameters.AddWithValue("@datum_zaposlenja", DateTime.Now.Date);
            cmd.Parameters.AddWithValue("@plata", plata);
            cmd.Parameters.AddWithValue("@osoba_jmb", osoba_jmb);
            cmd.Parameters.AddWithValue("@korisnicko_ime", korisnicko_ime);
            cmd.Parameters.AddWithValue("@lozinka", lozinka);
            cmd.Parameters.AddWithValue("@tip_zaposlenog", tip_zaposlenog);
            cmd.ExecuteNonQuery();
            conn.Close();


        }

        public static void deleteOsoba(string JMB)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM projektni_diagram.osoba WHERE JMB=@osobaJMB";
            cmd.Parameters.AddWithValue("@osobaJMB", JMB);
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public static void deleteZaposleni(string JMB)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM projektni_diagram.zaposleni WHERE OSOBA_JMB=@osobaJMB";
            cmd.Parameters.AddWithValue("@osobaJMB", JMB);
            cmd.ExecuteNonQuery();
            conn.Close();

        }





    } 
}
