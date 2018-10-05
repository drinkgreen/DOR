using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class GradeCreditMap : EntityTypeConfiguration<GradeCredit>
    {
        public GradeCreditMap()
        {
            // Primary Key
            this.HasKey(t => t.GradeId);

            // Properties
            this.Property(t => t.GradeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Grade)
                .HasMaxLength(50);

            this.Property(t => t.AddUser)
                .HasMaxLength(50);

            this.Property(t => t.UpdUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("GradeCredit");
            this.Property(t => t.GradeId).HasColumnName("GradeId");
            this.Property(t => t.Grade).HasColumnName("Grade");
            this.Property(t => t.DisableDate).HasColumnName("DisableDate");
            this.Property(t => t.AddUser).HasColumnName("AddUser");
            this.Property(t => t.UpdUser).HasColumnName("UpdUser");
            this.Property(t => t.AddDate).HasColumnName("AddDate");
        }
    }
}
