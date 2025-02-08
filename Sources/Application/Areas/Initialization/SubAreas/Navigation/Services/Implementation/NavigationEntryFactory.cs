using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.Navigation.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.SubAreas.Navigation.Services.Implementation
{
    [UsedImplicitly]
    internal class NavigationEntryFactory : INavigationEntryFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly IViewModelDisplayService _vmDisplayService;

        public NavigationEntryFactory(
            IViewModelDisplayService vmDisplayService,
            IViewModelFactory viewModelFactory,
            IServiceProvider serviceProvider)
        {
            _vmDisplayService = vmDisplayService;
            _viewModelFactory = viewModelFactory;
            _serviceProvider = serviceProvider;
        }

        public async Task<IReadOnlyCollection<NavigationEntry>> CreateAllAsync()
        {
            var navigatableViewModelTypes =
                _serviceProvider
                    .GetServices<IViewModel>()
                    .OfType<INavigatableViewModel>()
                    .Select(f => f.GetType())
                    .ToList();

            var tasks = navigatableViewModelTypes.Select(type => _viewModelFactory.CreateAsync(type));
            var navigationViewModels = await Task.WhenAll(tasks);

            var result = navigationViewModels
                .Cast<INavigatableViewModel>()
                .OrderBy(f => f.NavigationSequence)
                .Select(CreateNavigationEntry)
                .ToList();

            return result;
        }

        [SuppressMessage(
            "Usage",
            "VSTHRD110:Observe result of async calls",
            Justification = "Need to use ICommand interface")]
        private NavigationEntry CreateNavigationEntry(INavigatableViewModel viewModel)
        {
            var navigationCommand = new RelayCommand(
                () =>
                {
                    _vmDisplayService.DisplayAsync(viewModel.GetType());
                });

            return new NavigationEntry(navigationCommand, viewModel.NavigationDescription);
        }
    }
}