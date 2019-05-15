using System.Windows.Input;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Commands
{
    public interface IViewModelCommand
    {
        ICommand Command { get; }
        string Description { get; }
    }
}