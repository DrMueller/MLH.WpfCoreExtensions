using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.ViewExtensions.Grids.InformationGrids.ViewData
{
    public class InformationGridEntryViewData
    {
        public InformationGridEntryViewData(string message)
        {
            Guard.StringNotNullOrEmpty(() => message);

            Message = message;
        }

        public string Message { get; }
    }
}