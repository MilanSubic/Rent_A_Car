using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjekatHCI_Rent_A_Car
{
    static class Simulation
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
          

            List<Osoba> lista = new List<Osoba>();
            lista = DB_metode.getOsobe();
            for(int i=0;i<lista.Count();i++)
            {
                Console.WriteLine(lista[i].JMB + " " + lista[i].ime + " " + lista[i].prezime + " "+lista[i].telefon+" "+ lista[i].id_adrese);
            }
           
            Application.Run(new PocetnaForma());
        }
    }
}
