using ADMA.EWRS.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace ADMA.EWRS.Data.Access.EFConfigurations
{
    public class WeeklyInputMap : EntityTypeConfiguration<WeeklyInput>
    {
        public WeeklyInputMap()
        {
            // Primary Key
            this.HasKey(t => t.WeeklyInput_Id);

            // Properties
            this.Property(t => t.InputText)
                .IsRequired();

            this.Property(t => t.UpdateBy)
                .HasMaxLength(50);

            this.Property(t => t.RowVersion)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();

            // Table & Column Mappings
            this.ToTable("WeeklyInput", "Weekly");
            this.Property(t => t.WeeklyInput_Id).HasColumnName("WeeklyInput_Id");
            this.Property(t => t.InputText).HasColumnName("InputText");
            this.Property(t => t.Subject_Id).HasColumnName("Subject_Id");
            this.Property(t => t.WeekNo).HasColumnName("WeekNo");
            this.Property(t => t.IsLocked).HasColumnName("IsLocked");
            this.Property(t => t.LockedBy_UserId).HasColumnName("LockedBy_UserId");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdateBy).HasColumnName("UpdateBy");
            this.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
            this.Property(t => t.RowVersion).HasColumnName("RowVersion");

            // Relationships
            this.HasRequired(t => t.Subject)
                .WithMany(t => t.WeeklyInputs)
                .HasForeignKey(d => d.Subject_Id);

        }
    }
}
