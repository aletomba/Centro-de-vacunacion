using Prog3TpFinal.InputData;
using Prog3TpFinal.menu;
using Prog3TpFinal.models;
using Prog3TpFinal.services.personService;
using System.Linq;

namespace Prog3TpFinal.controlers
{
    internal class Controller
    {
        private readonly IPersonService _service;
       
        public Controller(IPersonService service)
        {
            _service = service;
        }

        public void AddPersonToList(List<Person> newPerson)
        {
            if (newPerson == null)
            {
                throw new ArgumentNullException(nameof(newPerson));
            }
            else
            {
                try
                {                    
                    _service.savePerson(newPerson);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
           
        }

        public List<Person> GetPeople()
        {
            try
            {
                return _service.GetAllPersons();
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine($"Ocurrio un error : {ex.Message}");
                return null;
            }           
           
        }

        public bool PersonExist(int id)
        {
            try
            {
                var answer = _service.GetPersonById(id);
                if (answer == null)
                {
                    return false;
                }
                else
                {
                    Console.WriteLine($"la persona {answer.Name} apellido {answer.LastName} ya existe");
                    Thread.Sleep(2000);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrio un error",ex.Message);
                return false;
            }

        }

        public bool SearchPerson(int id)
        {
            var search = _service.GetPersonById(id);
            if(search == null)
            {
                Console.WriteLine("la persona que busca no existe");
                Thread.Sleep(2000);
                return true;
            }
            else
            {
                Console.WriteLine($"Nombre: {search.Name} apellido: {search.LastName} vacunas : {search.VacineList1.Count}");
                Thread.Sleep(2000);
                return false;
            }
            
        }

        public List<Person> VaccinatePerson(List<Person> persons,int document,Vacine vacine)
        {
            try
            {
                var position = _service.PositionPerson(document,persons);
                persons[position].VacineList1.Add(vacine);
                Console.WriteLine($"la persona, nombre: {persons[position].Name} apellido: {persons[position].LastName} recibio {persons[position].VacineList1.Count} dosis");
                Thread.Sleep(2000);
                return persons;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"La persona que intenta vacunar no existe {ex.Message}");
                Thread.Sleep(3000);
                return null;
            }
            
        }       

        public void ListOfVaccine(int document, List<Person> persons)
        {
            var position = _service.PositionPerson(document,persons);
            int i = 0;
            if (persons[position].VacineList1.Count() > 0)
            {
                foreach (Vacine vacine in persons[position].VacineList1)
                {
                    Console.WriteLine($"{i + 1} Dosis de {vacine.typeOfVacine} fecha: {vacine.Date}");
                    Thread.Sleep(3000);
                    i++;
                }
            }

        }

        public void searchByDate(List<Person> persons,DateTime firstDate, DateTime secondDate)
        {
            int count = 0;

            if (persons.Count() > 0)
            {
                foreach (Person person in persons)
                {
                    foreach (Vacine vacine in person.VacineList1)
                    {
                        if (vacine.Date >= firstDate && vacine.Date < secondDate.AddDays(1))
                        {
                            Console.WriteLine($"Cantidad de dosis entre {firstDate} y  {secondDate} son:  {person.VacineList1.Count()}");
                            Thread.Sleep(2000);
                        }
                    }
                    count++;
                }
            }
            else
            {
                Console.WriteLine("No hay personas registradas");
            }
        }
    }
}
