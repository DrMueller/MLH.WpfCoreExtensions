using System;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.ViewModelMapping.Models
{
    internal class ViewViewModelMap
    {
        public ViewViewModelMap(Type viewType, Type viewModelType)
        {
            Guard.ObjectNotNull(() => viewType);
            Guard.ObjectNotNull(() => viewModelType);

            ViewModelType = viewModelType;
            ViewType = viewType;
        }

        public Type ViewModelType { get; }
        public Type ViewType { get; }
    }
}