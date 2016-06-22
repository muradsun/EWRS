using System;
using System.Collections.Generic;

namespace ADMA.EWRS.Data.Models
{
    public partial class Configuration
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public int RefId { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
