using System;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Navigation.Services
{
    internal interface INavigationConfigurationService
    {
        void Initialize(Action<IViewModel> navigationCallback);

        void OnNavigation(IViewModel viewModel);
    }
}