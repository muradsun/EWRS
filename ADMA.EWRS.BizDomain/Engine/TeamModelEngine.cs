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
    public class TeamModelEngine
    {
        public IEnumerable<ValidationError> Validate(List<TeamModel> teamModelCollection, UnitOfWork unitOfWork)
        {
            ICollection<ValidationError> dbError = unitOfWork.Templates.GetDbValidationErrors();
            //I have no business validations - proceed

            if (dbError == null)
                dbError = new List<ValidationError>();

            if (teamModelCollection != null && ! teamModelCollection.Any(t => t.IsUpdater == true))
                dbError.Add(new ValidationError("IsUpdater", " At least one updater should be selected in Team Model", teamModelCollection.GetType().ToString()));

            return dbError;
        }
    }
}
