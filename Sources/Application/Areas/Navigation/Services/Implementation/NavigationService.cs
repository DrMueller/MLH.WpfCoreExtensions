using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Navigation.Services.Implementation
{
    internal class NavigationService : INavigationService
    {
        private readonly IViewModelFactory _containerViewModelBaseFactory;
        private readonly INavigationConfigurationService _navigationConfigurationService;

        public NavigationService(
            INavigationConfigurationService navigationConfigurationService,
            IViewModelFactory containerViewModelBaseFactory)
        {
            _navigationConfigurationService = navigationConfigurationService;
            _containerViewModelBaseFactory = containerViewModelBaseFactory;
        }

        public async Task NavigateToAsync<T>()
            where T : IViewModel
        {
            var target = await _containerViewModelBaseFactory.CreateAsync<T>();
            await NavigateToAsync(target);
        }

        public Task NavigateToAsync(IViewModel target)
        {
            _navigationConfigurationService.OnNavigation(target);
            return Task.CompletedTask;
        }
    }
}