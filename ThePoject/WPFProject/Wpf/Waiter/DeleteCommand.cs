using BL;
using BussinnesEntity;
using System;
using System.Windows;
using System.Windows.Input;

namespace Wpf.Waiter
{
    public class DeleteCommand : ICommand 
    {
        private readonly Func<bool> _canExecute;
        private readonly Action<Order> _deleted;

        public DeleteCommand(Func<bool> canExecute, Action<Order> deleted)
        {
            _canExecute = canExecute;
            _deleted = deleted;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute();
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                var order = parameter as Order;
                if (order != null)
                {
                    var result = MessageBox.Show("Are you sure you wish to delete the order?",
                                                              "Confirm Delete", MessageBoxButton.OKCancel);

                    if (result.Equals(MessageBoxResult.OK))
                    {
                        BussinesLogic bl = new BussinesLogic();
                        bl.Delete(order); 
                        if (_deleted != null)
                        {
                            _deleted(order);
                        }
                    }
                }
            }
        }

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
