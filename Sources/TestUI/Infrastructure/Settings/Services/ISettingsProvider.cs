using Mmu.Mlh.WpfCoreExtensions.TestUI.Infrastructure.Settings.Models;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Infrastructure.Settings.Services
{
    public interface ISettingsProvider
    {
        AppSettings ProvideSettings();
    }
}