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

                //Person p = new Person() { FirstName = "Kitchen", LastName = "Kitchen", Email = "Kitchen@Kitchen", Password = "Kitchen", PersonType = BussinnesEntity.Type.chef };
                //Person p1 = new Person() { FirstName = "Manager", LastName = "Manager", Email = "Manager@Manager", Password = "Manager", PersonType = BussinnesEntity.Type.manager };
                //Person p2 = new Person() { FirstName = "Waiter", LastName = "Waiter", Email = "Waiter@Waiter", Password = "Waiter", PersonType = BussinnesEntity.Type.waiter };
                //d.Insert(p);
                //d.Insert(p1);
                //d.Insert(p2);
                //Table t = new Table() { Plasace = 10 };
                
                //Order o = new Order() { Sum = 100, Done = true };

                //Ration r1 = new Ration() { Description = "r21", Price = 10, Done = false, CreationDate = DateTime.Now };
                //Ration r2 = new Ration() { Description = "r22", Price = 42.5, Done = true, CreationDate = DateTime.Now };

                //o.Table = t;
                //o.RationList.Add(r1);
                //o.RationList.Add(r2);
                

                //d.Insert(o);
                 
                //d.Insert(o);
                //d.Insert(r1);
                //d.Insert(r2);
                //o.RationList = new Ration { r1, r2 };
                
                 

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
            /*Ration r1 = new Ration() { Description = "r21", Price = 10, OrderId = 2, Done = false, CreationDate = DateTime.Now };
            Ration r2 = new Ration() { Description = "r22", Price = 42.5, OrderId = 2, Done = true, CreationDate = DateTime.Now };

            List<Order> o = d.GetAllOrders();
            o.FirstOrDefault().RationList = new Ration[] { r1, r2 };
            return o;*/
            /*List<Order> orders = new List<Order>();
            foreach (var order in d.GetAllOrders())
            {
                Order o = new Order();
                o.OrderID = order.OrderID;
                o.RationList = d.GetAllRationsOfSpasificOrder(order.OrderID);
                o.Sum = order.Sum;
                o.Done = order.Done;
                o.TableId = order.TableId;
                //o.Table = order.Table;
                orders.Add(o);
            }
            return orders;*/
            
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
            List<Table> tables = new List<Table>();
            foreach (var table in d.GetAllTables())
            {
                Table t = new Table();
                t.TableId = table.TableId;
                t.Plasace = table.Plasace;
                t.OrderList = d.GetAllOrdersOfSpasificTable(table.TableId);
                tables.Add(t);
            }
            return tables;
        }
    }
}
