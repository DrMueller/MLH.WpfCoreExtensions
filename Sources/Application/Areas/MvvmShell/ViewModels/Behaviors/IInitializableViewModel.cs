using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors
{
    public interface IInitializableViewModel : IViewModelWithBehavior
    {
        Task InitializeAsync([CanBeNull] params object[] initParams);
    }
}