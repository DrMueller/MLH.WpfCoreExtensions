using System;
using System.Linq;
using System.Windows;
using Mmu.Mlh.WpfCoreExtensions.Areas.ViewExtensions.DragAndDrop.Models;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.ViewExtensions.DragAndDrop.AttachedProperties
{
    public static class DropBinding
    {
        public static readonly DependencyProperty DroppedProperty = DependencyProperty.RegisterAttached(
            "Dropped",
            typeof(Action<DroppedFile>),
            typeof(DropBinding),
            new PropertyMetadata(DroppedPropertyChanged));

        public static Action<DroppedFile> GetDropped(DependencyObject dependencyObject)
        {
            return (Action<DroppedFile>)dependencyObject.GetValue(DroppedProperty);
        }

        public static void SetDropped(DependencyObject dependencyObject, Action<DroppedFile> value)
        {
            dependencyObject.SetValue(DroppedProperty, value);
        }

        private static void DroppedPropertyChanged(
            DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs args)
        {
#pragma warning disable SA1119 // Statement must not use unnecessary parenthesis
            if (!(dependencyObject is UIElement uiElement))
#pragma warning restore SA1119 // Statement must not use unnecessary parenthesis
            {
                return;
            }

            uiElement.AllowDrop = true;
            uiElement.PreviewDragOver += (sender, e) =>
            {
                e.Handled = true;
            };

            if (args.OldValue == null && args.NewValue != null)
            {
                uiElement.Drop += UiElement_Drop;
            }
            else if (args.OldValue != null && args.NewValue == null)
            {
                uiElement.Drop += UiElement_Drop;
            }
        }

        private static void UiElement_Drop(object sender, DragEventArgs e)
        {
            var dependencyObject = sender as DependencyObject;
            var callback = (Action<DroppedFile>)dependencyObject?.GetValue(DroppedProperty);

            if (callback == null)
            {
                return;
            }

            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                return;
            }

            var files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (!(files?.Any() ?? false))
            {
                return;
            }

            var filePath = files.First();
            callback(new DroppedFile(filePath));
        }
    }
}