using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.AppStart.Orchestration.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.AppStart.Orchestration.Services;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Infrastructure.Initialization
{
    internal static class InitializationService
    {
        internal static void Initialize()
        {
            var assembly = typeof(InitializationService).Assembly;
            var containerConfig = ContainerConfiguration.CreateFromAssembly(assembly);
            var container = ContainerInitializationService.CreateInitializedContainer(containerConfig);

            container
                .GetInstance<IAppStartService>()
                .StartApp(new WpfAppConfig(assembly));
        }
    }
}