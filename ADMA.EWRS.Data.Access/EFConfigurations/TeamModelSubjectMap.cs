using ADMA.EWRS.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace ADMA.EWRS.Data.Access.EfConfigurations
{
    public class TeamModelSubjectMap : EntityTypeConfiguration<TeamModelSubject>
    {
        public TeamModelSubjectMap()
        {
            // Primary Key
            this.HasKey(t => t.TeamModelSubjects_Id);

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
            this.ToTable("TeamModelSubjects", "Weekly");
            this.Property(t => t.TeamModelSubjects_Id).HasColumnName("TeamModelSubjects_Id");
            this.Property(t => t.TeamModel_Id).HasColumnName("TeamModel_Id");
            this.Property(t => t.Subject_Id).HasColumnName("Subject_Id");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdateBy).HasColumnName("UpdateBy");
            this.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
            this.Property(t => t.RowVersion).HasColumnName("RowVersion");

            // Relationships
            this.HasRequired(t => t.Subject)
                .WithMany(t => t.TeamModelSubjects)
                .HasForeignKey(d => d.Subject_Id);
            this.HasRequired(t => t.TeamModel)
                .WithMany(t => t.TeamModelSubjects)
                .HasForeignKey(d => d.TeamModel_Id);

        }
    }
}
