using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Models;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Services.Servants
{
    internal interface IAppInitializationServant
    {
        Task StartAppAsync(WpfAppConfiguration config);
    }
}