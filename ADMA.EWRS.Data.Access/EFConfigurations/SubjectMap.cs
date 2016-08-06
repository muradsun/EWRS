using ADMA.EWRS.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace ADMA.EWRS.Data.Access.EfConfigurations
{
    public class SubjectMap : EntityTypeConfiguration<Subject>
    {
        public SubjectMap()
        {
            // Primary Key
            this.HasKey(t => t.Subject_Id);

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
            this.ToTable("Subjects", "Weekly");
            this.Property(t => t.Subject_Id).HasColumnName("Subject_Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Template_Id).HasColumnName("Template_Id");
            this.Property(t => t.SubjectStatus_Id).HasColumnName("SubjectStatus_Id");
            this.Property(t => t.PercentComplete).HasColumnName("PercentComplete");
            this.Property(t => t.DueDate).HasColumnName("DueDate");
            this.Property(t => t.IsMandatory).HasColumnName("IsMandatory");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdateBy).HasColumnName("UpdateBy");
            this.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
            this.Property(t => t.RowVersion).HasColumnName("RowVersion");
            this.Property(t => t.Project_Id).HasColumnName("Project_Id");
            this.Property(t => t.SequenceNo).HasColumnName("SequenceNo").IsRequired();

            // Relationships
            this.HasRequired(t => t.SubjectStatus)
                .WithMany(t => t.Subjects)
                .HasForeignKey(d => d.SubjectStatus_Id);
            this.HasRequired(t => t.Template)
                .WithMany(t => t.Subjects)
                .HasForeignKey(d => d.Template_Id);
                //.WillCascadeOnDelete(); //Murad Enable the cascade by default okay dude, f. 
        }
    }
}
