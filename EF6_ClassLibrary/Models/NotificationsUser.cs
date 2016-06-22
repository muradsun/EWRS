using System;
using System.Collections.Generic;

namespace EF6_ClassLibrary.Models
{
    public partial class NotificationsUser
    {
        public int NotificationUser_Id { get; set; }
        public int Notification_Id { get; set; }
        public int User_id { get; set; }
        public bool IsRead { get; set; }
        public byte[] RowVersion { get; set; }
        public virtual User User { get; set; }
        public virtual Notification Notification { get; set; }
    }
}
