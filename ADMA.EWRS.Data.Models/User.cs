using System;
using System.Collections.Generic;

namespace ADMA.EWRS.Data.Models
{
    public partial class User
    {
        public User()
        {
            //this.Delegations = new List<Delegation>();
            //this.Delegations1 = new List<Delegation>();
            this.Groups = new List<Group>();
            this.GroupUsers = new List<GroupUser>();
            this.NotificationsUsers = new List<NotificationsUser>();
            this.Projects = new List<Project>();
            this.ReviewWorkflows = new List<ReviewWorkflow>();
            this.ReviewWorkflows1 = new List<ReviewWorkflow>();
            this.TeamModels = new List<TeamModel>();
        }

        public int User_Id { get; set; }
        public string PF_NO { get; set; }
        public string FIRST_NAME { get; set; }
        public string FAMILY_NAME { get; set; }
        public string EMPLOYEE_NAME { get; set; }
        public string POST_TITLE_LONG_DESC { get; set; }
        public string LOCATION { get; set; }
        public string ENGAGEMENT_TYPE { get; set; }
        public string GENDER { get; set; }
        public string EMAIL { get; set; }
        public string OFFICE_TELEPHONE_NUMBER { get; set; }
        public string OFFICE_LOCATION { get; set; }
        public string EMPLOYMENT_TYPE { get; set; }
        public int POSITION_ID { get; set; }
        public int ORGANIZATION_ID { get; set; }
        public Nullable<bool> IsFromHRMS { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public byte[] RowVersion { get; set; }
        //public  ICollection<Delegation> Delegations { get; set; }
        //public  ICollection<Delegation> Delegations1 { get; set; }
        public  ICollection<Group> Groups { get; set; }
        public  ICollection<GroupUser> GroupUsers { get; set; }
        public  ICollection<NotificationsUser> NotificationsUsers { get; set; }
        public  ICollection<Project> Projects { get; set; }
        public  ICollection<ReviewWorkflow> ReviewWorkflows { get; set; }
        public  ICollection<ReviewWorkflow> ReviewWorkflows1 { get; set; }
        public  ICollection<TeamModel> TeamModels { get; set; }
    }
}
