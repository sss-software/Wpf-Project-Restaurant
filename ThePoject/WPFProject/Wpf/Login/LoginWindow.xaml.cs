using System.Windows;
using System;

namespace Wpf.Login
{
    public interface ILoadable
    {
        void Loaded(BussinnesEntity.Type type);
        void Cancel();
    }

    public partial class LoginWindow : Window, ILoadable
    {
        public LoginWindow()
        {
            InitializeComponent();
            DataContext = new LogInViewModel(this);
        }

        public new void Loaded(BussinnesEntity.Type type)
        {
            Dispatcher.Invoke(new Action(delegate
            {
                Hide();
                switch (type)
                {
                    case BussinnesEntity.Type.chef:
                        Window window = new KitchenWindow();
                        window.Show();
                        break;
                    case BussinnesEntity.Type.manager:
                        break;
                    case BussinnesEntity.Type.waiter:
                        break;
                    default:
                        break;
                }

            }));
        }

        public new void Cancel()
        {
            this.Hide();
        }
    }
}
