using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.Navigation.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.Navigation.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Container
{
    internal sealed class ViewModelContainer : ViewModelBase, IViewModelContainer
    {
        private readonly IInformationSubscriptionService _informationSubscriptionService;
        private readonly INavigationEntryFactory _navigationEntryFactory;
        private readonly IViewModelDisplayConfigurationService _vmDisplayConfigService;
        private IViewModel _currentContent;
        private InformationEntryViewData _informationEntry;
        private IEnumerable<NavigationEntry> _navigationEntries;

        public ViewModelContainer(
            IViewModelDisplayConfigurationService vmDisplayConfigService,
            INavigationEntryFactory navigationEntryFactory,
            IInformationSubscriptionService informationSubscriptionService)
        {
            _vmDisplayConfigService = vmDisplayConfigService;
            _navigationEntryFactory = navigationEntryFactory;
            _informationSubscriptionService = informationSubscriptionService;
        }

        public static ParametredRelayCommand CloseApp =>
            new ParametredRelayCommand(
                o =>
                {
                    var closable = (IClosableView)o;
                    closable.Close();
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

        public IEnumerable<NavigationEntry> NavigationEntries
        {
            get => _navigationEntries;
            set => OnPropertyChanged(value, ref _navigationEntries);
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