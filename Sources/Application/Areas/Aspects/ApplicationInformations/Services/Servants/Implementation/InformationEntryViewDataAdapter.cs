using System.Windows.Media;
using JetBrains.Annotations;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.ViewData;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Services.Servants.Implementation
{
    [UsedImplicitly]
    internal class InformationEntryViewDataAdapter : IInformationEntryViewDataAdapter
    {
        public InformationEntryViewData Adapt(InformationEntry infoEntry)
        {
            return new InformationEntryViewData(
                infoEntry.Message,
                infoEntry.ShowBusy,
                infoEntry.DisplayLengthInSeconds,
                AdaptType(infoEntry.EntryType));
        }

        private InformationEntryTypeViewData AdaptType(InformationEntryType type)
        {
            switch (type)
            {
                case InformationEntryType.Error:
                {
                    return InformationEntryTypeViewData.Error;
                }
                case InformationEntryType.Success:
                    {
                        return InformationEntryTypeViewData.Success;
                    }
                default:
                    {
                        return InformationEntryTypeViewData.Info;
                    }
            }
        }

    }
}