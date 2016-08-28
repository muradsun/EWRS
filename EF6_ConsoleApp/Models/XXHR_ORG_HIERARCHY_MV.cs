using System;
using System.Collections.Generic;

namespace EF6_ConsoleApp.Models
{
    public partial class XXHR_ORG_HIERARCHY_MV
    {
        public string ORGNAME { get; set; }
        public int ORGID { get; set; }
        public string ORGTYPE { get; set; }
        public string BU_NAME { get; set; }
        public Nullable<int> BU_ID { get; set; }
        public string DIV_NAME { get; set; }
        public Nullable<int> DIV_ID { get; set; }
        public string DEP_NAME { get; set; }
        public Nullable<int> DEP_ID { get; set; }
        public string TEAM_NAME { get; set; }
        public Nullable<int> TEAM_ID { get; set; }
        public string SECTION_NAME { get; set; }
        public Nullable<int> SECTION_ID { get; set; }
    }
}
