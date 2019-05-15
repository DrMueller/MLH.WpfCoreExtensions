using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.AppStart.Orchestration.Services.Servants;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.AppStart.Orchestration.Services.Servants.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.AppStart.SubAreas.ViewModelMapping.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.AppStart.SubAreas.ViewModelMapping.Services.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.AppStart.SubAreas.ViewModelMapping.Services.Servants;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.AppStart.SubAreas.ViewModelMapping.Services.Servants.Implementation;
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

            // AppStart
            For<IAppInitializationService>().Use<AppInitializationService>().Singleton();
            For<IViewModelMappingInitializationService>().Use<ViewModelMappingInitializationService>().Singleton();
            For<IDataTemplateFactory>().Use<DataTemplateFactory>().Singleton();
            For<IResourceDictionaryFactory>().Use<ResourceDictionaryFactory>().Singleton();
            For<IViewViewModelMapFactory>().Use<ViewViewModelMapFactory>().Singleton();

            // MvvmShell
            For<ViewModelContainer>().Singleton();
            For<IViewModelFactory>().Use<ViewModelFactory>().Singleton();

            // Navigation
            For<INavigationConfigurationService>().Use<NavigationConfigurationService>().Singleton();
            For<INavigationEntryFactory>().Use<NavigationEntryFactory>().Singleton();
            For<INavigationService>().Use<NavigationService>().Singleton();
        }
    }
}