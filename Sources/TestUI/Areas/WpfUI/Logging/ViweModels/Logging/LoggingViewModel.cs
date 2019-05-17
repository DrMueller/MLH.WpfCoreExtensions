using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Logging.ViweModels.Logging
{
    public class LoggingViewModel : ViewModelBase, INavigatableVm, IInitializableVm
    {
        private readonly CommandContainer _commandContainer;
        public CommandsViewData Commands => _commandContainer.Commands;
        public string HeadingDescription => "Logging stuff";
        public string NavigationDescription => "Logging";
        public int NavigationSequence => 4;

        public LoggingViewModel(CommandContainer commandContainer)
        {
            _commandContainer = commandContainer;
        }

        public async Task InitializeAsync(params object[] initParams)
        {
            await _commandContainer.InitializeAsync(this);
        }
    }
}