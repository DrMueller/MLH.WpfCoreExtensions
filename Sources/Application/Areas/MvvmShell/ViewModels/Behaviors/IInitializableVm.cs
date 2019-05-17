using System.Threading.Tasks;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors
{
    public interface IInitializableVm : IVmWithBehavior
    {
        Task InitializeAsync(params object[] initParams);
    }
}