using System.Collections.Generic;
using System.Reflection;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.ViewModelMapping.Models;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.ViewModelMapping.Services.Servants
{
    internal interface IViewViewModelMapFactory
    {
        IReadOnlyCollection<ViewViewModelMap> CreateAll(Assembly rootAssembly);
    }
}