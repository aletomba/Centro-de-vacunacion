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

    }
}
