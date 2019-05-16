using System.Threading.Tasks;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors
{
    public interface IInitializableViewModel : IViewModelWithBehaviorBase
    {
        Task InitializeAsync(params object[] initParams);
    }
}