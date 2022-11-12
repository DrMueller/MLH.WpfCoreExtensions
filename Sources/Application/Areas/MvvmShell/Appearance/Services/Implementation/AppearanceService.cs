using MaterialDesignThemes.Wpf;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Appearance.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Appearance.Services.Servants;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Appearance.Services.Implementation
{
    internal class AppearanceService : IAppearanceService
    {
        private static readonly PaletteHelper _paletteHelper = new PaletteHelper();
        private readonly IAppearanceThemeRepository _themeRepo;

        public AppearanceTheme AppearanceTheme
        {
            get => _themeRepo.Load();
            set
            {
                var baseTheme = value == AppearanceTheme.Dark
                    ? new MaterialDesignDarkTheme()
                    : (IBaseTheme)new MaterialDesignLightTheme();
                var theme = _paletteHelper.GetTheme();
                theme.SetBaseTheme(baseTheme);
                _paletteHelper.SetTheme(theme);

                _themeRepo.Save(value);
            }
        }

        public AppearanceService(IAppearanceThemeRepository themeRepo)
        {
            _themeRepo = themeRepo;
        }
    }
}