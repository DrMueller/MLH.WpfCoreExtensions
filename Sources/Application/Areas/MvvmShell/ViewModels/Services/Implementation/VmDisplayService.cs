using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services.Implementation
{
    internal class VmDisplayService : IVmDisplayService
    {
        private readonly IVmDisplayConfigurationService _displayConfigService;
        private readonly IVmFactory _viewModelFactory;

        public VmDisplayService(
            IVmDisplayConfigurationService displayConfigService,
            IVmFactory containerViewModelBaseFactory)
        {
            _displayConfigService = displayConfigService;
            _viewModelFactory = containerViewModelBaseFactory;
        }

        public async Task DisplayAsync<T>(params object[] initParams)
            where T : IDisplayableVm
        {
            var target = await _viewModelFactory.CreateAsync<T>(initParams);
            await DisplayAsync(target);
        }

        public Task DisplayAsync(IDisplayableVm target)
        {
            _displayConfigService.OnDisplay(target);
            return Task.CompletedTask;
        }
    }
}