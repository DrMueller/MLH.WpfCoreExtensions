using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.Mlh.WpfCoreExtensions.UnitTests.TestingInfrastructure.ViewModelMocks
{
    public class InitializibleMockViewModel : ViewModelBase, IInitializableViewModel
    {
        public object[] InitParams { get; private set; }
        public bool WasInitialized { get; private set; }

        public Task InitializeAsync(params object[] initParams)
        {
            WasInitialized = true;
            InitParams = initParams;
            return Task.CompletedTask;
        }
    }
}