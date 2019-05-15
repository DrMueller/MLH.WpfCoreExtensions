using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.AppStart.Orchestration.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.AppStart.SubAreas.ViewModelMapping.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Container;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.AppStart.Orchestration.Services.Implementation
{
    internal class AppStartService : IAppStartService
    {
        private readonly IViewModelMappingInitializationService _viewModelMappingInitService;
        private readonly ViewModelContainer _viewModelContainer;

        public AppStartService(
            IViewModelMappingInitializationService viewModelMappingInitService,
            ViewModelContainer viewModelContainer)
        {
            _viewModelMappingInitService = viewModelMappingInitService;
            _viewModelContainer = viewModelContainer;
        }

        public void StartApp(WpfAppConfig config)
        {
            _viewModelMappingInitService.Initialize(config.WpfAssembly);
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