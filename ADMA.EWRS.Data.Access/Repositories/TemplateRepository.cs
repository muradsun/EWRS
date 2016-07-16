//Murad :: Info : Must ADD referance to Entity and Linq to see the extension methods
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ADMA.EWRS.Data.Models.Repositories;
using ADMA.EWRS.Data.Models;


namespace ADMA.EWRS.Data.Access.Repositories
{
    public class TemplateRepository : Repository<Template, EWRSContext>, ITemplatesRepository
    {
        public TemplateRepository(EWRSContext context)
            : base(context)
        {

        }

        public Template GetTemplate(int projectId)
        {
            return DbContext.Templates.Include("Subjects").Where(t => t.Project_Id == projectId).FirstOrDefault();
        }
    }
}
