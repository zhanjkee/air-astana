using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirAstana.Shared.Validators
{
    public class DataAnnotationsValidator
    {
        public static bool TryValidate(object instance, out ICollection<ValidationResult> results)
        {
            var context = new ValidationContext(instance);
            results = new List<ValidationResult>();

            return Validator.TryValidateObject(instance, context, results, validateAllProperties: true);
        }
    }
}
