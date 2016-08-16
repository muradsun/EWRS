using ADMA.EWRS.Data.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADMA.EWRS.Data.Models
{
    public partial class TeamModel : BaseModel
    {
        public TeamModel()
        {
            this.TeamModelSubjects = new List<TeamModelSubject>();
        }

        public int TeamModel_Id { get; set; }
        public Nullable<int> User_Id { get; set; }
        public Nullable<int> Group_Id { get; set; }
        public int Project_Id { get; set; }
        public bool IsUpdater { get; set; }

        /// <summary>
        /// Is project level updater or viewer
        /// </summary>
        public bool IsProjectLevel { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public byte[] RowVersion { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public Group Group { get; set; }
        public Project Project { get; set; }
        public ICollection<TeamModelSubject> TeamModelSubjects { get; set; }

        //Ignored Properties
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public uint Sequance { get; set; }

        public TeamModeWizardStepView TransferToTeamModeWizardStepView()
        {
            return new TeamModeWizardStepView()
            {
                Group_Id = this.Group_Id,
                IsProjectLevel = this.IsProjectLevel,
                IsUpdater = this.IsUpdater,
                Project_Id = this.Project_Id,
                SequenceNo = this.Sequance,
                Subjects = this.TeamModelSubjects.Select(s => s.TransformToTeamModelSubjectView()).ToList(),
                TeamModel_Id = this.TeamModel_Id,
                UserName = this.Name, //t.User_Id.HasValue ? t.User.EMPLOYEE_NAME : t.Group.Name,
                User_Id = this.User_Id
            };
        }
    }
}
