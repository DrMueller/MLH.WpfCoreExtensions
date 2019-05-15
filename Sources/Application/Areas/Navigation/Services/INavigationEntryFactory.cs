using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.Navigation.Models;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Navigation.Services
{
    internal interface INavigationEntryFactory
    {
        Task<IReadOnlyCollection<NavigationEntry>> CreateAllAsync();
    }
}