using Mmu.Mlh.DataAccess.FileSystem.Infrastructure.Settings.Services;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Infrastructure.Settings.Services;
using StructureMap;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Infrastructure.DependencyInjection
{
    public class TestUIRegistry : Registry
    {
        public TestUIRegistry()
        {
            Scan(scanner =>
            {
                scanner.AssemblyContainingType<TestUIRegistry>();
                scanner.WithDefaultConventions();
            });

            For<IFileSystemSettingsProvider>().Use<SettingsProvider>().Singleton();
        }
    }
}