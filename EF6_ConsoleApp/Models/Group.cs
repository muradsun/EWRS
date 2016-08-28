using System;
using System.Collections.Generic;

namespace EF6_ConsoleApp.Models
{
    public partial class Group
    {
        public Group()
        {
            this.GroupPermissions = new List<GroupPermission>();
            this.GroupUsers = new List<GroupUser>();
            this.TeamModels = new List<TeamModel>();
        }

        public int Group_Id { get; set; }
        public string Name { get; set; }
        public bool IsSystemGoup { get; set; }
        public Nullable<int> Owner_UserId { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public byte[] RowVersion { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<GroupPermission> GroupPermissions { get; set; }
        public virtual ICollection<GroupUser> GroupUsers { get; set; }
        public virtual ICollection<TeamModel> TeamModels { get; set; }
    }
}
