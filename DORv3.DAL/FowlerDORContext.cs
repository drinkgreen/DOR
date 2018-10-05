
namespace DORv3.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FowlerDORContext : DbContext
    {
        public FowlerDORContext()
            : base("name=FowlerDORContext")
        {
        }

        public virtual DbSet<MasterFI> MasterFIs { get; set; }
        public virtual DbSet<BUSINESSSOURCE> BUSINESSSOURCEs { get; set; }
        public virtual DbSet<DealerShip> DealerShips { get; set; }
        public virtual DbSet<Deal> Deals { get; set; }
        public virtual DbSet<DealsbyFinMgr> DealsbyFinMgrs { get; set; }
        public virtual DbSet<DealsDetail> DealsDetails { get; set; }
        public virtual DbSet<DealStatus> DealStatus { get; set; }
        public virtual DbSet<DOR_import> DOR_import { get; set; }
        public virtual DbSet<DORHistory> DORHistories { get; set; }
        public virtual DbSet<DORLienHolder> DORLienHolders { get; set; }
        public virtual DbSet<DORProduct> DORProducts { get; set; }
        public virtual DbSet<FinanceManager> FinanceManagers { get; set; }
        public virtual DbSet<FinanceType> FinanceTypes { get; set; }
        public virtual DbSet<FindUnwidDeal> FindUnwidDeals { get; set; }
        public virtual DbSet<finmgrfix> finmgrfixes { get; set; }
        public virtual DbSet<GradeCredit> GradeCredits { get; set; }
        public virtual DbSet<Make> Makes { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<MonthlyHistory> MonthlyHistories { get; set; }
        public virtual DbSet<mtd_holder> mtd_holder { get; set; }
        public virtual DbSet<OtherIncome> OtherIncomes { get; set; }
        public virtual DbSet<OtherProduct> OtherProducts { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleScreenXRef> RoleScreenXRefs { get; set; }
        public virtual DbSet<SalesCategory> SalesCategories { get; set; }
        public virtual DbSet<SalesManager> SalesManagers { get; set; }
        public virtual DbSet<SalesPerson> SalesPersons { get; set; }
        public virtual DbSet<Screen> Screens { get; set; }
        public virtual DbSet<Security> Securities { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRoleXRef> UserRoleXRefs { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<VehicleType> VehicleTypes { get; set; }
        public virtual DbSet<viewBackout> viewBackouts { get; set; }
        public virtual DbSet<viewBackoutsDetail> viewBackoutsDetails { get; set; }
        public virtual DbSet<viewCashDealswithFinRe> viewCashDealswithFinRes { get; set; }
        public virtual DbSet<viewDeal> viewDeals { get; set; }
        public virtual DbSet<viewDealswithoutsalesmgr> viewDealswithoutsalesmgrs { get; set; }
        public virtual DbSet<viewDORProduct> viewDORProducts { get; set; }
        public virtual DbSet<viewNonCashProdforCashDeal> viewNonCashProdforCashDeals { get; set; }
        public virtual DbSet<viewScreenbytype> viewScreenbytypes { get; set; }
        public virtual DbSet<viewScreenTypeOrder> viewScreenTypeOrders { get; set; }
        public virtual DbSet<viewUnwindDateFix> viewUnwindDateFixes { get; set; }
        public virtual DbSet<viewUserRole> viewUserRoles { get; set; }
        public virtual DbSet<VSales_Recap> VSales_Recap { get; set; }
        public virtual DbSet<XRef_UserDealershipRoles> XRef_UserDealershipRoles { get; set; }
        public virtual DbSet<Year> Years { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MasterFI>()
                .Property(e => e.gross)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MasterFI>()
                .Property(e => e.holdback)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MasterFI>()
                .Property(e => e.payablegross)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MasterFI>()
                .Property(e => e.frontendgross)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MasterFI>()
                .Property(e => e.trade1acv)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MasterFI>()
                .Property(e => e.trade1payoff)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MasterFI>()
                .Property(e => e.trade1equity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MasterFI>()
                .Property(e => e.trade2acv)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MasterFI>()
                .Property(e => e.trade2payoff)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MasterFI>()
                .Property(e => e.trade2equity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MasterFI>()
                .Property(e => e.ficashdown)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MasterFI>()
                .Property(e => e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MasterFI>()
                .Property(e => e.gap)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MasterFI>()
                .Property(e => e.enviro)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MasterFI>()
                .Property(e => e.etch)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MasterFI>()
                .Property(e => e.dent)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MasterFI>()
                .Property(e => e.tirewheel)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MasterFI>()
                .Property(e => e.cl)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MasterFI>()
                .Property(e => e.ah)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MasterFI>()
                .Property(e => e.vsc)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MasterFI>()
                .Property(e => e.TBD)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MasterFI>()
                .Property(e => e.Maint)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MasterFI>()
                .Property(e => e.finresv)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MasterFI>()
                .Property(e => e.frontend)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MasterFI>()
                .Property(e => e.backend)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MasterFI>()
                .Property(e => e.totalgross)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MasterFI>()
                .Property(e => e.amt_fin)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Deal>()
                .Property(e => e.payablegross)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Deal>()
                .Property(e => e.FinReserve)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DealsbyFinMgr>()
                .Property(e => e.BEGross)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DealsDetail>()
                .Property(e => e.PAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DOR_import>()
                .Property(e => e.FEGross)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DOR_import>()
                .Property(e => e.Holdback)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DOR_import>()
                .Property(e => e.payablegross)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DOR_import>()
                .Property(e => e.Trade1ACV)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DOR_import>()
                .Property(e => e.Trade1PayOff)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DOR_import>()
                .Property(e => e.Trade1Equity)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DOR_import>()
                .Property(e => e.Trade2ACV)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DOR_import>()
                .Property(e => e.Trade2PayOff)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DOR_import>()
                .Property(e => e.Trade2Equity)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DOR_import>()
                .Property(e => e.PaymentIn)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DOR_import>()
                .Property(e => e.PaymentOut)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DOR_import>()
                .Property(e => e.CashDown)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DOR_import>()
                .Property(e => e.FinReserve)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DOR_import>()
                .Property(e => e.BEGross)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DOR_import>()
                .Property(e => e.TotGross)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DORHistory>()
                .Property(e => e.FEGross)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DORHistory>()
                .Property(e => e.Holdback)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DORHistory>()
                .Property(e => e.payablegross)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DORHistory>()
                .Property(e => e.Trade1ACV)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DORHistory>()
                .Property(e => e.Trade1PayOff)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DORHistory>()
                .Property(e => e.Trade1Equity)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DORHistory>()
                .Property(e => e.Trade2ACV)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DORHistory>()
                .Property(e => e.Trade2PayOff)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DORHistory>()
                .Property(e => e.Trade2Equity)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DORHistory>()
                .Property(e => e.PaymentIn)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DORHistory>()
                .Property(e => e.PaymentOut)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DORHistory>()
                .Property(e => e.CashDown)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DORHistory>()
                .Property(e => e.FinReserve)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DORHistory>()
                .Property(e => e.BEGross)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DORHistory>()
                .Property(e => e.TotGross)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DORProduct>()
                .Property(e => e.PAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FindUnwidDeal>()
                .Property(e => e.payablegross)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FindUnwidDeal>()
                .Property(e => e.FinReserve)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FindUnwidDeal>()
                .Property(e => e.BEGross)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FindUnwidDeal>()
                .Property(e => e.TotGross)
                .HasPrecision(19, 4);

            modelBuilder.Entity<mtd_holder>()
                .Property(e => e.deal_dent)
                .HasPrecision(19, 4);

            modelBuilder.Entity<mtd_holder>()
                .Property(e => e.deal_cl)
                .HasPrecision(19, 4);

            modelBuilder.Entity<mtd_holder>()
                .Property(e => e.deal_warr)
                .HasPrecision(19, 4);

            modelBuilder.Entity<mtd_holder>()
                .Property(e => e.deal_gap)
                .HasPrecision(19, 4);

            modelBuilder.Entity<mtd_holder>()
                .Property(e => e.deal_etch)
                .HasPrecision(19, 4);

            modelBuilder.Entity<mtd_holder>()
                .Property(e => e.deal_tw)
                .HasPrecision(19, 4);

            modelBuilder.Entity<mtd_holder>()
                .Property(e => e.deal_enviro)
                .HasPrecision(19, 4);

            modelBuilder.Entity<mtd_holder>()
                .Property(e => e.deal_fin)
                .HasPrecision(19, 4);

            modelBuilder.Entity<mtd_holder>()
                .Property(e => e.deal_frnt_end)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OtherIncome>()
                .Property(e => e.PAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<viewBackout>()
                .Property(e => e.payablegross)
                .HasPrecision(19, 4);

            modelBuilder.Entity<viewBackout>()
                .Property(e => e.BEGross)
                .HasPrecision(19, 4);

            modelBuilder.Entity<viewCashDealswithFinRe>()
                .Property(e => e.FinReserve)
                .HasPrecision(19, 4);

            modelBuilder.Entity<viewDeal>()
                .Property(e => e.payablegross)
                .HasPrecision(19, 4);

            modelBuilder.Entity<viewDeal>()
                .Property(e => e.BEGross)
                .HasPrecision(19, 4);

            modelBuilder.Entity<viewNonCashProdforCashDeal>()
                .Property(e => e.PAmount)
                .HasPrecision(19, 4);
        }
    }
}
