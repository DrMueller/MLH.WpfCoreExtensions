using System.Windows.Input;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands
{
    public class ViewModelCommand : IViewModelCommand
    {
        public ICommand Command { get; }
        public string Description { get; }

        public ViewModelCommand(string description, ICommand command)
        {
            Description = description;
            Command = command;
        }
    }
}