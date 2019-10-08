using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Rules.Core;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Rules
{
    public static class ValidationRuleFactory
    {
        public static StringNotNullOrEmptyRule StringNotNullOrEmpty()
        {
            return new StringNotNullOrEmptyRule();
        }
    }
}