﻿using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Details.ViewServices;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Overview.ViewModels.Overview;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Details.ViewModels.Details
{
    public class CommandContainer : IViewModelCommandContainer<IndividualDetailsViewModel>
    {
        private readonly IIndividualDetailsViewService _detailsService;
        private readonly IViewModelDisplayService _vmDisplayService;
        private IndividualDetailsViewModel _context;

        public CommandContainer(
            IViewModelDisplayService vmDisplayService,
            IIndividualDetailsViewService detailsService)
        {
            _vmDisplayService = vmDisplayService;
            _detailsService = detailsService;
        }

        public CommandsViewData Commands { get; private set; }

        private ViewModelCommand Cancel
        {
            get
            {
                return new ViewModelCommand(
                    "Cancel",
#pragma warning disable VSTHRD101 // Avoid unsupported async delegates
                    new RelayCommand(async () => await NavigateToOverviewAsync()));
#pragma warning restore VSTHRD101 // Avoid unsupported async delegates
            }
        }

        private ViewModelCommand SaveIndividual
        {
            get
            {
                return new ViewModelCommand(
                    "Save",
                    new RelayCommand(
#pragma warning disable VSTHRD101 // Avoid unsupported async delegates
                        async () =>
                        {
                            await _detailsService.SaveAsync(_context.IndividualDetails);
                            await NavigateToOverviewAsync();
                        },
                        () => !_context.IndividualDetails.HasErrors));
#pragma warning restore VSTHRD101 // Avoid unsupported async delegates
            }
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
            await _vmDisplayService.DisplayAsync<IndividualsOverviewViewModel>();
        }
    }
}