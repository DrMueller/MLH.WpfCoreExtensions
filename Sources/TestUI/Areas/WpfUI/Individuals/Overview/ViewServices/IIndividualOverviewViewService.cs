using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.ViewData;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Overview.ViewServices
{
    public interface IIndividualOverviewViewService
    {
        Task DeleteIndividualAsync(string id);

        Task<IReadOnlyCollection<IndividualOverviewViewData>> LoadAllAsync();
    }
}