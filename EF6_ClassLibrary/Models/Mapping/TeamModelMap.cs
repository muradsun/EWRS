using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EF6_ClassLibrary.Models.Mapping
{
    public class TeamModelMap : EntityTypeConfiguration<TeamModel>
    {
        public TeamModelMap()
        {
            // Primary Key
            this.HasKey(t => t.TeamModel_Id);

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

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("TeamModel", "Weekly");
            this.Property(t => t.TeamModel_Id).HasColumnName("TeamModel_Id");
            this.Property(t => t.User_Id).HasColumnName("User_Id");
            this.Property(t => t.Group_Id).HasColumnName("Group_Id");
            this.Property(t => t.Project_Id).HasColumnName("Project_Id");
            this.Property(t => t.IsUpdater).HasColumnName("IsUpdater");
            this.Property(t => t.IsProjectLevelUpdater).HasColumnName("IsProjectLevelUpdater");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdateBy).HasColumnName("UpdateBy");
            this.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
            this.Property(t => t.RowVersion).HasColumnName("RowVersion");
            this.Property(t => t.Name).HasColumnName("Name");

            // Relationships
            this.HasOptional(t => t.User)
                .WithMany(t => t.TeamModels)
                .HasForeignKey(d => d.User_Id);
            this.HasOptional(t => t.Group)
                .WithMany(t => t.TeamModels)
                .HasForeignKey(d => d.Group_Id);
            this.HasRequired(t => t.Project)
                .WithMany(t => t.TeamModels)
                .HasForeignKey(d => d.Project_Id);

        }
    }
}
