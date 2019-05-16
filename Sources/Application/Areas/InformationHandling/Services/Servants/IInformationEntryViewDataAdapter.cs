using Mmu.Mlh.WpfCoreExtensions.Areas.InformationHandling.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.InformationHandling.ViewData;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.InformationHandling.Services.Servants
{
    internal interface IInformationEntryViewDataAdapter
    {
        InformationEntryViewData Adapt(InformationEntry infoEntry);
    }
}