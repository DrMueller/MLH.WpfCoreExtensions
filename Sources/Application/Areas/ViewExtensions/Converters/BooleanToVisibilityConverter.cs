using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.ViewExtensions.Converters
{
    internal class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visibility = (Visibility)value;
            return visibility == Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var b = (bool)value;
            return b ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}