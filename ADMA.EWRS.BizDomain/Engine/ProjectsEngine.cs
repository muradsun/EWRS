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
    public class ProjectsEngine
    {
        public IEnumerable<ValidationError> Validate(Project project, UnitOfWork unitOfWork)
        {
            ICollection<ValidationError> dbError = unitOfWork.Projects.GetDbValidationErrors();
            //I have no business validations - proceed

            if (dbError == null)
                dbError = new List<ValidationError>();

            if (string.IsNullOrWhiteSpace(project.Name))
                dbError.Add(new ValidationError("Name", " Project Name is required, minimum 3 characters", project.GetType().ToString()));

            return dbError;
        }
    }
}
