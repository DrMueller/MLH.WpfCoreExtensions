using System.Collections.Generic;
using System.Reflection;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.AppStart.SubAreas.ViewModelMapping.Models;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.AppStart.SubAreas.ViewModelMapping.Services.Servants
{
    internal interface IViewViewModelMapFactory
    {
        IReadOnlyCollection<ViewViewModelMap> CreateAll(Assembly rootAssembly);
    }
}