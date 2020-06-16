using JetBrains.Annotations;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors
{
    [PublicAPI]
    public interface IDisplayableViewModel : IViewModelWithBehavior
    {
        string HeadingDescription { get; }
    }
}