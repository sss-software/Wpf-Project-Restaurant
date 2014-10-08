using System;
using System.Globalization;
using System.Windows.Data;

namespace Bornander.UI.Test.Converters
{
    [ValueConversion(typeof(double), typeof(string))]   
    public class DoubleToAmountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return String.Format("{0:###,###,##0.00}", (double)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
