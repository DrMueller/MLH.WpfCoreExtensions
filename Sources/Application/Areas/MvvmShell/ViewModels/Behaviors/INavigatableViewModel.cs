namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors
{
    public interface INavigatableViewModel : IDisplayableViewModel
    {
        string NavigationDescription { get; }
        int NavigationSequence { get; }
    }
}