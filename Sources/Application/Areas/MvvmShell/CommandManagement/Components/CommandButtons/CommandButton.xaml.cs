using System.Windows;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandButtons
{
    public partial class CommandButton
    {
        public static readonly DependencyProperty ViewModelCommandProperty =
            DependencyProperty.Register(
                nameof(ViewModelCommand),
                typeof(ViewModelCommand),
                typeof(CommandButton),
                new PropertyMetadata(null, null));

        public CommandButton()
        {
            InitializeComponent();
        }

        public ViewModelCommand ViewModelCommand
        {
            get => (ViewModelCommand)GetValue(ViewModelCommandProperty);
            set => SetValue(ViewModelCommandProperty, value);
        }
    }
}