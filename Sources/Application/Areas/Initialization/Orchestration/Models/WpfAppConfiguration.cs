using System.Reflection;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Models
{
    public class WpfAppConfiguration
    {
        public WpfAppConfiguration(Assembly wpfAssembly, WindowConfiguration windowConfiguration)
        {
            Guard.ObjectNotNull(() => wpfAssembly);
            Guard.ObjectNotNull(() => windowConfiguration);

            WpfAssembly = wpfAssembly;
            WindowConfiguration = windowConfiguration;
        }

        public WindowConfiguration WindowConfiguration { get; }
        public Assembly WpfAssembly { get; }
    }
}