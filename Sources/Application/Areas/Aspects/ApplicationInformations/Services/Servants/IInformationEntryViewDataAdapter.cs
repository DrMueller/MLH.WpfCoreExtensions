using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.ViewData;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Services.Servants
{
    internal interface IInformationEntryViewDataAdapter
    {
        InformationEntryViewData Adapt(InformationEntry infoEntry);
    }
}