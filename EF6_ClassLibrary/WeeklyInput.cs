namespace EF6_ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Weekly.WeeklyInput")]
    public partial class WeeklyInput
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WeeklyInput()
        {
            ReviewWorkflowInstances = new HashSet<ReviewWorkflowInstance>();
            WeeklyInputHistories = new HashSet<WeeklyInputHistory>();
        }

        [Key]
        public int WeeklyInput_Id { get; set; }

        [Required]
        public string InputText { get; set; }

        public int Subject_Id { get; set; }

        public int WeekNo { get; set; }

        public bool IsLocked { get; set; }

        public int? LockedBy_UserId { get; set; }

        public DateTime CreatedDate { get; set; }

        [StringLength(50)]
        public string UpdateBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReviewWorkflowInstance> ReviewWorkflowInstances { get; set; }

        public virtual Subject Subject { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WeeklyInputHistory> WeeklyInputHistories { get; set; }
    }
}
