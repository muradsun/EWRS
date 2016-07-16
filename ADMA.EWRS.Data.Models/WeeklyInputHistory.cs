using System;
using System.Collections.Generic;

namespace ADMA.EWRS.Data.Models
{
    public partial class WeeklyInputHistory
    {
        public int WeeklyInputHistory_Id { get; set; }
        public int WeeklyInput_Id { get; set; }
        public string Comment { get; set; }
        public string InputText { get; set; }
        public int ActionBy_UserId { get; set; }
        public string Action { get; set; }
        public System.DateTime ActionDate { get; set; }
        public int Subject_Id { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public byte[] RowVersion { get; set; }
        public  Subject Subject { get; set; }
        public  WeeklyInput WeeklyInput { get; set; }
    }
}
