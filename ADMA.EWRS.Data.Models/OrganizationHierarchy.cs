using System;
using System.Collections.Generic;

namespace ADMA.EWRS.Data.Models
{
    /// <summary>
    /// HR Clone View from HRMS
    /// </summary>
    public partial class OrganizationHierarchy
    {
        public string ORGNAME { get; set; }
        public decimal ORGID { get; set; }
        public string ORGTYPE { get; set; }
        public string BU_NAME { get; set; }
        public string BU_ID { get; set; }
        public string DIV_NAME { get; set; }
        public string DIV_ID { get; set; }
        public string DEP_NAME { get; set; }
        public string DEP_ID { get; set; }
        public string TEAM_NAME { get; set; }
        public string TEAM_ID { get; set; }
        public string SECTION_NAME { get; set; }
        public string SECTION_ID { get; set; }
    }
}
