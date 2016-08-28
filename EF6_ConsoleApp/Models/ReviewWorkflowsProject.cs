using System;
using System.Collections.Generic;

namespace EF6_ConsoleApp.Models
{
    public partial class ReviewWorkflowsProject
    {
        public ReviewWorkflowsProject()
        {
            this.ReviewWorkflowInstances = new List<ReviewWorkflowInstance>();
        }

        public int ReviewWorkflowsProjects_Id { get; set; }
        public bool IsProjectDefaultWorkflow { get; set; }
        public Nullable<int> TeamModel_Id { get; set; }
        public int Project_Id { get; set; }
        public int ReviewWorkflow_Id { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public byte[] RowVersion { get; set; }
        public virtual Project Project { get; set; }
        public virtual ICollection<ReviewWorkflowInstance> ReviewWorkflowInstances { get; set; }
        public virtual ReviewWorkflow ReviewWorkflow { get; set; }
    }
}
