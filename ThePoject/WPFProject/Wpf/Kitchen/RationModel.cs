using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinnesEntity;

namespace Wpf
{
    public class RationModel : BaseINPC
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

        public RationModel(Ration r)
        {
            this.TableId = r.TableId;
            this.Type = r.Type;
            this.CreationDate = r.CreationDate.ToShortTimeString();
            this.Price = r.Price;
            this.Done = r.Done;
            this.the_r = r;
            this.rationImagePath = r.Type.ToString();
            
        }

        private string rationImagePath;
        public string RationImagePath
        {
            get
            {
                return string.Format(@"Z:\git\Wpf-Project-Restaurant\ThePoject\WPFProject\Wpf\Images\{0}.jpg", rationImagePath);
                                       
            }
            private set{}
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
