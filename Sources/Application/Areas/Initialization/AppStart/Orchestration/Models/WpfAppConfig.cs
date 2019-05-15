using System.Reflection;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.AppStart.Orchestration.Models
{
    public class WpfAppConfig
    {
        public Assembly WpfAssembly { get; }

        public WpfAppConfig(Assembly wpfAssembly)
        {
            Guard.ObjectNotNull(() => wpfAssembly);
            WpfAssembly = wpfAssembly;
        }
    }
}