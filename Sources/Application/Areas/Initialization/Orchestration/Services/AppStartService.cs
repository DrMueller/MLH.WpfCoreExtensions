using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Services;
using Mmu.Mlh.ServiceProvisioning.Areas.Provisioning.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Services.Servants;
using Mmu.Mlh.WpfCoreExtensions.Infrastructure.DependencyInjection;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Services
{
    public static class AppStartService
    {
        [SuppressMessage("Code Quality", "IDE0067:Dispose objects before losing scope", Justification = "The disposable lives and dies with the application")]
        public static async Task StartAppAsync(WpfAppConfiguration config, Action<IServiceLocator> afterInitializedCallback = null)
        {
            WpfAppRegistryCollection.WpfAssembly = config.WpfAssembly;

            var containerConfig = ContainerConfiguration.CreateFromAssembly(config.WpfAssembly, initializeAutoMapper: true);
            var container = ServiceProvisioningInitializer.CreateContainer(containerConfig);

            var initService = container.GetInstance<IAppInitializationServant>();
            await initService.StartAppAsync(config, afterInitializedCallback);
        }
    }
}