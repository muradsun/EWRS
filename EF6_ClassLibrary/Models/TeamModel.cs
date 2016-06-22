using System;
using System.Collections.Generic;

namespace EF6_ClassLibrary.Models
{
    public partial class TeamModel
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
        public bool IsProjectLevelUpdater { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public byte[] RowVersion { get; set; }
        public string Name { get; set; }
        public virtual User User { get; set; }
        public virtual Group Group { get; set; }
        public virtual Project Project { get; set; }
        public virtual ICollection<TeamModelSubject> TeamModelSubjects { get; set; }
    }
}
