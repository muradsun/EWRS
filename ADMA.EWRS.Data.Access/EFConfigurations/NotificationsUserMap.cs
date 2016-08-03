using ADMA.EWRS.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ADMA.EWRS.Data.Access.EfConfigurations
{
    public class NotificationsUserMap : EntityTypeConfiguration<NotificationsUser>
    {
        public NotificationsUserMap()
        {
            // Primary Key
            this.HasKey(t => t.NotificationUser_Id);

            // Properties
            this.Property(t => t.NotificationUser_Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.RowVersion)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();

            // Table & Column Mappings
            this.ToTable("NotificationsUsers", "System");
            this.Property(t => t.NotificationUser_Id).HasColumnName("NotificationUser_Id");
            this.Property(t => t.Notification_Id).HasColumnName("Notification_Id");
            this.Property(t => t.User_id).HasColumnName("User_id");
            this.Property(t => t.IsRead).HasColumnName("IsRead");
            this.Property(t => t.RowVersion).HasColumnName("RowVersion");

            // Relationships
            this.HasRequired(t => t.User)
                .WithMany(t => t.NotificationsUsers)
                .HasForeignKey(d => d.User_id);
            this.HasRequired(t => t.Notification)
                .WithMany(t => t.NotificationsUsers)
                .HasForeignKey(d => d.Notification_Id);

        }
    }
}
