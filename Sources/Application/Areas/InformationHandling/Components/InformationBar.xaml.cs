using System.Windows;
using System.Windows.Controls;
using Mmu.Mlh.WpfCoreExtensions.Areas.InformationHandling.ViewData;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.InformationHandling.Components
{
    /// <summary>
    /// Interaction logic for InformationBar.xaml
    /// </summary>
    internal partial class InformationBar : UserControl
    {
        public static readonly DependencyProperty InformationEntryProperty =
            DependencyProperty.Register(
            nameof(InformationEntry),
            typeof(InformationEntryViewData),
            typeof(InformationBar));

        public InformationEntryViewData InformationEntry
        {
            get => (InformationEntryViewData)GetValue(InformationEntryProperty);
            set => SetValue(InformationEntryProperty, value);
        }

        public InformationBar()
        {
            InitializeComponent();
        }
    }
}