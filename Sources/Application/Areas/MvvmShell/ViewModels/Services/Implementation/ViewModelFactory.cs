using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services.Implementation
{
    [UsedImplicitly]
    internal class ViewModelFactory : IViewModelFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ViewModelFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
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

            var result = (IViewModel)_serviceProvider.GetService(viewModelType);

            if (result is IInitializableViewModel initializable)
            {
                await initializable.InitializeAsync(initParams);
            }

            return result;
        }
    }
}