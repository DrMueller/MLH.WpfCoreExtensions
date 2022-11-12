using JetBrains.Annotations;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.ViewData
{
    [PublicAPI]
    internal class InformationEntryViewData
    {
        public static string BusyIndicatorSource =>
            "/Mmu.Mlh.WpfCoreExtensions;component/Infrastructure/Assets/FA_Cog_Green.png";

        public int? DisplayLengthInSeconds { get; }
        public int EntryType { get; }
        public string Message { get; }
        public bool ShowBusyIndicator { get; }

        public InformationEntryViewData(
            string message,
            bool showBusyIndicator,
            int? displayLengthInSeconds,
            InformationEntryTypeViewData entryType)
        {
            Message = message;
            ShowBusyIndicator = showBusyIndicator;
            DisplayLengthInSeconds = displayLengthInSeconds;
            EntryType = (int)entryType;
        }
    }
}