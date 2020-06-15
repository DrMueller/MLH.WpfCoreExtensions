using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands
{
    public class AsyncRelayCommand : ICommand
    {
        private readonly Func<Task> _action;
        private readonly Func<bool> _canExecute;

        public AsyncRelayCommand(Func<Task> action, Func<bool> canExecute = null)
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

        public async void Execute(object parameter)
        {
            await _action();
        }
    }
}