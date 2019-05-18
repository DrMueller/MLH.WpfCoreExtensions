using System.Threading.Tasks;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors
{
    public interface IInitializableViewModel : IViewModelWithBehavior
    {
        Task InitializeAsync(params object[] initParams);
    }
}