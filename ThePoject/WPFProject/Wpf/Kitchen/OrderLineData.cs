using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinnesEntity;

namespace Wpf
{
    public class OrderLineData : BaseINPC
    {
        public Ration the_r {get;set;}
        private int tableId;
        public int TableId
        {
            get { return tableId; }
            set { tableId = value; RaisePropertyChanged("TableId"); }
        }

        
        private RationType type;
        public RationType Type
        {
            get { return type; }
            set { type = value; RaisePropertyChanged("Type"); }
        }


        private string creationDate;
        public string CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; RaisePropertyChanged("CreationDate"); }
        }

        private double price;
        public double Price
        {
            get { return price; }
            set { price = value; RaisePropertyChanged("Price"); }
        }

        private bool done;
        public bool Done
        {
            get { return done; }
            set { done = value; RaisePropertyChanged("Done"); }
        }

        public OrderLineData(Ration r)
        {
            this.TableId = r.TableId;
            this.Type = r.Type;
            this.CreationDate = r.CreationDate.ToShortTimeString();
            this.Price = r.Price;
            this.Done = r.Done;
            this.the_r = r;
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
