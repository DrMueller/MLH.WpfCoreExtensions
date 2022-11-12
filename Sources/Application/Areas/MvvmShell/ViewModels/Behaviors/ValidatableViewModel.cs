using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Configuration.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Configuration.Services.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Validation.Models;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors
{
    [PublicAPI]
    public abstract class ValidatableViewModel<T> : ViewModelBase, INotifyDataErrorInfo, IInitializableViewModel
        where T : ValidatableViewModel<T>
    {
        private ValidationContainer<T> _container;
        public bool HasErrors => _container.HasErrors;

        public IEnumerable GetErrors(string propertyName)
        {
            return _container.GetErrorMessages(propertyName);
        }

        public Task InitializeAsync(params object[] initParams)
        {
            var configBuilder = new ValidationConfigurationBuilder<T>(this);
            _container = ConfigureValidation(configBuilder);

            return OnInitializeAsync(initParams);
        }

        // If HasErrors is true, WPF loops through all the properties and marks them on the UI
        // We don't want always to have this behavior, especially on initial states
        // We therefore bypass INotifyDataErrorInfo
        // Sidenote: no course or article in the internet has a solution
        // Usage of thus property can be found in the TimeBuddy
        public bool RevalidateAnyErrors()
        {
            return _container.RevalidateAnyErrors();
        }

        public void ValidateProperty(string propertyName)
        {
            _container.Validate(propertyName);
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

        protected override void OnPropertyChanged<TP>(
            TP newValue, ref TP oldValue,
            [CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(newValue, ref oldValue, propertyName);
            _container.Validate(propertyName);
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
    }
}