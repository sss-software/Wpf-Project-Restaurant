using System.Windows;
using Bornander.UI.Test.Login;

namespace Bornander.UI.Test
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SimpleTest(object sender, RoutedEventArgs e)
        {
            Window window = new SimpleTest();
            window.ShowDialog();
        }

        private void ComplexTest(object sender, RoutedEventArgs e)
        {
            Window window = new LoginWindow();
            window.ShowDialog();
        }
    }
}
