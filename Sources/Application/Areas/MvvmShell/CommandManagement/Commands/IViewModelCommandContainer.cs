using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands
{
    public interface IViewModelCommandContainer<T>
        where T : IViewModel
    {
        Task InitializeAsync(T context);
    }
}