using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatHCI_Rent_A_Car
{
    class Zaposleni
    {

        public string osoba_JMB { get; set; }
        public DateTime datum_zaposlenja { get; set; }
        public double plata { get; set; }

        public string korisnicko_ime { get; set; }
        public string lozinka { get; set; }
        public string tip_zaposlenog { get; set; }

        public Zaposleni() { }


    }
}
