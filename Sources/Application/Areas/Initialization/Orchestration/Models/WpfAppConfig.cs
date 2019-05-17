using System;
using System.IO;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Mmu.Mlh.LanguageExtensions.Areas.Assemblies.Extensions;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Models
{
    public class WpfAppConfig
    {
        public string AppTitle { get; }
        public ImageSource Icon { get; }
        public Assembly WpfAssembly { get; }

        public WpfAppConfig(Assembly wpfAssembly, string appTitle, ImageSource icon)
        {
            Guard.ObjectNotNull(() => wpfAssembly);
            Guard.StringNotNullOrEmpty(() => appTitle);
            Guard.ObjectNotNull(() => icon);

            WpfAssembly = wpfAssembly;
            AppTitle = appTitle;
            Icon = icon;
        }

        public static WpfAppConfig CreateWithDefaultIcon(Assembly wpfAssembly, string appTitle)
        {
            var defaultIcon = ReadDefaultIcon();
            return new WpfAppConfig(wpfAssembly, appTitle, defaultIcon);
        }

        private static ImageSource ReadDefaultIcon()
        {
            var assemblyBasePath = typeof(WpfAppConfig).Assembly.GetBasePath();
            var iconPath = Path.Combine(assemblyBasePath, "Infrastructure", "Assets", "App.ico");
            var iconUri = new Uri(iconPath);
            var icon = new BitmapImage(iconUri);
            return icon;
        }
    }
}