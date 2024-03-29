﻿using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using JetBrains.Annotations;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.AttachedProperties
{
    [PublicAPI]
    public static class CommandBinding
    {
        public static readonly DependencyProperty ViewModelCommandProperty =
            DependencyProperty.RegisterAttached(
                "ViewModelCommand",
                typeof(IViewModelCommand),
                typeof(CommandBinding),
                new PropertyMetadata(AttachBinding));

        public static void AttachBinding(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            var viewModelCommand = (IViewModelCommand)args.NewValue;

            if (dependencyObject is ButtonBase buttonBase)
            {
                if (viewModelCommand != null)
                {
                    buttonBase.Content = viewModelCommand.Description;
                    buttonBase.Command = viewModelCommand.Command;
                }
                else
                {
                    buttonBase.Content = null;
                    buttonBase.Command = null;
                }
            }
            else
            {
                throw new Exception("ViewModelCommand must implement ButtonBase.");
            }
        }

        public static IViewModelCommand GetViewModelCommand(DependencyObject dependencyObject)
        {
            return (IViewModelCommand)dependencyObject.GetValue(ViewModelCommandProperty);
        }

        public static void SetViewModelCommand(DependencyObject dependencyObject, IViewModelCommand value)
        {
            dependencyObject.SetValue(ViewModelCommandProperty, value);
        }
    }
}