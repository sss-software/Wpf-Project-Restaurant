using BL;
using BussinnesEntity;
using System;
using System.Windows;
using System.Windows.Input;

namespace Wpf.Waiter
{
    public class DeleteRationCommand : ICommand 
    {
        private readonly Func<bool> _canExecute;
        private readonly Action<Order, Ration> _deleted;

        public DeleteRationCommand(Func<bool> canExecute, Action<Order, Ration> deleted)
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
                var values = (object[])parameter;
               
                var order = values[0] as Order;
                var ration = values[1] as Ration;

                if (order != null)
                {
                    var result = MessageBox.Show("Are you sure you wish to delete the ration?",
                                                              "Confirm Delete", MessageBoxButton.OKCancel);

                    if (result.Equals(MessageBoxResult.OK))
                    {
                        //BussinesLogic bl = new BussinesLogic();
                        //bl.Delete(order);
                        order.RationList.Remove(ration);
                        if (_deleted != null)
                        {
                            _deleted(order,ration);
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
