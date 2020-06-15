using System.Diagnostics.CodeAnalysis;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Views.Interfaces
{
    [SuppressMessage("Microsoft.Design", "CA1040:AvoidEmptyInterfaces", Justification = "Marker Interface")]
#pragma warning disable SA1515 // Single-line comment must be preceded by blank line
// ReSharper disable once UnusedTypeParameter
    public interface IViewMap<TViewModel>
#pragma warning restore SA1515 // Single-line comment must be preceded by blank line
        where TViewModel : IViewModel
    {
    }
}