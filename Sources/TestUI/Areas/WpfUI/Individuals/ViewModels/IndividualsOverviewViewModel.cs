using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.ViewModels
{
    public class IndividualsOverviewViewModel : ViewModelBase, INavigatableViewModel
    {
        public string NavigationDescription => "Individuals";

        public int NavigationSequence => 2;

        public string HeadingDescription => "Hello Individuals";
    }
}