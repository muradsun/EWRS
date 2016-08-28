//Murad :: Info : Must ADD referance to Entity and Linq to see the extension methods
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ADMA.EWRS.Data.Models.Repositories;
using ADMA.EWRS.Data.Models;

namespace ADMA.EWRS.Data.Access.Repositories
{
    public class ReviewWorkflowsRepository : Repository<ReviewWorkflow, EWRSContext>, IReviewWorkflowsRepository
    {
        public ReviewWorkflowsRepository(EWRSContext context)
          : base(context)
        {

        }

        public ICollection<ReviewWorkflowsProject> GetReviewWorkflowFlagsForProject(int? teamModelId, int projectId)
        {
            return DbContext.ReviewWorkflowsProjects.Where(w => w.Project_Id == projectId && 
                                                          ( w.TeamModel_Id == teamModelId || teamModelId.HasValue == false )).ToList();
        }

        public ReviewWorkflow GetWorkflowWithActors(int reviewWorkflowId)
        {
            return DbContext.ReviewWorkflows.Include(a => a.ReviewWorkflowActors).Where( r => r.ReviewWorkflow_Id == reviewWorkflowId).FirstOrDefault();
        }
    }
}