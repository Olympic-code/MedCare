using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedCare.Application.ViewModels
{
    //public class ViewModelCommand : ICommand
    //{
    //    private Action<object> _executeAction;
    //    private Predicate<object> _canExecuteAction;

    //    public event EventHandler CanExecuteChanged
    //    {
    //        add { CommandManager.RequerySuggested += value; }
    //        remove { CommandManager.RequerySuggested -= value; }
    //    }

    //    public ViewModelCommand(Action<object> execute, Predicate<object> canExecuteAction = null)
    //    {
    //        _executeAction = execute;
    //        _canExecuteAction = canExecuteAction;
    //    }

    //    public bool CanExecute(object parameter)
    //    {
    //        return _canExecuteAction == null ? true : _canExecuteAction(parameter);
    //    }

    //    public void Execute(object parameter)
    //    {
    //        _executeAction(parameter);
    //    }
    //}
}
