using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class viewUserRoleMap : EntityTypeConfiguration<viewUserRole>
    {
        public viewUserRoleMap()
        {
            // Primary Key
            this.HasKey(t => t.SecurityId);

            // Properties
            this.Property(t => t.UserId)
                .HasMaxLength(50);

            this.Property(t => t.UserName)
                .HasMaxLength(50);

            this.Property(t => t.SecurityId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("viewUserRole");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.DealerShip).HasColumnName("DealerShip");
            this.Property(t => t.RoleId).HasColumnName("RoleId");
            this.Property(t => t.SecurityId).HasColumnName("SecurityId");
            this.Property(t => t.DisableDate).HasColumnName("DisableDate");
        }
    }
}
