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
    public class BussinesLogic
    {
        private dal d;
        public BussinesLogic()
        {
            if (d == null)
            {
                d = new dal();
                /*Person p = new Person() { FirstName = "Kitchen", LastName = "Kitchen", Email = "Kitchen@Kitchen", Password = "Kitchen", PersonType = BussinnesEntity.Type.chef };
                Person p1 = new Person() { FirstName = "Manager", LastName = "Manager", Email = "Manager@Manager", Password = "Manager", PersonType = BussinnesEntity.Type.manager };
                Person p2 = new Person() { FirstName = "Waiter", LastName = "Waiter", Email = "Waiter@Waiter", Password = "Waiter", PersonType = BussinnesEntity.Type.waiter };
                d.Insert(p);
                d.Insert(p1);
                d.Insert(p2);
                Table t = new Table() { Plasace = 10 };
                d.Insert(t);
                 
                Order o = new Order() { Sum = 100, TableId = 2, Done = true };
                
                Ration r1 = new Ration() { Description = "r21", Price = 10, OrderId = 2, Done = false ,CreationDate=DateTime.Now };
                Ration r2 = new Ration() { Description = "r22", Price = 42.5, OrderId = 2, Done = true, CreationDate = DateTime.Now };
                
                d.Insert(r1);
                d.Insert(r2);
                o.RationList = new Ration[] { r1, r2 };
                d.Insert(o);
                 */

            }
        }

        public Person GetPersonByEmail(string email)
        {
            return d.GetPersonByEmail(email);
        }

        public void Insert(object obj)
        {
            d.Insert(obj);
        }

        public void Delete(object obj)
        {
            d.Delete(obj);
        }

        public void Update(object obj)
        {
            d.Update(obj);
        }

        public List<Order> GetAllOrders()
        {
            //Temp exmp. moshe, you need implament the Order to return with list of ration - now is null
            Ration r1 = new Ration() { Description = "r21", Price = 10, OrderId = 2, Done = false, CreationDate = DateTime.Now };
            Ration r2 = new Ration() { Description = "r22", Price = 42.5, OrderId = 2, Done = true, CreationDate = DateTime.Now };

            List<Order> o = d.GetAllOrders();
            o.FirstOrDefault().RationList = new Ration[] { r1, r2 };
            return o;
            //
            //return d.GetAllOrders();
        }

        public List<Order> GetAllOrdersOfSpasificTable(int idTable)
        {
            return d.GetAllOrdersOfSpasificTable(idTable);
        }

        public List<Ration> GetAllRations()
        {
            return d.GetAllRations();
        }

        public List<Ration> GetAllRationsOfSpasificOrder(int idOrder)
        {
            return d.GetAllRationsOfSpasificOrder(idOrder);
        }

        public List<Table> GetAllTables()
        {
            return d.GetAllTables();
        }
    }
}
