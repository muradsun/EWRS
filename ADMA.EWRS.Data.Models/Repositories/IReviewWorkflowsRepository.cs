using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.Data.Models.Repositories
{
    //This is special repository mapped to many classes, bu the main class of dealing is ReviewWorkflow.
    public interface IReviewWorkflowsRepository : IRepository<ReviewWorkflow>
    {
        ICollection<ReviewWorkflowsProject> GetReviewWorkflowFlagsForProject(int? teamModelId, int projectId);
        ReviewWorkflow GetWorkflowWithActors(int reviewWorkflowId);

    }
}
