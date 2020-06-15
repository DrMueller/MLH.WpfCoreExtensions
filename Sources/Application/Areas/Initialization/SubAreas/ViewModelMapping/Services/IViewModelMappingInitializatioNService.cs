using System.Reflection;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.ViewModelMapping.Services
{
    internal interface IViewModelMappingInitializationService
    {
        void Initialize(Assembly rootAssembly);
    }
}