using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Navigation.Services
{
    public interface INavigationService
    {
        Task NavigateToAsync<T>()
            where T : IViewModel;

        Task NavigateToAsync(IViewModel target);
    }
}