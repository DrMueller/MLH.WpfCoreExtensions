using System.Windows.Media;
using Mmu.Mlh.WpfCoreExtensions.Areas.InformationHandling.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.InformationHandling.ViewData;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.InformationHandling.Services.Servants.Implementation
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

        //private static SolidBrush AdaptBrush(InformationEntryType entryType)
        //{
        //    switch (entryType)
        //    {
        //        case InformationEntryType.Info:
        //            {
        //                return new SolidBrush(Color.Black);
        //            }

        //        case InformationEntryType.Success:
        //            {
        //                return new SolidBrush(Color.DarkGreen);
        //            }

        //        case InformationEntryType.Exception:
        //            {
        //                return new SolidBrush(Color.DarkRed);
        //            }

        //        default:
        //            {
        //                return new SolidBrush(Color.Black);
        //            }
        //    }
        //}

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

                case InformationEntryType.Exception:
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