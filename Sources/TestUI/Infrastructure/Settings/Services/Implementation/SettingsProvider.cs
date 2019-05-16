using System;
using System.IO;
using System.Reflection;
using Mmu.Mlh.DataAccess.FileSystem.Infrastructure.Settings.Models;
using Mmu.Mlh.DataAccess.FileSystem.Infrastructure.Settings.Services;
using Mmu.Mlh.SettingsProvisioning.Areas.Factories;
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
            var fileSystemSettingsDto = _settingsFactory.CreateSettings<FileSystemSettingsDto>(
                 "FileSystemSettings",
                 string.Empty,
                 GetCodeBasePath());

            return new FileSystemSettings
            {
                DirectoryPath = fileSystemSettingsDto.DirectoryPath
            };
        }

        public AppSettings ProvideSettings()
        {
            var appSettingsDto = _settingsFactory.CreateSettings<AppSettingsDto>(
                 "AppSettings",
                 string.Empty,
                 GetCodeBasePath());

            return new AppSettings(appSettingsDto.Value1, appSettingsDto.Value2);
        }

        private string GetCodeBasePath()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var result = Uri.UnescapeDataString(uri.Path);
            result = Path.GetDirectoryName(result);

            return result;
        }
    }
}