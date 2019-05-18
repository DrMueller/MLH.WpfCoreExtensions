using System.Windows.Controls;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Views.Interfaces;

namespace Mmu.Mlh.WpfCoreExtensions.NugetTestUI.Areas.Individuals.ViewModels.Overview
{
    /// <summary>
    /// Interaction logic for IndividualsView.xaml
    /// </summary>
    public partial class IndividualsOverviewView : UserControl, IViewMap<IndividualsOverviewViewModel>
    {
        public IndividualsOverviewView()
        {
            InitializeComponent();
        }
    }
}