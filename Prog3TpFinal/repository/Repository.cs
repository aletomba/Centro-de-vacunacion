using Prog3TpFinal.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Prog3TpFinal.repository
{
    internal class Repository:IRepository
    {
        public void SerializeLists(List<Person> people)
        {
            File.WriteAllText("personas.json", JsonSerializer.Serialize(people));
        }


        public List<Person> DeserializeList()
        {
            
          return JsonSerializer.Deserialize<List<Person>>(File.ReadAllText("personas.json"));            

        }
    }
}
