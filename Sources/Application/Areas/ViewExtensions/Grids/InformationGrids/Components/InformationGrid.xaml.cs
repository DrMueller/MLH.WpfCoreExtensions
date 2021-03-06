﻿using System.Collections.ObjectModel;
using System.Windows;
using Mmu.Mlh.WpfCoreExtensions.Areas.ViewExtensions.Grids.InformationGrids.ViewData;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.ViewExtensions.Grids.InformationGrids.Components
{
    public partial class InformationGrid
    {
        public static readonly DependencyProperty InformationEntriesProperty = DependencyProperty.Register(nameof(InformationEntries), typeof(ObservableCollection<InformationGridEntryViewData>), typeof(InformationGrid));

        public InformationGrid()
        {
            InitializeComponent();
        }

        public ObservableCollection<InformationGridEntryViewData> InformationEntries
        {
            get => (ObservableCollection<InformationGridEntryViewData>)GetValue(InformationEntriesProperty);
            set => SetValue(InformationEntriesProperty, value);
        }
    }
}