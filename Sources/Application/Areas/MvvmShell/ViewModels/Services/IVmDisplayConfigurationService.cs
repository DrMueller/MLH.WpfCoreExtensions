using System;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Interfaces;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services
{
    internal interface IVmDisplayConfigurationService
    {
        void Initialize(Action<IViewModel> navigationCallback);

        void OnDisplay(IViewModel viewModel);
    }
}