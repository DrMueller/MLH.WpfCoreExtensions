using System.Threading.Tasks;
using JetBrains.Annotations;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.ViewModelHierarchy.Views.ChildVm
{
    [PublicAPI]
    public class ChildVmViewModel : ViewModelBase, IChildVmViewModel
    {
        private string _childText;

        public ChildVmViewModel(CommandContainer commandContainer)
        {
            CommandContainer = commandContainer;
        }

        public string ChildText
        {
            get => _childText;
            set => OnPropertyChanged(value, ref _childText);
        }

        public CommandContainer CommandContainer { get; }

        public async Task InitializeAsync(params object[] initParams)
        {
            await CommandContainer.InitializeAsync(this);
        }
    }
}