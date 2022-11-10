using System;
using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfCoreExtensions.Areas.ViewExtensions.DragAndDrop.Models;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.DragAndDrop.ViewModels
{
    public class DragAndDropViewModel : ViewModelBase, IInitializableViewModel, INavigatableViewModel
    {
        private string _filePath;

        public Action<DroppedFile> FileDropped =>
            droppedFile =>
            {
                FilePath = droppedFile.FilePath;
            };

        public string FilePath
        {
            get => _filePath;
            set => OnPropertyChanged(value, ref _filePath);
        }

        public Task InitializeAsync(params object[] initParams)
        {
            return Task.CompletedTask;
        }

        public string HeadingDescription { get; } = "Drog & Drop";
        public string NavigationDescription { get; } = "Drag & Drop";
        public int NavigationSequence { get; } = 5;
    }
}