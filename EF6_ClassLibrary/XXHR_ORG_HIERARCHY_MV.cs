namespace EF6_ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HR.XXHR_ORG_HIERARCHY_MV")]
    public partial class XXHR_ORG_HIERARCHY_MV
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(240)]
        public string ORGNAME { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal ORGID { get; set; }

        [StringLength(30)]
        public string ORGTYPE { get; set; }

        [StringLength(4000)]
        public string BU_NAME { get; set; }

        [StringLength(4000)]
        public string BU_ID { get; set; }

        [StringLength(4000)]
        public string DIV_NAME { get; set; }

        [StringLength(4000)]
        public string DIV_ID { get; set; }

        [StringLength(4000)]
        public string DEP_NAME { get; set; }

        [StringLength(4000)]
        public string DEP_ID { get; set; }

        [StringLength(4000)]
        public string TEAM_NAME { get; set; }

        [StringLength(4000)]
        public string TEAM_ID { get; set; }

        [StringLength(4000)]
        public string SECTION_NAME { get; set; }

        [StringLength(4000)]
        public string SECTION_ID { get; set; }
    }
}
