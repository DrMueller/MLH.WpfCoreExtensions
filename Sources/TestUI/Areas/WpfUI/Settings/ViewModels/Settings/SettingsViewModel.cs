using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Settings.ViewModels.Settings
{
    public class SettingsViewModel : ViewModelBase, INavigatableVm, IInitializableVm
    {
        private readonly CommandContainer _commandContainer;
        public CommandsViewData Commands => _commandContainer.Commands;
        public string HeadingDescription => "Settings";
        public string NavigationDescription => "Fun with Settings";
        public int NavigationSequence => 5;

        private string _settingsInfo;

        public string SettingsInfo
        {
            get => _settingsInfo;
            set
            {
                if (_settingsInfo != value)
                {
                    _settingsInfo = value;
                    OnPropertyChanged();
                }
            }
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