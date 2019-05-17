using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.Navigation.Models;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.Navigation.Services
{
    internal interface INavigationEntryFactory
    {
        Task<IReadOnlyCollection<NavigationEntry>> CreateAllAsync();
    }
}