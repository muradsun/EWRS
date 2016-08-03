using ADMA.EWRS.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace ADMA.EWRS.Data.Access.EfConfigurations
{
    public class PositionHierarchyMap : EntityTypeConfiguration<PositionHierarchy>
    {
        public PositionHierarchyMap()
        {
            // Primary Key
            this.HasKey(t => new { t.POSITION_ID, t.REP_TO_POSITION_ID });

            // Properties
            this.Property(t => t.POSITION_NAME)
                .HasMaxLength(4000);

            this.Property(t => t.POSITION_ORG_LEVEL)
                .HasMaxLength(4000);

            this.Property(t => t.ACTING_POSITION_NAME)
                .HasMaxLength(240);

            this.Property(t => t.REPORTING_TO_POSITION_NAME)
                .HasMaxLength(4000);

            this.Property(t => t.REPORTING_TO_POS_ORG_LEVEL)
                .HasMaxLength(4000);

            this.Property(t => t.POSITION_ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.REP_TO_POSITION_ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("POSITION_HIREARCHY", "HR");
            this.Property(t => t.POSITION_NAME).HasColumnName("POSITION_NAME");
            this.Property(t => t.POSITION_ORG_LEVEL).HasColumnName("POSITION_ORG_LEVEL");
            this.Property(t => t.ACTING_POSITION_NAME).HasColumnName("ACTING_POSITION_NAME");
            this.Property(t => t.REPORTING_TO_POSITION_NAME).HasColumnName("REPORTING_TO_POSITION_NAME");
            this.Property(t => t.REPORTING_TO_POS_ORG_LEVEL).HasColumnName("REPORTING_TO_POS_ORG_LEVEL");
            this.Property(t => t.POSITION_ID).HasColumnName("POSITION_ID");
            this.Property(t => t.ACTING_POS_ID).HasColumnName("ACTING_POS_ID");
            this.Property(t => t.REP_TO_POSITION_ID).HasColumnName("REP_TO_POSITION_ID");
        }
    }
}
