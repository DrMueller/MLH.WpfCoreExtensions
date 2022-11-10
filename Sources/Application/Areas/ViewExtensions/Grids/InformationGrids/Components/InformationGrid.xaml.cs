using System.Collections.ObjectModel;
using System.Windows;
using JetBrains.Annotations;
using Mmu.Mlh.WpfCoreExtensions.Areas.ViewExtensions.Grids.InformationGrids.ViewData;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.ViewExtensions.Grids.InformationGrids.Components
{
    [UsedImplicitly]
    public partial class InformationGrid
    {
        public static readonly DependencyProperty InformationEntriesProperty =
            DependencyProperty.Register(
                nameof(InformationEntries),
                typeof(ObservableCollection<InformationGridEntryViewData>),
                typeof(InformationGrid));

        public InformationGrid()
        {
            InitializeComponent();
        }

        public ObservableCollection<InformationGridEntryViewData> InformationEntries
        {
            get => (ObservableCollection<InformationGridEntryViewData>)GetValue(InformationEntriesProperty);
            set => SetValue(InformationEntriesProperty, value);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            InformationEntries.Clear();
        }
    }
}