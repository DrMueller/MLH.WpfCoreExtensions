using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services.Implementation
{
    internal class ViewModelDisplayService : IViewModelDisplayService
    {
        private readonly IViewModelDisplayConfigurationService _displayConfigService;
        private readonly IViewModelFactory _viewModelFactory;

        public ViewModelDisplayService(
            IViewModelDisplayConfigurationService displayConfigService,
            IViewModelFactory containerViewModelBaseFactory)
        {
            _displayConfigService = displayConfigService;
            _viewModelFactory = containerViewModelBaseFactory;
        }

        public async Task DisplayAsync<T>(params object[] initParams)
            where T : IDisplayableViewModel
        {
            var target = await _viewModelFactory.CreateAsync<T>(initParams);
            await DisplayAsync(target);
        }

        public Task DisplayAsync(IDisplayableViewModel target)
        {
            _displayConfigService.OnDisplay(target);
            return Task.CompletedTask;
        }
    }
}