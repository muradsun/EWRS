namespace EF6_ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HR.POSITION_HIREARCHY")]
    public partial class POSITION_HIREARCHY
    {
        [StringLength(4000)]
        public string POSITION_NAME { get; set; }

        [StringLength(4000)]
        public string POSITION_ORG_LEVEL { get; set; }

        [StringLength(240)]
        public string ACTING_POSITION_NAME { get; set; }

        [StringLength(4000)]
        public string REPORTING_TO_POSITION_NAME { get; set; }

        [StringLength(4000)]
        public string REPORTING_TO_POS_ORG_LEVEL { get; set; }

        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal POSITION_ID { get; set; }

        public double? ACTING_POS_ID { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal REP_TO_POSITION_ID { get; set; }
    }
}
