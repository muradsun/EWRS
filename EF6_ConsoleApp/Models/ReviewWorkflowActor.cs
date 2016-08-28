using System;
using System.Collections.Generic;

namespace EF6_ConsoleApp.Models
{
    public partial class ReviewWorkflowActor
    {
        public int ReviewWorkflowActor_Id { get; set; }
        public int ReviewWorkflow_Id { get; set; }
        public byte SequenceNo { get; set; }
        public Nullable<int> Group_Id { get; set; }
        public Nullable<int> User_Id { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public byte[] RowVersion { get; set; }
        public virtual ReviewWorkflow ReviewWorkflow { get; set; }
    }
}
