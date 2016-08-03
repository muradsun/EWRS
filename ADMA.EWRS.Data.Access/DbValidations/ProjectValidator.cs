using ADMA.EWRS.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.Data.Access.DbValidations
{
    public class ProjectValidator
    {
        public DbEntityValidationResult Validate(DbEntityEntry entityEntry)
        {
            Project project = ((Project)entityEntry.Entity);

            //New Project
            if (project.ProjectStatus_Id != 0)
            {
                //Check Percent
                if (project.PercentComplete < 0 || project.PercentComplete > 100)
                    return new DbEntityValidationResult(entityEntry, new List<DbValidationError>
                        {
                             new DbValidationError( "PercentComplete",
                                 string.Format( "[Percent Complete] should be between 0 and 100; Your Entry [{0}] is invalid", project.PercentComplete))
                        });
            }

            return null;
        }
    }
}

