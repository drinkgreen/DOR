using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class viewBackoutMap : EntityTypeConfiguration<viewBackout>
    {
        public viewBackoutMap()
        {
            // Primary Key
            this.HasKey(t => t.DORId);

            // Properties
            this.Property(t => t.DORId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.DealNumber)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("viewBackouts");
            this.Property(t => t.DORId).HasColumnName("DORId");
            this.Property(t => t.DealNumber).HasColumnName("DealNumber");
            this.Property(t => t.DealerId).HasColumnName("DealerId");
            this.Property(t => t.StatusId).HasColumnName("StatusId");
            this.Property(t => t.DeliveryDate).HasColumnName("DeliveryDate");
            this.Property(t => t.payablegross).HasColumnName("payablegross");
            this.Property(t => t.BEGross).HasColumnName("BEGross");
        }
    }
}
