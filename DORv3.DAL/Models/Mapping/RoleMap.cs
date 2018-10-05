using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.Display)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Roles");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Display).HasColumnName("Display");
            this.Property(t => t.IsAdmin).HasColumnName("IsAdmin");
            this.Property(t => t.IsDataManager).HasColumnName("IsDataManager");
            this.Property(t => t.CanAdd).HasColumnName("CanAdd");
            this.Property(t => t.CanUpdate).HasColumnName("CanUpdate");
            this.Property(t => t.CanDelete).HasColumnName("CanDelete");
            this.Property(t => t.Adjustments).HasColumnName("Adjustments");
            this.Property(t => t.OtherIncome).HasColumnName("OtherIncome");
            this.Property(t => t.Unwind).HasColumnName("Unwind");
            this.Property(t => t.ReportsOnly).HasColumnName("ReportsOnly");
        }
    }
}
