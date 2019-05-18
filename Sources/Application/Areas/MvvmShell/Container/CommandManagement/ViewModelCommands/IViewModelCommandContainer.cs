using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Container.CommandManagement.ViewModelCommands
{
    public interface IViewModelCommandContainer<T>
        where T : IViewModel
    {
        Task InitializeAsync(T context);
    }
}