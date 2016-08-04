using System.Collections.Generic;
using System.Xml.Linq;
using ADMA.Workflow.Core.Model;

namespace ADMA.Workflow.Core.Parser
{
    public interface IWorkflowParser<in TSchemeMedium> where TSchemeMedium : class
    {
        ProcessDefinition Parse(TSchemeMedium schemeMedium);

    }


}
