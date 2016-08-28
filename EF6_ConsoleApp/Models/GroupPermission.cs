using System;
using System.Collections.Generic;

namespace EF6_ConsoleApp.Models
{
    public partial class GroupPermission
    {
        public int GroupPermissions_Id { get; set; }
        public int Group_Id { get; set; }
        public int Permission_Id { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public byte[] RowVersion { get; set; }
        public virtual Group Group { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
