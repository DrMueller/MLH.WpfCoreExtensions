using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.InfosAndExceptions.ViewModels.InfosAndExceptions
{
    public class InfosAndExceptionsViewModel : ViewModelBase, IInitializableVm, INavigatableVm
    {
        private readonly CommandContainer _commandContainer;

        public CommandsViewData Commands => _commandContainer.Commands;

        public string HeadingDescription => "Infos and Exceptions";

        public string NavigationDescription => "Infos";

        public int NavigationSequence => 3;

        public InfosAndExceptionsViewModel(CommandContainer commandContainer)
        {
            _commandContainer = commandContainer;
        }

        public async Task InitializeAsync(params object[] initParams)
        {
            await _commandContainer.InitializeAsync(this);
        }
    }
}