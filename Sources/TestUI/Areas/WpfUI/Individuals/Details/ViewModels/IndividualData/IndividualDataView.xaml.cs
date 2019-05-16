using System.Windows.Controls;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Views.Interfaces;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Details.ViewModels.IndividualData
{
    /// <summary>
    /// Interaction logic for IndividualDataView.xaml
    /// </summary>
    public partial class IndividualDataView : UserControl, IViewMap<IndividualDataViewModel>
    {
        public IndividualDataView()
        {
            InitializeComponent();
        }
    }
}