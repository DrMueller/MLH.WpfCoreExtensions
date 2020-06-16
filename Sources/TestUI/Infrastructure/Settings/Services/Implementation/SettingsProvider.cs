using Mmu.Mlh.DataAccess.FileSystem.Infrastructure.Settings.Models;
using Mmu.Mlh.DataAccess.FileSystem.Infrastructure.Settings.Services;
using Mmu.Mlh.LanguageExtensions.Areas.Assemblies.Extensions;
using Mmu.Mlh.SettingsProvisioning.Areas.Factories;
using Mmu.Mlh.SettingsProvisioning.Areas.Models;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Infrastructure.Settings.Dtos;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Infrastructure.Settings.Models;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Infrastructure.Settings.Services.Implementation
{
    public class SettingsProvider : IFileSystemSettingsProvider, ISettingsProvider
    {
        private readonly ISettingsFactory _settingsFactory;

        public SettingsProvider(ISettingsFactory settingsFactory)
        {
            _settingsFactory = settingsFactory;
        }

        public FileSystemSettings ProvideFileSystemSettings()
        {
            var config = new SettingsConfiguration(
                "FileSystemSettings",
                string.Empty,
                typeof(SettingsProvider).Assembly.GetBasePath());

            var fileSystemSettingsDto = _settingsFactory.CreateSettings<FileSystemSettingsDto>(config);

            return new FileSystemSettings { DirectoryPath = fileSystemSettingsDto.DirectoryPath };
        }

        public AppSettings ProvideSettings()
        {
            var config = new SettingsConfiguration(
                "AppSettings",
                string.Empty,
                typeof(SettingsProvider).Assembly.GetBasePath());

            var appSettingsDto = _settingsFactory.CreateSettings<AppSettingsDto>(config);

            return new AppSettings(appSettingsDto.Value1, appSettingsDto.Value2);
        }
    }
}