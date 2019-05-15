using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.AppStart.Orchestration.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.AppStart.Orchestration.Services.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.AppStart.SubAreas.ViewModelMapping.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.AppStart.SubAreas.ViewModelMapping.Services.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.AppStart.SubAreas.ViewModelMapping.Services.Servants;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.AppStart.SubAreas.ViewModelMapping.Services.Servants.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Container;
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
            For<IAppStartService>().Use<AppStartService>().Singleton();

            For<IViewModelMappingInitializationService>().Use<ViewModelMappingInitializationService>().Singleton();
            For<IDataTemplateFactory>().Use<DataTemplateFactory>().Singleton();
            For<IResourceDictionaryFactory>().Use<ResourceDictionaryFactory>().Singleton();
            For<IViewViewModelMapFactory>().Use<ViewViewModelMapFactory>().Singleton();

            // MvvmShell
            For<ViewModelContainer>().Singleton();
        }
    }
}