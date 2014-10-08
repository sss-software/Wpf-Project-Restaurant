using System.Windows;
using System;

namespace Wpf.Login
{
    public interface ILoadable
    {
        void Loaded(String UserName);
    }

    public partial class LoginWindow : Window, ILoadable
    {
        public LoginWindow()
        {
            InitializeComponent();
            DataContext = new LogInViewModel(this);
        }

        public new void Loaded(String UserName)
        {
            Dispatcher.Invoke(new Action(delegate
            {
                Hide();
                switch (UserName)
                {
                    default:
                        Window window = new Kitchen();
                        window.Show();
                    break;
                }
                
            }));
        }
    }
}
