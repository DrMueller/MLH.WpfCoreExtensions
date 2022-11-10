using System.Collections.ObjectModel;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfCoreExtensions.Areas.ViewExtensions.Grids.InformationGrids.ViewData;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.InfosAndExceptions.ViewModels.InfosAndExceptions
{
    [PublicAPI]
    public class InfosAndExceptionsViewModel : ViewModelBase, IInitializableViewModel, INavigatableViewModel
    {
        private readonly CommandContainer _commandContainer;

        public InfosAndExceptionsViewModel(CommandContainer commandContainer)
        {
            _commandContainer = commandContainer;
        }

        public CommandsViewData Commands => _commandContainer.Commands;

        public ObservableCollection<InformationGridEntryViewData> InformationEntries { get; } =
            new ObservableCollection<InformationGridEntryViewData>();

        public async Task InitializeAsync(params object[] initParams)
        {
            await _commandContainer.InitializeAsync(this);
        }

        public string HeadingDescription => "Infos and Exceptions";

        public string NavigationDescription => "Infos";

        public int NavigationSequence => 3;
    }
}