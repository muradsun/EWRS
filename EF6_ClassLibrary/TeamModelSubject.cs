namespace EF6_ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Weekly.TeamModelSubjects")]
    public partial class TeamModelSubject
    {
        [Key]
        public int TeamModelSubjects_Id { get; set; }

        public int TeamModel_Id { get; set; }

        public int Subject_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        [StringLength(50)]
        public string UpdateBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual TeamModel TeamModel { get; set; }
    }
}
