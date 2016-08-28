using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EF6_ConsoleApp.Models.Mapping
{
    public class ReviewWorkflowInstanceMap : EntityTypeConfiguration<ReviewWorkflowInstance>
    {
        public ReviewWorkflowInstanceMap()
        {
            // Primary Key
            this.HasKey(t => t.ReviewWorkflowInstance_Id);

            // Properties
            this.Property(t => t.Comment)
                .HasMaxLength(1000);

            this.Property(t => t.Action)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.UpdateBy)
                .HasMaxLength(50);

            this.Property(t => t.RowVersion)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();

            // Table & Column Mappings
            this.ToTable("ReviewWorkflowInstances", "Weekly");
            this.Property(t => t.ReviewWorkflowInstance_Id).HasColumnName("ReviewWorkflowInstance_Id");
            this.Property(t => t.SequenceNo).HasColumnName("SequenceNo");
            this.Property(t => t.WeeklyInput_Id).HasColumnName("WeeklyInput_Id");
            this.Property(t => t.ReviewWorkflowsProjects_Id).HasColumnName("ReviewWorkflowsProjects_Id");
            this.Property(t => t.Comment).HasColumnName("Comment");
            this.Property(t => t.Action).HasColumnName("Action");
            this.Property(t => t.ReadDate).HasColumnName("ReadDate");
            this.Property(t => t.ActionDate).HasColumnName("ActionDate");
            this.Property(t => t.User_Id).HasColumnName("User_Id");
            this.Property(t => t.Group_Id).HasColumnName("Group_Id");
            this.Property(t => t.ActionBy_UserId).HasColumnName("ActionBy_UserId");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdateBy).HasColumnName("UpdateBy");
            this.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
            this.Property(t => t.RowVersion).HasColumnName("RowVersion");

            // Relationships
            this.HasRequired(t => t.ReviewWorkflowsProject)
                .WithMany(t => t.ReviewWorkflowInstances)
                .HasForeignKey(d => d.ReviewWorkflowsProjects_Id);
            this.HasOptional(t => t.WeeklyInput)
                .WithMany(t => t.ReviewWorkflowInstances)
                .HasForeignKey(d => d.WeeklyInput_Id);

        }
    }
}
