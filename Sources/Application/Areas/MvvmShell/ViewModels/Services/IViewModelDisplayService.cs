using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Interfaces;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services
{
    public interface IViewModelDisplayService
    {
        Task DisplayAsync<T>(params object[] initParams)
            where T : IViewModel;

        Task DisplayAsync(IViewModel target);
    }
}