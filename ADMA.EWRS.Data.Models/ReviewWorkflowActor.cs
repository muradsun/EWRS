using ADMA.EWRS.Data.Models.ViewModel;
using System;
using System.Collections.Generic;

namespace ADMA.EWRS.Data.Models
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

        public ReviewWorkflowActorView TransformToReviewWorkflowActor()
        {
            return new ReviewWorkflowActorView() {
                Group_Id = this.Group_Id,
                SequenceNo =  this.SequenceNo,
                User_Id = this.User_Id
            };
        }
    }
}
