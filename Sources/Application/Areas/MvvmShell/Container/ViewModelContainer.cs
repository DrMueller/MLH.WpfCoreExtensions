using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.Navigation.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Navigation.Services;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Container
{
    internal sealed class ViewModelContainer : INotifyPropertyChanged
    {
        private readonly INavigationConfigurationService _navigationConfigService;
        private readonly INavigationEntryFactory _navigationEntryFactory;
        private IViewModel _currentContent;

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

        public IEnumerable<NavigationEntry> NavigationEntries { get; private set; }

        public ViewModelContainer(
            INavigationConfigurationService navigationConfigService,
            INavigationEntryFactory navigationEntryFactory)
        {
            _navigationConfigService = navigationConfigService;
            _navigationEntryFactory = navigationEntryFactory;
        }

        public async Task InitializeAsync()
        {
            _navigationConfigService.Initialize(vm => CurrentContent = vm);
            NavigationEntries = await _navigationEntryFactory.CreateAllAsync();
            NavigationEntries.FirstOrDefault()?.NavigationCommand.Execute(null);
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}