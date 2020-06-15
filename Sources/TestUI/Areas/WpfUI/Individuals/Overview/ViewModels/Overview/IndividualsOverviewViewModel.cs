using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfCoreExtensions.Areas.ViewExtensions.Grids.SearchGrids.Models;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Overview.ViewData;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Overview.ViewServices;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Overview.ViewModels.Overview
{
    public class IndividualsOverviewViewModel : ViewModelBase, INavigatableViewModel, IInitializableViewModel
    {
        private readonly CommandContainer _commandContainer;
        private readonly IIndividualOverviewViewService _overviewService;
        private GridSearchExpression _searchExpression;
        public CommandsViewData Commands => _commandContainer.Commands;
        public string HeadingDescription => "Individuals Overview";
        public ObservableCollection<IndividualOverviewViewData> Individuals { get; private set; }
        public string NavigationDescription => "Individuals";
        public int NavigationSequence => 2;
        public Func<object, bool> OnFiltering => FilterIndividual;

        public GridSearchExpression SearchExpression
        {
            get => _searchExpression;
            set
            {
                if (_searchExpression == value)
                {
                    return;
                }

                _searchExpression = value;
                OnPropertyChanged();
            }
        }

        public IndividualOverviewViewData SelectedIndividual { get; set; }
        public ICommand UpdateIndividualCommand => _commandContainer.UpdateIndividualCommand;

        public IndividualsOverviewViewModel(
            CommandContainer commandContainer,
            IIndividualOverviewViewService overviewService)
        {
            _commandContainer = commandContainer;
            _overviewService = overviewService;
        }

        public async Task InitializeAsync(params object[] initParams)
        {
            await _commandContainer.InitializeAsync(this);
            var individuals = await _overviewService.LoadAllAsync();
            Individuals = new ObservableCollection<IndividualOverviewViewData>(individuals);
        }

        private bool FilterIndividual(object data)
        {
            var ind = (IndividualOverviewViewData)data;
            return SearchExpression.IsPartOf(ind.FormattedName) || SearchExpression.IsPartOf(ind.FormattedBirthdate);
        }
    }
}