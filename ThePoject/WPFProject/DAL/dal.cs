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
            using (var db = new projectContext(conn.ConnectionString))
            {
                return db.Persons.FirstOrDefault(x => x.Email.Equals(email));
            }
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
                    try
                    {
                        Open();
                        Ration r = (Ration)obj;
                        db.Rations.Add(r);
                        db.SaveChanges();
                    }
                    finally
                    {
                        Close();
                    }
                }

                if (obj is Table)
                {
                    try
                    {
                        Open();
                        Table t = (Table)obj;
                        db.Tables.Add(t);
                        db.SaveChanges();
                    }
                    finally
                    {
                        Close();
                    }
                }
            }
        }

        public void Delete(object obj)
        {
            using (var db = new projectContext(conn.ConnectionString))
            {
                if (obj is Person)
                {
                    Person p = (Person)obj;
                    var person = db.Persons.FirstOrDefault(x => x.FirstName == p.FirstName);
                    db.Persons.Remove(person);
                    db.SaveChanges();
                }

                if (obj is Ration)
                {
                    Ration r = (Ration)obj;
                    var ration = db.Rations.FirstOrDefault(x => x.RationId == r.RationId);
                    db.Rations.Remove(ration);
                    db.SaveChanges();
                }

                if (obj is Table)
                {
                    Table t = (Table)obj;
                    var table = db.Tables.FirstOrDefault(x => x.TableId == t.TableId);
                    db.Tables.Remove(table);
                    db.SaveChanges();
                }
            }
        }

        public void Update(object obj)
        {
            using (var db = new projectContext(conn.ConnectionString))
            {
                if (obj is Person)
                {
                    Person p = (Person)obj;
                    var person = db.Persons.FirstOrDefault(x => x.PersonId == p.PersonId);
                    if (person != null)
                    {
                        person.PersonId = p.PersonId;
                        person.FirstName = p.FirstName;
                        person.LastName = p.LastName;
                        person.Email = p.Email;
                        person.Password = p.Password;
                        person.PersonType = p.PersonType;
                        db.SaveChanges();
                    }
                }

                if (obj is Ration)
                {
                    Ration r = (Ration)obj;
                    var ration = db.Rations.FirstOrDefault(x => x.RationId == r.RationId);
                    if (ration != null)
                    {
                        ration.RationId = r.RationId;
                        ration.Price = r.Price;
                        ration.Type = r.Type;
                        ration.Done = r.Done;
                        ration.TableId = r.TableId;
                        //if(r.Table != null)
                        //    Update(r.Table);
                        db.SaveChanges();
                    }
                }

                if (obj is Table)
                {
                    Table t = (Table)obj;
                    var table = db.Tables.FirstOrDefault(x => x.TableId == t.TableId);
                    if (table != null)
                    {
                        table.TableId = t.TableId;
                        table.Plasace = t.Plasace;
                        table.Notes = t.Notes;
                        foreach (var ration in t.RationList)
                        {
                            Update(ration);
                        }
                        db.SaveChanges();
                    }
                }
            }
        }

        public List<Person> GetAllPersons()
        {
            using (var db = new projectContext(conn.ConnectionString))
            {
                return db.Persons.ToList();
            }
        }

        public List<Ration> GetAllRations()
        {
            using (var db = new projectContext(conn.ConnectionString))
            {
                return db.Rations.ToList();
            }
        }

        public List<Ration> GetAllRationsOfSpasificTable(int idTable)
        {
            using (var db = new projectContext(conn.ConnectionString))
            {
                return db.Rations.Where(x => x.TableId == idTable).ToList();
            }
        }

        public List<Table> GetAllTables()
        {
            using (var db = new projectContext(conn.ConnectionString))
            {
                return db.Tables.ToList();
            }
        }
    }
}
