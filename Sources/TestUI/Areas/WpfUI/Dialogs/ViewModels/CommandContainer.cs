using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.Dialogs.FileDialogs.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Dialogs.FolderDialogs.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Container.CommandManagement.ViewModelCommands;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Dialogs.ViewModels
{
    public class CommandContainer : IViewModelCommandContainer<DialogsViewModel>
    {
        private readonly IFileDialogService _fileDialogServie;
        private readonly IFolderDialogService _folderDialogService;
        private DialogsViewModel _context;
        public CommandsViewData Commands { get; private set; }

        private ViewModelCommand SelectFile
        {
            get
            {
                return new ViewModelCommand(
                    "Select File",
                     new RelayCommand(() =>
                     {
                         var rslt = _fileDialogServie.SelectFile("All files (*.*)|*.*");

                         if (rslt.OkClicked)
                         {
                             _context.SelectedFilePath = rslt.FilePath;
                         }
                         else
                         {
                             _context.SelectedFilePath = string.Empty;
                         }
                     }));
            }
        }

        private ViewModelCommand SelectFolder
        {
            get
            {
                return new ViewModelCommand(
                    "Select Folder",
                     new RelayCommand(() =>
                     {
                         var rslt = _folderDialogService.SelectFolder();
                         if (rslt.OkClicked)
                         {
                             _context.SelectedFolderPath = rslt.FolderPath;
                         }
                         else
                         {
                             _context.SelectedFolderPath = string.Empty;
                         }
                     }));
            }
        }

        public CommandContainer(IFileDialogService fileDialogServie, IFolderDialogService folderDialogService)
        {
            _fileDialogServie = fileDialogServie;
            _folderDialogService = folderDialogService;
        }

        public Task InitializeAsync(DialogsViewModel context)
        {
            _context = context;
            Commands = new CommandsViewData(
                SelectFile,
                SelectFolder);

            return Task.CompletedTask;
        }
    }
}