using System;
using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.InformationHandling.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.InformationHandling.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.Navigation.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.ViewExtensions.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Details.ViewModels.Details;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Overview.ViewServices;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Overview.ViewModels.Overview
{
    public class CommandContainer : IViewModelCommandContainer<IndividualsOverviewViewModel>
    {
        private readonly IInformationPublisher _informationPublisher;
        private readonly INavigationService _navigationService;
        private readonly IIndividualOverviewViewService _overviewService;
        private IndividualsOverviewViewModel _context;
        public CommandsViewData Commands { get; private set; }

        private static ViewModelCommand ThrowException
        {
            get
            {
                return new ViewModelCommand(
                    "Throw Ex",
                    new RelayCommand(
                        () => throw new ArgumentException("Hello Test")));
            }
        }

        private ViewModelCommand CreateIndividual
        {
            get
            {
                return new ViewModelCommand(
                    "Create",
                    new AsyncRelayCommand(() => _navigationService.NavigateToAsync<IndividualDetailsViewModel>()));
            }
        }

        private ViewModelCommand DeleteIndividual
        {
            get
            {
                return new ViewModelCommand(
                    "Delete",
                    new AsyncRelayCommand(
                        DeleteIndividualAsync,
                        () => IsIndividualSelected));
            }
        }

        private bool IsIndividualSelected => _context.SelectedIndividual != null;

        private ViewModelCommand UpdateIndividual
        {
            get
            {
                return new ViewModelCommand(
                    "Update",
                    new RelayCommand(
                        async () => await _navigationService.NavigateToAsync<IndividualDetailsViewModel>(),
                        () => IsIndividualSelected));
            }
        }

        public CommandContainer(
            IInformationPublisher informationPublisher,
            IIndividualOverviewViewService overviewService,
            INavigationService navigationService)
        {
            _informationPublisher = informationPublisher;
            _overviewService = overviewService;
            _navigationService = navigationService;
        }

        public Task InitializeAsync(IndividualsOverviewViewModel context)
        {
            _context = context;
            Commands = new CommandsViewData(
                CreateIndividual,
                UpdateIndividual,
                DeleteIndividual,
                ThrowException);

            return Task.CompletedTask;
        }

        private async Task DeleteIndividualAsync()
        {
            _informationPublisher.Publish(InformationEntry.CreateInfo($"Deleting Individual {_context.SelectedIndividual.FormattedName}..", true));
            await _overviewService.DeleteIndividualAsync(_context.SelectedIndividual.Id);
            _informationPublisher.Publish(InformationEntry.CreateSuccess($"Individual deleted", false, 5));
        }
    }
}