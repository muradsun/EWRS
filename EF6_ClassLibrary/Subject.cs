namespace EF6_ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Weekly.Subjects")]
    public partial class Subject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Subject()
        {
            TeamModelSubjects = new HashSet<TeamModelSubject>();
            WeeklyInputs = new HashSet<WeeklyInput>();
            WeeklyInputHistories = new HashSet<WeeklyInputHistory>();
        }

        [Key]
        public int Subject_Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Name { get; set; }

        public int Template_Id { get; set; }

        public byte SubjectStatus_Id { get; set; }

        public byte PercentComplete { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DueDate { get; set; }

        public bool IsMandatory { get; set; }

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

        public int Project_Id { get; set; }

        public virtual SubjectStatus SubjectStatus { get; set; }

        public virtual Template Template { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeamModelSubject> TeamModelSubjects { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WeeklyInput> WeeklyInputs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WeeklyInputHistory> WeeklyInputHistories { get; set; }
    }
}
