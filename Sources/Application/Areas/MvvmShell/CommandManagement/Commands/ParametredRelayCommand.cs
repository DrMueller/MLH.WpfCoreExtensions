using System;
using System.Windows.Input;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands
{
    public class ParametredRelayCommand : ICommand
    {
        private readonly Action<object> _action;
        private readonly Func<bool> _canExecute;

        public ParametredRelayCommand(Action<object> action, Func<bool> canExecute = null)
        {
            _canExecute = canExecute;
            _action = action;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke() ?? true;
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }
    }
}