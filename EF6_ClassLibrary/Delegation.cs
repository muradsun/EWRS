namespace EF6_ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sec.Delegations")]
    public partial class Delegation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Delegation_Id { get; set; }

        public int User_Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime FromDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime ToDate { get; set; }
    }
}
