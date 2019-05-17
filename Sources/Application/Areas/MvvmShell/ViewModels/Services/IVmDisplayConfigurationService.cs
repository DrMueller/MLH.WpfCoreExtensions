using System;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services
{
    internal interface IVmDisplayConfigurationService
    {
        void Initialize(Action<IViewModel> navigationCallback);

        void OnDisplay(IViewModel viewModel);
    }
}