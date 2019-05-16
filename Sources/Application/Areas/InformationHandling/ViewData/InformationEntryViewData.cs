using System.Windows.Media;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.InformationHandling.ViewData
{
    public class InformationEntryViewData
    {
        public static string BusyIndicatorSource => "/Mmu.Mlh.WpfCoreExtensions;component/Infrastructure/Assets/FA_Cog_Green.png";
        public int? DisplayLengthInSeconds { get; }
        public Brush Foreground { get; }
        public string Message { get; }
        public bool ShowBusyIndicator { get; }

        public InformationEntryViewData(
            string message,
            bool showBusyIndicator,
            Brush foreground,
            int? displayLengthInSeconds)
        {
            Message = message;
            ShowBusyIndicator = showBusyIndicator;
            Foreground = foreground;
            DisplayLengthInSeconds = displayLengthInSeconds;
        }
    }
}