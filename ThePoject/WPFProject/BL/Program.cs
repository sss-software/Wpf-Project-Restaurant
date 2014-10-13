using BussinnesEntity;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person() { Email = "moshe@gmail.com", FirstName = "Moshe", LastName = "Gowers", Password = "1234", PersonType = BussinnesEntity.Type.manager };
            dal sc = new dal();
            sc.Insert(p);
            foreach(var x in sc.GetAllPersons())
            {
                Console.WriteLine(x.FirstName);
            }
        }
    }
}
