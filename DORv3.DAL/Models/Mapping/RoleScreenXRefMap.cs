using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class RoleScreenXRefMap : EntityTypeConfiguration<RoleScreenXRef>
    {
        public RoleScreenXRefMap()
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
            this.ToTable("RoleScreenXRef");
            this.Property(t => t.RefId).HasColumnName("RefId");
            this.Property(t => t.ScreenId).HasColumnName("ScreenId");
            this.Property(t => t.RoleId).HasColumnName("RoleId");
            this.Property(t => t.AddDate).HasColumnName("AddDate");
            this.Property(t => t.AddUser).HasColumnName("AddUser");
            this.Property(t => t.UpdUser).HasColumnName("UpdUser");
            this.Property(t => t.UpdDate).HasColumnName("UpdDate");
        }
    }
}
