using ADMA.EWRS.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ADMA.EWRS.Data.Access.EfConfigurations
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.User_Id);

            // Properties
            this.Property(t => t.PF_NO)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.FIRST_NAME)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.FAMILY_NAME)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.EMPLOYEE_NAME)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.POST_TITLE_LONG_DESC)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.LOCATION)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ENGAGEMENT_TYPE)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.EMAIL)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.OFFICE_TELEPHONE_NUMBER)
                .HasMaxLength(50);

            this.Property(t => t.OFFICE_LOCATION)
                .HasMaxLength(50);

            this.Property(t => t.EMPLOYMENT_TYPE)
                .IsRequired()
                .HasMaxLength(50);

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
            this.ToTable("Users", "HR");
            this.Property(t => t.User_Id).HasColumnName("User_Id");
            this.Property(t => t.PF_NO).HasColumnName("PF_NO");
            this.Property(t => t.FIRST_NAME).HasColumnName("FIRST_NAME");
            this.Property(t => t.FAMILY_NAME).HasColumnName("FAMILY_NAME");
            this.Property(t => t.EMPLOYEE_NAME).HasColumnName("EMPLOYEE_NAME");
            this.Property(t => t.POST_TITLE_LONG_DESC).HasColumnName("POST_TITLE_LONG_DESC");
            this.Property(t => t.LOCATION).HasColumnName("LOCATION");
            this.Property(t => t.ENGAGEMENT_TYPE).HasColumnName("ENGAGEMENT_TYPE");
            this.Property(t => t.GENDER).HasColumnName("GENDER");
            this.Property(t => t.EMAIL).HasColumnName("EMAIL");
            this.Property(t => t.OFFICE_TELEPHONE_NUMBER).HasColumnName("OFFICE_TELEPHONE_NUMBER");
            this.Property(t => t.OFFICE_LOCATION).HasColumnName("OFFICE_LOCATION");
            this.Property(t => t.EMPLOYMENT_TYPE).HasColumnName("EMPLOYMENT_TYPE");
            this.Property(t => t.POSITION_ID).HasColumnName("POSITION_ID");
            this.Property(t => t.ORGANIZATION_ID).HasColumnName("ORGANIZATION_ID");
            this.Property(t => t.IsFromHRMS).HasColumnName("IsFromHRMS");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdateBy).HasColumnName("UpdateBy");
            this.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
            this.Property(t => t.RowVersion).HasColumnName("RowVersion");
        }
    }
}
