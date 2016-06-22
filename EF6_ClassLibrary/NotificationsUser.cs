namespace EF6_ClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("System.NotificationsUsers")]
    public partial class NotificationsUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NotificationUser_Id { get; set; }

        public int Notification_Id { get; set; }

        public int User_id { get; set; }

        public bool IsRead { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual User User { get; set; }

        public virtual Notification Notification { get; set; }
    }
}
