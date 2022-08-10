using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Appearance.Models;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Appearance.Services.Servants
{
    public interface IAppearanceThemeRepository
    {
        AppearanceTheme Load();

        void Save(AppearanceTheme theme);
    }
}