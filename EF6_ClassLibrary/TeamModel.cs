namespace EF6_ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Weekly.TeamModel")]
    public partial class TeamModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TeamModel()
        {
            TeamModelSubjects = new HashSet<TeamModelSubject>();
        }

        [Key]
        public int TeamModel_Id { get; set; }

        public int? User_Id { get; set; }

        public int? Group_Id { get; set; }

        public int Project_Id { get; set; }

        public bool IsUpdater { get; set; }

        public bool IsProjectLevel { get; set; }

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

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public virtual User User { get; set; }

        public virtual Group Group { get; set; }

        public virtual Project Project { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeamModelSubject> TeamModelSubjects { get; set; }
    }
}
