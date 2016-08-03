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

            return dbError;
        }
    }
}
