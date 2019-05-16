using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.ExceptionHandling.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.ViewModelMapping.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Container;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Services.Servants.Implementation
{
    internal class AppInitializationService : IAppInitializationService
    {
        private readonly IViewModelMappingInitializationService _viewModelMappingInitService;
        private readonly ViewModelContainer _viewModelContainer;
        private readonly IExceptionInitializationService _exceptionInitializationService;

        public AppInitializationService(
            IViewModelMappingInitializationService viewModelMappingInitService,
            ViewModelContainer viewModelContainer,
            IExceptionInitializationService exceptionInitializationService)
        {
            _viewModelMappingInitService = viewModelMappingInitService;
            _viewModelContainer = viewModelContainer;
            _exceptionInitializationService = exceptionInitializationService;
        }

        public async Task StartAppAsync(WpfAppConfig config)
        {
            _exceptionInitializationService.HookGlobalExceptions();
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