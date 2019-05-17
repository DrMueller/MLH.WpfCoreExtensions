using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.Navigation.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.Navigation.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Container
{
    internal sealed class ViewModelContainer : INotifyPropertyChanged
    {
        private readonly IInformationSubscriptionService _informationSubscriptionService;
        private readonly INavigationEntryFactory _navigationEntryFactory;
        private readonly IVmDisplayConfigurationService _vmDisplayConfigService;
        private IViewModel _currentContent;
        private InformationEntryViewData _informationEntry;
        private IEnumerable<NavigationEntry> _navigationEntries;

        public event PropertyChangedEventHandler PropertyChanged;

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
            IVmDisplayConfigurationService vmDisplayConfigService,
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

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}