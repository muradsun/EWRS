using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EF6_ConsoleApp.Models.Mapping
{
    public class GroupPermissionMap : EntityTypeConfiguration<GroupPermission>
    {
        public GroupPermissionMap()
        {
            // Primary Key
            this.HasKey(t => t.GroupPermissions_Id);

            // Properties
            this.Property(t => t.CreatedBy)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.UpdateBy)
                .HasMaxLength(50);

            this.Property(t => t.RowVersion)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();

            // Table & Column Mappings
            this.ToTable("GroupPermissions", "Sec");
            this.Property(t => t.GroupPermissions_Id).HasColumnName("GroupPermissions_Id");
            this.Property(t => t.Group_Id).HasColumnName("Group_Id");
            this.Property(t => t.Permission_Id).HasColumnName("Permission_Id");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdateBy).HasColumnName("UpdateBy");
            this.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
            this.Property(t => t.RowVersion).HasColumnName("RowVersion");

            // Relationships
            this.HasRequired(t => t.Group)
                .WithMany(t => t.GroupPermissions)
                .HasForeignKey(d => d.Group_Id);
            this.HasRequired(t => t.Permission)
                .WithMany(t => t.GroupPermissions)
                .HasForeignKey(d => d.Permission_Id);

        }
    }
}
