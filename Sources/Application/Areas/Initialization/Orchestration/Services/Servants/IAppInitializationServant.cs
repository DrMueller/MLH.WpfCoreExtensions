using System;
using System.Threading.Tasks;
using Mmu.Mlh.ServiceProvisioning.Areas.Provisioning.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Models;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Services.Servants
{
    internal interface IAppInitializationServant
    {
        Task StartAppAsync(WpfAppConfig config, Action<IServiceLocator> afterInitializedCallback);
    }
}