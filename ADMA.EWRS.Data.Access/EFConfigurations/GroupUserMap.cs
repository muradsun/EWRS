using ADMA.EWRS.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace ADMA.EWRS.Data.Access.EFConfigurations
{
    public class GroupUserMap : EntityTypeConfiguration<GroupUser>
    {
        public GroupUserMap()
        {
            // Primary Key
            this.HasKey(t => t.GroupUsers_Id);

            // Properties
            this.Property(t => t.GroupUsers_Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UpdateBy)
                .HasMaxLength(50);

            this.Property(t => t.RowVersion)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();

            // Table & Column Mappings
            this.ToTable("GroupUsers", "Sec");
            this.Property(t => t.GroupUsers_Id).HasColumnName("GroupUsers_Id");
            this.Property(t => t.User_Id).HasColumnName("User_Id");
            this.Property(t => t.Group_Id).HasColumnName("Group_Id");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdateBy).HasColumnName("UpdateBy");
            this.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
            this.Property(t => t.RowVersion).HasColumnName("RowVersion");

            // Relationships
            this.HasRequired(t => t.User)
                .WithMany(t => t.GroupUsers)
                .HasForeignKey(d => d.User_Id);
            this.HasRequired(t => t.Group)
                .WithMany(t => t.GroupUsers)
                .HasForeignKey(d => d.Group_Id);

        }
    }
}
