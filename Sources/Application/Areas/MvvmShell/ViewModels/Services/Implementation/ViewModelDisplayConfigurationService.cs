using System;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services.Implementation
{
    internal class ViewModelDisplayConfigurationService : IViewModelDisplayConfigurationService
    {
        private Action<IDisplayableViewModel> _navigationCallback;

        public void Initialize(Action<IDisplayableViewModel> navigationCallback)
        {
            _navigationCallback = navigationCallback;
        }

        public void OnDisplay(IDisplayableViewModel viewModel)
        {
            _navigationCallback(viewModel);
        }
    }
}