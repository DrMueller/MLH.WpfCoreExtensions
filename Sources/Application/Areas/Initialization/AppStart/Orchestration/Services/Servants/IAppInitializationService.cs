using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.AppStart.Orchestration.Models;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.AppStart.Orchestration.Services.Servants
{
    internal interface IAppInitializationService
    {
        Task StartAppAsync(WpfAppConfig config);
    }
}