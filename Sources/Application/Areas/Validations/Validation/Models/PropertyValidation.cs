using System.Collections.Generic;
using System.Linq;
using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Rules;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Validation.Models
{
    internal class PropertyValidation
    {
        private readonly IReadOnlyCollection<IValidationRule> _rules;
        public string PropertyName { get; }

        public PropertyValidation(string propertyName, IReadOnlyCollection<IValidationRule> rules)
        {
            PropertyName = propertyName;
            _rules = rules;
        }

        internal IReadOnlyCollection<string> GetValidationErrorMessages(object value)
        {
            return _rules
                .Select(f => f.Validate(value))
                .Where(f => !f.IsValid)
                .Select(f => f.ErrorMessage)
                .ToList();
        }
    }
}