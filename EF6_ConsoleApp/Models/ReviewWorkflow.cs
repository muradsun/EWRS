using System;
using System.Collections.Generic;

namespace EF6_ConsoleApp.Models
{
    public partial class ReviewWorkflow
    {
        public ReviewWorkflow()
        {
            this.ReviewWorkflowActors = new List<ReviewWorkflowActor>();
            this.ReviewWorkflowsProjects = new List<ReviewWorkflowsProject>();
        }

        public int ReviewWorkflow_Id { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public byte[] RowVersion { get; set; }
        public int Owner_UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ReviewWorkflowActor> ReviewWorkflowActors { get; set; }
        public virtual ICollection<ReviewWorkflowsProject> ReviewWorkflowsProjects { get; set; }
    }
}
