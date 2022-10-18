using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog3TpFinal.models
{
    class Person
    {
        
        private InfoContact infoContact = new InfoContact();

        private Direction direction = new Direction();

        private List<Vacine> VacineList = new List<Vacine>();


        public Person()
        {

        }

        [Required]        
        public string? Name { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        [MinLength(8)]        
        public int Document { get; set; }
        [Required]
        public string? Country { get; set; }        
        public enum TipeDocument { DNI = 1, LC = 2, LE = 3}
        [Required]
        public string? TypeSelect { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public InfoContact InfoContact { get => infoContact; set => infoContact = value; }
        [Required]
        public Direction Direction { get => direction; set => direction = value; }
        public List<Vacine> VacineList1 { get => VacineList; set => VacineList = value; }

        public bool validateTypeDni(Person.TipeDocument dniSelected)
        {
            if (((long)dniSelected)>3 || ((long)dniSelected) <= 0)
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
