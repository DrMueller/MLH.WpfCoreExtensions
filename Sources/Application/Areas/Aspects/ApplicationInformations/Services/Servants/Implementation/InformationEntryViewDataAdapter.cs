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