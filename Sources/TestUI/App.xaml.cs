using System.Windows;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Infrastructure.Initialization;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            InitializationService.Initialize();
        }
    }
}