using System;
using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services
{
    public interface IViewModelDisplayService
    {
        Task DisplayAsync<T>(params object[] initParams)
            where T : IDisplayableViewModel;

        Task DisplayAsync(Type targetType);
    }
}