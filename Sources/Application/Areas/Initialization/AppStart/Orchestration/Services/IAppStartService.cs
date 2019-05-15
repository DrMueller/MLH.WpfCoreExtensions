using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.AppStart.Orchestration.Models;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.AppStart.Orchestration.Services
{
    public interface IAppStartService
    {
        void StartApp(WpfAppConfig confg);
    }
}