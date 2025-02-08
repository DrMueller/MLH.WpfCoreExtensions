using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Services.Servants;

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
            IServiceProvider serviceProvider)
        {
            _mutex = new Mutex(false, config.WindowConfiguration.AppTitle);
            _mutex.WaitOne();

            var initService = serviceProvider.GetService<IAppInitializationServant>();
            await initService.StartAppAsync(config);
            _mutex.ReleaseMutex();
        }
    }
}