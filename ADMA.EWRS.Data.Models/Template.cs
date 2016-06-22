using System;
using System.Collections.Generic;

namespace ADMA.EWRS.Data.Models
{
    public partial class Template
    {
        public Template()
        {
            this.Subjects = new List<Subject>();
        }

        public int Template_Id { get; set; }
        public string Name { get; set; }
        public int Project_Id { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public byte[] RowVersion { get; set; }
        public virtual Project Project { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
