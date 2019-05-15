namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors
{
    public interface INavigatableViewModel : IViewModelWithBehaviorBase
    {
        string HeadingDescription { get; }
        string NavigationDescription { get; }
        int NavigationSequence { get; }
    }
}