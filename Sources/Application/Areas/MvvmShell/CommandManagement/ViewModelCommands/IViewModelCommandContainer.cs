using System.Threading.Tasks;
using JetBrains.Annotations;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands
{
    [PublicAPI]
    public interface IViewModelCommandContainer<in T>
        where T : IViewModel
    {
        Task InitializeAsync(T context);
    }
}