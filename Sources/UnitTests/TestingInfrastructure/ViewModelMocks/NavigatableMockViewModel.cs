using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.Mlh.WpfCoreExtensions.UnitTests.TestingInfrastructure.ViewModelMocks
{
    public class NavigatableMockViewModel : ViewModelBase, INavigatableViewModel
    {
        public string HeadingDescription => "Mock Heading";
        public string NavigationDescription => "Mock";
        public int NavigationSequence => 1;
    }
}