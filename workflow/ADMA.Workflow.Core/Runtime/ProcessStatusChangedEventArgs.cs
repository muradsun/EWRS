using System;
using System.Collections.Generic;
using ADMA.Workflow.Core.Model;
using ADMA.Workflow.Core.Persistence;

namespace ADMA.Workflow.Core.Runtime
{
    public class ProcessStatusChangedEventArgs : EventArgs
    {
        public Guid ProcessId { get; private set; }
        public ProcessStatus OldStatus { get; private set; }
        public ProcessStatus NewStatus { get; private set; }
        public List<ParameterDefinitionWithValue> ProcessParameters { get; internal set; }
        public string ProcessName { get; internal set; }

        public ProcessStatusChangedEventArgs (Guid processId, ProcessStatus oldStatus, ProcessStatus newStatus)
        {
            ProcessId = processId;
            OldStatus = oldStatus;
            NewStatus = newStatus;
        }
    }
}
