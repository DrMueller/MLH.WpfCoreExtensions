using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfCoreExtensions.Infrastructure.DependencyInjection.Provisioning.Services;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services.Implementation
{
    [UsedImplicitly]
    internal class ViewModelFactory : IViewModelFactory
    {
        private readonly IServiceLocator _serviceLocator;

        public ViewModelFactory(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public async Task<T> CreateAsync<T>(params object[] initParams)
            where T : IViewModel
        {
            return (T)await CreateAsync(typeof(T), initParams);
        }

        public async Task<IViewModel> CreateAsync(Type viewModelType)
        {
            return await CreateAsync(viewModelType, null);
        }

        private async Task<IViewModel> CreateAsync(Type viewModelType, params object[] initParams)
        {
            var viewModelBaseType = typeof(IViewModel);

            if (!viewModelBaseType.IsAssignableFrom(viewModelType))
            {
                throw new ArgumentException($"{viewModelType!.Name} is not assignable from IViewModel.");
            }

            var result = (IViewModel)_serviceLocator.GetService(viewModelType);

            if (result is IInitializableViewModel initializable)
            {
                await initializable.InitializeAsync(initParams);
            }

            return result;
        }
    }
}