using Mmu.Mlh.WpfCoreExtensions.Areas.ExceptionHandling.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.ExceptionHandling.Services.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.InformationHandling.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.InformationHandling.Services.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.InformationHandling.Services.Servants;
using Mmu.Mlh.WpfCoreExtensions.Areas.InformationHandling.Services.Servants.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Services.Servants;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Services.Servants.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.ViewModelMapping.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.ViewModelMapping.Services.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.ViewModelMapping.Services.Servants;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.ViewModelMapping.Services.Servants.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.Logging.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Logging.Services.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Container;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.Navigation.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Navigation.Services.Implementation;
using StructureMap;

namespace Mmu.Mlh.WpfCoreExtensions.Infrastructure.DependencyInjection
{
    public class AppRegistry : Registry
    {
        public AppRegistry()
        {
            Scan(scanner =>
            {
                scanner.AssemblyContainingType<AppRegistry>();
                scanner.WithDefaultConventions();
            });

            // ExceptionHandling
            For<IExceptionHandler>().Use<ExceptionHandler>().Singleton();
            For<IExceptionInitializationService>().Use<ExceptionInitializationService>().Singleton();

            // InformationHandling
            For<IInformationPublisher>().Use<InformationPublisher>().Singleton();
            For<IInformationSubscriptionService>().Use<InformationSubscriptionService>().Singleton();
            For<IInformationEntryViewDataAdapter>().Use<InformationEntryViewDataAdapter>().Singleton();

            // Initialization
            For<IAppInitializationService>().Use<AppInitializationService>().Singleton();
            For<IViewModelMappingInitializationService>().Use<ViewModelMappingInitializationService>().Singleton();
            For<IDataTemplateFactory>().Use<DataTemplateFactory>().Singleton();
            For<IResourceDictionaryFactory>().Use<ResourceDictionaryFactory>().Singleton();
            For<IViewViewModelMapFactory>().Use<ViewViewModelMapFactory>().Singleton();

            // Logging
            For<ILoggingService>().Use<LoggingService>().Singleton();

            // MvvmShell
            For<ViewModelContainer>().Singleton();
            For<IViewModelDisplayConfigurationService>().Use<ViewModelDisplayConfigurationService>().Singleton();
            For<IViewModelDisplayService>().Use<ViewModelDisplayService>().Singleton();
            For<IViewModelFactory>().Use<ViewModelFactory>().Singleton();

            // Navigation
            For<INavigationEntryFactory>().Use<NavigationEntryFactory>().Singleton();
        }
    }
}