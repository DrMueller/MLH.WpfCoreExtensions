using System;
using Microsoft.Extensions.Configuration;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Infrastructure.Settings.Models;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Infrastructure.Settings.Services.Servants.Implementation
{
    internal class AppSettingsFactory : IAppSettingsFactory
    {
        public AppSettings Create()
        {
            var configBuilder = new ConfigurationBuilder();

            configBuilder
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", true, false);

            var configRoot = configBuilder.Build();

            return configRoot
                .GetSection(AppSettings.SectionKey)
                .Get<AppSettings>();
        }
    }
}