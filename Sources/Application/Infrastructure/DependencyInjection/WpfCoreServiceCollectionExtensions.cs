using Microsoft.Extensions.DependencyInjection;
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
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.ExceptionHandling.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.ExceptionHandling.Services.Implementation;
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
    public static class WpfCoreServiceCollectionExtensions
    {
        public static IServiceCollection AddWpfCore(this IServiceCollection services)
        {
            services.AddSingleton<IExceptionHandler, ExceptionHandler>();
            services.AddSingleton<IExceptionInitializationService, ExceptionInitializationService>();
            services.AddSingleton<IInformationPublisher, InformationPublisher>();
            services.AddSingleton<IInformationSubscriptionService, InformationSubscriptionService>();
            services.AddSingleton<IInformationEntryViewDataAdapter, InformationEntryViewDataAdapter>();
            services.AddSingleton<ILoggingService, LoggingService>();
            services.AddSingleton<IAppInitializationServant, AppInitializationServant>();
            services.AddSingleton<IViewModelMappingInitializationService, ViewModelMappingInitializationService>();
            services.AddSingleton<INavigationEntryFactory, NavigationEntryFactory>();
            services.AddSingleton<IResourceDictionaryFactory, ResourceDictionaryFactory>();
            services.AddSingleton<IViewViewModelMapFactory, ViewViewModelMapFactory>();
            services.AddSingleton<IDataTemplateFactory, DataTemplateFactory>();
            services.AddSingleton<IMaterialDesignInitializationService, MaterialDesignInitializationService>();

            // MvvmShell
            services.AddSingleton<IViewModelContainer, ViewModelContainer>();
            services.AddSingleton<IViewModelDisplayConfigurationService, ViewModelDisplayConfigurationService>();
            services.AddSingleton<IViewModelDisplayService, ViewModelDisplayService>();
            services.AddSingleton<IViewModelFactory, ViewModelFactory>();

            // Appearance
            services.AddSingleton<IAppearanceService, AppearanceService>();
            services.AddSingleton<IAppearanceThemeRepository, AppearanceThemeRepository>();

            return services;
        }
    }
}