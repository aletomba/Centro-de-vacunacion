using Prog3TpFinal.InputData;
using Prog3TpFinal.models;

namespace Prog3TpFinal.services.personService
{
    internal interface IPersonService
    {
        void savePerson (List<Person> people);
        
        List<Person> GetAllPersons();
    }
}
