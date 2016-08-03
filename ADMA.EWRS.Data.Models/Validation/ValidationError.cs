using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.Data.Models.Validation
{
    public class ValidationError
    {
        //
        // Summary:
        //     Creates an instance of System.Data.Entity.Validation.DbValidationError.
        //
        // Parameters:
        //   propertyName:
        //     Name of the invalid property. Can be null.
        //
        //   errorMessage:
        //     Validation error message. Can be null.
        public ValidationError(string propertyName, string errorMessage, string entityName)
        {
            ErrorMessage = errorMessage;
            PropertyName = propertyName;
            EntityName = entityName;
        }

        //
        // Summary:
        //     Gets validation error message.
        public string EntityName { get; }

        //
        // Summary:
        //     Gets validation error message.
        public string ErrorMessage { get; }
        //
        // Summary:
        //     Gets name of the invalid property.
        public string PropertyName { get; }
    }

}
