using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazhopee.Common.Helpers
{
    public class DataValidationHelper
    {
        public static (bool, string) ValidateObject(object instance)
        { 
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(instance);

            if (!Validator.TryValidateObject(instance, validationContext, validationResults))
            {
                var results = (false, string.Join("; ", validationResults.Select(item => item.ErrorMessage)));

                GC.Collect();

                return results;
            }

            GC.Collect();

            return (true, string.Empty);
        }
    }
}
