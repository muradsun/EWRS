using System;
using System.Collections.Generic;

namespace EF6_ConsoleApp.Models
{
    public partial class Notification
    {
        public Notification()
        {
            this.NotificationsUsers = new List<NotificationsUser>();
        }

        public int Notification_Id { get; set; }
        public byte NotificationType { get; set; }
        public string Message { get; set; }
        public Nullable<int> xRef_PK { get; set; }
        public byte[] RowVersion { get; set; }
        public virtual ICollection<NotificationsUser> NotificationsUsers { get; set; }
    }
}
