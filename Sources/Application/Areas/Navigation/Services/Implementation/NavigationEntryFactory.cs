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
        private readonly IVmFactory _viewModelFactory;
        private readonly IVmDisplayService _vmDisplayService;

        public NavigationEntryFactory(
            IVmDisplayService vmDisplayService,
            IVmFactory viewModelFactory)
        {
            _vmDisplayService = vmDisplayService;
            _viewModelFactory = viewModelFactory;
        }

        public async Task<IReadOnlyCollection<NavigationEntry>> CreateAllAsync()
        {
            var navigationViewModels = await _viewModelFactory.CreateAllWithBehaviorAsync<INavigatableVm>();
            var result = navigationViewModels
                .OrderBy(f => f.NavigationSequence)
                .Select(CreateNavigationEntry)
                .ToList();

            return result;
        }

        private NavigationEntry CreateNavigationEntry(INavigatableVm viewModel)
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