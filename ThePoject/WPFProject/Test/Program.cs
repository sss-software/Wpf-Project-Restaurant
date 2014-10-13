using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            dal d = new dal();
            foreach (var person in d.GetAllPersons())
            {
                Console.WriteLine(person.FirstName + " " + person.LastName + " " + person.PersonType.ToString());
            }
        }
    }
}
