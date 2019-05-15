using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Navigation.Models;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Navigation.Services.Implementation
{
    internal class NavigationEntryFactory : INavigationEntryFactory
    {
        private readonly INavigationService _navigationService;
        private readonly IViewModelFactory _viewModelFactory;

        public NavigationEntryFactory(
            INavigationService navigationService,
            IViewModelFactory viewModelFactory)
        {
            _navigationService = navigationService;
            _viewModelFactory = viewModelFactory;
        }

        public async Task<IReadOnlyCollection<NavigationEntry>> CreateAllAsync()
        {
            var navigationViewModels = await _viewModelFactory.CreateAllWithBehaviorAsync<INavigatableViewModel>();
            var result = navigationViewModels
                .OrderBy(f => f.NavigationSequence)
                .Select(CreateNavigationEntry)
                .ToList();

            return result;
        }

        private NavigationEntry CreateNavigationEntry(INavigatableViewModel viewModel)
        {
            var navigationCommand = new RelayCommand(
                () =>
                {
                    _navigationService.NavigateToAsync(viewModel);
                });

            return new NavigationEntry(navigationCommand, viewModel.NavigationDescription);
        }
    }
}