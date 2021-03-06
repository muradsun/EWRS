using System;
using System.Collections.Generic;

namespace EF6_ConsoleApp.Models
{
    public partial class Delegation
    {
        public int Delegation_Id { get; set; }
        public int User_Id { get; set; }
        public int Delegated_UserId { get; set; }
        public System.DateTime FromDate { get; set; }
        public System.DateTime ToDate { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public byte[] RowVersion { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
