namespace EF6_ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Weekly.ReviewWorkflowInstances")]
    public partial class ReviewWorkflowInstance
    {
        [Key]
        public int ReviewWorkflowInstance_Id { get; set; }

        public byte SequenceNo { get; set; }

        public int? WeeklyInput_Id { get; set; }

        public int ReviewWorkflowsProjects_Id { get; set; }

        [StringLength(1000)]
        public string Comment { get; set; }

        [Required]
        [StringLength(10)]
        public string Action { get; set; }

        public DateTime? ReadDate { get; set; }

        public DateTime? ActionDate { get; set; }

        public int? User_Id { get; set; }

        public int? Group_Id { get; set; }

        public int? ActionBy_UserId { get; set; }

        public DateTime CreatedDate { get; set; }

        [StringLength(50)]
        public string UpdateBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual ReviewWorkflowsProject ReviewWorkflowsProject { get; set; }

        public virtual WeeklyInput WeeklyInput { get; set; }
    }
}
