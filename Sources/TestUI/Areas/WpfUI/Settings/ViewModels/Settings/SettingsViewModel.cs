using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Settings.ViewModels.Settings
{
    public class SettingsViewModel : ViewModelBase, INavigatableViewModel, IInitializableViewModel
    {
        private readonly CommandContainer _commandContainer;
        private string _settingsInfo;
        public CommandsViewData Commands => _commandContainer.Commands;
        public string HeadingDescription => "Settings";
        public string NavigationDescription => "Fun with Settings";
        public int NavigationSequence => 5;

        public string SettingsInfo
        {
            get => _settingsInfo;
            set => OnPropertyChanged(value, ref _settingsInfo);
        }

        public SettingsViewModel(CommandContainer commandContainer)
        {
            _commandContainer = commandContainer;
        }

        public async Task InitializeAsync(params object[] initParams)
        {
            await _commandContainer.InitializeAsync(this);
        }
    }
}