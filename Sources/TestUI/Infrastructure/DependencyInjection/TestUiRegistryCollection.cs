using JetBrains.Annotations;
using Lamar;
using Microsoft.Extensions.DependencyInjection;
using Mmu.Mlh.DataAccess.FileSystem.Areas.Settings.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Infrastructure.DependencyInjection;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Infrastructure.Settings.Services;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Infrastructure.Settings.Services.Implementation;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Infrastructure.Settings.Services.Servants;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Infrastructure.Settings.Services.Servants.Implementation;

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
                    scanner.AddAllTypesOf<IViewModel>();
                });

            this.AddWpfCore();
            this.AddAutoMapper(typeof(TestUiRegistryCollection).Assembly);
            For<IFileSystemSettingsProvider>().Use<SettingsProvider>().Singleton();
            For<ISettingsProvider>().Use<SettingsProvider>().Singleton();
            For<IAppSettingsFactory>().Use<AppSettingsFactory>().Singleton();
        }
    }
}