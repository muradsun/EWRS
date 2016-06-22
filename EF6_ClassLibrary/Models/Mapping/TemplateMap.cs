using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EF6_ClassLibrary.Models.Mapping
{
    public class TemplateMap : EntityTypeConfiguration<Template>
    {
        public TemplateMap()
        {
            // Primary Key
            this.HasKey(t => t.Template_Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(500);

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
            this.ToTable("Templates", "Weekly");
            this.Property(t => t.Template_Id).HasColumnName("Template_Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Project_Id).HasColumnName("Project_Id");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdateBy).HasColumnName("UpdateBy");
            this.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
            this.Property(t => t.RowVersion).HasColumnName("RowVersion");

            // Relationships
            this.HasRequired(t => t.Project)
                .WithMany(t => t.Templates)
                .HasForeignKey(d => d.Project_Id);

        }
    }
}
