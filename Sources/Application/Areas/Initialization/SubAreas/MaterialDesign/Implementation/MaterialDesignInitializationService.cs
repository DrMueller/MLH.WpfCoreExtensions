using System;
using System.Windows;
using MaterialDesignThemes.Wpf;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.RessourceDictionaries.Services;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.MaterialDesign.Implementation
{
    internal class MaterialDesignInitializationService : IMaterialDesignInitializationService
    {
        private readonly IResourceDictionaryFactory _resourceDictionaryFactory;

        public MaterialDesignInitializationService(IResourceDictionaryFactory resourceDictionaryFactory)
        {
            _resourceDictionaryFactory = resourceDictionaryFactory;
        }

        public void Initialize()
        {
            //var bundledTheme = new BundledTheme
            //{
            //    BaseTheme = BaseTheme.Light,
            //    PrimaryColor = MaterialDesignColors.PrimaryColor.DeepPurple,
            //    SecondaryColor = MaterialDesignColors.SecondaryColor.Lime
            //};

            //var mergedDict = _resourceDictionaryFactory.CreateEmpty();
            //mergedDict.MergedDictionaries.Add(bundledTheme);

            //var defaultsDict = _resourceDictionaryFactory.CreateEmpty();
            //defaultsDict.Source = new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml");
            //mergedDict.MergedDictionaries.Add(defaultsDict);

            //Application.Current.Resources.MergedDictionaries.Add(mergedDict);
        }
    }
}
