using System.Windows.Controls;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Views.Interfaces;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.ViewModelHierarchy.Views.ChildVm
{
    /// <summary>
    ///     Interaction logic for ChildVmView.xaml
    /// </summary>
    public partial class ChildVmView : UserControl, IViewMap<ChildVmViewModel>
    {
        public ChildVmView()
        {
            InitializeComponent();
        }
    }
}