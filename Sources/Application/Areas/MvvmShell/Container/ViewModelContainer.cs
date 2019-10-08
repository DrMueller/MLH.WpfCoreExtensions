using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.Navigation.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.Navigation.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Container
{
    internal sealed class ViewModelContainer : ViewModelBase
    {
        private readonly IInformationSubscriptionService _informationSubscriptionService;
        private readonly INavigationEntryFactory _navigationEntryFactory;
        private readonly IViewModelDisplayConfigurationService _vmDisplayConfigService;
        private IViewModel _currentContent;
        private InformationEntryViewData _informationEntry;
        private IEnumerable<NavigationEntry> _navigationEntries;

        public static ParametredRelayCommand CloseApp
        {
            get
            {
                return new ParametredRelayCommand(
                    o =>
                    {
                        var closable = (IClosableView)o;
                        closable.Close();
                    });
            }
        }

        public IViewModel CurrentContent
        {
            get => _currentContent;
            private set
            {
                if (_currentContent == value)
                {
                    return;
                }

                _currentContent = value;
                OnPropertyChanged();
            }
        }

        public InformationEntryViewData InformationEntry
        {
            get => _informationEntry;
            set
            {
                if (value != _informationEntry)
                {
                    _informationEntry = value;
                    OnPropertyChanged();
                }
            }
        }

        public IEnumerable<NavigationEntry> NavigationEntries
        {
            get => _navigationEntries;
            set
            {
                if (value != _navigationEntries)
                {
                    _navigationEntries = value;
                    OnPropertyChanged();
                }
            }
        }

        public ViewModelContainer(
            IViewModelDisplayConfigurationService vmDisplayConfigService,
            INavigationEntryFactory navigationEntryFactory,
            IInformationSubscriptionService informationSubscriptionService)
        {
            _vmDisplayConfigService = vmDisplayConfigService;
            _navigationEntryFactory = navigationEntryFactory;
            _informationSubscriptionService = informationSubscriptionService;
        }

        public async Task InitializeAsync()
        {
            _vmDisplayConfigService.Initialize(vm => CurrentContent = vm);
            _informationSubscriptionService.Register(vd => InformationEntry = vd);
            NavigationEntries = await _navigationEntryFactory.CreateAllAsync();
            NavigationEntries.FirstOrDefault()?.NavigationCommand.Execute(null);
        }
    }
}