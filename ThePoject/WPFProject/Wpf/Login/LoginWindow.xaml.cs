using System.Windows;
using System;
using Wpf.Manager;
using Wpf.Waiter;

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
                Window window ;
                switch (type)
                {
                    case BussinnesEntity.Type.chef:
                        window = new KitchenWindow();
                        window.Show();
                    break;
                    case BussinnesEntity.Type.manager:
                        window = new ManagerWindow();
                        window.Show();
                    break;
                    case BussinnesEntity.Type.waiter:
                        window = new WaiterWindow();
                        window.Show();
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
