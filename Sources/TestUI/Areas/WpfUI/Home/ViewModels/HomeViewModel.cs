using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Home.ViewModels
{
    public class HomeViewModel : ViewModelBase, INavigatableVm
    {
        public string NavigationDescription => "Home";

        public int NavigationSequence => 1;

        public string HeadingDescription => "Hello Home";
    }
}