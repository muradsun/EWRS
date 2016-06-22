namespace EF6_ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sec.GroupUsers")]
    public partial class GroupUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GroupUsers_Id { get; set; }

        public int User_Id { get; set; }

        public int Group_Id { get; set; }

        public DateTime CreatedDate { get; set; }

        [StringLength(50)]
        public string UpdateBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual User User { get; set; }

        public virtual Group Group { get; set; }
    }
}
