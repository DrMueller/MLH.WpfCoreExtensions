using System.Collections.Generic;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Rules;
using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Validation.Models;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Configuration.Services.Implementation
{
    internal class PropertyRulesBuilder<T> : IPropertyRulesBuilder<T>
        where T : ValidatableViewModel<T>
    {
        private readonly IValidationConfigurationBuilder<T> _parent;
        private readonly string _propertyName;
        private readonly List<IValidationRule> _rules;

        public PropertyRulesBuilder(string propertyName, IValidationConfigurationBuilder<T> parent)
        {
            _rules = new List<IValidationRule>();
            _propertyName = propertyName;
            _parent = parent;
        }

        public IPropertyRulesBuilder<T> ApplyRule(IValidationRule rule)
        {
            _rules.Add(rule);
            return this;
        }

        public IValidationConfigurationBuilder<T> BuildForProperty()
        {
            return _parent;
        }

        internal PropertyValidation BuildValidation()
        {
            return new PropertyValidation(_propertyName, _rules);
        }
    }
}