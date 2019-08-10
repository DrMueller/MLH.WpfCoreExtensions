using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.AttachedProperties
{
    public static class CommandBinding
    {
        public static readonly DependencyProperty ViewModelCommandProperty =
            DependencyProperty
            .RegisterAttached(
                "ViewModelCommand",
                typeof(IViewModelCommand),
                typeof(CommandBinding),
                new PropertyMetadata(AttachOrRemoveBinding));

        public static IViewModelCommand ViewModelCommand(DependencyObject dependencyObject)
        {
            return (IViewModelCommand)dependencyObject.GetValue(ViewModelCommandProperty);
        }

        public static void ViewModelCommand(DependencyObject dependencyObject, IViewModelCommand value)
        {
            dependencyObject.SetValue(ViewModelCommandProperty, value);
        }

        public static void AttachOrRemoveBinding(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            var viewModelCommand = (IViewModelCommand)args.NewValue;

            if (dependencyObject is ButtonBase buttonBase)
            {
                buttonBase.Content = viewModelCommand.Description;
                buttonBase.Command = viewModelCommand.Command;
            }
            else
            {
                throw new Exception("ViewModelCommand must implement ButtonBase.");
            }
        }
    }
}