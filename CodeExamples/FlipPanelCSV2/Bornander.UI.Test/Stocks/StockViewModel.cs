using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace Bornander.UI.Test.Stocks
{
    public class StockViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; private set; }
        public string FullName { get; private set; }
        public IList<double> History { get; private set; }
        public ICommand TogglePerspectiveCommand { get; private set; } 

        private bool isOverviewCurrent = true;

        public StockViewModel(string name, string fullName)
        {
            Name = name;
            FullName = fullName;
            History = new List<double>();
            Random random = new Random();
            TogglePerspectiveCommand = new DelegateCommand(x => IsOverviewCurrent = !IsOverviewCurrent);
        }

        private void Notify(params string[] propertyNames)
        {
            if (PropertyChanged != null)
            {
                foreach (string propertyName in propertyNames)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }

        private bool HasHistory
        {
            get { return History.Count > 1; }
        }

        public void OnNewPrice(double newPrice)
        {
            History.Add(newPrice);
            History = new List<double>(History);
            Notify("History", "Price", "AbsoluteChange", "RelativeChange", "Min", "Max", "IsBetter");
        }

        public bool IsOverviewCurrent
        {
            get { return isOverviewCurrent; }
            set
            {
                isOverviewCurrent = value;
                Notify("IsOverviewCurrent");
            }
        }

        public double Price
        {
            get { return History.LastOrDefault(); }
        }

        public double AbsoluteChange
        {
            get 
            {
                if (HasHistory)
                    return History.Last() - History[History.Count - 2];
                else
                    return 0;
            }
        }

        public double RelativeChange
        {
            get { return HasHistory ? AbsoluteChange / History.Last() : 0; }
        }

        public double Max
        {
            get { return HasHistory ? History.Max() : 0.0; }
        }

        public double Min
        {
            get { return HasHistory ? History.Min() : 0.0; }
        }

        public bool IsBetter
        {
            get { return HasHistory ? Math.Sign(History.Last() - History[History.Count - 2]) >= 0 : true; }
        }
    }
}
