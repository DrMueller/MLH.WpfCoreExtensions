using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
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

        public async Task InitializeAsync(params object[] initParams)
        {
            var idMaybe = (Maybe<string>)initParams.First();

            await idMaybe.Evaluate(
                whenSome: async id =>
                {
                    IndividualDetails = await _detailsService.LoadAsync(id);
                },
                whenNone: () =>
                {
                    IndividualDetails = new IndividualDetailsViewData();
                    return Task.CompletedTask;
                });

            IndividualData.Initialize(IndividualDetails);
            await _commandContainer.InitializeAsync(this);
        }
    }
}