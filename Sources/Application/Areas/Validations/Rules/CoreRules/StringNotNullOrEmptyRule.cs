using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Validation.Models;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Rules.CoreRules
{
    public class StringNotNullOrEmptyRule : IValidationRule
    {
        public ValidationResult Validate(object value)
        {
            var str = value?.ToString();
            return string.IsNullOrEmpty(str) ?
                ValidationResult.CreateInvalid("String must not be null or empty.") :
                ValidationResult.CreateValid();
        }
    }
}