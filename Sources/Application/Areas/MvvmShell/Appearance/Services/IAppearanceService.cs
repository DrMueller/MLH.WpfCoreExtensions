using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Appearance.Models;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Appearance.Services
{
    public interface IAppearanceService
    {
        AppearanceTheme AppearanceTheme { get; set; }
        internal void Initialize();
    }
}