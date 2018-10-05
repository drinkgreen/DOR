using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class UserRoleXRefMap : EntityTypeConfiguration<UserRoleXRef>
    {
        public UserRoleXRefMap()
        {
            // Primary Key
            this.HasKey(t => t.RefId);

            // Properties
            this.Property(t => t.RefId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AddUser)
                .HasMaxLength(50);

            this.Property(t => t.UpdUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("UserRoleXRef");
            this.Property(t => t.RefId).HasColumnName("RefId");
            this.Property(t => t.SecurityId).HasColumnName("SecurityId");
            this.Property(t => t.RoleId).HasColumnName("RoleId");
            this.Property(t => t.AddDate).HasColumnName("AddDate");
            this.Property(t => t.UpdDate).HasColumnName("UpdDate");
            this.Property(t => t.AddUser).HasColumnName("AddUser");
            this.Property(t => t.UpdUser).HasColumnName("UpdUser");
        }
    }
}
