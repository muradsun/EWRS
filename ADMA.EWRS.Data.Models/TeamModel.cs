using System;
using System.Collections.Generic;

namespace ADMA.EWRS.Data.Models
{
    public partial class TeamModel: BaseModel
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
        public  User User { get; set; }
        public  Group Group { get; set; }
        public  Project Project { get; set; }
        public  List<TeamModelSubject> TeamModelSubjects { get; set; }


    }
}
