using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile
{
    public static class ObjectValidator
    {
        public static bool TryValidateFullObject ( object value, out IEnumerable<ValidationResult> results )
        {
            results = new List<ValidationResult>();

            var context = new ValidationContext(value);

            return Validator.TryValidateObject(value, context, (ICollection<ValidationResult>)results, true);
        }

        public static void ValidateFullObject ( object value )
        {
            var context = new ValidationContext(value);

            Validator.ValidateObject(value, context, true);
        }
    }
}
