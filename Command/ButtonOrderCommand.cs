using CrazyElephant.Service;
using CrazyElephant.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace CrazyElephant.Command
{
    public class ButtonOrderCommand : ICommand
    {
        private readonly Action orderAction;

        public ButtonOrderCommand(Action action)
        {
            this.orderAction = action;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            orderAction();
        }
    }
}
