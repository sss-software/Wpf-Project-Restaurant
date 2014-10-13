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

                if (obj is Order)
                {
                    try
                    {
                        Open();
                        Order o = (Order)obj;
                        db.Orders.Add(o);
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

                if (obj is Order)
                {
                    Order o = (Order)obj;
                    var order = db.Orders.FirstOrDefault(x => x.OrderID == o.OrderID);
                    db.Orders.Remove(order);
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
                        ration.Description = r.Description;
                        ration.RationDone = r.RationDone;
                        ration.OrderId = r.OrderId;
                        //ration.Order = r.Order;
                        db.SaveChanges();
                    }
                }

                if (obj is Order)
                {
                    Order o = (Order)obj;
                    var order = db.Orders.FirstOrDefault(x => x.OrderID == o.OrderID);
                    if (order != null)
                    {
                        order.OrderID = o.OrderID;
                        order.RationList = o.RationList;
                        order.Sum = o.Sum;
                        order.OrderDone = o.OrderDone;
                        order.TableId = o.TableId;
                        order.Table = o.Table;
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

        public List<Order> GetAllOrders()
        {
            using (var db = new projectContext(conn.ConnectionString))
            {
                return db.Orders.ToList();
            }
        }

        public List<Order> GetAllOrdersOfSpasificTable(int idTable)
        {
            using (var db = new projectContext(conn.ConnectionString))
            {
                return db.Orders.Where(x => x.TableId == idTable).ToList();
            }
        }

        public List<Ration> GetAllRations()
        {
            using (var db = new projectContext(conn.ConnectionString))
            {
                return db.Rations.ToList();
            }
        }

        public List<Ration> GetAllRationsOfSpasificOrder(int idOrder)
        {
            using (var db = new projectContext(conn.ConnectionString))
            {
                return db.Rations.Where(x => x.OrderId == idOrder).ToList();
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
