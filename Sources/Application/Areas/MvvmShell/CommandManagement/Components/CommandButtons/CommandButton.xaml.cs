using System.Windows;
using System.Windows.Controls;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandButtons
{
    /// <summary>
    /// Interaction logic for CommandButton.xaml
    /// </summary>
    public partial class CommandButton : UserControl
    {
        public static readonly DependencyProperty ViewModelCommandProperty =
            DependencyProperty.Register(
                nameof(ViewModelCommand),
                typeof(ViewModelCommand),
                typeof(CommandButton),
                new PropertyMetadata(null, null));

        public ViewModelCommand ViewModelCommand
        {
            get => (ViewModelCommand)GetValue(ViewModelCommandProperty);
            set => SetValue(ViewModelCommandProperty, value);
        }

        public CommandButton()
        {
            InitializeComponent();
        }
    }
}