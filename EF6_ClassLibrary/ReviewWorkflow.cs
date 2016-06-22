namespace EF6_ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Weekly.ReviewWorkflows")]
    public partial class ReviewWorkflow
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReviewWorkflow()
        {
            ReviewWorkflowsProjects = new HashSet<ReviewWorkflowsProject>();
        }

        [Key]
        public int ReviewWorkflow_Id { get; set; }

        public byte SequenceNo { get; set; }

        [Required]
        [StringLength(1000)]
        public string Name { get; set; }

        public int? User_Id { get; set; }

        public int? Group_Id { get; set; }

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

        public int Owner_UserId { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        public virtual Group Group { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReviewWorkflowsProject> ReviewWorkflowsProjects { get; set; }
    }
}
