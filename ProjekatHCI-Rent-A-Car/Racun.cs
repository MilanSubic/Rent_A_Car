using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatHCI_Rent_A_Car
{
    class Racun
    {
        public int id_racuna { get; set; }
        public DateTime vrijeme_izdavanja { get; set; }
        public double iznos { get; set; }
        public string radnikJMB { get; set; }

        public Racun()
        {

        }
    }
}
