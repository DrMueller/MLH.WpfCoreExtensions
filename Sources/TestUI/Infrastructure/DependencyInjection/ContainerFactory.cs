using Lamar;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Infrastructure.DependencyInjection
{
    internal static class ContainerFactory
    {
        internal static IContainer Create()
        {
            return new Container(cfg =>
            {
                cfg.Scan(scanner =>
                {
                    scanner.AssembliesFromApplicationBaseDirectory();
                    scanner.LookForRegistries();
                });
            });
        }
    }
}