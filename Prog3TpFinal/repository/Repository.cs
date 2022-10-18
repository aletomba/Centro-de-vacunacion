using Prog3TpFinal.models;
using System.Text.Json;

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
            if (File.Exists("personas.json"))
            {
                return JsonSerializer.Deserialize<List<Person>>(File.ReadAllText("personas.json"));
            }
            else return new List<Person>();
        }
    }
}
