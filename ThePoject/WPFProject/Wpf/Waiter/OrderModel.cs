using BussinnesEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.Waiter
{
    public class OrderModel:BaseINPC
    {
        private Order o;

        public double Sum
        {
            get { return o.Sum; }
            set
            {
                o.Sum = value;
                RaisePropertyChanged("Sum");
            }
        }
        public int OrderID
        {
            get { return o.OrderID; }
            set
            {
                o.OrderID = value;
                RaisePropertyChanged("OrderID");
            }
        }
        public int TableId
        {
            get { return o.TableId; }
            set
            {
                o.TableId = value;
                RaisePropertyChanged("TableId");
            }
        }

        public bool Done
        {
            get { return o.Done; }
            set
            {
                o.Done = value;
                RaisePropertyChanged("Done");
            }
        }

    }
}
