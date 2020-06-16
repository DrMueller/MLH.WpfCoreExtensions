using JetBrains.Annotations;
using Lamar;
using Mmu.Mlh.DataAccess.FileSystem.Infrastructure.Settings.Services;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Infrastructure.Settings.Services;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Infrastructure.Settings.Services.Implementation;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Infrastructure.DependencyInjection
{
    [UsedImplicitly]
    public class TestUiRegistryCollection : ServiceRegistry
    {
        public TestUiRegistryCollection()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<TestUiRegistryCollection>();
                    scanner.WithDefaultConventions();
                });

            For<IFileSystemSettingsProvider>().Use<SettingsProvider>().Singleton();
            For<ISettingsProvider>().Use<SettingsProvider>().Singleton();
        }
    }
}