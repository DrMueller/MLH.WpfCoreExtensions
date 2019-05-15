using System.Windows;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.AppStart.SubAreas.ViewModelMapping.Models;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.AppStart.SubAreas.ViewModelMapping.Services.Servants
{
    internal interface IDataTemplateFactory
    {
        DataTemplate CreateWithViewModelMappings(ViewViewModelMap map);
    }
}