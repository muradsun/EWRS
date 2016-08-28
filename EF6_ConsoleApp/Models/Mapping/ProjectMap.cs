using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EF6_ConsoleApp.Models.Mapping
{
    public class ProjectMap : EntityTypeConfiguration<Project>
    {
        public ProjectMap()
        {
            // Primary Key
            this.HasKey(t => t.Project_Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.Description)
                .HasMaxLength(1000);

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
            this.ToTable("Projects", "Weekly");
            this.Property(t => t.Project_Id).HasColumnName("Project_Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.PercentComplete).HasColumnName("PercentComplete");
            this.Property(t => t.ProjectStatus_Id).HasColumnName("ProjectStatus_Id");
            this.Property(t => t.StatusReason).HasColumnName("StatusReason");
            this.Property(t => t.ORGANIZATION_ID).HasColumnName("ORGANIZATION_ID");
            this.Property(t => t.Owner_UserId).HasColumnName("Owner_UserId");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdateBy).HasColumnName("UpdateBy");
            this.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
            this.Property(t => t.RowVersion).HasColumnName("RowVersion");

            // Relationships
            this.HasRequired(t => t.User)
                .WithMany(t => t.Projects)
                .HasForeignKey(d => d.Owner_UserId);
            this.HasRequired(t => t.ProjectStatus)
                .WithMany(t => t.Projects)
                .HasForeignKey(d => d.ProjectStatus_Id);

        }
    }
}
