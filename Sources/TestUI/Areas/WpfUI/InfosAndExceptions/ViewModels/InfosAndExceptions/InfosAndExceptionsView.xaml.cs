using System.Windows.Controls;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Views.Interfaces;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.InfosAndExceptions.ViewModels.InfosAndExceptions
{
    /// <summary>
    /// Interaction logic for InfosAndExceptionsView.xaml
    /// </summary>
    public partial class InfosAndExceptionsView : UserControl, IViewMap<InfosAndExceptionsViewModel>
    {
        public InfosAndExceptionsView()
        {
            InitializeComponent();
        }
    }
}