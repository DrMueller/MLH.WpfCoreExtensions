using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using JetBrains.Annotations;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.Navigation.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.Navigation.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Appearance.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Appearance.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Container
{
    [PublicAPI]
    internal sealed class ViewModelContainer : ViewModelBase, IViewModelContainer
    {
        private readonly IAppearanceService _appearanceService;
        private readonly IInformationSubscriptionService _informationSubscriptionService;
        private readonly INavigationEntryFactory _navigationEntryFactory;
        private readonly IViewModelDisplayConfigurationService _vmDisplayConfigService;
        private IViewModel _currentContent;
        private InformationEntryViewData _informationEntry;
        private bool _isMainNavigationPaneOpen;
        private IEnumerable<NavigationEntry> _navigationEntries;

        public ViewModelContainer(
            IViewModelDisplayConfigurationService vmDisplayConfigService,
            INavigationEntryFactory navigationEntryFactory,
            IInformationSubscriptionService informationSubscriptionService,
            IAppearanceService appearanceService)
        {
            _vmDisplayConfigService = vmDisplayConfigService;
            _navigationEntryFactory = navigationEntryFactory;
            _informationSubscriptionService = informationSubscriptionService;
            _appearanceService = appearanceService;
        }

        public static ParametredRelayCommand CloseApp =>
            new ParametredRelayCommand(
                o =>
                {
                    var closable = (IClosableView)o;
                    closable.Close();
                });

        public ICommand CloseMainNavigationPane =>
            new RelayCommand(
                () =>
                {
                    IsMainNavigationPaneOpen = false;
                });

        public IViewModel CurrentContent
        {
            get => _currentContent;
            private set => OnPropertyChanged(value, ref _currentContent);
        }

        public InformationEntryViewData InformationEntry
        {
            get => _informationEntry;
            set => OnPropertyChanged(value, ref _informationEntry);
        }

        public bool IsMainNavigationPaneOpen
        {
            get => _isMainNavigationPaneOpen;
            set => OnPropertyChanged(value, ref _isMainNavigationPaneOpen);
        }

        public IEnumerable<NavigationEntry> NavigationEntries
        {
            get => _navigationEntries;
            set => OnPropertyChanged(value, ref _navigationEntries);
        }

        public AppearanceTheme SelectedAppearanceTheme
        {
            get => _appearanceService.AppearanceTheme;
            set => _appearanceService.AppearanceTheme = value;
        }

        public ICommand Toggle =>
            new RelayCommand(
                () =>
                {
                    IsMainNavigationPaneOpen = !_isMainNavigationPaneOpen;
                });

        public async Task InitializeAsync()
        {
            _vmDisplayConfigService.Initialize(vm => CurrentContent = vm);
            _informationSubscriptionService.Register(vd => InformationEntry = vd);
            NavigationEntries = await _navigationEntryFactory.CreateAllAsync();
            NavigationEntries.FirstOrDefault()?.NavigationCommand.Execute(null);
        }
    }
}