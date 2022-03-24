using System.Threading.Tasks;
using JetBrains.Annotations;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.ViewModelHierarchy.Views.ChildVm;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.ViewModelHierarchy.Views.ParentVm
{
    [PublicAPI]
    public class ParentVmViewModel : ViewModelBase, IParentVmViewModel
    {
        private readonly IViewModelFactory _vmFactory;

        private ChildVmViewModel _childVm;

        private string _parentText;

        public ParentVmViewModel(
            CommandContainer commandContainer,
            IViewModelFactory vmFactory)
        {
            CommandContainer = commandContainer;
            _vmFactory = vmFactory;
        }

        public ChildVmViewModel ChildVm
        {
            get => _childVm;
            set => OnPropertyChanged(value, ref _childVm);
        }

        public CommandContainer CommandContainer { get; }
        public string HeadingDescription => "Parent Child Stuff";
        public string NavigationDescription => "Parent Child";
        public int NavigationSequence => 7;

        public string ParentText
        {
            get => _parentText;
            set => OnPropertyChanged(value, ref _parentText);
        }

        public async Task InitializeAsync(params object[] initParams)
        {
            ChildVm = await _vmFactory.CreateAsync<ChildVmViewModel>();
            ChildVm.RegisterPropertyChange(nameof(ChildVmViewModel.ChildText), () => ParentText = ChildVm.ChildText);
            await CommandContainer.InitializeAsync(this);
        }
    }
}