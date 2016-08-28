using ADMA.EWRS.Data.Access;
using ADMA.EWRS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.BizDomain
{
    public class WorkflowManager : BaseManager
    {
        private UnitOfWork UnitOfWork { get { return base._unitOfWork; } }

        public WorkflowManager(IServiceProvider _provider)
            : base(_provider)
        {
            BusinessErrors = Enumerable.Empty<ADMA.EWRS.Data.Models.Validation.ValidationError>();
        }

        public WorkflowManager(IServiceProvider _provider, UnitOfWork unitOfWork)
            : base(_provider, unitOfWork)
        {
            BusinessErrors = Enumerable.Empty<ADMA.EWRS.Data.Models.Validation.ValidationError>();
        }

        public ICollection<ReviewWorkflowsProject> GetProjectWorkflowFlags(int? teamModelId, int projectId)
        {
            return UnitOfWork.ReviewWorkflows.GetReviewWorkflowFlagsForProject(teamModelId, projectId);
        }
        public ReviewWorkflow GetWorkflowWithActors(int reviewWorkflowId)
        {
            return UnitOfWork.ReviewWorkflows.GetWorkflowWithActors(reviewWorkflowId);
        }


    }
}
