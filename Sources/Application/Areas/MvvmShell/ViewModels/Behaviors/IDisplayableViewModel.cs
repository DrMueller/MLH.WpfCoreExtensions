namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors
{
    public interface IDisplayableViewModel : IViewModelWithBehavior
    {
        string HeadingDescription { get; }
    }
}