using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EF6_ConsoleApp.Models.Mapping
{
    public class ReviewWorkflowActorMap : EntityTypeConfiguration<ReviewWorkflowActor>
    {
        public ReviewWorkflowActorMap()
        {
            // Primary Key
            this.HasKey(t => t.ReviewWorkflowActor_Id);

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
            this.ToTable("ReviewWorkflowActors", "Weekly");
            this.Property(t => t.ReviewWorkflowActor_Id).HasColumnName("ReviewWorkflowActor_Id");
            this.Property(t => t.ReviewWorkflow_Id).HasColumnName("ReviewWorkflow_Id");
            this.Property(t => t.SequenceNo).HasColumnName("SequenceNo");
            this.Property(t => t.Group_Id).HasColumnName("Group_Id");
            this.Property(t => t.User_Id).HasColumnName("User_Id");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdateBy).HasColumnName("UpdateBy");
            this.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
            this.Property(t => t.RowVersion).HasColumnName("RowVersion");

            // Relationships
            this.HasRequired(t => t.ReviewWorkflow)
                .WithMany(t => t.ReviewWorkflowActors)
                .HasForeignKey(d => d.ReviewWorkflow_Id);

        }
    }
}
