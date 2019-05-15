using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services
{
    internal interface IViewModelFactory
    {
        Task<T> CreateAsync<T>()
            where T : IViewModel;

        Task<IReadOnlyCollection<TBehavior>> CreateAllWithBehaviorAsync<TBehavior>()
            where TBehavior : IViewModelWithBehaviorBase;
    }
}