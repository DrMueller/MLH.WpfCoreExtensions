using System.Reflection;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Models
{
    public class WpfAppConfiguration
    {
        public WindowConfiguration WindowConfiguration { get; }
        public bool HandleException { get; }
        public Assembly WpfAssembly { get; }

        public WpfAppConfiguration(
            Assembly wpfAssembly,
            WindowConfiguration windowConfiguration,
            bool handleException = true)
        {
            Guard.ObjectNotNull(() => wpfAssembly);
            Guard.ObjectNotNull(() => windowConfiguration);

            WpfAssembly = wpfAssembly;
            WindowConfiguration = windowConfiguration;
            HandleException = handleException;
        }
    }
}