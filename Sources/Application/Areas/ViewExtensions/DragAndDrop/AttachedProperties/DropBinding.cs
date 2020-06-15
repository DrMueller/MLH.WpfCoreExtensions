using System;
using System.Linq;
using System.Windows;
using Mmu.Mlh.WpfCoreExtensions.Areas.ViewExtensions.DragAndDrop.Models;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.ViewExtensions.DragAndDrop.AttachedProperties
{
    public static class DropBinding
    {
        public static readonly DependencyProperty DropCommandProperty = DependencyProperty.RegisterAttached(
            "DropCommand",
            typeof(Action<DroppedFile>),
            typeof(DropBinding),
            new PropertyMetadata(DropCommandPropertyChanged));

        public static Action<DroppedFile> GetDropCommand(DependencyObject dependencyObject)
        {
            return (Action<DroppedFile>)dependencyObject.GetValue(DropCommandProperty);
        }

        public static void SetDropCommand(DependencyObject dependencyObject, Action<DroppedFile> value)
        {
            dependencyObject.SetValue(DropCommandProperty, value);
        }

        private static void DropCommandPropertyChanged(
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
            var callback = (Action<DroppedFile>)dependencyObject?.GetValue(DropCommandProperty);

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