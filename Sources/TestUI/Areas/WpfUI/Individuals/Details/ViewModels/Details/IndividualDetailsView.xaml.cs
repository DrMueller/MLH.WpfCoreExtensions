using System.Windows.Controls;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Views.Interfaces;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Details.ViewModels.Details
{
    /// <summary>
    /// Interaction logic for IndividualDetailsView.xaml
    /// </summary>
    public partial class IndividualDetailsView : UserControl, IViewMap<IndividualDetailsViewModel>
    {
        public IndividualDetailsView()
        {
            InitializeComponent();
        }
    }
}