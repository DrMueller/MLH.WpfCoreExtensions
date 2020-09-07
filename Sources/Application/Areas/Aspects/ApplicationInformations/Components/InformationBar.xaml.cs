using System.Windows;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.ViewData;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Components
{
    internal partial class InformationBar
    {
        public static readonly DependencyProperty InformationEntryProperty =
            DependencyProperty.Register(
                nameof(InformationEntry),
                typeof(InformationEntryViewData),
                typeof(InformationBar));

        public InformationBar()
        {
            InitializeComponent();
        }

        public InformationEntryViewData InformationEntry
        {
            get => (InformationEntryViewData)GetValue(InformationEntryProperty);
            set => SetValue(InformationEntryProperty, value);
        }
    }
}