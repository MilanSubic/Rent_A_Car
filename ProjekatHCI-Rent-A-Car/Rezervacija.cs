using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatHCI_Rent_A_Car
{
    class Rezervacija
    {
        public int id_rezervacije { get; set; }
        public DateTime datumOd { get; set; }
        public DateTime datumDo { get; set; }
        public string status { get; set; }

       

        public int id_vozila { get; set; }
        public int id_racuna { get; set; }
        public string osobaJMB { get; set; }

        public Rezervacija(int id_rezervacije,DateTime datumOd,DateTime datumDo,string status,string osobaJMB)
        {
            this.id_rezervacije = id_rezervacije;
            this.datumOd = datumOd;
            this.datumDo = datumDo;
            this.status = status;
            this.osobaJMB = osobaJMB;
        }

        public Rezervacija() 
        {
           
        }
    }
}
