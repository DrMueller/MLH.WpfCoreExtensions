using JetBrains.Annotations;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.ViewExtensions.Grids.InformationGrids.ViewData
{
    [PublicAPI]
    public class InformationGridEntryViewData
    {
        public string Message { get; }

        public InformationGridEntryViewData(string message)
        {
            Guard.StringNotNullOrEmpty(() => message);

            Message = message;
        }
    }
}