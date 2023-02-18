using MaterialDesignThemes.Wpf;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Appearance.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Appearance.Services.Servants;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Appearance.Services.Implementation
{
    internal class AppearanceService : IAppearanceService
    {
        private static readonly PaletteHelper _paletteHelper = new();
        private readonly IAppearanceThemeRepository _themeRepo;

        public void Initialize()
        {
            var existingTheme = _themeRepo.Load();
            ApplyTheme(existingTheme);
        }

        public AppearanceTheme AppearanceTheme
        {
            get => _themeRepo.Load();
            set
            {
                ApplyTheme(value);
            }
        }

        private void ApplyTheme(AppearanceTheme appeareanceTheme)
        {
            var baseTheme = appeareanceTheme == AppearanceTheme.Dark
                ? new MaterialDesignDarkTheme()
                : (IBaseTheme)new MaterialDesignLightTheme();
            var theme = _paletteHelper.GetTheme();
            theme.SetBaseTheme(baseTheme);
            _paletteHelper.SetTheme(theme);

            _themeRepo.Save(appeareanceTheme);
        }

        public AppearanceService(IAppearanceThemeRepository themeRepo)
        {
            _themeRepo = themeRepo;
        }
    }
}