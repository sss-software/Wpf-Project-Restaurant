using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarouselWPFTestApp
{
    public class PersonData : INPCBase
    {
        private string firstName;
        private string lastName;
        private string salutation;
        private bool isMale;

        public PersonData(string firstName, string lastName, 
            string salutation, bool isMale)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.salutation = salutation;
            this.isMale = isMale;
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    NotifyPropertyChanged("FirstName");
                    NotifyPropertyChanged("FullName");
                }
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    NotifyPropertyChanged("LastName");
                    NotifyPropertyChanged("FullName");
                }
            }
        }

        public string Salutation
        {
            get { return salutation; }
            set
            {
                if (salutation != value)
                {
                    salutation = value;
                    NotifyPropertyChanged("Salutation");
                }
            }
        }

        public bool IsMale
        {
            get { return isMale; }
            set
            {
                if (isMale != value)
                {
                    isMale = value;
                    NotifyPropertyChanged("IsMale");
                }
            }
        }

        public string FullName
        {
            get
            {
                return String.Format("{0} {1} {2}", Salutation, FirstName, LastName);
            }
        }
    }
}
