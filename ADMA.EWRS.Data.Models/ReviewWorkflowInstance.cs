using System;
using System.Collections.Generic;

namespace ADMA.EWRS.Data.Models
{
    public partial class ReviewWorkflowInstance
    {
        public int ReviewWorkflowInstance_Id { get; set; }
        public byte SequenceNo { get; set; }
        public Nullable<int> WeeklyInput_Id { get; set; }
        public int ReviewWorkflowsProjects_Id { get; set; }
        public string Comment { get; set; }
        public string Action { get; set; }
        public Nullable<System.DateTime> ReadDate { get; set; }
        public Nullable<System.DateTime> ActionDate { get; set; }
        public Nullable<int> User_Id { get; set; }
        public Nullable<int> Group_Id { get; set; }
        public Nullable<int> ActionBy_UserId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public byte[] RowVersion { get; set; }
        public virtual ReviewWorkflowsProject ReviewWorkflowsProject { get; set; }
        public virtual WeeklyInput WeeklyInput { get; set; }
    }
}
