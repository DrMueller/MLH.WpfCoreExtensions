using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.Navigation.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.Navigation.Services.Implementation
{
    internal class NavigationEntryFactory : INavigationEntryFactory
    {
        private readonly IViewModelFactory _viewModelFactory;
        private readonly IViewModelDisplayService _vmDisplayService;

        public NavigationEntryFactory(
            IViewModelDisplayService vmDisplayService,
            IViewModelFactory viewModelFactory)
        {
            _vmDisplayService = vmDisplayService;
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
                    _vmDisplayService.DisplayAsync(viewModel);
                });

            return new NavigationEntry(navigationCommand, viewModel.NavigationDescription);
        }
    }
}