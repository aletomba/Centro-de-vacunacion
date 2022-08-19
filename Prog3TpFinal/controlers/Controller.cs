using Prog3TpFinal.InputData;
using Prog3TpFinal.menu;
using Prog3TpFinal.models;
using Prog3TpFinal.services.personService;

namespace Prog3TpFinal.controlers
{
    internal class Controller
    {
        private readonly IPersonService _service;
       
        public Controller(IPersonService service)
        {
            _service = service;
        }

        public void AddPerson(List<Person> newPerson)
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
            catch(Exception)
            {
                return new List<Person>();
            }           
           
        }

        public bool PersonExist(int id)
        {

            var peoples = this.GetPeople();
            if (peoples.Count > 0)
            {
                foreach (var people in peoples)
                {
                    if (people.Document == id)
                    {
                        Console.WriteLine($"la persona {people.Name} ya existe");
                        Console.ReadKey();
                        return true;
                        
                    }
                }

            }
          return false;

        }

       

    }
}
