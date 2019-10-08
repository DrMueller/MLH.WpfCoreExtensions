using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Rules;
using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Validation.Models;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Details.ValidationRules
{
    public class FirstNameMustBeMatthiasRule : IValidationRule
    {
        public ValidationResult Validate(object value)
        {
            var val = value?.ToString() ?? string.Empty;
            if (val != "Matthias")
            {
                return ValidationResult.CreateInvalid("First name must be Matthias.");
            }

            return ValidationResult.CreateValid();
        }
    }
}