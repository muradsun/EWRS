using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EF6_ConsoleApp.Models.Mapping
{
    public class ProjectStatusMap : EntityTypeConfiguration<ProjectStatus>
    {
        public ProjectStatusMap()
        {
            // Primary Key
            this.HasKey(t => t.ProjectStatus_Id);

            // Properties
            this.Property(t => t.ProjectStatus_Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Status)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.RowVersion)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();

            // Table & Column Mappings
            this.ToTable("ProjectStatuses", "Weekly");
            this.Property(t => t.ProjectStatus_Id).HasColumnName("ProjectStatus_Id");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.RowVersion).HasColumnName("RowVersion");
        }
    }
}
