using System;
using System.Diagnostics.CodeAnalysis;
using MaterialDesignThemes.Wpf;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Appearance.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Appearance.Services.Servants;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Appearance.Services.Implementation
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by StructureMap")]
    internal class AppearanceService : IAppearanceService
    {
        private const string RegistryKeyAppearanceTheme = "AppearanceTheme";
        private static readonly PaletteHelper _paletteHelper = new PaletteHelper();
        private readonly IRegistryHandler _registryHandler;

        public AppearanceTheme AppearanceTheme
        {
            get
            {
                {
                    var savedTheme = _registryHandler.LoadFromCurrentUserApplicationRegistry(RegistryKeyAppearanceTheme);
                    var appearanceTheme = AppearanceTheme.Dark;
                    if (!string.IsNullOrEmpty(savedTheme))
                    {
                        appearanceTheme = (AppearanceTheme)Enum.Parse(typeof(AppearanceTheme), savedTheme);
                    }

                    return appearanceTheme;
                }
            }
            set
            {
                var baseTheme = value == AppearanceTheme.Dark ? new MaterialDesignDarkTheme() : (IBaseTheme)new MaterialDesignLightTheme();
                var theme = _paletteHelper.GetTheme();
                theme.SetBaseTheme(baseTheme);
                _paletteHelper.SetTheme(theme);

                _registryHandler.SaveIntoCurrentUserApplicationRegistry(RegistryKeyAppearanceTheme, value.ToString());
            }
        }

        public AppearanceService(IRegistryHandler registryHandler)
        {
            _registryHandler = registryHandler;
        }

        public void Initialize()
        {
            var currentAppearance = AppearanceTheme;
            AppearanceTheme = currentAppearance;
        }
    }
}