using System.Collections.Generic;
using System.Linq;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Validation.Models
{
    public class ValidationContainer<T>
        where T : ValidatableViewModel<T>
    {
        private readonly IReadOnlyCollection<PropertyValidation> _propertyValidations;
        private readonly ValidatableViewModel<T> _viewModel;
        internal bool HasErrors { get; private set; }

        internal ValidationContainer(
            ValidatableViewModel<T> viewModel,
            IReadOnlyCollection<PropertyValidation> propertyValidations)
        {
            _viewModel = viewModel;
            _propertyValidations = propertyValidations;
        }

        internal IReadOnlyCollection<string> GetErrorMessages(string propertyName)
        {
            var propertyValidations = _propertyValidations.Where(f => f.PropertyName == propertyName);
            Guard.That(() => propertyValidations.Count() == 1, $"Property {propertyName} must be configured exactly once.");

            var propertyValue = _viewModel.GetType().GetProperty(propertyName)?.GetValue(_viewModel);
            var errorMessages = propertyValidations.Single().GetValidationErrorMessages(propertyValue);

            HasErrors = errorMessages.Any();
            return errorMessages;
        }

        internal void Validate(string propertyName)
        {
            if (GetErrorMessages(propertyName).Any())
            {
                _viewModel.OnErrorsChanged(propertyName);
            }
        }
    }
}