using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services
{
    internal interface IVmFactory
    {
        Task<IReadOnlyCollection<TBehavior>> CreateAllWithBehaviorAsync<TBehavior>()
            where TBehavior : IVmWithBehavior;

        Task<T> CreateAsync<T>(params object[] initParams)
            where T : IViewModel;
    }
}