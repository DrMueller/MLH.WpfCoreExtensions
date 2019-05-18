using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.Mlh.WpfCoreExtensions.NugetTestUI.Areas.Individuals.ViewModels.Overview
{
    public class IndividualsOverviewViewModel : ViewModelBase, IInitializableViewModel, INavigatableViewModel
    {
        private readonly CommandContainer _commandContainer;
        public CommandsViewData Commands => _commandContainer.Commands;
        public string HeadingDescription => "Individuals Overview";
        public string NavigationDescription => "Individuals";
        public int NavigationSequence => 1;

        public IndividualsOverviewViewModel(CommandContainer commandContainer)
        {
            _commandContainer = commandContainer;
        }

        public async Task InitializeAsync(params object[] initParams)
        {
            await _commandContainer.InitializeAsync(this);
        }
    }
}