using ADMA.EWRS.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace ADMA.EWRS.Data.Access.EfConfigurations
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

            this.Property(t => t.UpdateBy)
                .HasMaxLength(50);

            this.Property(t => t.RowVersion)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();

            // Table & Column Mappings
            this.ToTable("Delegations", "Sec");
            this.Property(t => t.Delegation_Id).HasColumnName("Delegation_Id");
            this.Property(t => t.User_Id).HasColumnName("User_Id");
            this.Property(t => t.Delegated_UserId).HasColumnName("Delegated_UserId");
            this.Property(t => t.FromDate).HasColumnName("FromDate");
            this.Property(t => t.ToDate).HasColumnName("ToDate");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdateBy).HasColumnName("UpdateBy");
            this.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
            this.Property(t => t.RowVersion).HasColumnName("RowVersion");

            //// Relationships
            //this.HasRequired(t => t.User)
            //    .WithMany(t => t.Delegations)
            //    .HasForeignKey(d => d.User_Id);

            //this.HasRequired(t => t.Delegated_UserId)
            //    .WithMany(t => t.Delegations1)
            //    .HasForeignKey(d => d.Delegated_UserId);

        }
    }
}
