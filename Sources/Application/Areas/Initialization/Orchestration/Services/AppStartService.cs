using System;
using System.Reflection;
using System.Threading.Tasks;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Services;
using Mmu.Mlh.ServiceProvisioning.Areas.Provisioning.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Services.Servants;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using StructureMap;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Services
{
    public static class AppStartService
    {
        public static async Task StartAppAsync(WpfAppConfig config, Action<IServiceLocator> afterInitializedCallback = null)
        {
            var containerConfig = ContainerConfiguration.CreateFromAssembly(config.WpfAssembly, initializeAutoMapper: true);
            var container = ContainerInitializationService.CreateInitializedContainer(containerConfig);
            ConfigureViewModels(container, config.WpfAssembly);

            var initService = container.GetInstance<IAppInitializationServant>();
            await initService.StartAppAsync(config, afterInitializedCallback);
        }

        private static void ConfigureViewModels(Container container, Assembly wpfAssembly)
        {
            container.Configure(cfg =>
            {
                cfg.Scan(scanner =>
                {
                    scanner.Assembly(wpfAssembly);
                    scanner.AddAllTypesOf<IViewModel>();
                });

                cfg.For<IViewModel>().Transient();
            });
        }
    }
}