using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands
{
    public class ParametredAsyncRelayCommand : ICommand
    {
        private readonly Func<object, Task> _action;
        private readonly Func<object, bool> _canExecute;

        public ParametredAsyncRelayCommand(Func<object, Task> action, Func<object, bool> canExecute = null)
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
            return _canExecute?.Invoke(parameter) ?? true;
        }

        [SuppressMessage("Usage", "VSTHRD100:Avoid async void methods", Justification = "Need to use ICommand interface")]
        public async void Execute(object parameter)
        {
            await _action(parameter);
        }
    }
}