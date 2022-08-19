using Prog3TpFinal.models;
using Prog3TpFinal.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
