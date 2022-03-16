using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Validation.Models
{
    internal class PropertyErrors
    {
        private IDictionary<string, bool> _propertyErrors;

        public PropertyErrors()
        {
            _propertyErrors = new Dictionary<string, bool>();
        }

        public bool HasErrors
        {
            get => _propertyErrors.Any(f => f.Value);
        }

        internal void UpsertProperty(string propertyName, bool hasErrors)
        {
            if (!_propertyErrors.ContainsKey(propertyName))
            {
                _propertyErrors.Add(propertyName, hasErrors);
            }
            else
            {
                _propertyErrors[propertyName] = hasErrors;
            }
        }

    }
}
