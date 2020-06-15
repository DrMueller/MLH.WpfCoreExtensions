using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.ViewData;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.Services.Servants
{
    internal interface IInformationEntryViewDataAdapter
    {
        InformationEntryViewData Adapt(InformationEntry infoEntry);
    }
}