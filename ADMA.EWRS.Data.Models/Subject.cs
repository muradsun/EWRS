using System;
using System.Collections.Generic;

namespace ADMA.EWRS.Data.Models
{
    public partial class Subject
    {
        public Subject()
        {
            this.TeamModelSubjects = new List<TeamModelSubject>();
            this.WeeklyInputs = new List<WeeklyInput>();
            this.WeeklyInputHistories = new List<WeeklyInputHistory>();
        }

        public int Subject_Id { get; set; }
        public string Name { get; set; }
        public int Template_Id { get; set; }
        public byte SubjectStatus_Id { get; set; }
        public byte PercentComplete { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public bool IsMandatory { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public byte[] RowVersion { get; set; }
        public int Project_Id { get; set; }
        public virtual SubjectStatus SubjectStatus { get; set; }
        public virtual Template Template { get; set; }
        public virtual ICollection<TeamModelSubject> TeamModelSubjects { get; set; }
        public virtual ICollection<WeeklyInput> WeeklyInputs { get; set; }
        public virtual ICollection<WeeklyInputHistory> WeeklyInputHistories { get; set; }
    }
}
