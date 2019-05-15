using System.Windows.Controls;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Views.Interfaces;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.Home.ViewModels;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.Home.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl, IViewMap<HomeViewModel>
    {
        public HomeView()
        {
            InitializeComponent();
        }
    }
}