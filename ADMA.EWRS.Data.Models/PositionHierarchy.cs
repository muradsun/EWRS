using System;
using System.Collections.Generic;

namespace ADMA.EWRS.Data.Models
{
    /// <summary>
    /// HR Clone View from HRMS
    /// </summary>
    public partial class PositionHierarchy
    {
        public string POSITION_NAME { get; set; }
        public string POSITION_ORG_LEVEL { get; set; }
        public string ACTING_POSITION_NAME { get; set; }
        public string REPORTING_TO_POSITION_NAME { get; set; }
        public string REPORTING_TO_POS_ORG_LEVEL { get; set; }
        public decimal POSITION_ID { get; set; }
        public Nullable<double> ACTING_POS_ID { get; set; }
        public decimal REP_TO_POSITION_ID { get; set; }
    }
}
