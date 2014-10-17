using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinnesEntity
{
    public class Ration
    {
        public int RationId { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
        public int OrderId { get; set; }
        public DateTime CreationDate { get; set; }
        //public virtual Order Order { get; set; }

    }
}
