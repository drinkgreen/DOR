using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class viewUnwindDateFixMap : EntityTypeConfiguration<viewUnwindDateFix>
    {
        public viewUnwindDateFixMap()
        {
            // Primary Key
            this.HasKey(t => t.DORId);

            // Properties
            this.Property(t => t.DORId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.lname1)
                .HasMaxLength(50);

            this.Property(t => t.AddUser)
                .HasMaxLength(50);

            this.Property(t => t.UpdUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("viewUnwindDateFix");
            this.Property(t => t.DealerId).HasColumnName("DealerId");
            this.Property(t => t.DORId).HasColumnName("DORId");
            this.Property(t => t.StatusId).HasColumnName("StatusId");
            this.Property(t => t.DeliveryDate).HasColumnName("DeliveryDate");
            this.Property(t => t.UnwindDate).HasColumnName("UnwindDate");
            this.Property(t => t.lname1).HasColumnName("lname1");
            this.Property(t => t.AddUser).HasColumnName("AddUser");
            this.Property(t => t.UpdUser).HasColumnName("UpdUser");
            this.Property(t => t.BackoutDate).HasColumnName("BackoutDate");
        }
    }
}
