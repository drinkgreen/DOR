using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class VSales_RecapMap : EntityTypeConfiguration<VSales_Recap>
    {
        public VSales_RecapMap()
        {
            // Primary Key
            this.HasKey(t => t.SalesRecapRecordID);

            // Properties
            this.Property(t => t.dealership)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("VSales_Recap");
            this.Property(t => t.SalesRecapRecordID).HasColumnName("SalesRecapRecordID");
            this.Property(t => t.dealership).HasColumnName("dealership");
            this.Property(t => t.dealer_id).HasColumnName("dealer_id");
            this.Property(t => t.new_cars).HasColumnName("new_cars");
            this.Property(t => t.new_trucks).HasColumnName("new_trucks");
            this.Property(t => t.new_suvs).HasColumnName("new_suvs");
            this.Property(t => t.used_vehicles).HasColumnName("used_vehicles");
            this.Property(t => t.total_vehicles).HasColumnName("total_vehicles");
            this.Property(t => t.cash).HasColumnName("cash");
            this.Property(t => t.nc_cash_per).HasColumnName("nc_cash_per");
            this.Property(t => t.nt_cash_per).HasColumnName("nt_cash_per");
            this.Property(t => t.ns_cash_per).HasColumnName("ns_cash_per");
            this.Property(t => t.uv_cash_per).HasColumnName("uv_cash_per");
            this.Property(t => t.conv).HasColumnName("conv");
            this.Property(t => t.nc_conv_per).HasColumnName("nc_conv_per");
            this.Property(t => t.nt_conv_per).HasColumnName("nt_conv_per");
            this.Property(t => t.ns_conv_per).HasColumnName("ns_conv_per");
            this.Property(t => t.uv_conv_per).HasColumnName("uv_conv_per");
            this.Property(t => t.rbf).HasColumnName("rbf");
            this.Property(t => t.nc_rbf_per).HasColumnName("nc_rbf_per");
            this.Property(t => t.nt_rbf_per).HasColumnName("nt_rbf_per");
            this.Property(t => t.ns_rbf_per).HasColumnName("ns_rbf_per");
            this.Property(t => t.uv_rbf_per).HasColumnName("uv_rbf_per");
            this.Property(t => t.osf).HasColumnName("osf");
            this.Property(t => t.nc_osf_per).HasColumnName("nc_osf_per");
            this.Property(t => t.nt_osf_per).HasColumnName("nt_osf_per");
            this.Property(t => t.ns_osf_per).HasColumnName("ns_osf_per");
            this.Property(t => t.uv_osf_per).HasColumnName("uv_osf_per");
            this.Property(t => t.ave_nc_front).HasColumnName("ave_nc_front");
            this.Property(t => t.ave_nt_front).HasColumnName("ave_nt_front");
            this.Property(t => t.ave_ns_front).HasColumnName("ave_ns_front");
            this.Property(t => t.ave_nv_front).HasColumnName("ave_nv_front");
            this.Property(t => t.ave_uv_front).HasColumnName("ave_uv_front");
            this.Property(t => t.ave_nc_back).HasColumnName("ave_nc_back");
            this.Property(t => t.ave_nt_back).HasColumnName("ave_nt_back");
            this.Property(t => t.ave_ns_back).HasColumnName("ave_ns_back");
            this.Property(t => t.ave_nv_back).HasColumnName("ave_nv_back");
            this.Property(t => t.ave_uv_back).HasColumnName("ave_uv_back");
            this.Property(t => t.tot_income).HasColumnName("tot_income");
            this.Property(t => t.avg_front).HasColumnName("avg_front");
            this.Property(t => t.avg_fi_gross).HasColumnName("avg_fi_gross");
            this.Property(t => t.avg_f_b).HasColumnName("avg_f_b");
        }
    }
}
