using System.Reflection;
using JetBrains.Annotations;
using Lamar;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;

namespace Mmu.Mlh.WpfCoreExtensions.Infrastructure.DependencyInjection
{
    [UsedImplicitly]
    public class WpfAppRegistryCollection : ServiceRegistry
    {
        internal static Assembly WpfAssembly { get; set; }

        public WpfAppRegistryCollection()
        {
            // This more of a convenience feature, therefore if the registry is loaded with the InitializeApplication method called, the WpfAssembly is null
            if (WpfAssembly == null)
            {
                return;
            }

            Scan(
                scanner =>
                {
                    scanner.Assembly(WpfAssembly);
                    scanner.AddAllTypesOf<IViewModel>();
                });
        }
    }
}