using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog3TpFinal.models
{
    internal class Vacine
    {
        public Vacine()
        {

        }
        public int IdVacine { get; set; }
        public DateTime Date { get; set; }
        public enum VacineType { Sinopharm = 1, AstraZeneca = 2, Pfizr = 3, Sputnik = 4 }
        public string typeOfVacine { get; set; }


        public bool validateTypeVaccine(Vacine.VacineType vaccineType)
        {
            if (((long)vaccineType) > 3 || ((long)vaccineType) <= 0)
            {
                Console.WriteLine("Debe seleccionar una opcion correcta");
                Thread.Sleep(2000);
                return false;
            }
            else
            {
                return true;
            }

        }

    }
}
