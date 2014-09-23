using BussinnesEntity;
using ProjectContext;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class dal
    {
        private SqlConnection conn = new SqlConnection();

        public dal()
        {
            conn.ConnectionString = "Data Source=(localdb)\\Projects;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
        }

        public void Open()
        {
            conn.Open();
        }

        public void Close()
        {
            conn.Close();
        }

        public Person GetPersonByEmail(string email)
        {
            return null;
        }

        public void Insert(object obj)
        {
            using (var db = new projectContext(conn.ConnectionString))
            {
                
                if (obj is Person)
                {
                    try
                    {
                        Open();
                        Person p = (Person)obj;
                        db.Persons.Add(p);
                        db.SaveChanges();
                    }
                    finally
                    {
                        Close();
                    }


                }

                if (obj is Ration)
                {

                }

                if (obj is Order)
                {

                }
            }
        }

        public void Delete(object obj)
        {
            if (obj is Person)
            {

            }

            if (obj is Ration)
            {

            }

            if (obj is Order)
            {

            }
        }

        public void Update(object obj)
        {
            if (obj is Person)
            {

            }

            if (obj is Ration)
            {

            }

            if (obj is Order)
            {

            }
        }

        public List<Person> GetAllPersons()
        {
            using (var db = new projectContext(conn.ConnectionString))
            {
               var y =  db.Persons.ToList();
               return y;
            }
            
        }
    }
}
