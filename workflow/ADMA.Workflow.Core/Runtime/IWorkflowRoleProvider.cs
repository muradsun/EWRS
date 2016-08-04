using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADMA.Workflow.Core.Runtime
{
    public interface IWorkflowRoleProvider
    {
        bool IsInRole(Guid identityId, string roleId);
        IEnumerable<Guid> GetAllInRole(string roleId);
    }
}
