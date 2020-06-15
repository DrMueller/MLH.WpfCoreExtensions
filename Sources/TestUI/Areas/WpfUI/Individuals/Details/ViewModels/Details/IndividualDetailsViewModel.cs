using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Details.ViewData;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Details.ViewModels.IndividualData;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Details.ViewServices;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Details.ViewModels.Details
{
    public class IndividualDetailsViewModel : ViewModelBase, IInitializableViewModel, IDisplayableViewModel
    {
        private readonly CommandContainer _commandContainer;
        private readonly IIndividualDetailsViewService _detailsService;
        private readonly IViewModelFactory _viewModelFactory;
        private IndividualDetailsViewData _individualDetails;

        public IndividualDetailsViewModel(
            IViewModelFactory viewModelFactory,
            CommandContainer commandContainer,
            IIndividualDetailsViewService detailsService,
            IndividualDataViewModel individualData)
        {
            _viewModelFactory = viewModelFactory;
            _commandContainer = commandContainer;
            _detailsService = detailsService;
            IndividualData = individualData;
        }

        public CommandsViewData Commands => _commandContainer.Commands;

        public string HeadingDescription { get; private set; }
        public IndividualDataViewModel IndividualData { get; }

        public IndividualDetailsViewData IndividualDetails
        {
            get => _individualDetails;
            set
            {
                if (_individualDetails != value)
                {
                    _individualDetails = value;
                    OnPropertyChanged();
                }
            }
        }

        public async Task InitializeAsync(params object[] initParams)
        {
            var idMaybe = (Maybe<string>)initParams.First();

            await idMaybe.Evaluate(
                async id =>
                {
                    IndividualDetails = await _detailsService.LoadAsync(id);
                    HeadingDescription = "Edit Individual";
                },
                async () =>
                {
                    IndividualDetails = await _viewModelFactory.CreateAsync<IndividualDetailsViewData>();
                    HeadingDescription = "New Individual";
                });

            IndividualData.Initialize(IndividualDetails);
            await _commandContainer.InitializeAsync(this);
        }
    }
}