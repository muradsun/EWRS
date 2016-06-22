using System;
using System.Collections.Generic;

namespace ADMA.EWRS.Data.Models
{
    public partial class ReviewWorkflow
    {
        public ReviewWorkflow()
        {
            this.ReviewWorkflowsProjects = new List<ReviewWorkflowsProject>();
        }

        public int ReviewWorkflow_Id { get; set; }
        public byte SequenceNo { get; set; }
        public string Name { get; set; }
        public Nullable<int> User_Id { get; set; }
        public Nullable<int> Group_Id { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public byte[] RowVersion { get; set; }
        public int Owner_UserId { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        public virtual Group Group { get; set; }
        public virtual ICollection<ReviewWorkflowsProject> ReviewWorkflowsProjects { get; set; }
    }
}
