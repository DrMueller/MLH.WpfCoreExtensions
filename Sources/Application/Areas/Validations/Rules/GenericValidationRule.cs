using System;
using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Validation.Models;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Rules
{
    public class GenericValidationRule : IValidationRule
    {
        private readonly Func<object, ValidationResult> _validationCallback;

        public GenericValidationRule(Func<object, ValidationResult> validationCallback)
        {
            _validationCallback = validationCallback;
        }

        public ValidationResult Validate(object value)
        {
            return _validationCallback(value);
        }
    }
}