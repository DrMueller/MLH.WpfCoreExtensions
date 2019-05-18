using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Dialogs.ViewModels
{
    public class DialogsViewModel : ViewModelBase, INavigatableViewModel, IInitializableViewModel
    {
        private readonly CommandContainer _commandContainer;

        private string _selectedFilePath;
        private string _selectedFolderPath;
        public CommandsViewData Commands => _commandContainer.Commands;
        public string HeadingDescription => "Fun with Dialogs";
        public string NavigationDescription => "Dialogs";

        public int NavigationSequence => 5;

        public string SelectedFilePath
        {
            get => _selectedFilePath;
            set
            {
                if (_selectedFilePath != value)
                {
                    _selectedFilePath = value;
                    OnPropertyChanged();
                }
            }
        }

        public string SelectedFolderPath
        {
            get => _selectedFolderPath;
            set
            {
                if (_selectedFolderPath != value)
                {
                    _selectedFolderPath = value;
                    OnPropertyChanged();
                }
            }
        }

        public DialogsViewModel(CommandContainer commandContainer)
        {
            _commandContainer = commandContainer;
        }

        public async Task InitializeAsync(params object[] initParams)
        {
            await _commandContainer.InitializeAsync(this);
        }
    }
}