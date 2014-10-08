using System;
using System.Windows.Input;

namespace Wpf
{
    public class DelegateCommand : ICommand
    {
        public Predicate<object> CanExecutePredicate { get; private set; }
        public Action<object> ExecuteAction { get; private set; }

        public DelegateCommand(Action<object> execute)
            : this(null, execute)
        {
        }

        public DelegateCommand(Predicate<object> canExecute, Action<object> execute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            CanExecutePredicate = canExecute;
            ExecuteAction = execute;
        }

        public bool CanExecute(object parameter)
        {
            if (CanExecutePredicate == null)
                return true;

            return CanExecutePredicate(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            ExecuteAction(parameter);
        }
    }
}
