using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfCoreExtensions.Areas.ViewExtensions.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Details.ViewData;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Details.ViewModels.IndividualData;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Details.ViewServices;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Details.ViewModels.Details
{
    public class IndividualDetailsViewModel : ViewModelBase, IInitializableViewModel
    {
        private readonly CommandContainer _commandContainer;
        private readonly IIndividualDetailsViewService _detailsService;
        private IndividualDetailsViewData _individualDetails;
        public CommandsViewData Commands => _commandContainer.Commands;

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

        public IndividualDetailsViewModel(
            CommandContainer commandContainer,
            IIndividualDetailsViewService detailsService,
            IndividualDataViewModel individualData)
        {
            _commandContainer = commandContainer;
            _detailsService = detailsService;
            IndividualData = individualData;
        }

        public async Task InitializeAsync()
        {
            IndividualDetails = new IndividualDetailsViewData();
            IndividualData.Initialize(IndividualDetails);
            await _commandContainer.InitializeAsync(this);
        }
    }
}