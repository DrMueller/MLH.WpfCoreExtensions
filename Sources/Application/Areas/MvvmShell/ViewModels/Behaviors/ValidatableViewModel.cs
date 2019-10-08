using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Configuration.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Configuration.Services.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Validation.Models;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors
{
    public abstract class ValidatableViewModel<T> : ViewModelBase, INotifyDataErrorInfo, IInitializableViewModel
        where T : ValidatableViewModel<T>
    {
        private ValidationContainer<T> _container;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public bool HasErrors => _container?.HasErrors ?? false;

        public IEnumerable GetErrors(string propertyName) => _container.GetErrorMessages(propertyName);

        public Task InitializeAsync(params object[] initParams)
        {
            var configBuilder = new ValidationConfigurationBuilder<T>(this);
            _container = ConfigureValidation(configBuilder);
            return OnInitializeAsync(initParams);
        }

        internal void OnErrorsChanged([CallerMemberName] string propertyName = null)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        protected abstract ValidationContainer<T> ConfigureValidation(IValidationConfigurationBuilder<T> builder);

        protected virtual Task OnInitializeAsync(params object[] initParams)
        {
            return Task.CompletedTask;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            _container.Validate(propertyName);
        }
    }
}