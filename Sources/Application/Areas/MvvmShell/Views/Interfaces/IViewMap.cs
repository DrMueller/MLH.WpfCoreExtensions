using System.Diagnostics.CodeAnalysis;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Views.Interfaces
{
    [SuppressMessage("Microsoft.Design", "CA1040:AvoidEmptyInterfaces", Justification = "Marker Interface")]
    public interface IViewMap<TViewModel>
        where TViewModel : IViewModel
    {
    }
}