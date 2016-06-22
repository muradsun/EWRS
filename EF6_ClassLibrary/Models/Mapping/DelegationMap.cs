using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EF6_ClassLibrary.Models.Mapping
{
    public class DelegationMap : EntityTypeConfiguration<Delegation>
    {
        public DelegationMap()
        {
            // Primary Key
            this.HasKey(t => t.Delegation_Id);

            // Properties
            this.Property(t => t.Delegation_Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Delegations", "Sec");
            this.Property(t => t.Delegation_Id).HasColumnName("Delegation_Id");
            this.Property(t => t.User_Id).HasColumnName("User_Id");
            this.Property(t => t.FromDate).HasColumnName("FromDate");
            this.Property(t => t.ToDate).HasColumnName("ToDate");
        }
    }
}
