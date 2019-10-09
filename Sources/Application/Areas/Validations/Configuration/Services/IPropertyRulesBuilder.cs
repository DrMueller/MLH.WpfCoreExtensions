using System;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Rules;
using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Validation.Models;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Configuration.Services
{
    public interface IPropertyRulesBuilder<T>
        where T : ValidatableViewModel<T>
    {
        IPropertyRulesBuilder<T> ApplyRule(IValidationRule rule);

        IPropertyRulesBuilder<T> ApplyRule(Func<object, ValidationResult> ruleExpression);

        IValidationConfigurationBuilder<T> BuildForProperty();
    }
}