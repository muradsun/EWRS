using System;
using System.Collections.Generic;

namespace ADMA.EWRS.Data.Models
{
    public partial class SubjectStatus
    {
        public SubjectStatus()
        {
            this.Subjects = new List<Subject>();
        }

        public byte SubjectStatus_Id { get; set; }
        public string Status { get; set; }
        public byte[] RowVersion { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}