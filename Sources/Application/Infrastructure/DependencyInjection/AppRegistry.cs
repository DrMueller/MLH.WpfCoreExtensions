﻿using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ExceptionHandling.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ExceptionHandling.Services.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.Services.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.Services.Servants;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.Services.Servants.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.Logging.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.Logging.Services.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.Dialogs.FileDialogs.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Dialogs.FileDialogs.Services.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.Dialogs.FolderDialogs.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Dialogs.FolderDialogs.Services.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Services.Servants;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Services.Servants.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.Navigation.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.Navigation.Services.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.ViewModelMapping.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.ViewModelMapping.Services.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.ViewModelMapping.Services.Servants;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.ViewModelMapping.Services.Servants.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Container;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services.Implementation;
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

            // Aspects
            For<IExceptionHandler>().Use<ExceptionHandler>().Singleton();
            For<IExceptionInitializationService>().Use<ExceptionInitializationService>().Singleton();

            For<IInformationPublisher>().Use<InformationPublisher>().Singleton();
            For<IInformationSubscriptionService>().Use<InformationSubscriptionService>().Singleton();
            For<IInformationEntryViewDataAdapter>().Use<InformationEntryViewDataAdapter>().Singleton();

            For<ILoggingService>().Use<LoggingService>().Singleton();

            // Dialogs
            For<IFileDialogService>().Use<FileDialogService>().Singleton();
            For<IFolderDialogService>().Use<FolderDialogService>().Singleton();

            // Initialization
            For<IAppInitializationServant>().Use<AppInitializationServant>().Singleton();

            For<IViewModelMappingInitializationService>().Use<ViewModelMappingInitializationService>().Singleton();
            For<INavigationEntryFactory>().Use<NavigationEntryFactory>().Singleton();
            For<IResourceDictionaryFactory>().Use<ResourceDictionaryFactory>().Singleton();
            For<IViewViewModelMapFactory>().Use<ViewViewModelMapFactory>().Singleton();
            For<IDataTemplateFactory>().Use<DataTemplateFactory>().Singleton();

            // MvvmShell
            For<ViewModelContainer>().Singleton();
            For<IViewModelDisplayConfigurationService>().Use<ViewModelDisplayConfigurationService>().Singleton();
            For<IViewModelDisplayService>().Use<ViewModelDisplayService>().Singleton();
            For<IViewModelFactory>().Use<ViewModelFactory>().Singleton();
        }
    }
}