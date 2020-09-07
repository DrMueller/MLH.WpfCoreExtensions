using System;
using System.Threading.Tasks;
using Mmu.Mlh.ServiceProvisioning.Areas.Provisioning.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ExceptionHandling.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.ViewModelMapping.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Container;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Services.Servants.Implementation
{
    internal class AppInitializationServant : IAppInitializationServant
    {
        private readonly IExceptionInitializationService _exceptionInitializationService;
        private readonly IInformationPublisher _infoPublisher;
        private readonly IServiceLocator _serviceLocator;
        private readonly IViewModelContainer _viewModelContainer;
        private readonly IViewModelMappingInitializationService _viewModelMappingInitService;

        public AppInitializationServant(
            IViewModelMappingInitializationService viewModelMappingInitService,
            IViewModelContainer viewModelContainer,
            IExceptionInitializationService exceptionInitializationService,
            IInformationPublisher infoPublisher,
            IServiceLocator serviceLocator)
        {
            _viewModelMappingInitService = viewModelMappingInitService;
            _viewModelContainer = viewModelContainer;
            _exceptionInitializationService = exceptionInitializationService;
            _infoPublisher = infoPublisher;
            _serviceLocator = serviceLocator;
        }

        public async Task StartAppAsync(WpfAppConfiguration config, Action<IServiceLocator> afterInitializedCallback)
        {
            _exceptionInitializationService.HookGlobalExceptions();
            _viewModelMappingInitService.Initialize(config.WpfAssembly);
            await _viewModelContainer.InitializeAsync();
            _infoPublisher.Publish(InformationEntry.CreateInfo("Here could be your text..", false));

            afterInitializedCallback?.Invoke(_serviceLocator);

            ShowApp(config);
        }

        private void ShowApp(WpfAppConfiguration config)
        {
            var viewContainer = new ViewContainer
            {
                DataContext = _viewModelContainer,
                Title = config.WindowConfiguration.AppTitle,
                Icon = config.WindowConfiguration.Icon,
                Width = config.WindowConfiguration.WindowWidth,
                Height = config.WindowConfiguration.WindowHeight
            };

            viewContainer.ShowDialog();
        }
    }
}