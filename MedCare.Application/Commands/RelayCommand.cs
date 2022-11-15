using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedCare.Application.Commands
{
    public class RelayCommand : ICommand
    {

        public event EventHandler CanExecuteChanged;
        public Action action;

        public RelayCommand(Action action)
        {
            if (action == null)
                throw new NullReferenceException("execute");

            this.action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter) => action.Invoke();
    }
}
