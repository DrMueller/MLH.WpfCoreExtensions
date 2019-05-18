using Mmu.Mlh.WpfCoreExtensions.Areas.Dialogs.FileDialogs.Models;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Dialogs.FileDialogs.Services
{
    public interface IFileDialogService
    {
        FileDialogResult SelectFile(string filter);
    }
}