using ADMA.EWRS.Data.Models.ViewModel;
using System;
using System.Collections.Generic;

namespace ADMA.EWRS.Data.Models
{
    public partial class TeamModelSubject : BaseModel
    {
        public int TeamModelSubjects_Id { get; set; }
        public int TeamModel_Id { get; set; }
        public int Subject_Id { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public byte[] RowVersion { get; set; }
        public  Subject Subject { get; set; }
        public  TeamModel TeamModel { get; set; }

        internal TeamModelSubjectView TransformToTeamModelSubjectView()
        {
            return new TeamModelSubjectView() {
                Subject_Id = this.Subject_Id,
                TeamModelSubjects_Id = this.TeamModelSubjects_Id,
                TeamModel_Id = this.TeamModel_Id 
            };
        }
    }
}
