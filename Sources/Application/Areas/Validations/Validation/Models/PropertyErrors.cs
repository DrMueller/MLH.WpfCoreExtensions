using System.Collections.Generic;
using System.Linq;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Validation.Models
{
    internal class PropertyErrors
    {
        private readonly IDictionary<string, bool> _propertyErrors;
        public bool HasErrors => _propertyErrors.Any(f => f.Value);

        public PropertyErrors()
        {
            _propertyErrors = new Dictionary<string, bool>();
        }

        internal void UpsertProperty(string propertyName, bool hasErrors)
        {
            _propertyErrors[propertyName] = hasErrors;
        }
    }
}