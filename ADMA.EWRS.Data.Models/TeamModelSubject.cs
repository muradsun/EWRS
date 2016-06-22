using System;
using System.Collections.Generic;

namespace ADMA.EWRS.Data.Models
{
    public partial class TeamModelSubject
    {
        public int TeamModelSubjects_Id { get; set; }
        public int TeamModel_Id { get; set; }
        public int Subject_Id { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public byte[] RowVersion { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual TeamModel TeamModel { get; set; }
    }
}
