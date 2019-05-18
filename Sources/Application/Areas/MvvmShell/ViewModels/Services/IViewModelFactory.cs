using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services
{
    internal interface IViewModelFactory
    {
        Task<IReadOnlyCollection<TBehavior>> CreateAllWithBehaviorAsync<TBehavior>()
            where TBehavior : IViewModelWithBehavior;

        Task<T> CreateAsync<T>(params object[] initParams)
            where T : IViewModel;
    }
}