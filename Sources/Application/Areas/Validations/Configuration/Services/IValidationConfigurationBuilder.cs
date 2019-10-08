using System;
using System.Linq.Expressions;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Validation.Models;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Configuration.Services
{
    public interface IValidationConfigurationBuilder<T>
        where T : ValidatableViewModel<T>
    {
        ValidationContainer<T> Build();

        IPropertyRulesBuilder<T> ForProperty<TField>(Expression<Func<T, TField>> expression);
    }
}