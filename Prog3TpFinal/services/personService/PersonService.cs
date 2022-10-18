using Prog3TpFinal.models;
using Prog3TpFinal.repository;

namespace Prog3TpFinal.services.personService
{
    internal class PersonService:IPersonService
    {
        private readonly IRepository _repository;

        public PersonService(IRepository repository)
        {
            _repository = repository;
        }

        public void savePerson (List<Person> people)
        {
           _repository.SerializeLists(people);
        }
    

        public List<Person> GetAllPersons()
        {
            return _repository.DeserializeList().ToList();          
            
        }      

        public Person GetPersonById(int id)
        {
            var person = GetAllPersons();
            if (person.Count > 0)
            {
                foreach (var people in person)
                {
                    if (people.Document == id)
                    {                     
                        return people;
                    }
                }
            }           
           
            return null;                                                    
           
        }

        public int PositionPerson(int document,List<Person>persons)
        {
            if (GetPersonById(document) == null)
            {
                throw new Exception();
            }
            else
            {
                return persons.FindIndex(x => x.Document == document);
            }
            
        }

      
    }
}
