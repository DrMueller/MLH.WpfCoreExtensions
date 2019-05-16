using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Details.ViewData;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Details.ViewServices
{
    public interface IIndividualDetailsViewService
    {
        Task<IndividualDetailsViewData> LoadAsync(string id);

        Task SaveAsync(IndividualDetailsViewData data);
    }
}