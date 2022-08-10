using System;
using Microsoft.Win32;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Appearance.Models;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Appearance.Services.Servants.Implementation
{
    public class AppearanceThemeRepository : IAppearanceThemeRepository
    {
        private const string RegistryKeyAppearanceTheme = "AppearanceTheme";

        public AppearanceTheme Load()
        {
            var regKey = GetCurrentUserApplicationRegistryKey();
            var themeValue = (string)regKey.GetValue(RegistryKeyAppearanceTheme, string.Empty);

            var theme = string.IsNullOrEmpty(themeValue)
                ? AppearanceTheme.Dark
                : (AppearanceTheme)Enum.Parse(typeof(AppearanceTheme), themeValue);

            return theme;
        }

        public void Save(AppearanceTheme theme)
        {
            var regKey = GetCurrentUserApplicationRegistryKey();
            regKey.SetValue(RegistryKeyAppearanceTheme, theme.ToString());
            regKey.Close();
        }

        private static RegistryKey GetCurrentUserApplicationRegistryKey()
        {
            var assemblyName = typeof(AppearanceThemeRepository).Assembly.GetName().Name;
            var subKey = string.Concat("SOFTWARE", @"\", assemblyName);
            var result = Registry.CurrentUser.CreateSubKey(subKey);

            return result;
        }
    }
}