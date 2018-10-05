using DORv3.BLL.BusinessObjects;
using DORv3.BLL.FilterObjects;
using DORv3.BLL.ReportObjects;
using DORv3.DAL.Models;
using QueryDesigner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;

namespace DORv3.BLL
{
    public class MTDRecapBiz
    {
        private FowlerDORContext context;
        private IList<MasterFIRecord> mFIs;
        private int dealerID;

        private List<int> DealerIDs { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DealerShip Dealership { get; set; }
        public List<DealerShip> Dealerships { get; set; }
        public string vehicleType { get; set; }
        //private List<TreeFilter> Master_Filters { get; set; }
        //private List<TreeFilter> OI_Filters { get; set; }
        //private FilterContainer MasterFilters { get; set; }
        //private FilterContainer OIFilters { get; set; }
        public VehicleType VehicleType { get; set;}
        public List<VehicleType> VehicleTypes { get; private set; }
        public List<DealStatu> DealStatuses { get; set; }
        public List<Vehicle> VehicleKinds { get; set; }
        public List<SalesCategory> SalesCategories { get; set; }
        public List<MTDFilterObj> ReportFilters { get; private set; }
        public List<FinanceManager> FinanceManagers { get; set; }
        public List<SalesManager> SalesManagers { get; set; }
        public List<SalesPerson> SalesPeople { get; set; }
        public List<BUSINESSSOURCE> BusinessSources { get; set; }

        public MTDRecapBiz(List<int> dealerIDs, DateTime startDate, DateTime endDate, int dealerID, List<MTDFilterObj> filters)
        {
            context = new FowlerDORContext();
            this.Dealerships = context.DealerShips.Where(d => dealerIDs.Contains(d.DealerID)).ToList();
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.ReportFilters = filters;
            this.DealerIDs = dealerIDs;
            //this.VehicleType = type;
            //this.Master_Filters = filters;
            //this.OI_Filters = filters;
            GetDealerships(dealerID);
            GetVehicleTypes();
            GetDealStatuses();
            GetVehicleKinds();
            GetBusinessSources();
            GetSalesCategories();
            GetFinanceManagers();
            GetSalesManagers();
            GetSalesPeople();
            //AddMasterFilters();
           // AddOIFilters();
        }

        public MTDRecapBiz(List<int> dealerIDs, DateTime startDate, DateTime endDate, int dealerID, string vehicleType)
        {
            context = new FowlerDORContext();
            this.Dealerships = context.DealerShips.Where(d => dealerIDs.Contains(d.DealerID)).ToList();
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.DealerIDs = dealerIDs;
            this.dealerID = dealerID;
            this.vehicleType = vehicleType;
            GetDealerships(dealerID);
            if (vehicleType != "")
            {
                GetVehicleTypes();
            }
            else
            {
                GetVehicleTypes(vehicleType);
            }
            
            GetDealStatuses();
            GetVehicleKinds();
            GetBusinessSources();
            GetSalesCategories();
            GetFinanceManagers();
            GetSalesManagers();
            GetSalesPeople();

            this.ReportFilters = new List<MTDFilterObj>();

            // MasterFilters = null;
            //OIFilters = null;

        }


        public List<MTDReportObject> BuildMTDReport()
        {
            List<MTDReportObject> report = new List<MTDReportObject>();
            this.mFIs = GetMasterFIs();
            ProcessFilters();

            //var masterQuery = context.MasterFIs.Where(m => m.Dealerid == Dealership.DealerID && m.salescategory != "6"
            //                && ((m.salesdate >= StartDate && m.salesdate <= EndDate)
            //                || (m.unwinddate >= StartDate && m.unwinddate <= EndDate))
            //                ).ToList();

            var masterQuery = mFIs.ToList();

            List<OtherIncome> oiQuery = new List<OtherIncome>();
            if (Dealership == null || Dealership.DealerID == 0)
            {
                oiQuery = context.OtherIncomes.Where(o => DealerIDs.Contains((int)o.DealerId)
                             && (o.AdjDate >= StartDate && o.AdjDate <= EndDate)).ToList();
            }
            else
            {
                oiQuery = context.OtherIncomes.Where(o => o.DealerId == Dealership.DealerID
                                             && (o.AdjDate >= StartDate && o.AdjDate <= EndDate)).ToList();
            }

            //if (MasterFilters != null)
            //{
            //    //var masterQuery2 = context.MasterFIs.Where(m => (
            //    //            (m.salesdate >= StartDate && m.salesdate <= EndDate) || (m.unwinddate >= StartDate && m.unwinddate <= EndDate)
            //    //            )).Where("VehicleType=@0","N").ToList();

            //    masterQuery = masterQuery.Where()
            //        //.Where("VehicleType=@0", "N").ToList();
            //}

            //if (vehicleType != null && vehicleType != "All")
            //{
            //    masterQuery = masterQuery.Where(m => m.vehicletype == this.vehicleType).ToList();
            //    //oiQuery.Where(o=>o.VehicleTypeId)
            //}


            //var oiQuery2 = context.OtherIncomes.Request(OIFilters).ToList();


            MTDReportObject mtdObj = null;
            int rowCount = 0;
            foreach(var record in masterQuery)
            {
                mtdObj = new MTDReportObject();
                var mRecord = record.Record;
                rowCount += 1;
                
                mtdObj.rownum = rowCount;
                mtdObj.dealerID = mRecord.Dealerid;
                //mtdObj.deal_id = mRecord.dealnum;
                mtdObj.deal_status = context.DealStatus.Where(s => s.StatusId == mRecord.status).Select(s => s.StatusName).FirstOrDefault();
                mtdObj.deal_delv_date = mRecord.salesdate.ToShortDateString();
                mtdObj.deal_stck_num = mRecord.stocknum;
                mtdObj.deal_mileage = mRecord.mileage;
                mtdObj.deal_customer = mRecord.buyerlname;
                mtdObj.deal_year = mRecord.year;
                mtdObj.deal_new_used = mRecord.vehicletype;
                mtdObj.deal_FIMgr = context.FinanceManagers.Where(f => f.FMId == mRecord.fimanager).Select(f => f.FMName).FirstOrDefault();
                mtdObj.deal_sp_1 = context.SalesPersons.Where(sp1 => sp1.ID == mRecord.salesperson1).Select(sp1 => sp1.SPName).FirstOrDefault();
                //mtdObj.deal_sp_2 = context.SalesPersons.Where(sp2 => sp2.SPtoMasterId.ToString() == mRecord.salesperson2).Select(sp2 => sp2.SPName).FirstOrDefault();
                mtdObj.deal_fin_type = context.FinanceTypes.Where(f => f.FinanceTypeId.ToString() == mRecord.fitype).Select(f => f.FinanceType1).FirstOrDefault();
                mtdObj.deal_trade_year = mRecord.trade1year;
                mtdObj.deal_trade_model = mRecord.trade1model;
                mtdObj.deal_title_status = 1;
                mtdObj.deal_trade_value = mRecord.trade1acv;
                mtdObj.deal_dent = mRecord.dent;
                mtdObj.deal_windsh = mRecord.Maint;
                mtdObj.deal_cl = mRecord.cl;
                mtdObj.deal_ah = mRecord.ah;
                mtdObj.deal_map = (mRecord.vscoption == "Map"? mRecord.vsc : 0);
                mtdObj.deal_warr = mRecord.Maint;
                mtdObj.deal_gap = mRecord.gap;
                mtdObj.deal_etch = mRecord.etch;
                mtdObj.deal_tw = mRecord.tirewheel;
                mtdObj.deal_enviro = mRecord.enviro;
                mtdObj.deal_fin = mRecord.finresv;
                mtdObj.deal_frnt_end = Math.Round((decimal)mRecord.payablegross,0);
                mtdObj.deal_back_end = Math.Round((decimal)mRecord.backend, 0);
                mtdObj.deal_tot_tot = Math.Round((decimal)mRecord.totalgross, 0);

                report.Add(mtdObj);
            }
            int activeDealCount = rowCount;
            foreach (var oRecord in oiQuery)
            {
                mtdObj = new MTDReportObject();
                rowCount += 1;
                mtdObj.rownum = rowCount;
                mtdObj.dealerID = (int)oRecord.DealerId;
                //mtdObj.deal_id = oRecord.DealNum.ToString();
                mtdObj.deal_status = oRecord.OtherType == "OI" ? "Other Income" : "Adj.";
                mtdObj.deal_delv_date = oRecord.SaleDate.HasValue ? oRecord.SaleDate.Value.ToShortDateString() : "";
                mtdObj.deal_customer = oRecord.lname1;
                mtdObj.deal_new_used = context.VehicleTypes.Where(oi => oi.VehicleTypeId == oRecord.VehicleTypeId).Select(oi => oi.VehicleType1).First().ToString().Substring(0, 1);
                mtdObj.deal_FIMgr = context.FinanceManagers.Where(f => f.FMId == oRecord.FinanceManagerId).Select(f => f.FMName).FirstOrDefault();
                mtdObj.deal_frnt_end = Math.Round((decimal)oRecord.PAmount, 0);

                report.Add(mtdObj);
            }

            if (rowCount > 0)
            {
                var totals = report.Select(r => new
                {
                    ACV = r.deal_trade_value,
                    Dent = r.deal_dent,
                    Windsh = r.deal_windsh,
                    CL = r.deal_cl,
                    AH = r.deal_ah,
                    Map = r.deal_map,
                    Warr = r.deal_warr,
                    Gap = r.deal_gap,
                    Etch = r.deal_etch,
                    TW = r.deal_tw,
                    //key
                    //SmartNote
                    Enviro = r.deal_enviro,
                    Fin = r.deal_fin,
                    FrontEnd = r.deal_frnt_end,
                    BackEnd = r.deal_back_end,
                    Total = r.deal_tot_tot

                });

                report.Add(new MTDReportObject
                {
                    rownum = activeDealCount,
                    deal_trade_value = totals.Select(t => t.ACV).Sum(),
                    deal_dent = totals.Select(t => t.Dent).Sum(),
                    deal_windsh = totals.Select(t => t.Windsh).Sum(),
                    deal_cl = totals.Select(t => t.CL).Sum(),
                    deal_ah = totals.Select(t => t.AH).Sum(),
                    deal_map = totals.Select(t => t.Map).Sum(),
                    deal_warr = totals.Select(t => t.Warr).Sum(),
                    deal_gap = totals.Select(t => t.Gap).Sum(),
                    deal_etch = totals.Select(t => t.Etch).Sum(),
                    deal_tw = totals.Select(t => t.TW).Sum(),
                    deal_enviro = totals.Select(t => t.Enviro).Sum(),
                    deal_fin = totals.Select(t => t.Fin).Sum(),
                    deal_frnt_end = totals.Select(t => t.FrontEnd).Sum(),
                    deal_back_end = totals.Select(t => t.BackEnd).Sum(),
                    deal_tot_tot = totals.Select(t => t.Total).Sum()
                });
            }
            

            return report;
        }

        private void ProcessFilters()
        {
            foreach(var filter in ReportFilters)
            {
                string whereString = "";
                switch(filter.Property)
                {
                    case "Dealer":
                        whereString = "Record.Dealerid = @0";
                        break;
                    case "VehicleType":
                        whereString = "Record.vehicletypeid = @0";
                        break;
                    case "DealStatus":
                        whereString = "Record.status = @0";
                        break;
                    case "VehicleKind":
                        whereString = "Record.vehicleId = @0";
                        break;
                    case "SalesCategory":
                        whereString = "Record.salescategory = @0";
                        break;
                    case "BusinessSource":
                        whereString = "Record.businesssource = @0";
                        break;
                    case "SalesManager":
                        whereString = "Record.salesmanager = @0";
                        break;
                    case "SalesPerson":
                        whereString = "(Record.salesperson1 = @0 || Record.salesperson2 = @0 || Record.salesperson3 = @0)";
                        break;
                    case "FinanceManager":
                        whereString = "Record.fimanager = @0";
                        break;
                    default:
                        break;
                }

                if (whereString != "")
                {
                    mFIs = mFIs.Where(whereString, filter.Value).ToList();
                }
                
            }
        }

        private IList<MasterFIRecord> GetMasterFIs()
        {
            return context.MasterFIs
                .Where(m => new int[] { 4,5,6,7,9 }.Contains(m.status)
                        && ((m.delvdate >= StartDate && m.delvdate <= EndDate)
                            || (m.delvdate == new DateTime(1900, 1, 1) && m.salesdate >= StartDate && m.salesdate <= EndDate)))
                 .Select(d => new MasterFIRecord
                 {
                     RecordType = "M",
                     Record = d
                 }).ToList();
        }

        //private void AddMasterFilters()
        //{
        //    MasterFilters = new FilterContainer
        //    {
        //        Where = new TreeFilter
        //        {
        //            OperatorType = TreeFilterType.And,
        //            Operands = Master_Filters
        //        }
        //    };
        //}

        //private void AddOIFilters()
        //{
        //    OIFilters = new FilterContainer
        //    {
        //        Where = new TreeFilter
        //        {
        //            OperatorType = TreeFilterType.And,
        //            Operands = OI_Filters
        //        }
        //    };
        //}

        private void GetDealerships(int dealerID)
        {
           // this.Dealerships = context.DealerShips.ToList();
            this.Dealership = Dealerships.Where(d => d.DealerID == dealerID).FirstOrDefault();
        }

        private void GetVehicleTypes()
        {
            this.VehicleTypes = context.VehicleTypes.ToList();
        }

        private void GetVehicleTypes(string vehicleType)
        {
            GetVehicleTypes();
            this.VehicleType = VehicleTypes.Where(v => v.VehicleType1 == vehicleType).FirstOrDefault();
        }

        private void GetDealStatuses()
        {
            this.DealStatuses = context.DealStatus.ToList();
        }

        private void GetVehicleKinds()
        {
            this.VehicleKinds = context.Vehicles.Where(v=>v.DisableDate == null).ToList();
        }

        private void GetBusinessSources()
        {
            this.BusinessSources = context.BUSINESSSOURCEs.ToList();
        }

        private void GetSalesCategories()
        {
            this.SalesCategories = context.SalesCategories.ToList();
        }

        private void GetFinanceManagers()
        {
            this.FinanceManagers = context.FinanceManagers.ToList();
        }
        private void GetSalesPeople()
        {
            this.SalesPeople = context.SalesPersons.ToList();
        }

        private void GetSalesManagers()
        {
            this.SalesManagers = context.SalesManagers.ToList();
        }
    }
}