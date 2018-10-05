using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class TurnOptionMap : EntityTypeConfiguration<TurnOption>
    {
        public TurnOptionMap()
        {
            // Primary Key
            this.HasKey(t => t.TurnID);

            // Properties
            this.Property(t => t.TurnID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TurnOptions");
            this.Property(t => t.TurnID).HasColumnName("TurnID");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
