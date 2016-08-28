using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EF6_ConsoleApp.Models.Mapping
{
    public class XXHR_ORG_HIERARCHY_MVMap : EntityTypeConfiguration<XXHR_ORG_HIERARCHY_MV>
    {
        public XXHR_ORG_HIERARCHY_MVMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ORGNAME, t.ORGID });

            // Properties
            this.Property(t => t.ORGNAME)
                .IsRequired()
                .HasMaxLength(240);

            this.Property(t => t.ORGID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ORGTYPE)
                .HasMaxLength(30);

            this.Property(t => t.BU_NAME)
                .HasMaxLength(4000);

            this.Property(t => t.DIV_NAME)
                .HasMaxLength(4000);

            this.Property(t => t.DEP_NAME)
                .HasMaxLength(4000);

            this.Property(t => t.TEAM_NAME)
                .HasMaxLength(4000);

            this.Property(t => t.SECTION_NAME)
                .HasMaxLength(4000);

            // Table & Column Mappings
            this.ToTable("XXHR_ORG_HIERARCHY_MV", "HR");
            this.Property(t => t.ORGNAME).HasColumnName("ORGNAME");
            this.Property(t => t.ORGID).HasColumnName("ORGID");
            this.Property(t => t.ORGTYPE).HasColumnName("ORGTYPE");
            this.Property(t => t.BU_NAME).HasColumnName("BU_NAME");
            this.Property(t => t.BU_ID).HasColumnName("BU_ID");
            this.Property(t => t.DIV_NAME).HasColumnName("DIV_NAME");
            this.Property(t => t.DIV_ID).HasColumnName("DIV_ID");
            this.Property(t => t.DEP_NAME).HasColumnName("DEP_NAME");
            this.Property(t => t.DEP_ID).HasColumnName("DEP_ID");
            this.Property(t => t.TEAM_NAME).HasColumnName("TEAM_NAME");
            this.Property(t => t.TEAM_ID).HasColumnName("TEAM_ID");
            this.Property(t => t.SECTION_NAME).HasColumnName("SECTION_NAME");
            this.Property(t => t.SECTION_ID).HasColumnName("SECTION_ID");
        }
    }
}
