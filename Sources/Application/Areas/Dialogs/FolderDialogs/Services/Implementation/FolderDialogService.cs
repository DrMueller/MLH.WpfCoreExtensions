using System.Windows.Forms;
using Mmu.Mlh.WpfCoreExtensions.Areas.Dialogs.FolderDialogs.Models;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Dialogs.FolderDialogs.Services.Implementation
{
    internal class FolderDialogService : IFolderDialogService
    {
        public FolderDialogResult SelectFolder()
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    return new FolderDialogResult(true, folderBrowserDialog.SelectedPath);
                }

                return new FolderDialogResult(false, string.Empty);
            }
        }
    }
}