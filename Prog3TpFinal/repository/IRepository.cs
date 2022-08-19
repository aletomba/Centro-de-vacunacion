using Prog3TpFinal.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog3TpFinal.repository
{
    internal interface IRepository
    {
        void SerializeLists(List<Person> people);
        List<Person> DeserializeList();

    }
}
