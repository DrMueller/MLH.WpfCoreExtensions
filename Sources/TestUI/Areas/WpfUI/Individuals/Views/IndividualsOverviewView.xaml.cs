using System.Windows.Controls;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Views.Interfaces;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.ViewModels;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Views
{
    /// <summary>
    /// Interaction logic for IndividualsOverviewView.xaml
    /// </summary>
    public partial class IndividualsOverviewView : UserControl, IViewMap<IndividualsOverviewViewModel>
    {
        public IndividualsOverviewView()
        {
            InitializeComponent();
        }
    }
}