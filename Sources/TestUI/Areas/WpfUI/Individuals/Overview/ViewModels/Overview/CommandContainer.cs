using System.Threading.Tasks;
using System.Windows.Input;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.ViewExtensions.Grids.SearchGrids.Models;
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

        public ICommand UpdateIndividualCommand =>
            new AsyncRelayCommand(
                async () =>
                {
                    var idMaybe = (Maybe<string>)_context.SelectedIndividual.Id;
                    await _vmDisplayService.DisplayAsync<IndividualDetailsViewModel>(idMaybe);
                },
                () => IsIndividualSelected);

        private ViewModelCommand ClearSearch =>
            new ViewModelCommand(
                "Clear search",
                new RelayCommand(
                    () => _context.SearchExpression = GridSearchExpression.CreateEmpty()));

        private ViewModelCommand CreateIndividual =>
            new ViewModelCommand(
                "Create",
                new AsyncRelayCommand(
                    () =>
                        _vmDisplayService.DisplayAsync<IndividualDetailsViewModel>(Maybe.CreateNone<string>())));

        private ViewModelCommand DeleteIndividual =>
            new ViewModelCommand(
                "Delete",
                new AsyncRelayCommand(
                    DeleteIndividualAsync,
                    () => IsIndividualSelected));

        private bool IsIndividualSelected => _context.SelectedIndividual != null;

        private ViewModelCommand SearchMatthias2 =>
            new ViewModelCommand(
                "Search Matthias2",
                new RelayCommand(
                    () => _context.SearchExpression = GridSearchExpression.CreateFrom("Matthias2")));

        private ViewModelCommand UpdateIndividual =>
            new ViewModelCommand(
                "Update",
                UpdateIndividualCommand);

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
                DeleteIndividual,
                SearchMatthias2,
                ClearSearch);

            return Task.CompletedTask;
        }

        private async Task DeleteIndividualAsync()
        {
            _informationPublisher.Publish(
                InformationEntry.CreateInfo(
                    $"Deleting Individual {_context.SelectedIndividual.FormattedName}..",
                    true));
            await _overviewService.DeleteIndividualAsync(_context.SelectedIndividual.Id);
            _context.Individuals.Remove(_context.SelectedIndividual);
            _informationPublisher.Publish(InformationEntry.CreateSuccess("Individual deleted", false, 5));
        }
    }
}