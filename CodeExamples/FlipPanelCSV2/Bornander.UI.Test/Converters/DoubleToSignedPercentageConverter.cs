using System;
using System.Globalization;
using System.Windows.Data;

namespace Bornander.UI.Test.Converters
{
    [ValueConversion(typeof(double), typeof(string))]
    public class DoubleToSignedPercentageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double percentage = Math.Round(100.0 * (double)value, 2);
            return String.Format("{0}{1:###,###,##0.00}%", percentage < 0 ? String.Empty : "+", percentage);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
