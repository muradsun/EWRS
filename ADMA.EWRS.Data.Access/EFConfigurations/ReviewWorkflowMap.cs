using ADMA.EWRS.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace ADMA.EWRS.Data.Access.EFConfigurations
{
    public class ReviewWorkflowMap : EntityTypeConfiguration<ReviewWorkflow>
    {
        public ReviewWorkflowMap()
        {
            // Primary Key
            this.HasKey(t => t.ReviewWorkflow_Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
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
            this.ToTable("ReviewWorkflows", "Weekly");
            this.Property(t => t.ReviewWorkflow_Id).HasColumnName("ReviewWorkflow_Id");
            this.Property(t => t.SequenceNo).HasColumnName("SequenceNo");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.User_Id).HasColumnName("User_Id");
            this.Property(t => t.Group_Id).HasColumnName("Group_Id");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdateBy).HasColumnName("UpdateBy");
            this.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
            this.Property(t => t.RowVersion).HasColumnName("RowVersion");
            this.Property(t => t.Owner_UserId).HasColumnName("Owner_UserId");

            // Relationships
            this.HasOptional(t => t.User)
                .WithMany(t => t.ReviewWorkflows)
                .HasForeignKey(d => d.User_Id);
            
            //Murad :: TODO : Check This relation
            //this.HasRequired(t => t.User1)
            //    .WithMany(t => t.ReviewWorkflows1)
            //    .HasForeignKey(d => d.Owner_UserId);

            this.HasOptional(t => t.Group)
                .WithMany(t => t.ReviewWorkflows)
                .HasForeignKey(d => d.Group_Id);

        }
    }
}
