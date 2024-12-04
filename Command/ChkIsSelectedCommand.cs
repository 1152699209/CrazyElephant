using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CrazyElephant.Command
{
    public class ChkIsSelectedCommand : ICommand
    {
        private readonly Action chkAction;
        public event EventHandler? CanExecuteChanged;

        public ChkIsSelectedCommand(Action action)
        {
            this.chkAction = action;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            chkAction();
        }
    }
}
