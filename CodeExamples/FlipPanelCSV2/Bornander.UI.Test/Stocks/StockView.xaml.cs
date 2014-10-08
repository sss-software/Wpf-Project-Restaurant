using System.Windows.Controls;
using System;

namespace Bornander.UI.Test.Stocks
{
    public partial class StockView : UserControl
    {
        private int index = 0;
        private static readonly Tuple<string, string>[] Companies = new[]
            {
                Tuple.Create("STCT", "Setec Astronomy"),
                Tuple.Create("VDLI", "Vandelay Import"),
                Tuple.Create("VDLE", "Vandelay Export"),
                Tuple.Create("MOBY", "Mooby"),
                Tuple.Create("SLGL", "Soul Glo"),
                Tuple.Create("CYSY", "Syberdyne Systems"),
                Tuple.Create("WEYU", "Weyland-Yutani"),
                Tuple.Create("DDAN", "Dapper Dan"),
                Tuple.Create("OAIR", "Oceanic Airlines")
            };

        public StockView()
        {
            InitializeComponent();
            DataContext = new StockViewModel(Companies[index].Item1, Companies[index].Item2);
            ++index;
            PriceGenerator.Instance.Register((StockViewModel)DataContext);
        }

        private void FlipPanel_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            flipper.FrontVisible = !flipper.FrontVisible;
        }
    }
}
