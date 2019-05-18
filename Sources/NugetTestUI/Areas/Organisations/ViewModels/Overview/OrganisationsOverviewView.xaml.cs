using System.Windows.Controls;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Views.Interfaces;

namespace Mmu.Mlh.WpfCoreExtensions.NugetTestUI.Areas.Organisations.ViewModels.Overview
{
    /// <summary>
    /// Interaction logic for OrganisationsOverviewView.xaml
    /// </summary>
    public partial class OrganisationsOverviewView : UserControl, IViewMap<OrganisationsOverviewViewModel>
    {
        public OrganisationsOverviewView()
        {
            InitializeComponent();
        }
    }
}