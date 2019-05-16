using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfCoreExtensions.Areas.ViewExtensions.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Overview.ViewServices;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.ViewData;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Overview.ViewModels.Overview
{
    public class IndividualsOverviewViewModel : ViewModelBase, INavigatableViewModel, IInitializableViewModel
    {
        private readonly CommandContainer _commandContainer;
        private readonly IIndividualOverviewViewService _overviewService;
        public CommandsViewData Commands => _commandContainer.Commands;

        public string HeadingDescription => "Hello Individuals";
        public IEnumerable<IndividulOverviewViewData> Individuals { get; private set; }
        public string NavigationDescription => "Individuals";
        public int NavigationSequence => 2;
        public IndividulOverviewViewData SelectedIndividual { get; set; }

        public IndividualsOverviewViewModel(
            CommandContainer commandContainer,
            IIndividualOverviewViewService overviewService)
        {
            _commandContainer = commandContainer;
            _overviewService = overviewService;
        }

        public async Task InitializeAsync()
        {
            await _commandContainer.InitializeAsync(this);
            Individuals = await _overviewService.LoadAllAsync();
        }
    }
}