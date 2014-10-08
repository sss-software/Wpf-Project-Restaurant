using System.Windows;
using System.Windows.Controls;

namespace Bornander.UI.Test
{
    public partial class SimpleTest : Window
    {
        public SimpleTest()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            flipper.FrontVisible = !flipper.FrontVisible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (flipOrientationButton.Content.ToString().Contains("Horizontal"))
            {
                flipper.SpinAxis = Orientation.Vertical;
                flipOrientationButton.Content = "Vertical spin axis";
            }
            else
            {
                flipper.SpinAxis = Orientation.Horizontal;
                flipOrientationButton.Content = "Horizontal spin axis";
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            flipper.SpinTime = e.NewValue;
        }
    }
}
