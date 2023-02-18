using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Mmu.Mlh.ServiceProvisioning.Areas.Provisioning.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.ExceptionHandling.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.MaterialDesign;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.ViewModelMapping.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Container;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Services.Servants.Implementation
{
    [UsedImplicitly]
    internal class AppInitializationServant : IAppInitializationServant
    {
        private readonly IExceptionInitializationService _exceptionInitializationService;
        private readonly IInformationPublisher _infoPublisher;
        private readonly IMaterialDesignInitializationService _mdInitServices;
        private readonly IServiceLocator _serviceLocator;
        private readonly IViewModelContainer _viewModelContainer;
        private readonly IViewModelMappingInitializationService _viewModelMappingInitService;

        public AppInitializationServant(
            IViewModelMappingInitializationService viewModelMappingInitService,
            IViewModelContainer viewModelContainer,
            IExceptionInitializationService exceptionInitializationService,
            IInformationPublisher infoPublisher,
            IServiceLocator serviceLocator,
            IMaterialDesignInitializationService mdInitServices)
        {
            _viewModelMappingInitService = viewModelMappingInitService;
            _viewModelContainer = viewModelContainer;
            _exceptionInitializationService = exceptionInitializationService;
            _infoPublisher = infoPublisher;
            _serviceLocator = serviceLocator;
            _mdInitServices = mdInitServices;
        }

        public async Task StartAppAsync(WpfAppConfiguration config, Action<IServiceLocator> afterInitializedCallback)
        {
            _mdInitServices.Initialize();
            _exceptionInitializationService.HookGlobalExceptions(config.HandleException);
            _viewModelMappingInitService.Initialize(config.WpfAssembly);
            await _viewModelContainer.InitializeAsync();
            _infoPublisher.Publish(InformationEntry.CreateInfo("Here could be your text.."));

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