using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class MakeMap : EntityTypeConfiguration<Make>
    {
        public MakeMap()
        {
            // Primary Key
            this.HasKey(t => t.MakeId);

            // Properties
            this.Property(t => t.MakeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Make1)
                .HasMaxLength(50);

            this.Property(t => t.AddUser)
                .HasMaxLength(50);

            this.Property(t => t.UpdUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Make");
            this.Property(t => t.MakeId).HasColumnName("MakeId");
            this.Property(t => t.Dealer).HasColumnName("Dealer");
            this.Property(t => t.Make1).HasColumnName("Make");
            this.Property(t => t.DisableDate).HasColumnName("DisableDate");
            this.Property(t => t.AddUser).HasColumnName("AddUser");
            this.Property(t => t.UpdUser).HasColumnName("UpdUser");
            this.Property(t => t.AddDate).HasColumnName("AddDate");
        }
    }
}
