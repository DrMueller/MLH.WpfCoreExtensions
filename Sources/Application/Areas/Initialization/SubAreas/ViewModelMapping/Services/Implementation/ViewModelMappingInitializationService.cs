using System.Collections;
using System.Reflection;
using System.Windows;
using JetBrains.Annotations;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.RessourceDictionaries.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.ViewModelMapping.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.ViewModelMapping.Services.Servants;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.ViewModelMapping.Services.Implementation
{
    [UsedImplicitly]
    internal class ViewModelMappingInitializationService : IViewModelMappingInitializationService
    {
        private readonly IDataTemplateFactory _dataTemplateFactory;
        private readonly IResourceDictionaryFactory _resourceDictionaryFactory;
        private readonly IViewViewModelMapFactory _viewViewModelMapFactory;

        public ViewModelMappingInitializationService(
            IDataTemplateFactory dataTemplateFactory,
            IResourceDictionaryFactory resourceDictionaryFactory,
            IViewViewModelMapFactory viewViewModelMapFactory)
        {
            _dataTemplateFactory = dataTemplateFactory;
            _resourceDictionaryFactory = resourceDictionaryFactory;
            _viewViewModelMapFactory = viewViewModelMapFactory;
        }

        public void Initialize(Assembly rootAssembly)
        {
            var resourceDictionary = _resourceDictionaryFactory.CreateEmpty();
            _viewViewModelMapFactory
                .CreateAll(rootAssembly)
                .ForEach(map => AddDataTemplate(resourceDictionary, map));

            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        }

        private void AddDataTemplate(IDictionary resourceDictionary, ViewViewModelMap map)
        {
            var dataTemplate = _dataTemplateFactory.CreateWithViewModelMappings(map);

            if (dataTemplate.DataTemplateKey == null)
            {
                return;
            }

            resourceDictionary.Add(dataTemplate.DataTemplateKey, dataTemplate);
        }
    }
}