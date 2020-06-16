using System.Reflection;
using Lamar;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;

namespace Mmu.Mlh.WpfCoreExtensions.Infrastructure.DependencyInjection
{
    public class WpfAppRegistryCollection : ServiceRegistry
    {
        public WpfAppRegistryCollection()
        {
            Scan(
                scanner =>
                {
                    scanner.Assembly(WpfAssembly);
                    scanner.AddAllTypesOf<IViewModel>();
                });

            //this.AddTransient<IViewModel>();
        }

        internal static Assembly WpfAssembly { get; set; }
    }
}