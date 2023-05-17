using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatHCI_Rent_A_Car
{
    class Kvar
    {
        public int id_vozila { get; set; }
        public string opis { get; set; }
        public double cijena { get; set; }
        
        public DateTime datum_popravke { get; set; }

        public Kvar() { }

    }
}
