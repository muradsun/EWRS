using System;
using System.Collections.Generic;

namespace ADMA.EWRS.Data.Models
{
    public partial class WeeklyInput
    {
        public WeeklyInput()
        {
            this.ReviewWorkflowInstances = new List<ReviewWorkflowInstance>();
            this.WeeklyInputHistories = new List<WeeklyInputHistory>();
        }

        public int WeeklyInput_Id { get; set; }
        public string InputText { get; set; }
        public int Subject_Id { get; set; }
        public int WeekNo { get; set; }
        public bool IsLocked { get; set; }
        public Nullable<int> LockedBy_UserId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public byte[] RowVersion { get; set; }
        public virtual ICollection<ReviewWorkflowInstance> ReviewWorkflowInstances { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<WeeklyInputHistory> WeeklyInputHistories { get; set; }
    }
}
