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

                //Table t1 = new Table() { Plasace = 10, Notes = "" };
                //Table t2 = new Table() { Plasace = 6, Notes = "VIP" };
                //Table t3 = new Table() { Plasace = 10, Notes = "At the door" };
                //Table t4 = new Table() { Plasace = 9, Notes = "By the window" };
                //Table t5 = new Table() { Plasace = 8, Notes = "" };
                //Table t6 = new Table() { Plasace = 10, Notes = "" };
                //Table t7 = new Table() { Plasace = 6, Notes = "VIP" };
                //Table t8 = new Table() { Plasace = 10, Notes = "At the door" };
                //Table t9 = new Table() { Plasace = 9, Notes = "By the window" };
                //Table t10 = new Table() { Plasace = 8, Notes = "" };
                //Table t11 = new Table() { Plasace = 10, Notes = "" };
                //Table t12 = new Table() { Plasace = 6, Notes = "VIP" };
                //Table t13 = new Table() { Plasace = 10, Notes = "At the door" };
                //Table t14 = new Table() { Plasace = 9, Notes = "By the window" };
                //Table t15 = new Table() { Plasace = 8, Notes = "" };
                //d.Insert(t1);
                //d.Insert(t2);
                //d.Insert(t3);
                //d.Insert(t4);
                //d.Insert(t5);
                //d.Insert(t6);
                //d.Insert(t7);
                //d.Insert(t8);
                //d.Insert(t9);
                //d.Insert(t10);
                //d.Insert(t11);
                //d.Insert(t12);
                //d.Insert(t13);
                //d.Insert(t14);
                //d.Insert(t15);

                //Ration r1 = new Ration() { Type = RationType.Chicken, Price = 10, Done = true, CreationDate = DateTime.Now, TableId = 1 };
                //Ration r2 = new Ration() { Type = RationType.Chicken, Price = 10, Done = true, CreationDate = DateTime.Now, TableId = 1 };
                //Ration r3 = new Ration() { Type = RationType.Fish, Price = 25.8, Done = true, CreationDate = DateTime.Now, TableId = 1 };
                //Ration r4 = new Ration() { Type = RationType.Fish, Price = 25.8, Done = true, CreationDate = DateTime.Now, TableId = 1 };
                //Ration r5 = new Ration() { Type = RationType.Meat, Price = 42.5, Done = true, CreationDate = DateTime.Now, TableId = 1 };
                //Ration r6 = new Ration() { Type = RationType.Salmon, Price = 34, Done = true, CreationDate = DateTime.Now, TableId = 2 };
                //Ration r7 = new Ration() { Type = RationType.Chicken, Price = 10, Done = true, CreationDate = DateTime.Now, TableId = 2 };
                //Ration r8 = new Ration() { Type = RationType.Schnitzel, Price = 12, Done = true, CreationDate = DateTime.Now, TableId = 2 };
                //Ration r9 = new Ration() { Type = RationType.Salmon, Price = 34, Done = true, CreationDate = DateTime.Now, TableId = 2 };
                //Ration r10 = new Ration() { Type = RationType.IceCream, Price = 5, Done = true, CreationDate = DateTime.Now, TableId = 2 };
                //Ration r11 = new Ration() { Type = RationType.Meat, Price = 42.5, Done = true, CreationDate = DateTime.Now, TableId = 2 };
                //Ration r12 = new Ration() { Type = RationType.Chicken, Price = 10, Done = true, CreationDate = DateTime.Now, TableId = 2 };
                //Ration r13 = new Ration() { Type = RationType.Meat, Price = 42.5, Done = true, CreationDate = DateTime.Now, TableId = 2 };
                //Ration r14 = new Ration() { Type = RationType.Fish, Price = 25.8, Done = true, CreationDate = DateTime.Now, TableId = 3 };
                //Ration r15 = new Ration() { Type = RationType.Meat, Price = 42.5, Done = true, CreationDate = DateTime.Now, TableId = 3 };
                //Ration r16 = new Ration() { Type = RationType.Chicken, Price = 10, Done = true, CreationDate = DateTime.Now, TableId = 3 };
                //Ration r17 = new Ration() { Type = RationType.IceCream, Price = 5, Done = true, CreationDate = DateTime.Now, TableId = 4 };
                //Ration r18 = new Ration() { Type = RationType.Fish, Price = 25.8, Done = true, CreationDate = DateTime.Now, TableId = 4 };
                //Ration r19 = new Ration() { Type = RationType.IceCream, Price = 5, Done = true, CreationDate = DateTime.Now, TableId = 4 };
                //Ration r20 = new Ration() { Type = RationType.Meat, Price = 42.5, Done = true, CreationDate = DateTime.Now, TableId = 4 };
                //Ration r21 = new Ration() { Type = RationType.Meat, Price = 42.5, Done = true, CreationDate = DateTime.Now, TableId = 4 };
                //Ration r22 = new Ration() { Type = RationType.Salmon, Price = 34, Done = true, CreationDate = DateTime.Now, TableId = 4 };
                //Ration r23 = new Ration() { Type = RationType.Salmon, Price = 34, Done = true, CreationDate = DateTime.Now, TableId = 4 };
                //Ration r24 = new Ration() { Type = RationType.Schnitzel, Price = 12, Done = true, CreationDate = DateTime.Now, TableId = 5 };
                //Ration r25 = new Ration() { Type = RationType.Schnitzel, Price = 12, Done = true, CreationDate = DateTime.Now, TableId = 5 };
                //Ration r26 = new Ration() { Type = RationType.IceCream, Price = 5, Done = true, CreationDate = DateTime.Now, TableId = 5 };
                //Ration r27 = new Ration() { Type = RationType.Chicken, Price = 10, Done = true, CreationDate = DateTime.Now, TableId = 5 };
                //Ration r28 = new Ration() { Type = RationType.Chicken, Price = 10, Done = true, CreationDate = DateTime.Now, TableId = 5 };
                //Ration r29 = new Ration() { Type = RationType.Fish, Price = 25.8, Done = true, CreationDate = DateTime.Now, TableId = 5 };
                //Ration r30 = new Ration() { Type = RationType.Chicken, Price = 10, Done = true, CreationDate = DateTime.Now, TableId = 5 };
                //d.Insert(r1);
                //d.Insert(r2);
                //d.Insert(r3);
                //d.Insert(r4);
                //d.Insert(r5);
                //d.Insert(r6);
                //d.Insert(r7);
                //d.Insert(r8);
                //d.Insert(r9);
                //d.Insert(r10);
                //d.Insert(r11);
                //d.Insert(r12);
                //d.Insert(r13);
                //d.Insert(r14);
                //d.Insert(r15);
                //d.Insert(r16);
                //d.Insert(r17);
                //d.Insert(r18);
                //d.Insert(r19);
                //d.Insert(r20);
                //d.Insert(r21);
                //d.Insert(r22);
                //d.Insert(r23);
                //d.Insert(r24);
                //d.Insert(r25);
                //d.Insert(r26);
                //d.Insert(r27);
                //d.Insert(r28);
                //d.Insert(r29);
                //d.Insert(r30);

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

        public List<Ration> GetAllRations()
        {
            return d.GetAllRations().Where(x => x.Done == false).ToList();
        }

        public List<Ration> GetAllRationsOfSpasificTable(int idTable)
        {
            return d.GetAllRationsOfSpasificTable(idTable);
        }

        public List<Table> GetAllTables()
        {
            List<Table> tables = new List<Table>();
            foreach (var table in d.GetAllTables())
            {
                Table t = new Table();
                t.TableId = table.TableId;
                t.Plasace = table.Plasace;
                t.RationList = d.GetAllRationsOfSpasificTable(table.TableId);
                tables.Add(t);
            }
            return tables;
        }
    }
}
