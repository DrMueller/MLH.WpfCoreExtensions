using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.ViewExtensions.Watermarks
{
    public static class WatermarkService
    {
        public static readonly DependencyProperty WatermarkProperty = DependencyProperty.RegisterAttached(
            "Watermark",
            typeof(object),
            typeof(WatermarkService),
            new FrameworkPropertyMetadata(null, OnWatermarkChanged));

        private static readonly Dictionary<object, ItemsControl> _itemsControls = new Dictionary<object, ItemsControl>();

        public static object GetWatermark(DependencyObject d)
        {
            return d.GetValue(WatermarkProperty);
        }

        public static void SetWatermark(DependencyObject d, object value)
        {
            d.SetValue(WatermarkProperty, value);
        }

        private static void Control_GotKeyboardFocus(object sender, RoutedEventArgs e)
        {
            var c = (Control)sender;

            if (ShouldShowWatermark(c))
            {
                ShowWatermark(c);
            }
            else
            {
                RemoveWatermark(c);
            }
        }

        private static void Control_Loaded(object sender, RoutedEventArgs e)
        {
            var control = (Control)sender;

            if (ShouldShowWatermark(control))
            {
                ShowWatermark(control);
            }
        }

        private static void ItemsChanged(object sender, ItemsChangedEventArgs e)
        {
            if (!_itemsControls.TryGetValue(sender, out var control))
            {
                return;
            }

            if (ShouldShowWatermark(control))
            {
                ShowWatermark(control);
            }
            else
            {
                RemoveWatermark(control);
            }
        }

        private static void ItemsSourceChanged(object sender, EventArgs e)
        {
            var c = (ItemsControl)sender;

            if (c.ItemsSource != null)
            {
                if (ShouldShowWatermark(c))
                {
                    ShowWatermark(c);
                }
                else
                {
                    RemoveWatermark(c);
                }
            }
            else
            {
                ShowWatermark(c);
            }
        }

        private static void OnWatermarkChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (Control)d;
            control.Loaded += Control_Loaded;

            if (d is ComboBox)
            {
                control.GotKeyboardFocus += Control_GotKeyboardFocus;
                control.LostKeyboardFocus += Control_Loaded;
            }
            else if (d is TextBox)
            {
                control.GotKeyboardFocus += Control_GotKeyboardFocus;
                control.LostKeyboardFocus += Control_Loaded;
                ((TextBox)control).TextChanged += Control_GotKeyboardFocus;
            }

            if (d is ItemsControl o && !(o is ComboBox))
            {
                o.ItemContainerGenerator.ItemsChanged += ItemsChanged;
                _itemsControls.Add(o.ItemContainerGenerator, o);

                var prop = DependencyPropertyDescriptor.FromProperty(ItemsControl.ItemsSourceProperty, o.GetType());
                prop.AddValueChanged(o, ItemsSourceChanged);
            }
        }

        private static void RemoveWatermark(UIElement control)
        {
            var layer = AdornerLayer.GetAdornerLayer(control);

            if (layer != null)
            {
                var adorners = layer.GetAdorners(control);

                if (adorners == null)
                {
                    return;
                }

                foreach (var adorner in adorners)
                {
                    if (adorner is WatermarkAdorner)
                    {
                        adorner.Visibility = Visibility.Hidden;
                        layer.Remove(adorner);
                    }
                }
            }
        }

        private static bool ShouldShowWatermark(Control c)
        {
            switch (c)
            {
                case ComboBox box:
                    return box.Text == string.Empty;
                case TextBoxBase _:
                    return (c as TextBox)?.Text == string.Empty;
                default:
                    {
                        if (c is ItemsControl control)
                        {
                            return control.Items.Count == 0;
                        }

                        return false;
                    }
            }
        }

        private static void ShowWatermark(Control control)
        {
            var layer = AdornerLayer.GetAdornerLayer(control);

            layer?.Add(new WatermarkAdorner(control, GetWatermark(control)));
        }
    }
}