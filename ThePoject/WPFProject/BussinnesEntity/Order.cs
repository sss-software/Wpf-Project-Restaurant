﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinnesEntity
{
    public class Order
    {
        public int OrderID { get; set; }
        public double Sum { get; set; }
        public bool Done { get; set; }
        public IEnumerable<Ration> OrderList { get; set; }
        public int IdTable { get; set; }
        public virtual Table Table { get; set; }
    }
}