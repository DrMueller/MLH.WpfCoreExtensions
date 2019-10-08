using System;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Configuration.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Rules;
using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Validation.Models;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Details.ViewData
{
    public class IndividualDetailsViewData : ValidatableViewModel<IndividualDetailsViewData>
    {
        public DateTime Birthdate { get; set; }
        public string FirstName { get; set; }
        public string Id { get; set; }
        public string LastName { get; set; }

        protected override ValidationContainer<IndividualDetailsViewData> ConfigureValidation(IValidationConfigurationBuilder<IndividualDetailsViewData> builder)
        {
            return builder.ForProperty(f => f.Birthdate)
                .ApplyRule(ValidationRuleFactory.StringNotNullOrEmpty())
                .BuildForProperty()
                .ForProperty(f => f.FirstName)
                .ApplyRule(ValidationRuleFactory.StringNotNullOrEmpty())
                .BuildForProperty()
                .Build();
        }
    }
}