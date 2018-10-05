using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class ScreenMap : EntityTypeConfiguration<Screen>
    {
        public ScreenMap()
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

            this.Property(t => t.ScreenASP)
                .HasMaxLength(50);

            this.Property(t => t.AddUser)
                .HasMaxLength(50);

            this.Property(t => t.UpdUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Screens");
            this.Property(t => t.ScreenId).HasColumnName("ScreenId");
            this.Property(t => t.ScreenName).HasColumnName("ScreenName");
            this.Property(t => t.ScreenType).HasColumnName("ScreenType");
            this.Property(t => t.ScreenASP).HasColumnName("ScreenASP");
            this.Property(t => t.ScreenOpt).HasColumnName("ScreenOpt");
            this.Property(t => t.AddUser).HasColumnName("AddUser");
            this.Property(t => t.UpdUser).HasColumnName("UpdUser");
            this.Property(t => t.AddDate).HasColumnName("AddDate");
            this.Property(t => t.UpdDate).HasColumnName("UpdDate");
            this.Property(t => t.ScreenOrder).HasColumnName("ScreenOrder");
        }
    }
}
