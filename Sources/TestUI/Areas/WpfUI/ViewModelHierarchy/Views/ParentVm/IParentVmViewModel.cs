using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.ViewModelHierarchy.Views.ChildVm;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.ViewModelHierarchy.Views.ParentVm
{
    public interface IParentVmViewModel : INavigatableViewModel, IInitializableViewModel
    {
        ChildVmViewModel ChildVm { get; }
    }
}