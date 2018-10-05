using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class viewScreenbytypeMap : EntityTypeConfiguration<viewScreenbytype>
    {
        public viewScreenbytypeMap()
        {
            // Primary Key
            this.HasKey(t => t.ScreenId);

            // Properties
            this.Property(t => t.ScreenId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ScreenName)
                .HasMaxLength(100);

            this.Property(t => t.ScreenType)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("viewScreenbytype");
            this.Property(t => t.ScreenId).HasColumnName("ScreenId");
            this.Property(t => t.ScreenName).HasColumnName("ScreenName");
            this.Property(t => t.ScreenType).HasColumnName("ScreenType");
            this.Property(t => t.ScreenOrder).HasColumnName("ScreenOrder");
        }
    }
}
