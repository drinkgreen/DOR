﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DORv3.Domain
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class FowlerDOR : DbContext
    {
        public FowlerDOR()
            : base("name=FowlerDOR")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<MasterFI> MasterFIs { get; set; }
        public virtual DbSet<BUSINESSSOURCE> BUSINESSSOURCEs { get; set; }
        public virtual DbSet<DealerShip> DealerShips { get; set; }
        public virtual DbSet<Deal> Deals { get; set; }
        public virtual DbSet<DealsbyFinMgr> DealsbyFinMgrs { get; set; }
        public virtual DbSet<DealsDetail> DealsDetails { get; set; }
        public virtual DbSet<DealStatu> DealStatus { get; set; }
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
        public virtual DbSet<Year> Years { get; set; }
    
        [DbFunction("FowlerDOR", "fn_GetWorkingDayCounts")]
        public virtual IQueryable<fn_GetWorkingDayCounts_Result> fn_GetWorkingDayCounts(Nullable<System.DateTime> date)
        {
            var dateParameter = date.HasValue ?
                new ObjectParameter("date", date) :
                new ObjectParameter("date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fn_GetWorkingDayCounts_Result>("[FowlerDOR].[fn_GetWorkingDayCounts](@date)", dateParameter);
        }
    
        [DbFunction("FowlerDOR", "fn_RecapReportMaster")]
        public virtual IQueryable<fn_RecapReportMaster_Result> fn_RecapReportMaster(Nullable<int> dealership, string startdate, string enddate)
        {
            var dealershipParameter = dealership.HasValue ?
                new ObjectParameter("dealership", dealership) :
                new ObjectParameter("dealership", typeof(int));
    
            var startdateParameter = startdate != null ?
                new ObjectParameter("startdate", startdate) :
                new ObjectParameter("startdate", typeof(string));
    
            var enddateParameter = enddate != null ?
                new ObjectParameter("enddate", enddate) :
                new ObjectParameter("enddate", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fn_RecapReportMaster_Result>("[FowlerDOR].[fn_RecapReportMaster](@dealership, @startdate, @enddate)", dealershipParameter, startdateParameter, enddateParameter);
        }
    
        [DbFunction("FowlerDOR", "fn_RecapSalesByFinType")]
        public virtual IQueryable<fn_RecapSalesByFinType_Result> fn_RecapSalesByFinType(Nullable<int> dealership, Nullable<int> fintype, string startdate, string enddate)
        {
            var dealershipParameter = dealership.HasValue ?
                new ObjectParameter("dealership", dealership) :
                new ObjectParameter("dealership", typeof(int));
    
            var fintypeParameter = fintype.HasValue ?
                new ObjectParameter("fintype", fintype) :
                new ObjectParameter("fintype", typeof(int));
    
            var startdateParameter = startdate != null ?
                new ObjectParameter("startdate", startdate) :
                new ObjectParameter("startdate", typeof(string));
    
            var enddateParameter = enddate != null ?
                new ObjectParameter("enddate", enddate) :
                new ObjectParameter("enddate", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fn_RecapSalesByFinType_Result>("[FowlerDOR].[fn_RecapSalesByFinType](@dealership, @fintype, @startdate, @enddate)", dealershipParameter, fintypeParameter, startdateParameter, enddateParameter);
        }
    
        [DbFunction("FowlerDOR", "fn_RecapUnAssignedProductTotals")]
        public virtual IQueryable<fn_RecapUnAssignedProductTotals_Result> fn_RecapUnAssignedProductTotals(string startdate, string enddate, Nullable<int> dealership)
        {
            var startdateParameter = startdate != null ?
                new ObjectParameter("startdate", startdate) :
                new ObjectParameter("startdate", typeof(string));
    
            var enddateParameter = enddate != null ?
                new ObjectParameter("enddate", enddate) :
                new ObjectParameter("enddate", typeof(string));
    
            var dealershipParameter = dealership.HasValue ?
                new ObjectParameter("dealership", dealership) :
                new ObjectParameter("dealership", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fn_RecapUnAssignedProductTotals_Result>("[FowlerDOR].[fn_RecapUnAssignedProductTotals](@startdate, @enddate, @dealership)", startdateParameter, enddateParameter, dealershipParameter);
        }
    
        public virtual ObjectResult<FinanceRecapObject> Get_Finance_Recap(string startdate, string enddate)
        {
            var startdateParameter = startdate != null ?
                new ObjectParameter("startdate", startdate) :
                new ObjectParameter("startdate", typeof(string));
    
            var enddateParameter = enddate != null ?
                new ObjectParameter("enddate", enddate) :
                new ObjectParameter("enddate", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FinanceRecapObject>("Get_Finance_Recap", startdateParameter, enddateParameter);
        }
    
        public virtual ObjectResult<MonthToDateObject> Get_MTD_18(string startdate, string enddate, Nullable<int> dealerID, string vehicletype)
        {
            var startdateParameter = startdate != null ?
                new ObjectParameter("startdate", startdate) :
                new ObjectParameter("startdate", typeof(string));
    
            var enddateParameter = enddate != null ?
                new ObjectParameter("enddate", enddate) :
                new ObjectParameter("enddate", typeof(string));
    
            var dealerIDParameter = dealerID.HasValue ?
                new ObjectParameter("dealerID", dealerID) :
                new ObjectParameter("dealerID", typeof(int));
    
            var vehicletypeParameter = vehicletype != null ?
                new ObjectParameter("vehicletype", vehicletype) :
                new ObjectParameter("vehicletype", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MonthToDateObject>("Get_MTD_18", startdateParameter, enddateParameter, dealerIDParameter, vehicletypeParameter);
        }
    
        public virtual ObjectResult<SalesRecapObject> get_sales_recap(string startdate, string enddate)
        {
            var startdateParameter = startdate != null ?
                new ObjectParameter("startdate", startdate) :
                new ObjectParameter("startdate", typeof(string));
    
            var enddateParameter = enddate != null ?
                new ObjectParameter("enddate", enddate) :
                new ObjectParameter("enddate", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SalesRecapObject>("get_sales_recap", startdateParameter, enddateParameter);
        }
    
        public virtual int get_sales_recap_2(string startdate, string enddate)
        {
            var startdateParameter = startdate != null ?
                new ObjectParameter("startdate", startdate) :
                new ObjectParameter("startdate", typeof(string));
    
            var enddateParameter = enddate != null ?
                new ObjectParameter("enddate", enddate) :
                new ObjectParameter("enddate", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("get_sales_recap_2", startdateParameter, enddateParameter);
        }
    
        public virtual int Update_Salesboard(Nullable<int> dealerID, Nullable<System.DateTime> date)
        {
            var dealerIDParameter = dealerID.HasValue ?
                new ObjectParameter("dealerID", dealerID) :
                new ObjectParameter("dealerID", typeof(int));
    
            var dateParameter = date.HasValue ?
                new ObjectParameter("date", date) :
                new ObjectParameter("date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Update_Salesboard", dealerIDParameter, dateParameter);
        }
    
        public virtual ObjectResult<usp_String_or_binary_data_truncated_Result> usp_String_or_binary_data_truncated(string @string)
        {
            var stringParameter = @string != null ?
                new ObjectParameter("String", @string) :
                new ObjectParameter("String", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_String_or_binary_data_truncated_Result>("usp_String_or_binary_data_truncated", stringParameter);
        }
    
        public virtual int wipe_mtd()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("wipe_mtd");
        }
    
        public virtual ObjectResult<SalesboardObject> Get_Salesboard(Nullable<System.DateTime> date)
        {
            var dateParameter = date.HasValue ?
                new ObjectParameter("date", date) :
                new ObjectParameter("date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SalesboardObject>("Get_Salesboard", dateParameter);
        }
    
        public virtual ObjectResult<NU_ReportObject> Get_NU_Report(string startdate, string enddate, Nullable<int> dealership)
        {
            var startdateParameter = startdate != null ?
                new ObjectParameter("startdate", startdate) :
                new ObjectParameter("startdate", typeof(string));
    
            var enddateParameter = enddate != null ?
                new ObjectParameter("enddate", enddate) :
                new ObjectParameter("enddate", typeof(string));
    
            var dealershipParameter = dealership.HasValue ?
                new ObjectParameter("dealership", dealership) :
                new ObjectParameter("dealership", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<NU_ReportObject>("Get_NU_Report", startdateParameter, enddateParameter, dealershipParameter);
        }
    
        public virtual ObjectResult<DOR1234Object> get_dor1234(string startdate, string enddate)
        {
            var startdateParameter = startdate != null ?
                new ObjectParameter("startdate", startdate) :
                new ObjectParameter("startdate", typeof(string));
    
            var enddateParameter = enddate != null ?
                new ObjectParameter("enddate", enddate) :
                new ObjectParameter("enddate", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DOR1234Object>("get_dor1234", startdateParameter, enddateParameter);
        }
    
        public virtual ObjectResult<sp_GetDealsSummary_Result> sp_GetDealsSummary()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetDealsSummary_Result>("sp_GetDealsSummary");
        }
    }
}
