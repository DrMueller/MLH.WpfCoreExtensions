using System.Windows.Controls;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Views.Interfaces;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Dialogs.ViewModels
{
    /// <summary>
    /// Interaction logic for DialogsView.xaml
    /// </summary>
    public partial class DialogsView : UserControl, IViewMap<DialogsViewModel>
    {
        public DialogsView()
        {
            InitializeComponent();
        }
    }
}