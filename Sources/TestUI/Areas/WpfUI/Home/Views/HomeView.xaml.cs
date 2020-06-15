using System.Windows;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Views.Interfaces;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Home.ViewModels;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Home.Views
{
    public partial class HomeView : IViewMap<HomeViewModel>
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private void UserControl_Drop(object sender, DragEventArgs e)
        {
            MessageBox.Show(e.Source.ToString());
        }
    }
}