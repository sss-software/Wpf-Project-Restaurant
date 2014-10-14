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
            return d.GetAllOrders();
        }

        public List<Order> GetAllOrdersOfSpasificTable(int idTable)
        {
            return d.GetAllOrdersOfSpasificTable(idTable);
        }

        public List<Ration> GetAllRations()
        {
            /*Table t = new Table() { Plasace = 10 };
            d.Insert(t);
            Order o = new Order() { Sum = 50, TableId = 1, OrderDone = false };
            d.Insert(o);
            var y = d.GetAllTables();
            var z = d.GetAllOrders();
            Ration r1 = new Ration() { Description = "r1", Price = 3.5, OrderId = 1, RationDone = false };
            Ration r2 = new Ration() { Description = "r2", Price = 4.5, OrderId = 1, RationDone = true };
            d.Insert(r1);
            d.Insert(r2);*/
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
