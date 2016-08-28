using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.Data.Models.ViewModel
{
    public class ReviewWorkflowsProjectView
    {
        public int ReviewWorkflowsProjects_Id { get; set; }
        public bool IsProjectDefaultWorkflow { get; set; }
        public Nullable<int> TeamModel_Id { get; set; }
        public int ReviewWorkflow_Id { get; set; }
    }
}
