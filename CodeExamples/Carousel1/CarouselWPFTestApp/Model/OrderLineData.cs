using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarouselWPFTestApp.Model
{
    class OrderLineData : INPCBase
    {
        private string product;
        private string image;
        private int quantity;
        private string comment;

        public OrderLineData(string _product, string _image, 
            int _quantity, string _comment)
        {
            this.product = _product;
            this.image = _image;
            this.quantity = _quantity;
            this.comment = _comment;
        }

        public string Product
        {
            get { return product; }
            set
            {
                if (product != value)
                {
                    product = value;
                    NotifyPropertyChanged("Product");
                }
            }
        }

        public string Image
        {
            get { return image; }
            set
            {
                if (image != value)
                {
                    image = value;
                    NotifyPropertyChanged("Image");
                }
            }
        }

        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (quantity != value)
                {
                    quantity = value;
                    NotifyPropertyChanged("Quantity");
                }
            }
        }

        public string Comment
        {
            get { return comment; }
            set
            {
                if (comment != value)
                {
                    comment = value;
                    NotifyPropertyChanged("Comment");
                }
            }
        }
    }
}
