using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.ServiceProvisioning.Areas.Provisioning.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services.Implementation
{
    internal class ViewModelFactory : IViewModelFactory
    {
        private readonly IServiceLocator _serviceLocator;

        public ViewModelFactory(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public async Task<IReadOnlyCollection<TBehavior>> CreateAllWithBehaviorAsync<TBehavior>()
            where TBehavior : IViewModelWithBehaviorBase
        {
            var behaviorType = typeof(TBehavior);
            var viewModelsWithBehaviorType =
                _serviceLocator
                    .GetAllServices<IViewModel>()
                    .Where(f => behaviorType.IsInstanceOfType(f))
                    .Select(f => f.GetType())
                    .ToList();

            var createTasks = viewModelsWithBehaviorType.Select(CreateAsync);
            var createdVieModels = await Task.WhenAll(createTasks);
            var result = createdVieModels.Cast<TBehavior>().ToList();
            return result;
        }

        public async Task<T> CreateAsync<T>()
            where T : IViewModel
        {
            return (T)await CreateAsync(typeof(T));
        }

        private async Task<IViewModel> CreateAsync(Type viewModelType)
        {
            var viewModelBaseType = typeof(IViewModel);
            if (!viewModelBaseType.IsAssignableFrom(viewModelType))
            {
                throw new ArgumentException($"{viewModelType.Name} is not assignable from IViewModel.");
            }

            var result = (IViewModel)_serviceLocator.GetService(viewModelType);
            if (result is IInitializableViewModel initializable)
            {
                await initializable.InitializeAsync();
            }

            return result;
        }
    }
}