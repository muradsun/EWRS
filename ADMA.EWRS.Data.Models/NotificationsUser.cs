using System;
using System.Collections.Generic;

namespace ADMA.EWRS.Data.Models
{
    public partial class NotificationsUser
    {
        public int NotificationUser_Id { get; set; }
        public int Notification_Id { get; set; }
        public int User_id { get; set; }
        public bool IsRead { get; set; }
        public byte[] RowVersion { get; set; }
        public  User User { get; set; }
        public  Notification Notification { get; set; }
    }
}
