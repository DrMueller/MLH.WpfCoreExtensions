using System.Collections.Generic;
using System.Linq;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Validation.Models
{
    public class ValidationContainer<T>
        where T : ValidatableViewModel<T>
    {
        private readonly IReadOnlyCollection<PropertyValidation> _propertyValidations;
        private readonly ValidatableViewModel<T> _viewModel;

        private readonly PropertyErrors _propertyErrors;

        internal ValidationContainer(
            ValidatableViewModel<T> viewModel,
            IReadOnlyCollection<PropertyValidation> propertyValidations)
        {
            _viewModel = viewModel;
            _propertyValidations = propertyValidations;
            _propertyErrors = new PropertyErrors();
        }

        internal bool HasErrors => _propertyErrors.HasErrors;

        internal bool RevalidateAnyErrors()
        {
            var allErorrMessages = _propertyValidations.SelectMany(val => ReadErrorMessages(val.PropertyName, val));
            return allErorrMessages.Any();
        }

        private IReadOnlyCollection<string> ReadErrorMessages(string propertyName, PropertyValidation propertyValidation)
        {
            var propertyValue = _viewModel.GetType().GetProperty(propertyName)?.GetValue(_viewModel);
            return propertyValidation.GetValidationErrorMessages(propertyValue);
        }

        internal IReadOnlyCollection<string> GetErrorMessages(string propertyName)
        {
            var propertyValidation = _propertyValidations.SingleOrDefault(f => f.PropertyName == propertyName);

            if (propertyValidation == null)
            {
                return new List<string>();
            }

            var errorMessages = ReadErrorMessages(propertyName, propertyValidation);
            _propertyErrors.UpsertProperty(propertyName, errorMessages.Any());

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