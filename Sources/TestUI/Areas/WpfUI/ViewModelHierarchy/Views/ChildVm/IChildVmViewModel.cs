using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.ViewModelHierarchy.Views.ChildVm
{
    public interface IChildVmViewModel : IInitializableViewModel
    {
        string ChildText { get; set; }
    }
}