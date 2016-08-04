using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADMA.Workflow.Core.Model
{
    public abstract class BaseDefinition
    {
        public virtual string Name { get; set; }

        protected BaseDefinition(){}
    }
}
