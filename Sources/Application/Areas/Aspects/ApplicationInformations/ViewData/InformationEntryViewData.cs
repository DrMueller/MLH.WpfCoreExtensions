using System.Windows.Media;
using JetBrains.Annotations;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.ViewData
{
    internal class InformationEntryViewData
    {
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

        public static string BusyIndicatorSource =>
            "/Mmu.Mlh.WpfCoreExtensions;component/Infrastructure/Assets/FA_Cog_Green.png";

        public int? DisplayLengthInSeconds { get; }

        [UsedImplicitly]
        public Brush Foreground { get; }

        public string Message { get; }
        public bool ShowBusyIndicator { get; }
    }
}