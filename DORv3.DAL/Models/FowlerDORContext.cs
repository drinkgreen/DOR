using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DORv3.DAL.Models.Mapping;

namespace DORv3.DAL.Models
{
    public partial class FowlerDORContext : DbContext
    {
        static FowlerDORContext()
        {
            Database.SetInitializer<FowlerDORContext>(null);
        }

        public FowlerDORContext()
            : base("Name=FowlerDORContext")
        {
        }

        public DbSet<AspNetRole> AspNetRoles { get; set; }
        public DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public DbSet<BUSINESSSOURCE> BUSINESSSOURCEs { get; set; }
        public DbSet<DealerShip> DealerShips { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<DealsbyFinMgr> DealsbyFinMgrs { get; set; }
        public DbSet<DealsDetail> DealsDetails { get; set; }
        public DbSet<DealStatu> DealStatus { get; set; }
        public DbSet<DOR_import> DOR_import { get; set; }
        public DbSet<DORHistory> DORHistories { get; set; }
        public DbSet<DORLienHolder> DORLienHolders { get; set; }
        public DbSet<DORProduct> DORProducts { get; set; }
        public DbSet<FinanceManager> FinanceManagers { get; set; }
        public DbSet<FinanceType> FinanceTypes { get; set; }
        public DbSet<FindUnwidDeal> FindUnwidDeals { get; set; }
        public DbSet<finmgrfix> finmgrfixes { get; set; }
        public DbSet<GradeCredit> GradeCredits { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<MasterFI> MasterFIs { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<MonthlyHistory> MonthlyHistories { get; set; }
        public DbSet<mtd_holder> mtd_holder { get; set; }
        public DbSet<OtherIncome> OtherIncomes { get; set; }
        public DbSet<OtherProduct> OtherProducts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Roles_OLD> Roles_OLD { get; set; }
        public DbSet<RoleScreenXRef> RoleScreenXRefs { get; set; }
        public DbSet<SalesCategory> SalesCategories { get; set; }
        public DbSet<SalesManager> SalesManagers { get; set; }
        public DbSet<SalesPerson> SalesPersons { get; set; }
        public DbSet<Screen> Screens { get; set; }
        public DbSet<Security> Securities { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<TurnOption> TurnOptions { get; set; }
        public DbSet<UserRoleXRef> UserRoleXRefs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<viewBackout> viewBackouts { get; set; }
        public DbSet<viewBackoutsDetail> viewBackoutsDetails { get; set; }
        public DbSet<viewCashDealswithFinRe> viewCashDealswithFinRes { get; set; }
        public DbSet<viewDeal> viewDeals { get; set; }
        public DbSet<viewDealswithoutsalesmgr> viewDealswithoutsalesmgrs { get; set; }
        public DbSet<viewDORProduct> viewDORProducts { get; set; }
        public DbSet<viewNonCashProdforCashDeal> viewNonCashProdforCashDeals { get; set; }
        public DbSet<viewScreenbytype> viewScreenbytypes { get; set; }
        public DbSet<viewScreenTypeOrder> viewScreenTypeOrders { get; set; }
        public DbSet<viewUnwindDateFix> viewUnwindDateFixes { get; set; }
        public DbSet<viewUserRole> viewUserRoles { get; set; }
        public DbSet<VSales_Recap> VSales_Recap { get; set; }
        public DbSet<XRef_UserDealershipRoles> XRef_UserDealershipRoles { get; set; }
        public DbSet<Year> Years { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AspNetRoleMap());
            modelBuilder.Configurations.Add(new AspNetUserClaimMap());
            modelBuilder.Configurations.Add(new AspNetUserLoginMap());
            modelBuilder.Configurations.Add(new BUSINESSSOURCEMap());
            modelBuilder.Configurations.Add(new DealerShipMap());
            modelBuilder.Configurations.Add(new DealMap());
            modelBuilder.Configurations.Add(new DealsbyFinMgrMap());
            modelBuilder.Configurations.Add(new DealsDetailMap());
            modelBuilder.Configurations.Add(new DealStatuMap());
            modelBuilder.Configurations.Add(new DOR_importMap());
            modelBuilder.Configurations.Add(new DORHistoryMap());
            modelBuilder.Configurations.Add(new DORLienHolderMap());
            modelBuilder.Configurations.Add(new DORProductMap());
            modelBuilder.Configurations.Add(new FinanceManagerMap());
            modelBuilder.Configurations.Add(new FinanceTypeMap());
            modelBuilder.Configurations.Add(new FindUnwidDealMap());
            modelBuilder.Configurations.Add(new finmgrfixMap());
            modelBuilder.Configurations.Add(new GradeCreditMap());
            modelBuilder.Configurations.Add(new MakeMap());
            modelBuilder.Configurations.Add(new MasterFIMap());
            modelBuilder.Configurations.Add(new ModelMap());
            modelBuilder.Configurations.Add(new MonthlyHistoryMap());
            modelBuilder.Configurations.Add(new mtd_holderMap());
            modelBuilder.Configurations.Add(new OtherIncomeMap());
            modelBuilder.Configurations.Add(new OtherProductMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new Roles_OLDMap());
            modelBuilder.Configurations.Add(new RoleScreenXRefMap());
            modelBuilder.Configurations.Add(new SalesCategoryMap());
            modelBuilder.Configurations.Add(new SalesManagerMap());
            modelBuilder.Configurations.Add(new SalesPersonMap());
            modelBuilder.Configurations.Add(new ScreenMap());
            modelBuilder.Configurations.Add(new SecurityMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new TurnOptionMap());
            modelBuilder.Configurations.Add(new UserRoleXRefMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new VehicleMap());
            modelBuilder.Configurations.Add(new VehicleTypeMap());
            modelBuilder.Configurations.Add(new viewBackoutMap());
            modelBuilder.Configurations.Add(new viewBackoutsDetailMap());
            modelBuilder.Configurations.Add(new viewCashDealswithFinReMap());
            modelBuilder.Configurations.Add(new viewDealMap());
            modelBuilder.Configurations.Add(new viewDealswithoutsalesmgrMap());
            modelBuilder.Configurations.Add(new viewDORProductMap());
            modelBuilder.Configurations.Add(new viewNonCashProdforCashDealMap());
            modelBuilder.Configurations.Add(new viewScreenbytypeMap());
            modelBuilder.Configurations.Add(new viewScreenTypeOrderMap());
            modelBuilder.Configurations.Add(new viewUnwindDateFixMap());
            modelBuilder.Configurations.Add(new viewUserRoleMap());
            modelBuilder.Configurations.Add(new VSales_RecapMap());
            modelBuilder.Configurations.Add(new XRef_UserDealershipRolesMap());
            modelBuilder.Configurations.Add(new YearMap());
        }
    }
}
