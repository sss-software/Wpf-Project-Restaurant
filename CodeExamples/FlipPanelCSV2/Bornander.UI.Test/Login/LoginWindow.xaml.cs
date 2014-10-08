using System.Windows;
using System;

namespace Bornander.UI.Test.Login
{
    public interface ILoadable
    {
        void Loaded();
    }

    public partial class LoginWindow : Window, ILoadable
    {
        public LoginWindow()
        {
            InitializeComponent();
            DataContext = new LogInViewModel(this);
        }

        public new void Loaded()
        {
            Dispatcher.Invoke(new Action(delegate
            {
                Close();
                Window window = new StockWindow();
                window.Show();
            }));
        }
    }
}
