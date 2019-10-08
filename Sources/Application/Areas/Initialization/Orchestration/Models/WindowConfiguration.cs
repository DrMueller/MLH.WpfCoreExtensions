using System;
using System.IO;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Mmu.Mlh.LanguageExtensions.Areas.Assemblies.Extensions;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Models
{
    public class WindowConfiguration
    {
        public string AppTitle { get; }
        public int WindowWidth { get; }
        public int WindowHeight { get; }
        public ImageSource Icon { get; }

        public WindowConfiguration(
            ImageSource icon,
            string appTitle,
            int windowWidth = 1200,
            int windowHeight = 800)
        {
            Guard.StringNotNullOrEmpty(() => appTitle);
            Guard.ObjectNotNull(() => icon);

            AppTitle = appTitle;
            WindowWidth = windowWidth;
            WindowHeight = windowHeight;
            Icon = icon;
        }

        public static WindowConfiguration CreateWithDefaultIcon(
            Assembly wpfAssembly,
            string appTitle,
            int windowWidth = 1200,
            int windowHeight = 800)
        {
            return new WindowConfiguration(
                CreateDefaultImageSource(wpfAssembly),
                appTitle,
                windowWidth,
                windowHeight);
        }

        private static ImageSource CreateDefaultImageSource(Assembly wpfAssembly)
        {
            var assemblyBasePath = wpfAssembly.GetBasePath();
            var iconPath = Path.Combine(assemblyBasePath, "Infrastructure", "Assets", "App.ico");
            var iconUri = new Uri(iconPath);
            var icon = new BitmapImage(iconUri);
            return icon;
        }
    }
}