using System.Windows;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.ViewModelMapping.Models;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.ViewModelMapping.Services.Servants
{
    internal interface IDataTemplateFactory
    {
        DataTemplate CreateWithViewModelMappings(ViewViewModelMap map);
    }
}