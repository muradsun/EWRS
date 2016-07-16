using System;
using System.Collections.Generic;

namespace ADMA.EWRS.Data.Models
{
    public partial class Project
    {
        public Project()
        {
            this.ReviewWorkflowsProjects = new List<ReviewWorkflowsProject>();
            this.TeamModels = new List<TeamModel>();
            this.Templates = new List<Template>();
        }

        public int Project_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte PercentComplete { get; set; }
        public Enums.ProjectStatusEnum ProjectStatus_Id { get; set; }
        public string StatusReason { get; set; }
        public int ORGANIZATION_ID { get; set; }
        public int Owner_UserId { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public byte[] RowVersion { get; set; }
        public  User User { get; set; }
        public  ProjectStatus ProjectStatus { get; set; }
        public  ICollection<ReviewWorkflowsProject> ReviewWorkflowsProjects { get; set; }
        public  ICollection<TeamModel> TeamModels { get; set; }
        public  ICollection<Template> Templates { get; set; }
    }
}
