using System;
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
        private readonly List<IValidationRule> _rules;
        public string PropertyName { get; }

        public PropertyRulesBuilder(string propertyName, IValidationConfigurationBuilder<T> parent)
        {
            _rules = new List<IValidationRule>();
            PropertyName = propertyName;
            _parent = parent;
        }

        public IPropertyRulesBuilder<T> ApplyRule(IValidationRule rule)
        {
            _rules.Add(rule);

            return this;
        }

        public IPropertyRulesBuilder<T> ApplyRule(Func<object, ValidationResult> ruleExpression)
        {
            var genericRule = new GenericValidationRule(ruleExpression);
            _rules.Add(genericRule);

            return this;
        }

        public IValidationConfigurationBuilder<T> BuildForProperty()
        {
            return _parent;
        }

        internal PropertyValidation BuildValidation()
        {
            return new PropertyValidation(PropertyName, _rules);
        }
    }
}