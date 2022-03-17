using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Mmu.Mlh.LanguageExtensions.Areas.Reflection.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.ViewModelMapping.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Views.Interfaces;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.ViewModelMapping.Services.Servants.Implementation
{
    [UsedImplicitly]
    internal class ViewViewModelMapFactory : IViewViewModelMapFactory
    {
        private static readonly Type _viewModelMapType = typeof(IViewMap<>);
        private readonly ITypeReflectionService _typeReflectionService;

        public ViewViewModelMapFactory(ITypeReflectionService typeReflectionService)
        {
            _typeReflectionService = typeReflectionService;
        }

        public IReadOnlyCollection<ViewViewModelMap> CreateAll(Assembly rootAssembly)
        {
            var viewMapTypes = GetViewMapTypes(rootAssembly);
            var result = viewMapTypes.Select(CreateFromViewMapType).ToList();

            return result;
        }

        private ViewViewModelMap CreateFromViewMapType(Type viewMapType)
        {
            var mapInterface = viewMapType.GetInterfaces().First(f =>
                _typeReflectionService.CheckIfTypeIsAssignableToGenericType(f, _viewModelMapType));

            var viewModelType = mapInterface.GetGenericArguments().First();

            return new ViewViewModelMap(viewMapType, viewModelType);
        }

        private IEnumerable<Type> GetViewMapTypes(Assembly rootAssembly)
        {
            var result = rootAssembly.GetTypes().Where(
                f =>
                    _typeReflectionService.CheckIfTypeIsAssignableToGenericType(f, _viewModelMapType)
                    && !f.IsInterface
                    && !f.IsAbstract).ToList();

            return result;
        }
    }
}