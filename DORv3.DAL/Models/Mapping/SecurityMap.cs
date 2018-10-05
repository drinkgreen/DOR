using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class SecurityMap : EntityTypeConfiguration<Security>
    {
        public SecurityMap()
        {
            // Primary Key
            this.HasKey(t => new { t.SecurityId, t.UserId });

            // Properties
            this.Property(t => t.SecurityId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserId)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.UserName)
                .HasMaxLength(50);

            this.Property(t => t.UserPass)
                .HasMaxLength(50);

            this.Property(t => t.AddUser)
                .HasMaxLength(50);

            this.Property(t => t.UpdUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Security");
            this.Property(t => t.SecurityId).HasColumnName("SecurityId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.UserPass).HasColumnName("UserPass");
            this.Property(t => t.DealerShip).HasColumnName("DealerShip");
            this.Property(t => t.DisableDate).HasColumnName("DisableDate");
            this.Property(t => t.AddDate).HasColumnName("AddDate");
            this.Property(t => t.UpdDate).HasColumnName("UpdDate");
            this.Property(t => t.AddUser).HasColumnName("AddUser");
            this.Property(t => t.UpdUser).HasColumnName("UpdUser");
        }
    }
}
