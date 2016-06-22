using System;
using System.Collections.Generic;

namespace EF6_ClassLibrary.Models
{
    public partial class ProjectStatus
    {
        public ProjectStatus()
        {
            this.Projects = new List<Project>();
        }

        public byte ProjectStatus_Id { get; set; }
        public string Status { get; set; }
        public byte[] RowVersion { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
