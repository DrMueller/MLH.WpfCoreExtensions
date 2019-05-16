namespace Mmu.Mlh.WpfCoreExtensions.Areas.InformationHandling.ViewData
{
    public class InformationEntryViewData
    {
        public static string BusyIndicatorSource => "/Mmu.Mlh.WpfCoreExtensions;component/Infrastructure/Assets/FA_Cog_Green.png";
        public string Message { get; }
        public bool ShowBusyIndicator { get; }

        public InformationEntryViewData(string message, bool showBusyIndicator)
        {
            Message = message;
            ShowBusyIndicator = showBusyIndicator;
        }
    }
}