using JetBrains.Annotations;
using Mmu.Mlh.DataAccess.FileSystem.Infrastructure.Settings.Services;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Infrastructure.Settings.Services;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Infrastructure.Settings.Services.Implementation;
using StructureMap;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Infrastructure.DependencyInjection
{
    [UsedImplicitly]
    public class TestUiRegistry : Registry
    {
        public TestUiRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<TestUiRegistry>();
                    scanner.WithDefaultConventions();
                });

            For<IFileSystemSettingsProvider>().Use<SettingsProvider>().Singleton();
            For<ISettingsProvider>().Use<SettingsProvider>().Singleton();
        }
    }
}