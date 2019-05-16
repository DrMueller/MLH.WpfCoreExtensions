using System.Threading.Tasks;
using System.Windows.Input;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using Mmu.Mlh.WpfCoreExtensions.Areas.InformationHandling.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.InformationHandling.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.ViewExtensions.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Details.ViewModels.Details;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Overview.ViewServices;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Overview.ViewModels.Overview
{
    public class CommandContainer : IViewModelCommandContainer<IndividualsOverviewViewModel>
    {
        private readonly IInformationPublisher _informationPublisher;
        private readonly IIndividualOverviewViewService _overviewService;
        private readonly IViewModelDisplayService _vmDisplayService;
        private IndividualsOverviewViewModel _context;
        public CommandsViewData Commands { get; private set; }

        public ICommand UpdateIndividualCommand
        {
            get
            {
                return new RelayCommand(
                        async () =>
                        {
                            var idMaybe = Maybe.CreateSome(_context.SelectedIndividual.Id);
                            await _vmDisplayService.DisplayAsync<IndividualDetailsViewModel>(idMaybe);
                        },
                        () => IsIndividualSelected);
            }
        }

        private ViewModelCommand CreateIndividual
        {
            get
            {
                return new ViewModelCommand(
                    "Create",
                    new AsyncRelayCommand(() => _vmDisplayService.DisplayAsync<IndividualDetailsViewModel>(Maybe.CreateNone<string>())));
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
                    UpdateIndividualCommand);
            }
        }

        public CommandContainer(
            IInformationPublisher informationPublisher,
            IIndividualOverviewViewService overviewService,
            IViewModelDisplayService vmDisplayService)
        {
            _informationPublisher = informationPublisher;
            _overviewService = overviewService;
            _vmDisplayService = vmDisplayService;
        }

        public Task InitializeAsync(IndividualsOverviewViewModel context)
        {
            _context = context;
            Commands = new CommandsViewData(
                CreateIndividual,
                UpdateIndividual,
                DeleteIndividual);

            return Task.CompletedTask;
        }

        private async Task DeleteIndividualAsync()
        {
            _informationPublisher.Publish(InformationEntry.CreateInfo($"Deleting Individual {_context.SelectedIndividual.FormattedName}..", true));
            await _overviewService.DeleteIndividualAsync(_context.SelectedIndividual.Id);
            _context.Individuals.Remove(_context.SelectedIndividual);
            _informationPublisher.Publish(InformationEntry.CreateSuccess($"Individual deleted", false, 5));
        }
    }
}