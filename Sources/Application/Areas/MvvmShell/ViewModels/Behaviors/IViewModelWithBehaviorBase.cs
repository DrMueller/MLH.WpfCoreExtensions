using System.Diagnostics.CodeAnalysis;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors
{
    [SuppressMessage("Microsoft.Design", "CA1040:AvoidEmptyInterfaces", Justification = "Marker Interface")]
    public interface IViewModelWithBehaviorBase : IViewModel
    {
    }
}