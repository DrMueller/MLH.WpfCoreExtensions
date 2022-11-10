using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Windows.Data;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Appearance.Models;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Appearance.Converters
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses",
        Justification = "Instantiated by StructureMap")]
    internal class LightThemeToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var appearanceTheme = (AppearanceTheme)value!;

            return appearanceTheme == AppearanceTheme.Light;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var appearanceThemeIsLight = (bool)value!;

            return appearanceThemeIsLight ? AppearanceTheme.Light : AppearanceTheme.Dark;
        }
    }
}