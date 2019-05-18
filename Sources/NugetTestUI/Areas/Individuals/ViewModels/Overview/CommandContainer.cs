using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;
using Mmu.Mlh.WpfCoreExtensions.NugetTestUI.Areas.Organisations.ViewModels.Overview;

namespace Mmu.Mlh.WpfCoreExtensions.NugetTestUI.Areas.Individuals.ViewModels.Overview
{
    public class CommandContainer : IViewModelCommandContainer<IndividualsOverviewViewModel>
    {
        private readonly IViewModelDisplayService _vmDisplayService;

        public CommandsViewData Commands { get; private set; }

        private ViewModelCommand NavigateToOrganisations
        {
            get
            {
                return new ViewModelCommand(
                    "Show Organisations",
                    new AsyncRelayCommand(() => _vmDisplayService.DisplayAsync<OrganisationsOverviewViewModel>()));
            }
        }

        public CommandContainer(IViewModelDisplayService vmDisplayService)
        {
            _vmDisplayService = vmDisplayService;
        }

        public Task InitializeAsync(IndividualsOverviewViewModel context)
        {
            Commands = new CommandsViewData(NavigateToOrganisations);
            return Task.CompletedTask;
        }
    }
}