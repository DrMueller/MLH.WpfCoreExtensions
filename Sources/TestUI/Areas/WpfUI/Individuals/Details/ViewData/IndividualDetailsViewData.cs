using System;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Configuration.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Rules;
using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Validation.Models;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Details.ValidationRules;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.Individuals.Details.ViewData
{
    public class IndividualDetailsViewData : ValidatableViewModel<IndividualDetailsViewData>
    {
        private DateTime _birthdate;
        private string _firstName;
        private string _id;
        private string _lastName;

        public DateTime Birthdate
        {
            get => _birthdate;
            set => OnPropertyChanged(value, ref _birthdate);
        }

        public string FirstName
        {
            get => _firstName;
            set => OnPropertyChanged(value, ref _firstName);
        }

        public string Id
        {
            get => _id;
            set => OnPropertyChanged(value, ref _id);
        }

        public string LastName
        {
            get => _lastName;
            set => OnPropertyChanged(value, ref _lastName);
        }

        protected override ValidationContainer<IndividualDetailsViewData> ConfigureValidation(
            IValidationConfigurationBuilder<IndividualDetailsViewData> builder)
        {
            return builder.ForProperty(f => f.Birthdate)
                .ApplyRule(ValidationRuleFactory.StringNotNullOrEmpty())
                .BuildForProperty()
                .ForProperty(f => f.FirstName)
                .ApplyRule(ValidationRuleFactory.StringNotNullOrEmpty())
                .ApplyRule(new FirstNameMustBeMatthiasRule())
                .BuildForProperty()
                .ForProperty(f => f.LastName)
                .ApplyRule(FirstNameEqualsLastName)
                .BuildForProperty()
                .Build();
        }

        private ValidationResult FirstNameEqualsLastName(object value)
        {
            if (FirstName != LastName)
            {
                return ValidationResult.CreateInvalid("Firstname must equal Lastname.");
            }

            return ValidationResult.CreateValid();
        }
    }
}