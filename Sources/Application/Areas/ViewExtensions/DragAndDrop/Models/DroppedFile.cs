using JetBrains.Annotations;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.ViewExtensions.DragAndDrop.Models
{
    [PublicAPI]
    public class DroppedFile
    {
        internal DroppedFile(string filePath)
        {
            Guard.StringNotNullOrEmpty(() => filePath);

            FilePath = filePath;
        }

        public string FilePath { get; }
    }
}