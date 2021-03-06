using ADMA.EWRS.Data.Models.ViewModel;
using System;
using System.Collections.Generic;

namespace ADMA.EWRS.Data.Models
{
    public partial class Subject : BaseModel
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
        public int SubjectStatus_Id { get; set; } //Enums.SubjectStatusEnum
        public byte PercentComplete { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public bool IsMandatory { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public byte[] RowVersion { get; set; }
        public int Project_Id { get; set; }
        public SubjectStatus SubjectStatus { get; set; }
        public Template Template { get; set; }
        public ICollection<TeamModelSubject> TeamModelSubjects { get; set; }
        public ICollection<WeeklyInput> WeeklyInputs { get; set; }
        public ICollection<WeeklyInputHistory> WeeklyInputHistories { get; set; }
        public int SequenceNo { get; set; }

        public SubjectWizardStepView TransformToSubjectWizardStepView()
        {
            return new SubjectWizardStepView()
            {
                DueDate = this.DueDate,
                IsMandatory = this.IsMandatory,
                Name = this.Name,
                SequenceNo = this.SequenceNo,
                Subject_Id = this.Subject_Id,
                Template_Id = this.Template_Id
            };
        }


    }
}
