using ADMA.EWRS.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ADMA.EWRS.Data.Access.EfConfigurations
{
    public class WeeklyInputHistoryMap : EntityTypeConfiguration<WeeklyInputHistory>
    {
        public WeeklyInputHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.WeeklyInputHistory_Id);

            // Properties
            this.Property(t => t.Comment)
                .HasMaxLength(1000);

            this.Property(t => t.InputText)
                .IsRequired();

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
            this.ToTable("WeeklyInputHistory", "Weekly");
            this.Property(t => t.WeeklyInputHistory_Id).HasColumnName("WeeklyInputHistory_Id");
            this.Property(t => t.WeeklyInput_Id).HasColumnName("WeeklyInput_Id");
            this.Property(t => t.Comment).HasColumnName("Comment");
            this.Property(t => t.InputText).HasColumnName("InputText");
            this.Property(t => t.ActionBy_UserId).HasColumnName("ActionBy_UserId");
            this.Property(t => t.Action).HasColumnName("Action");
            this.Property(t => t.ActionDate).HasColumnName("ActionDate");
            this.Property(t => t.Subject_Id).HasColumnName("Subject_Id");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdateBy).HasColumnName("UpdateBy");
            this.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
            this.Property(t => t.RowVersion).HasColumnName("RowVersion");

            // Relationships
            this.HasRequired(t => t.Subject)
                .WithMany(t => t.WeeklyInputHistories)
                .HasForeignKey(d => d.Subject_Id);
            this.HasRequired(t => t.WeeklyInput)
                .WithMany(t => t.WeeklyInputHistories)
                .HasForeignKey(d => d.WeeklyInput_Id);

        }
    }
}
