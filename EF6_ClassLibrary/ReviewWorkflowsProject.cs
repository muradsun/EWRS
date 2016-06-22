namespace EF6_ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Weekly.ReviewWorkflowsProjects")]
    public partial class ReviewWorkflowsProject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReviewWorkflowsProject()
        {
            ReviewWorkflowInstances = new HashSet<ReviewWorkflowInstance>();
        }

        [Key]
        public int ReviewWorkflowsProjects_Id { get; set; }

        public bool IsProjectDefaultWorkflow { get; set; }

        public int? TeamModel_Id { get; set; }

        public int Project_Id { get; set; }

        public int ReviewWorkflow_Id { get; set; }

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

        public virtual Project Project { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReviewWorkflowInstance> ReviewWorkflowInstances { get; set; }

        public virtual ReviewWorkflow ReviewWorkflow { get; set; }
    }
}
