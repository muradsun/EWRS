using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EF6_ConsoleApp.Models.Mapping
{
    public class NotificationMap : EntityTypeConfiguration<Notification>
    {
        public NotificationMap()
        {
            // Primary Key
            this.HasKey(t => t.Notification_Id);

            // Properties
            this.Property(t => t.Notification_Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Message)
                .IsRequired();

            this.Property(t => t.RowVersion)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();

            // Table & Column Mappings
            this.ToTable("Notifications", "System");
            this.Property(t => t.Notification_Id).HasColumnName("Notification_Id");
            this.Property(t => t.NotificationType).HasColumnName("NotificationType");
            this.Property(t => t.Message).HasColumnName("Message");
            this.Property(t => t.xRef_PK).HasColumnName("xRef_PK");
            this.Property(t => t.RowVersion).HasColumnName("RowVersion");
        }
    }
}
