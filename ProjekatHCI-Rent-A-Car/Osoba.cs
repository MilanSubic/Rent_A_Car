using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatHCI_Rent_A_Car
{
    class Osoba
    {
        public string JMB { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string telefon { get; set; }

        public string broj_vozacke { get; set; }
        public int id_adrese { get; set; }
        public Osoba(string JMB,string ime,string prezime,string telefon, string broj_vozacke,int id_adrese)
        {
            this.JMB = JMB;
            this.ime = ime;
            this.prezime = prezime;
            this.telefon = telefon;
            this.broj_vozacke = broj_vozacke;
            this.id_adrese = id_adrese;

        }

        public Osoba() { }

       

    }
}
