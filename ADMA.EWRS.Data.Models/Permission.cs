using System;
using System.Collections.Generic;

namespace ADMA.EWRS.Data.Models
{
    public partial class Permission
    {
        public Permission()
        {
            this.GroupPermissions = new List<GroupPermission>();
        }

        public int Permission_Id { get; set; }
        public string Name { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public byte[] RowVersion { get; set; }
        public virtual ICollection<GroupPermission> GroupPermissions { get; set; }
    }
}
