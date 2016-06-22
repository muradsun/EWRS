using ADMA.EWRS.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace ADMA.EWRS.Data.Access.EFConfigurations
{
    public class SubjectStatusMap : EntityTypeConfiguration<SubjectStatus>
    {
        public SubjectStatusMap()
        {
            // Primary Key
            this.HasKey(t => t.SubjectStatus_Id);

            // Properties
            this.Property(t => t.Status)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.RowVersion)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();

            // Table & Column Mappings
            this.ToTable("SubjectStatuses", "Weekly");
            this.Property(t => t.SubjectStatus_Id).HasColumnName("SubjectStatus_Id");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.RowVersion).HasColumnName("RowVersion");
        }
    }
}
