using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class DealerShipMap : EntityTypeConfiguration<DealerShip>
    {
        public DealerShipMap()
        {
            // Primary Key
            this.HasKey(t => new { t.DealerID, t.DealerName, t.Sort });

            // Properties
            this.Property(t => t.DealerID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.DealerName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.AddUser)
                .HasMaxLength(50);

            this.Property(t => t.UpdUser)
                .HasMaxLength(50);

            this.Property(t => t.DefaultMakes)
                .HasMaxLength(100);

            this.Property(t => t.RGBColor)
                .HasMaxLength(7);

            this.Property(t => t.Color)
                .HasMaxLength(25);

            this.Property(t => t.Sort)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("DealerShip");
            this.Property(t => t.DealerID).HasColumnName("DealerID");
            this.Property(t => t.DealerName).HasColumnName("DealerName");
            this.Property(t => t.DisableDate).HasColumnName("DisableDate");
            this.Property(t => t.AddUser).HasColumnName("AddUser");
            this.Property(t => t.UpdUser).HasColumnName("UpdUser");
            this.Property(t => t.AddDate).HasColumnName("AddDate");
            this.Property(t => t.DefaultMakes).HasColumnName("DefaultMakes");
            this.Property(t => t.RGBColor).HasColumnName("RGBColor");
            this.Property(t => t.Color).HasColumnName("Color");
            this.Property(t => t.Sort).HasColumnName("Sort");
        }
    }
}
