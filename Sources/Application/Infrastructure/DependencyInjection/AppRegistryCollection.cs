using JetBrains.Annotations;
using Lamar;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Services.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Services.Servants;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Services.Servants.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ExceptionHandling.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ExceptionHandling.Services.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.Logging.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.Logging.Services.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Services.Servants;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Services.Servants.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.MaterialDesign;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.MaterialDesign.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.Navigation.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.Navigation.Services.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.RessourceDictionaries.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.RessourceDictionaries.Services.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.ViewModelMapping.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.ViewModelMapping.Services.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.ViewModelMapping.Services.Servants;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.ViewModelMapping.Services.Servants.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Appearance.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Appearance.Services.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Appearance.Services.Servants;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Appearance.Services.Servants.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Container;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services.Implementation;

namespace Mmu.Mlh.WpfCoreExtensions.Infrastructure.DependencyInjection
{
    [UsedImplicitly]
    public class AppRegistryCollection : ServiceRegistry
    {
        public AppRegistryCollection()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<AppRegistryCollection>();
                    scanner.WithDefaultConventions();
                });

            // Aspects
            For<IExceptionHandler>().Use<ExceptionHandler>().Singleton();
            For<IExceptionInitializationService>().Use<ExceptionInitializationService>().Singleton();

            For<IInformationPublisher>().Use<InformationPublisher>().Singleton();
            For<IInformationSubscriptionService>().Use<InformationSubscriptionService>().Singleton();
            For<IInformationEntryViewDataAdapter>().Use<InformationEntryViewDataAdapter>().Singleton();

            For<ILoggingService>().Use<LoggingService>().Singleton();

            // Initialization
            For<IAppInitializationServant>().Use<AppInitializationServant>().Singleton();

            For<IViewModelMappingInitializationService>().Use<ViewModelMappingInitializationService>().Singleton();
            For<INavigationEntryFactory>().Use<NavigationEntryFactory>().Singleton();
            For<IResourceDictionaryFactory>().Use<ResourceDictionaryFactory>().Singleton();
            For<IViewViewModelMapFactory>().Use<ViewViewModelMapFactory>().Singleton();
            For<IDataTemplateFactory>().Use<DataTemplateFactory>().Singleton();
            For<IMaterialDesignInitializationService>().Use<MaterialDesignInitializationService>().Singleton();

            // MvvmShell
            For<IViewModelContainer>().Use<ViewModelContainer>().Singleton();
            For<IViewModelDisplayConfigurationService>().Use<ViewModelDisplayConfigurationService>().Singleton();
            For<IViewModelDisplayService>().Use<ViewModelDisplayService>().Singleton();
            For<IViewModelFactory>().Use<ViewModelFactory>().Singleton();

            // Appearance
            For<IAppearanceService>().Use<AppearanceService>().Singleton();
            For<IRegistryHandler>().Use<RegistryHandler>().Singleton();
        }
    }
}