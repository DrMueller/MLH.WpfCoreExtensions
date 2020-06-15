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
            set
            {
                if (_birthdate != value)
                {
                    _birthdate = value;
                    OnPropertyChanged();
                }
            }
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged();
                }
            }
        }

        protected override ValidationContainer<IndividualDetailsViewData> ConfigureValidation(IValidationConfigurationBuilder<IndividualDetailsViewData> builder)
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