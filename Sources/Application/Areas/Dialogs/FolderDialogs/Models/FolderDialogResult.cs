namespace Mmu.Mlh.WpfCoreExtensions.Areas.Dialogs.FolderDialogs.Models
{
    public class FolderDialogResult
    {
        public string FolderPath { get; }
        public bool OkClicked { get; }

        public FolderDialogResult(bool okClicked, string folderPath)
        {
            OkClicked = okClicked;
            FolderPath = folderPath;
        }
    }
}