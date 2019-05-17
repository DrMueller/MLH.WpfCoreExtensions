using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services
{
    public interface IVmDisplayService
    {
        Task DisplayAsync<T>(params object[] initParams)
            where T : IDisplayableVm;

        Task DisplayAsync(IDisplayableVm target);
    }
}