using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.Navigation.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.ViewExtensions.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Details.ViewServices;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Overview.ViewModels.Overview;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Details.ViewModels.Details
{
    public class CommandContainer : IViewModelCommandContainer<IndividualDetailsViewModel>
    {
        private readonly IIndividualDetailsViewService _detailsService;
        private readonly INavigationService _navigationService;
        private IndividualDetailsViewModel _context;

        public CommandsViewData Commands { get; private set; }

        private ViewModelCommand Cancel
        {
            get
            {
                return new ViewModelCommand(
                    "Cancel",
                    new RelayCommand(async () => await NavigateToOverviewAsync()));
            }
        }

        private ViewModelCommand SaveIndividual
        {
            get
            {
                return new ViewModelCommand(
                    "Save",
                    new RelayCommand(async () =>
                    {
                        await _detailsService.SaveAsync(_context.IndividualDetails);
                        await NavigateToOverviewAsync();
                    }));
            }
        }

        public CommandContainer(
            INavigationService navigationService,
            IIndividualDetailsViewService detailsService)
        {
            _navigationService = navigationService;
            _detailsService = detailsService;
        }

        public Task InitializeAsync(IndividualDetailsViewModel context)
        {
            _context = context;

            Commands = new CommandsViewData(
                SaveIndividual,
                Cancel);

            return Task.CompletedTask;
        }

        private async Task NavigateToOverviewAsync()
        {
            await _navigationService.NavigateToAsync<IndividualsOverviewViewModel>();
        }
    }
}