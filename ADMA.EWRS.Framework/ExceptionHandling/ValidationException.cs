using ADMA.EWRS.Data.Models.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.Framework.ExceptionHandling
{
    public class ValidationException : ApplicationException
    {
        public List<ValidationError> ValidationErrors { get; set; }

        public ValidationException(string message, List<ValidationError> validationErrors) : base(message)
        {
            ValidationErrors = validationErrors;
        }

    }
}
