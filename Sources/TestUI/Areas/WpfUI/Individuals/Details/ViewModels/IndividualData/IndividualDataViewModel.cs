using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Details.ViewData;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Details.ViewModels.IndividualData
{
    public class IndividualDataViewModel : ViewModelBase
    {
        public IndividualDetailsViewData IndividualDetails { get; private set; }

        public void Initialize(IndividualDetailsViewData individualDetails)
        {
            IndividualDetails = individualDetails;
        }
    }
}