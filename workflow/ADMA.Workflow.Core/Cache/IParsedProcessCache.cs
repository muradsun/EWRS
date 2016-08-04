using System;
using ADMA.Workflow.Core.Model;

namespace ADMA.Workflow.Core.Cache
{
    public interface IParsedProcessCache
    {
        void Clear();

        ProcessDefinition GetProcessDefinitionBySchemeId(Guid schemeId);

        void AddProcessDefinition(Guid schemeId, ProcessDefinition processDefinition);
    }
}
