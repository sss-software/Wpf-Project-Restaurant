using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinnesEntity
{
    public enum RationType { Chicken = 1, Meat = 2, Fish = 3, Schnitzel = 4, IceCream = 5, Salmon = 6 }
    public class Ration
    {
        public int RationId { get; set; }
        public double Price { get; set; }
        public RationType Type { get; set; }
        public bool Done { get; set; }
        public int TableId { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual Table Table { get; set; }

    }
}
