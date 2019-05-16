using System.Windows.Controls;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Views.Interfaces;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Overview.ViewModels.Overview
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