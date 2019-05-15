using System;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Navigation.Services.Implementation
{
    internal class NavigationConfigurationService : INavigationConfigurationService
    {
        private Action<IViewModel> _navigationCallback;

        public void Initialize(Action<IViewModel> navigationCallback)
        {
            _navigationCallback = navigationCallback;
        }

        public void OnNavigation(IViewModel viewModel)
        {
            _navigationCallback(viewModel);
        }
    }
}