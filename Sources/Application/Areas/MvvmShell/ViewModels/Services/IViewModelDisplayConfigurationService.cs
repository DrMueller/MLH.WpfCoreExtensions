using System;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services
{
    internal interface IViewModelDisplayConfigurationService
    {
        void Initialize(Action<IDisplayableViewModel> navigationCallback);

        void OnDisplay(IDisplayableViewModel viewModel);
    }
}