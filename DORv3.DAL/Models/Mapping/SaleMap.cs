using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class SaleMap : EntityTypeConfiguration<Sale>
    {
        public SaleMap()
        {
            // Primary Key
            this.HasKey(t => new { t.COL1, t.COL2, t.COL3, t.date });

            // Properties
            this.Property(t => t.COL1)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.COL2)
                .IsRequired()
                .HasMaxLength(600);

            this.Property(t => t.COL3)
                .IsRequired()
                .HasMaxLength(400);

            // Table & Column Mappings
            this.ToTable("Sales");
            this.Property(t => t.COL1).HasColumnName("COL1");
            this.Property(t => t.COL2).HasColumnName("COL2");
            this.Property(t => t.COL3).HasColumnName("COL3");
            this.Property(t => t.date).HasColumnName("date");
        }
    }
}
