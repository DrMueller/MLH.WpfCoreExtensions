using System.Windows;
using System.Windows.Controls;
using Mmu.Mlh.WpfCoreExtensions.Areas.ViewExtensions.Components.CommandBars.ViewData;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.ViewExtensions.Components.CommandBars.Controls
{
    /// <summary>
    /// Interaction logic for CommandBar.xaml
    /// </summary>
    public partial class CommandBar : UserControl
    {
        public static readonly DependencyProperty CommandsProperty =
            DependencyProperty.Register(
                nameof(Commands),
                typeof(CommandsViewData),
                typeof(CommandBar),
                new PropertyMetadata(null, null));

        public CommandsViewData Commands
        {
            get => (CommandsViewData)GetValue(CommandsProperty);
            set => SetValue(CommandsProperty, value);
        }

        public CommandBar()
        {
            InitializeComponent();
        }
    }
}