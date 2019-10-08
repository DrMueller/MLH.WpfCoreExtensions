using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Validation.Models;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Rules
{
    public interface IValidationRule
    {
        ValidationResult Validate(object value);
    }
}