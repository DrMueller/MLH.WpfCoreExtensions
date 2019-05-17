namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors
{
    public interface INavigatableVm : IDisplayableVm
    {
        string NavigationDescription { get; }
        int NavigationSequence { get; }
    }
}