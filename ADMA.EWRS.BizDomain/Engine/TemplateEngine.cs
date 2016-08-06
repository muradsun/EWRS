using ADMA.EWRS.Data.Access;
using ADMA.EWRS.Data.Models;
using ADMA.EWRS.Data.Models.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.BizDomain.Engine
{
    public class TemplateEngine
    {
        public IEnumerable<ValidationError> Validate(Template template, UnitOfWork unitOfWork)
        {
            ICollection<ValidationError> dbError = unitOfWork.Templates.GetDbValidationErrors();
            //I have no business validations - proceed

            if (dbError == null)
                dbError = new List<ValidationError>();

            if (string.IsNullOrWhiteSpace(template.Name) || template.Name.Length < 3)
                dbError.Add(new ValidationError("Name", " Template Name is required, minimum 3 characters", template.GetType().ToString()));

            if (template.Subjects == null || template.Subjects.Count == 0)
                dbError.Add(new ValidationError("Name", " Template should have at least one subject", template.GetType().ToString()));


            if (template.Subjects != null || template.Subjects.Count > 0)
                if (template.Subjects.Any(s => string.IsNullOrWhiteSpace(s.Name) || s.Name.Length < 3))
                    dbError.Add(new ValidationError("Template.Subject", "Subject Name of Template is required, minimum 3 characters", template.GetType().ToString()));

            return dbError;
        }
    }
}
