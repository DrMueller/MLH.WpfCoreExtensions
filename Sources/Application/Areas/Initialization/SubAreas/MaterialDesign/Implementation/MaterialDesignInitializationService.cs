using System;
using System.Windows;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.RessourceDictionaries.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Appearance.Services;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.MaterialDesign.Implementation
{
    internal class MaterialDesignInitializationService : IMaterialDesignInitializationService
    {
        private readonly IAppearanceService _appearanceService;
        private readonly IResourceDictionaryFactory _resourceDictionaryFactory;

        public MaterialDesignInitializationService(
            IResourceDictionaryFactory resourceDictionaryFactory,
            IAppearanceService appearanceService)
        {
            _resourceDictionaryFactory = resourceDictionaryFactory;
            _appearanceService = appearanceService;
        }

        public void Initialize()
        {
            var customColorTheme = new CustomColorTheme
            {
                BaseTheme = BaseTheme.Inherit,
                PrimaryColor = Color.FromRgb(0, 11, 178),
                SecondaryColor = Color.FromRgb(194, 255, 218)
            };

            var mergedDict = _resourceDictionaryFactory.CreateEmpty();
            mergedDict.MergedDictionaries.Add(customColorTheme);

            var defaultsDict = _resourceDictionaryFactory.CreateEmpty();
            defaultsDict.Source =
                new Uri(
                    "pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml");
            mergedDict.MergedDictionaries.Add(defaultsDict);

            Application.Current.Resources.MergedDictionaries.Add(mergedDict);

            _appearanceService.Initialize();
        }
    }
}