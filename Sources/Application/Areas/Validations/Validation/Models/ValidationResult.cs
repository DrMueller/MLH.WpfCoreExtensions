namespace Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Validation.Models
{
    public class ValidationResult
    {
        private ValidationResult(bool isValid, string errorMessage)
        {
            IsValid = isValid;
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }
        public bool IsValid { get; }

        public static ValidationResult CreateInvalid(string errorMessage)
        {
            return new ValidationResult(false, errorMessage);
        }

        public static ValidationResult CreateValid()
        {
            return new ValidationResult(true, string.Empty);
        }
    }
}