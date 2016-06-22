namespace EF6_ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HR.BusinessUnitesView")]
    public partial class BusinessUnitesView
    {
        [StringLength(4000)]
        public string BU_NAME { get; set; }

        [StringLength(4000)]
        public string BU_ID { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal ORGID { get; set; }
    }
}
