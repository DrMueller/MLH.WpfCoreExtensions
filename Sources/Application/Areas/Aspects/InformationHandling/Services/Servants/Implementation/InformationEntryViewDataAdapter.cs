using System.Windows.Media;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.ViewData;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.Services.Servants.Implementation
{
    internal class InformationEntryViewDataAdapter : IInformationEntryViewDataAdapter
    {
        public InformationEntryViewData Adapt(InformationEntry infoEntry)
        {
            var brush = AdaptBrush(infoEntry.EntryType);

            return new InformationEntryViewData(
                infoEntry.Message,
                infoEntry.ShowBusy,
                brush,
                infoEntry.DisplayLengthInSeconds);
        }

        private static Brush AdaptBrush(InformationEntryType entryType)
        {
            switch (entryType)
            {
                case InformationEntryType.Info:
                {
                    return Brushes.Black;
                }

                case InformationEntryType.Success:
                {
                    return Brushes.DarkGreen;
                }

                case InformationEntryType.Error:
                {
                    return Brushes.DarkRed;
                }

                default:
                {
                    return Brushes.Black;
                }
            }
        }
    }
}