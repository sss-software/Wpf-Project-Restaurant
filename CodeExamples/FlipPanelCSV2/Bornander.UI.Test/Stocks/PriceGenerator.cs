using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Bornander.UI.Test.Stocks
{
    public class PriceGenerator
    {
        public static PriceGenerator Instance { get; private set; }

        private IList<StockViewModel> observers = new List<StockViewModel>();
        private Timer timer = new Timer(100);
        private Random random = new Random();

        static PriceGenerator()
        {
            Instance = new PriceGenerator();
        }

        public PriceGenerator()
        {
            timer.Elapsed += GeneratePrice;
            timer.Start();
        }

        private void GeneratePrice(object sender, ElapsedEventArgs e)
        {
            StockViewModel model = observers[random.Next() % observers.Count];

            double newPrice;
            if (model.Price == 0 )
                newPrice = (500 + random.NextDouble() * 2000)  + random.NextDouble() * 200; 
            else
                newPrice = model.Price * (random.NextDouble() - 0.5) * 0.1;

            model.OnNewPrice(model.Price + newPrice);
        }

        public void Register(StockViewModel stock)
        {
            if (!observers.Contains(stock))
                observers.Add(stock);
        }

        public void Deregister(StockViewModel stock)
        {
            observers.Remove(stock);
        }
    }
}
