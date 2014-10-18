using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinnesEntity
{
    public class Table
    {
        public int TableId { get; set; }
        public int Plasace { get; set; }
        public virtual List<Order> OrderList { get; set; }

        public Table()
        {
            OrderList = new List<Order>();
        }
    }
}