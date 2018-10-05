using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class MasterFIMap : EntityTypeConfiguration<MasterFI>
    {
        public MasterFIMap()
        {
            // Primary Key
            this.HasKey(t => t.MasterFiId);

            // Properties
            this.Property(t => t.buyerlname)
                .HasMaxLength(50);

            this.Property(t => t.buyerfname)
                .HasMaxLength(50);

            this.Property(t => t.cobuyerlname)
                .HasMaxLength(50);

            this.Property(t => t.cobuyerfname)
                .HasMaxLength(50);

            this.Property(t => t.vehicle)
                .HasMaxLength(50);

            this.Property(t => t.vehicletype)
                .HasMaxLength(50);

            this.Property(t => t.otherbusinesssource)
                .HasMaxLength(50);

            this.Property(t => t.intent)
                .HasMaxLength(50);

            this.Property(t => t.turnoption)
                .HasMaxLength(50);

            this.Property(t => t.dealnum)
                .HasMaxLength(50);

            this.Property(t => t.stocknum)
                .HasMaxLength(50);

            this.Property(t => t.make)
                .HasMaxLength(50);

            this.Property(t => t.model)
                .HasMaxLength(50);

            this.Property(t => t.makeother)
                .HasMaxLength(50);

            this.Property(t => t.modelother)
                .HasMaxLength(50);

            this.Property(t => t.trade1make)
                .HasMaxLength(50);

            this.Property(t => t.trade1model)
                .HasMaxLength(50);

            this.Property(t => t.trade1makeother)
                .HasMaxLength(50);

            this.Property(t => t.trade1modelother)
                .HasMaxLength(50);

            this.Property(t => t.trade1intent)
                .HasMaxLength(50);

            this.Property(t => t.trade1title)
                .HasMaxLength(50);

            this.Property(t => t.trade1lien)
                .HasMaxLength(50);

            this.Property(t => t.trade2make)
                .HasMaxLength(50);

            this.Property(t => t.trade2model)
                .HasMaxLength(50);

            this.Property(t => t.trade2makeother)
                .HasMaxLength(50);

            this.Property(t => t.trade2modelother)
                .HasMaxLength(50);

            this.Property(t => t.trade2intent)
                .HasMaxLength(50);

            this.Property(t => t.trade2title)
                .HasMaxLength(50);

            this.Property(t => t.trade2lien)
                .HasMaxLength(50);

            this.Property(t => t.salesperson1per)
                .HasMaxLength(50);

            this.Property(t => t.salesperson2per)
                .HasMaxLength(50);

            this.Property(t => t.salesperson3per)
                .HasMaxLength(50);

            this.Property(t => t.fitype)
                .HasMaxLength(50);

            this.Property(t => t.fipaymentin)
                .HasMaxLength(50);

            this.Property(t => t.fipaymentout)
                .HasMaxLength(50);

            this.Property(t => t.fitermin)
                .HasMaxLength(50);

            this.Property(t => t.fitermout)
                .HasMaxLength(50);

            this.Property(t => t.lienholder)
                .IsRequired();

            this.Property(t => t.vscoption)
                .HasMaxLength(50);

            this.Property(t => t.datetoacct)
                .HasMaxLength(50);

            this.Property(t => t.bookeddate)
                .HasMaxLength(50);

            this.Property(t => t.datetotag)
                .HasMaxLength(50);

            this.Property(t => t.datetobank)
                .HasMaxLength(50);

            this.Property(t => t.datepaid)
                .HasMaxLength(50);

            this.Property(t => t.sectrade)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MasterFIs");
            this.Property(t => t.MasterFiId).HasColumnName("MasterFiId");
            this.Property(t => t.DORid).HasColumnName("DORid");
            this.Property(t => t.Dealerid).HasColumnName("Dealerid");
            this.Property(t => t.buyerlname).HasColumnName("buyerlname");
            this.Property(t => t.buyerfname).HasColumnName("buyerfname");
            this.Property(t => t.cobuyerlname).HasColumnName("cobuyerlname");
            this.Property(t => t.cobuyerfname).HasColumnName("cobuyerfname");
            this.Property(t => t.vehicle).HasColumnName("vehicle");
            this.Property(t => t.vehicleid).HasColumnName("vehicleid");
            this.Property(t => t.vehicletype).HasColumnName("vehicletype");
            this.Property(t => t.vehicletypeid).HasColumnName("vehicletypeid");
            this.Property(t => t.businesssource).HasColumnName("businesssource");
            this.Property(t => t.otherbusinesssource).HasColumnName("otherbusinesssource");
            this.Property(t => t.salescategory).HasColumnName("salescategory");
            this.Property(t => t.status).HasColumnName("status");
            this.Property(t => t.intent).HasColumnName("intent");
            this.Property(t => t.turnoption).HasColumnName("turnoption");
            this.Property(t => t.daysinstock).HasColumnName("daysinstock");
            this.Property(t => t.dealnum).HasColumnName("dealnum");
            this.Property(t => t.stocknum).HasColumnName("stocknum");
            this.Property(t => t.make).HasColumnName("make");
            this.Property(t => t.model).HasColumnName("model");
            this.Property(t => t.makeother).HasColumnName("makeother");
            this.Property(t => t.modelother).HasColumnName("modelother");
            this.Property(t => t.year).HasColumnName("year");
            this.Property(t => t.mileage).HasColumnName("mileage");
            this.Property(t => t.salesdate).HasColumnName("salesdate");
            this.Property(t => t.gross).HasColumnName("gross");
            this.Property(t => t.holdback).HasColumnName("holdback");
            this.Property(t => t.payablegross).HasColumnName("payablegross");
            this.Property(t => t.frontendgross).HasColumnName("frontendgross");
            this.Property(t => t.trade1status).HasColumnName("trade1status");
            this.Property(t => t.trade1make).HasColumnName("trade1make");
            this.Property(t => t.trade1model).HasColumnName("trade1model");
            this.Property(t => t.trade1makeother).HasColumnName("trade1makeother");
            this.Property(t => t.trade1modelother).HasColumnName("trade1modelother");
            this.Property(t => t.trade1year).HasColumnName("trade1year");
            this.Property(t => t.trade1mileage).HasColumnName("trade1mileage");
            this.Property(t => t.trade1intent).HasColumnName("trade1intent");
            this.Property(t => t.trade1title).HasColumnName("trade1title");
            this.Property(t => t.trade1lien).HasColumnName("trade1lien");
            this.Property(t => t.trade1acv).HasColumnName("trade1acv");
            this.Property(t => t.trade1payoff).HasColumnName("trade1payoff");
            this.Property(t => t.trade1equity).HasColumnName("trade1equity");
            this.Property(t => t.trade2status).HasColumnName("trade2status");
            this.Property(t => t.trade2make).HasColumnName("trade2make");
            this.Property(t => t.trade2model).HasColumnName("trade2model");
            this.Property(t => t.trade2makeother).HasColumnName("trade2makeother");
            this.Property(t => t.trade2modelother).HasColumnName("trade2modelother");
            this.Property(t => t.trade2year).HasColumnName("trade2year");
            this.Property(t => t.trade2mileage).HasColumnName("trade2mileage");
            this.Property(t => t.trade2intent).HasColumnName("trade2intent");
            this.Property(t => t.trade2title).HasColumnName("trade2title");
            this.Property(t => t.trade2lien).HasColumnName("trade2lien");
            this.Property(t => t.trade2acv).HasColumnName("trade2acv");
            this.Property(t => t.trade2payoff).HasColumnName("trade2payoff");
            this.Property(t => t.trade2equity).HasColumnName("trade2equity");
            this.Property(t => t.salesmanager).HasColumnName("salesmanager");
            this.Property(t => t.salesperson1).HasColumnName("salesperson1");
            this.Property(t => t.salesperson1per).HasColumnName("salesperson1per");
            this.Property(t => t.salesperson2).HasColumnName("salesperson2");
            this.Property(t => t.salesperson2per).HasColumnName("salesperson2per");
            this.Property(t => t.salesperson3).HasColumnName("salesperson3");
            this.Property(t => t.salesperson3per).HasColumnName("salesperson3per");
            this.Property(t => t.fimanager).HasColumnName("fimanager");
            this.Property(t => t.fitype).HasColumnName("fitype");
            this.Property(t => t.fipaymentin).HasColumnName("fipaymentin");
            this.Property(t => t.fipaymentout).HasColumnName("fipaymentout");
            this.Property(t => t.fitermin).HasColumnName("fitermin");
            this.Property(t => t.fitermout).HasColumnName("fitermout");
            this.Property(t => t.ficashdown).HasColumnName("ficashdown");
            this.Property(t => t.lienholder).HasColumnName("lienholder");
            this.Property(t => t.price).HasColumnName("price");
            this.Property(t => t.delvdate).HasColumnName("delvdate");
            this.Property(t => t.gradecreditid).HasColumnName("gradecreditid");
            this.Property(t => t.gradecredit).HasColumnName("gradecredit");
            this.Property(t => t.gap).HasColumnName("gap");
            this.Property(t => t.enviro).HasColumnName("enviro");
            this.Property(t => t.etch).HasColumnName("etch");
            this.Property(t => t.dent).HasColumnName("dent");
            this.Property(t => t.tirewheel).HasColumnName("tirewheel");
            this.Property(t => t.cl).HasColumnName("cl");
            this.Property(t => t.ah).HasColumnName("ah");
            this.Property(t => t.vsc).HasColumnName("vsc");
            this.Property(t => t.vscoption).HasColumnName("vscoption");
            this.Property(t => t.TBD).HasColumnName("TBD");
            this.Property(t => t.Maint).HasColumnName("Maint");
            this.Property(t => t.finresv).HasColumnName("finresv");
            this.Property(t => t.frontend).HasColumnName("frontend");
            this.Property(t => t.backend).HasColumnName("backend");
            this.Property(t => t.totalgross).HasColumnName("totalgross");
            this.Property(t => t.creditscore).HasColumnName("creditscore");
            this.Property(t => t.datetoacct).HasColumnName("datetoacct");
            this.Property(t => t.bookeddate).HasColumnName("bookeddate");
            this.Property(t => t.unwinddate).HasColumnName("unwinddate");
            this.Property(t => t.datetotag).HasColumnName("datetotag");
            this.Property(t => t.datetobank).HasColumnName("datetobank");
            this.Property(t => t.datepaid).HasColumnName("datepaid");
            this.Property(t => t.sectrade).HasColumnName("sectrade");
            this.Property(t => t.amt_fin).HasColumnName("amt_fin");
            this.Property(t => t.fintype).HasColumnName("fintype");
            this.Property(t => t.EnteredDt).HasColumnName("EnteredDt");
            this.Property(t => t.UpdatedDt).HasColumnName("UpdatedDt");
        }
    }
}
