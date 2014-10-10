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
