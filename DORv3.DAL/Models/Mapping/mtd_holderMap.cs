using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class mtd_holderMap : EntityTypeConfiguration<mtd_holder>
    {
        public mtd_holderMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.deal_id)
                .HasMaxLength(20);

            this.Property(t => t.deal_status)
                .HasMaxLength(50);

            this.Property(t => t.deal_stck_num)
                .HasMaxLength(20);

            this.Property(t => t.deal_customer)
                .HasMaxLength(50);

            this.Property(t => t.deal_new_used)
                .HasMaxLength(20);

            this.Property(t => t.deal_FIMgr)
                .HasMaxLength(50);

            this.Property(t => t.deal_sp_1)
                .HasMaxLength(60);

            this.Property(t => t.deal_sp_2)
                .HasMaxLength(60);

            this.Property(t => t.deal_fin_type)
                .HasMaxLength(50);

            this.Property(t => t.deal_trade_model)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("mtd_holder");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.deal_id).HasColumnName("deal_id");
            this.Property(t => t.deal_status).HasColumnName("deal_status");
            this.Property(t => t.deal_delv_date).HasColumnName("deal_delv_date");
            this.Property(t => t.deal_stck_num).HasColumnName("deal_stck_num");
            this.Property(t => t.deal_mileage).HasColumnName("deal_mileage");
            this.Property(t => t.deal_customer).HasColumnName("deal_customer");
            this.Property(t => t.deal_year).HasColumnName("deal_year");
            this.Property(t => t.deal_new_used).HasColumnName("deal_new_used");
            this.Property(t => t.deal_FIMgr).HasColumnName("deal_FIMgr");
            this.Property(t => t.deal_sp_1).HasColumnName("deal_sp_1");
            this.Property(t => t.deal_sp_2).HasColumnName("deal_sp_2");
            this.Property(t => t.deal_fin_type).HasColumnName("deal_fin_type");
            this.Property(t => t.deal_trade_year).HasColumnName("deal_trade_year");
            this.Property(t => t.deal_trade_model).HasColumnName("deal_trade_model");
            this.Property(t => t.deal_title_status).HasColumnName("deal_title_status");
            this.Property(t => t.deal_trade_value).HasColumnName("deal_trade_value");
            this.Property(t => t.deal_dent).HasColumnName("deal_dent");
            this.Property(t => t.deal_cl).HasColumnName("deal_cl");
            this.Property(t => t.deal_warr).HasColumnName("deal_warr");
            this.Property(t => t.deal_gap).HasColumnName("deal_gap");
            this.Property(t => t.deal_etch).HasColumnName("deal_etch");
            this.Property(t => t.deal_tw).HasColumnName("deal_tw");
            this.Property(t => t.deal_enviro).HasColumnName("deal_enviro");
            this.Property(t => t.deal_fin).HasColumnName("deal_fin");
            this.Property(t => t.deal_frnt_end).HasColumnName("deal_frnt_end");
        }
    }
}
