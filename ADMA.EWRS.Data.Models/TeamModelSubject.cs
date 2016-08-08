using System;
using System.Collections.Generic;

namespace ADMA.EWRS.Data.Models
{
    public partial class TeamModelSubject : BaseModel
    {
        public int TeamModelSubjects_Id { get; set; }
        public int TeamModel_Id { get; set; }
        public int Subject_Id { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public byte[] RowVersion { get; set; }
        public  Subject Subject { get; set; }
        public  TeamModel TeamModel { get; set; }
    }
}
