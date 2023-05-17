using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatHCI_Rent_A_Car
{
    class Vozilo
    {
        public int id_vozila { get; set; }
        public string proizvodjac { get; set; }
        public string model { get; set; }
        public int broj_mjesta { get; set; }
        public string gorivo { get; set; }
        public string prijenos { get; set; }
        public int zapremina_prtljaznika { get; set; }
        public double cijena { get; set; }

        public Vozilo(int id_vozila, string proizvodjac, string model, int broj_mjesta, string gorivo, string prijenos, int zapremina_prtljaznika, double cijena)
        {
            this.id_vozila = id_vozila;
            this.proizvodjac = proizvodjac;
            this.model = model;
            this.broj_mjesta = broj_mjesta;
            this.gorivo = gorivo;
            this.prijenos = prijenos;
            this.zapremina_prtljaznika = zapremina_prtljaznika;
            this.cijena = cijena;
        }

        public Vozilo() { }

    }
}
