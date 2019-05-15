using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.AppStart.Orchestration.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.AppStart.SubAreas.ViewModelMapping.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Container;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.AppStart.Orchestration.Services.Servants.Implementation
{
    internal class AppInitializationService : IAppInitializationService
    {
        private readonly IViewModelMappingInitializationService _viewModelMappingInitService;
        private readonly ViewModelContainer _viewModelContainer;

        public AppInitializationService(
            IViewModelMappingInitializationService viewModelMappingInitService,
            ViewModelContainer viewModelContainer)
        {
            _viewModelMappingInitService = viewModelMappingInitService;
            _viewModelContainer = viewModelContainer;
        }

        public async Task StartAppAsync(WpfAppConfig config)
        {
            _viewModelMappingInitService.Initialize(config.WpfAssembly);
            await _viewModelContainer.InitializeAsync();
            ShowApp();
        }

        private void ShowApp()
        {
            var viewContainer = new ViewContainer
            {
                DataContext = _viewModelContainer
            };

            viewContainer.ShowDialog();
        }
    }
}