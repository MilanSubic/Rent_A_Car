using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatHCI_Rent_A_Car
{
    class Adresa
    {
        public int id_adrese { get; set; }
        public string grad { get; set; }
        public string ulica { get; set; }
        public string broj { get; set; }

        public Adresa(int id_adrese,string grad,string ulica, string broj)
        {
            this.id_adrese = id_adrese;
            this.grad = grad;
            this.ulica = ulica;
            this.broj = broj;
        }
        public Adresa() { }

    }
}
