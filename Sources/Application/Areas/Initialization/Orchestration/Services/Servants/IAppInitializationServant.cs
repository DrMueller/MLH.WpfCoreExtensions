using System;
using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Models;
using Mmu.Mlh.WpfCoreExtensions.Infrastructure.DependencyInjection.Provisioning.Services;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Services.Servants
{
    internal interface IAppInitializationServant
    {
        Task StartAppAsync(WpfAppConfiguration config, Action<IServiceLocator> afterInitializedCallback);
    }
}