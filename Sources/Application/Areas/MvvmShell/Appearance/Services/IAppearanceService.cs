using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Appearance.Models;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Appearance.Services
{
    public interface IAppearanceService
    {
        internal void Initialize();

        AppearanceTheme AppearanceTheme { get; set; }
    }
}