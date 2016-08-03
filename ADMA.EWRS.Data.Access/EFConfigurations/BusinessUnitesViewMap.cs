using ADMA.EWRS.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ADMA.EWRS.Data.Access.EfConfigurations
{
    public class BusinessUnitesViewMap : EntityTypeConfiguration<BusinessUnitesView>
    {
        public BusinessUnitesViewMap()
        {
            // Primary Key
            this.HasKey(t => t.ORGID);

            // Properties
            this.Property(t => t.BU_NAME)
                .HasMaxLength(4000);

            this.Property(t => t.BU_ID)
                .HasMaxLength(4000);

            this.Property(t => t.ORGID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("BusinessUnitesView", "HR");
            this.Property(t => t.BU_NAME).HasColumnName("BU_NAME");
            this.Property(t => t.BU_ID).HasColumnName("BU_ID");
            this.Property(t => t.ORGID).HasColumnName("ORGID");
        }
    }
}
