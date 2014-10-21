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
        private readonly Action<Table> _deleted;

        public DeleteCommand(Func<bool> canExecute, Action<Table> deleted)
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
                var table = parameter as Table;
                if (table != null)
                {
                    var result = MessageBox.Show("Are you sure you wish to delete the Table?",
                                                              "Confirm Delete", MessageBoxButton.OKCancel);

                    if (result.Equals(MessageBoxResult.OK))
                    {
                        BussinesLogic bl = new BussinesLogic();
                        bl.Delete(table); 
                        if (_deleted != null)
                        {
                            _deleted(table);
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
