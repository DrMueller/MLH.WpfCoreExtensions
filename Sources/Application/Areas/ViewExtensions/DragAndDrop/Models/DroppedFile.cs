using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.ViewExtensions.DragAndDrop.Models
{
    public class DroppedFile
    {
        public string FilePath { get; }

        internal DroppedFile(string filePath)
        {
            Guard.StringNotNullOrEmpty(() => filePath);

            FilePath = filePath;
        }
    }
}