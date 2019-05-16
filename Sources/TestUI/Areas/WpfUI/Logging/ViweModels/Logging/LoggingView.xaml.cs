using System.Windows.Controls;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Views.Interfaces;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Logging.ViweModels.Logging
{
    /// <summary>
    /// Interaction logic for LoggingView.xaml
    /// </summary>
    public partial class LoggingView : UserControl, IViewMap<LoggingViewModel>
    {
        public LoggingView()
        {
            InitializeComponent();
        }
    }
}