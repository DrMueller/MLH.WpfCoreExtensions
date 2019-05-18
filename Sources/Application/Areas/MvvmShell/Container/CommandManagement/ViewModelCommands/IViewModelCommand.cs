using System.Windows.Input;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Container.CommandManagement.ViewModelCommands
{
    public interface IViewModelCommand
    {
        ICommand Command { get; }
        string Description { get; }
    }
}