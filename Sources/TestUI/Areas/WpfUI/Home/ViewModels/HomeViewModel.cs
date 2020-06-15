using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Home.ViewModels
{
    public class HomeViewModel : ViewModelBase, INavigatableViewModel
    {
        public string HeadingDescription => "Hello Home";
        public string NavigationDescription => "Home";

        public int NavigationSequence => 1;
    }
}