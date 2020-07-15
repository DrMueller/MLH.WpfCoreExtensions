using System.Threading.Tasks;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Container
{
    internal interface IViewModelContainer
    {
        Task InitializeAsync();
    }
}