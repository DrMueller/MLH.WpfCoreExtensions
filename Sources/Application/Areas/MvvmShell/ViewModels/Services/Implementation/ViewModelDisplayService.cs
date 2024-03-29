﻿using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services.Implementation
{
    [UsedImplicitly]
    internal class ViewModelDisplayService : IViewModelDisplayService
    {
        private readonly IViewModelDisplayConfigurationService _displayConfigService;
        private readonly IViewModelFactory _viewModelFactory;

        public ViewModelDisplayService(
            IViewModelDisplayConfigurationService displayConfigService,
            IViewModelFactory containerViewModelBaseFactory)
        {
            _displayConfigService = displayConfigService;
            _viewModelFactory = containerViewModelBaseFactory;
        }

        public async Task DisplayAsync<T>(params object[] initParams)
            where T : IDisplayableViewModel
        {
            var target = await _viewModelFactory.CreateAsync<T>(initParams);
            _displayConfigService.OnDisplay(target);
        }

        public async Task DisplayAsync(Type targetType)
        {
            if (!typeof(IDisplayableViewModel).IsAssignableFrom(targetType))
            {
                throw new ArgumentException($"{targetType!.Name} is not assignable from IDisplayableViewModel.");
            }

            var target = (IDisplayableViewModel)await _viewModelFactory.CreateAsync(targetType);
            _displayConfigService.OnDisplay(target);
        }
    }
}