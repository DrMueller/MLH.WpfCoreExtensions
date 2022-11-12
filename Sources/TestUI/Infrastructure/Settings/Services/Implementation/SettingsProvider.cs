using System;
using Mmu.Mlh.DataAccess.FileSystem.Areas.Settings.Models;
using Mmu.Mlh.DataAccess.FileSystem.Areas.Settings.Services;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Infrastructure.Settings.Models;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Infrastructure.Settings.Services.Servants;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Infrastructure.Settings.Services.Implementation
{
    public class SettingsProvider : IFileSystemSettingsProvider, ISettingsProvider
    {
        private readonly Lazy<AppSettings> _lazyAppSettings;
        private readonly Lazy<FileSystemSettings> _lazyFileSystemSettingsSettings;

        public SettingsProvider(IAppSettingsFactory appSettingsFactory)
        {
            _lazyAppSettings = new Lazy<AppSettings>(appSettingsFactory.Create);
            _lazyFileSystemSettingsSettings = new Lazy<FileSystemSettings>(
                () => new FileSystemSettings { DirectoryPath = _lazyAppSettings.Value.DirectoryPath });
        }

        public FileSystemSettings ProvideFileSystemSettings()
        {
            return _lazyFileSystemSettingsSettings.Value;
        }

        public AppSettings ProvideSettings()
        {
            return _lazyAppSettings.Value;
        }
    }
}