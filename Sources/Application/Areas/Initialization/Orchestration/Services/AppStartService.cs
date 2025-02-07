using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Services.Servants;
using Mmu.Mlh.WpfCoreExtensions.Infrastructure.DependencyInjection;
using Mmu.Mlh.WpfCoreExtensions.Infrastructure.DependencyInjection.Initialization.Models;
using Mmu.Mlh.WpfCoreExtensions.Infrastructure.DependencyInjection.Initialization.Services;
using Mmu.Mlh.WpfCoreExtensions.Infrastructure.DependencyInjection.Provisioning.Services;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Services
{
    public static class AppStartService
    {
        private static Mutex _mutex;

        [SuppressMessage(
            "Code Quality",
            "IDE0067:Dispose objects before losing scope",
            Justification = "The disposable lives and dies with the application")]
        public static async Task StartAppAsync(
            WpfAppConfiguration config,
            Action<IServiceLocator> afterInitializedCallback = null)
        {
            _mutex = new Mutex(false, config.WindowConfiguration.AppTitle);
            _mutex.WaitOne();

            WpfAppRegistryCollection.WpfAssembly = config.WpfAssembly;

            var containerConfig =
                ContainerConfiguration.CreateFromAssembly(config.WpfAssembly, initializeAutoMapper: true);
            var container = ServiceProvisioningInitializer.CreateContainer(containerConfig);

            var initService = container.GetInstance<IAppInitializationServant>();
            await initService.StartAppAsync(config, afterInitializedCallback);
            _mutex.ReleaseMutex();
        }
    }
}