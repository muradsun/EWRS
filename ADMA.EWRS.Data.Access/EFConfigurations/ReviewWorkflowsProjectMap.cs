using ADMA.EWRS.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace ADMA.EWRS.Data.Access.EFConfigurations
{
    public class ReviewWorkflowsProjectMap : EntityTypeConfiguration<ReviewWorkflowsProject>
    {
        public ReviewWorkflowsProjectMap()
        {
            // Primary Key
            this.HasKey(t => t.ReviewWorkflowsProjects_Id);

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
            this.ToTable("ReviewWorkflowsProjects", "Weekly");
            this.Property(t => t.ReviewWorkflowsProjects_Id).HasColumnName("ReviewWorkflowsProjects_Id");
            this.Property(t => t.IsProjectDefaultWorkflow).HasColumnName("IsProjectDefaultWorkflow");
            this.Property(t => t.TeamModel_Id).HasColumnName("TeamModel_Id");
            this.Property(t => t.Project_Id).HasColumnName("Project_Id");
            this.Property(t => t.ReviewWorkflow_Id).HasColumnName("ReviewWorkflow_Id");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdateBy).HasColumnName("UpdateBy");
            this.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
            this.Property(t => t.RowVersion).HasColumnName("RowVersion");

            // Relationships
            this.HasRequired(t => t.Project)
                .WithMany(t => t.ReviewWorkflowsProjects)
                .HasForeignKey(d => d.Project_Id);
            this.HasRequired(t => t.ReviewWorkflow)
                .WithMany(t => t.ReviewWorkflowsProjects)
                .HasForeignKey(d => d.ReviewWorkflow_Id);

        }
    }
}
