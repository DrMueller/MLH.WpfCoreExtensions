using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Rules;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Configuration.Services
{
    public interface IPropertyRulesBuilder<T>
        where T : ValidatableViewModel<T>
    {
        IPropertyRulesBuilder<T> ApplyRule(IValidationRule rule);

        IValidationConfigurationBuilder<T> BuildForProperty();
    }
}