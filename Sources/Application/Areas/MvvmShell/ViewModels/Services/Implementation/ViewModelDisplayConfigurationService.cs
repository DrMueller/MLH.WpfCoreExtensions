using System;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Interfaces;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services.Implementation
{
    internal class ViewModelDisplayConfigurationService : IViewModelDisplayConfigurationService
    {
        private Action<IViewModel> _navigationCallback;

        public void Initialize(Action<IViewModel> navigationCallback)
        {
            _navigationCallback = navigationCallback;
        }

        public void OnDisplay(IViewModel viewModel)
        {
            _navigationCallback(viewModel);
        }
    }
}