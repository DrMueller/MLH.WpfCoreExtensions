using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.ExceptionHandling.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.InformationHandling.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.InformationHandling.Services;
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
        private readonly IInformationPublisher _infoPublisher;

        public AppInitializationService(
            IViewModelMappingInitializationService viewModelMappingInitService,
            ViewModelContainer viewModelContainer,
            IExceptionInitializationService exceptionInitializationService,
            IInformationPublisher infoPublisher)
        {
            _viewModelMappingInitService = viewModelMappingInitService;
            _viewModelContainer = viewModelContainer;
            _exceptionInitializationService = exceptionInitializationService;
            _infoPublisher = infoPublisher;
        }

        public async Task StartAppAsync(WpfAppConfig config)
        {
            _exceptionInitializationService.HookGlobalExceptions();
            _viewModelMappingInitService.Initialize(config.WpfAssembly);
            await _viewModelContainer.InitializeAsync();
            _infoPublisher.Publish(InformationEntry.CreateInfo("Here could be your text..", false));
            ShowApp(config);
        }

        private void ShowApp(WpfAppConfig config)
        {
            var viewContainer = new ViewContainer
            {
                DataContext = _viewModelContainer,
                Title = config.AppTitle,
                Icon = config.Icon
            };

            viewContainer.ShowDialog();
        }
    }
}