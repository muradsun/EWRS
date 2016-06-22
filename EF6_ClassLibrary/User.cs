namespace EF6_ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HR.Users")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Groups = new HashSet<Group>();
            GroupUsers = new HashSet<GroupUser>();
            NotificationsUsers = new HashSet<NotificationsUser>();
            ReviewWorkflows = new HashSet<ReviewWorkflow>();
            ReviewWorkflows1 = new HashSet<ReviewWorkflow>();
            TeamModels = new HashSet<TeamModel>();
        }

        [Key]
        public int User_Id { get; set; }

        [Required]
        [StringLength(10)]
        public string PF_NO { get; set; }

        [Required]
        [StringLength(250)]
        public string FIRST_NAME { get; set; }

        [Required]
        [StringLength(250)]
        public string FAMILY_NAME { get; set; }

        [Required]
        [StringLength(250)]
        public string EMPLOYEE_NAME { get; set; }

        [Required]
        [StringLength(500)]
        public string POST_TITLE_LONG_DESC { get; set; }

        [Required]
        [StringLength(50)]
        public string LOCATION { get; set; }

        [Required]
        [StringLength(50)]
        public string ENGAGEMENT_TYPE { get; set; }

        public byte GENDER { get; set; }

        [Required]
        [StringLength(250)]
        public string EMAIL { get; set; }

        [StringLength(50)]
        public string OFFICE_TELEPHONE_NUMBER { get; set; }

        [StringLength(50)]
        public string OFFICE_LOCATION { get; set; }

        [Required]
        [StringLength(50)]
        public string EMPLOYMENT_TYPE { get; set; }

        public int POSITION_ID { get; set; }

        public int ORGANIZATION_ID { get; set; }

        public bool? IsFromHRMS { get; set; }

        public bool IsActive { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Group> Groups { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GroupUser> GroupUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NotificationsUser> NotificationsUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReviewWorkflow> ReviewWorkflows { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReviewWorkflow> ReviewWorkflows1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeamModel> TeamModels { get; set; }
    }
}
