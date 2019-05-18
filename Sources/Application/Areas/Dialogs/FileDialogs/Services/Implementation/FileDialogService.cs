using System.Windows.Forms;
using Mmu.Mlh.WpfCoreExtensions.Areas.Dialogs.FileDialogs.Models;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Dialogs.FileDialogs.Services.Implementation
{
    internal class FileDialogService : IFileDialogService
    {
        public FileDialogResult SelectFile(string filter)
        {
            using (var openFileDialog = new OpenFileDialog { Filter = filter })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return new FileDialogResult(true, openFileDialog.FileName);
                }

                return new FileDialogResult(false, string.Empty);
            }
        }
    }
}