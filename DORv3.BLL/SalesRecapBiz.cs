using DORv3.BLL.BusinessObjects;
using DORv3.BLL.ReportObjects;
using DORv3.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.BLL
{
    public class SalesRecapBiz
    {
        private FowlerDORContext context;
        private IList<MasterFIRecord> mFIs, mUnwinds;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public SalesRecapBiz(DateTime startDate, DateTime endDate)
        {
            context = new FowlerDORContext();
            this.StartDate = startDate;
            this.EndDate = endDate;
            mFIs = GetMasterFIs();
            mUnwinds = GetUnwinds();
        }

        public List<SalesRecapReportObject> BuildSalesRecapReport(List<int> dealerIDs)
        {
            List<SalesRecapReportObject> report = new List<SalesRecapReportObject>();
            //Start Building

            var dealers = context.DealerShips.Where(d => dealerIDs.Contains(d.DealerID) && (d.DisableDate == null || d.DisableDate > StartDate)).OrderBy(d=>d.Sort).Select(d => new { Name = d.DealerName, ID = d.DealerID });
            var finTypes = context.FinanceTypes.Select(f => f.FinanceTypeId.ToString());

            SalesRecapReportObject srObj = null;

            foreach (var dealer in dealers)
            {
                srObj = new SalesRecapReportObject();
                srObj.dealership = dealer.Name;
                var id = dealer.ID;

                #region Get Vehicle Counts

                var vehicleCountQuery = (mFIs.Union(mUnwinds))
                                .Where(v => (id != 99 ? v.Record.Dealerid == id : v.Record.Dealerid > 0))
                                .Select(v => new
                                {
                                    FinType = v.Record.fitype,
                                    BackEnd = v.Record.backend,
                                    PayableGross = v.Record.payablegross,
                                    UsedVehicle = ((v.RecordType == "U") ? -1 : 1) * (v.Record.vehicletype == "U" ? 1 : 0),
                                    NewCar = ((v.RecordType == "U") ? -1 : 1) * (v.Record.vehicletype == "N" && v.Record.vehicle == "P" ? 1 : 0),
                                    NewTruck = ((v.RecordType == "U") ? -1 : 1) * (v.Record.vehicletype == "N" && v.Record.vehicle == "T" ? 1 : 0),
                                    NewSUV = ((v.RecordType == "U") ? -1 : 1) * (v.Record.vehicletype == "N" && v.Record.vehicle == "S" ? 1 : 0),
                                });
                srObj.used_vehicles = vehicleCountQuery.Select(x => x.UsedVehicle).Sum();
                srObj.new_cars = vehicleCountQuery.Select(x => x.NewCar).Sum();
                srObj.new_trucks = vehicleCountQuery.Select(x => x.NewTruck).Sum();
                srObj.new_suvs = vehicleCountQuery.Select(x => x.NewSUV).Sum();
                srObj.total_vehicles = srObj.used_vehicles + srObj.new_cars + srObj.new_trucks + srObj.new_suvs;
                if (srObj.total_vehicles == null || srObj.total_vehicles == 0) { break; }
                #endregion

                #region Get Financial Counts
                decimal? nv_front = 0, uv_front = 0, nc_front = 0, nt_front = 0, ns_front = 0;
                decimal? nv_back = 0, uv_back = 0, nc_back = 0, nt_back = 0, ns_back = 0;
 
                foreach (var fitype in finTypes)
                {
                    //int dealamt = vehicleCountQuery.Where(d => d.FinType == fitype).Select(x => (x.UsedVehicle + x.NewCar + x.NewTruck + x.NewSUV)).Sum();
                    //decimal dealper = (srObj.total_vehicles > 0) ? Math.Round((decimal)((dealamt * 1.0) / srObj.total_vehicles), 2) : 0;

                    var dealamt_uv = vehicleCountQuery.Where(v => v.FinType == fitype).Select(v => v.UsedVehicle).Sum();
                    var dealamt_nc = vehicleCountQuery.Where(v => v.FinType == fitype).Select(v => v.NewCar).Sum();
                    var dealamt_nt = vehicleCountQuery.Where(v => v.FinType == fitype).Select(v => v.NewTruck).Sum();
                    var dealamt_ns = vehicleCountQuery.Where(v => v.FinType == fitype).Select(v => v.NewSUV).Sum();

                    //var finAmt = (mFIs.Union(mUnwinds)).Where(m => m.Record.Dealerid == id && m.Record.fitype == fitype)
                    var finResv_uv = vehicleCountQuery.Where(v => v.UsedVehicle != 0 && v.FinType == fitype).Select(v =>  v.BackEnd).Sum();
                    var finResv_nc = vehicleCountQuery.Where(v => v.NewCar != 0 && v.FinType == fitype).Select(v => v.BackEnd).Sum();
                    var finResv_nt = vehicleCountQuery.Where(v => v.NewTruck != 0 && v.FinType == fitype).Select(v => v.BackEnd).Sum();
                    var finResv_ns = vehicleCountQuery.Where(v => v.NewSUV != 0 && v.FinType == fitype).Select(v => v.BackEnd).Sum();

                    var grossprofit_uv = vehicleCountQuery.Where(v => v.UsedVehicle != 0 && v.FinType == fitype).Select(v => v.PayableGross).Sum();
                    var grossprofit_nc = vehicleCountQuery.Where(v => v.NewCar != 0 && v.FinType == fitype).Select(v => v.PayableGross).Sum();
                    var grossprofit_nt = vehicleCountQuery.Where(v => v.NewTruck != 0 && v.FinType == fitype).Select(v => v.PayableGross).Sum();
                    var grossprofit_ns = vehicleCountQuery.Where(v => v.NewSUV != 0 && v.FinType == fitype).Select(v => v.PayableGross).Sum();

                    var per_deal_uv = (dealamt_uv > 0) ? (int?) Math.Round(grossprofit_uv / dealamt_uv,0) : 0;
                    var per_deal_nc = (dealamt_nc > 0) ? (int?) Math.Round(grossprofit_nc / dealamt_nc, 0) : 0;
                    var per_deal_nt = (dealamt_nt > 0) ? (int?) Math.Round(grossprofit_nt / dealamt_nt, 0) : 0;
                    var per_deal_ns = (dealamt_ns > 0) ? (int?) Math.Round(grossprofit_ns / dealamt_ns, 0) : 0;

                    //Add to running Finance Totals
                    nc_front += grossprofit_nc;
                    nt_front += grossprofit_nt;
                    ns_front += grossprofit_ns;
                    uv_front += grossprofit_uv;

                    nc_back += finResv_nc;
                    nt_back += finResv_nt;
                    ns_back += finResv_ns;
                    uv_back += finResv_uv;

                    int dealamt = vehicleCountQuery.Where(d => d.FinType == fitype).Select(x => (x.UsedVehicle + x.NewCar + x.NewTruck + x.NewSUV)).Sum();
                    decimal dealper = (srObj.total_vehicles > 0) ? Math.Round((decimal)((dealamt * 1.0) / srObj.total_vehicles), 2) : 0;
                    switch (fitype)
                    {
                        case "1":
                            srObj.cash = dealamt;
                            srObj.cash_per = dealper;
                            srObj.nc_cash_per = per_deal_nc;
                            srObj.nt_cash_per = per_deal_nt;
                            srObj.ns_cash_per = per_deal_ns;
                            srObj.uv_cash_per = per_deal_uv;
                            break;
                        case "2":
                            srObj.conv = dealamt;
                            srObj.conv_per = dealper;
                            srObj.nc_conv_per = per_deal_nc;
                            srObj.nt_conv_per = per_deal_nt;
                            srObj.ns_conv_per = per_deal_ns;
                            srObj.uv_conv_per = per_deal_uv;
                            break;
                        case "3":
                            srObj.rbf = dealamt;
                            srObj.rbf_per = dealper;
                            srObj.nc_rbf_per = per_deal_nc;
                            srObj.nt_rbf_per = per_deal_nt;
                            srObj.ns_rbf_per = per_deal_ns;
                            srObj.uv_rbf_per = per_deal_uv;
                            break;
                        case "4":
                            srObj.osf = dealamt;
                            srObj.osf_per = dealper;
                            srObj.nc_osf_per = per_deal_nc;
                            srObj.nt_osf_per = per_deal_nt;
                            srObj.ns_osf_per = per_deal_ns;
                            srObj.uv_osf_per = 0;// per_deal_uv;
                            break;
                    }

                }
                #endregion
                var oi_NV_FE = GetOtherIncome().Where(o => (id != 99 ? o.DealerId == id : o.DealerId > 0) && o.PType == "FE" && o.VehicleTypeId == 1).Select(o => o.PAmount).Sum();
                var oi_NV_Other = GetOtherIncome().Where(o => (id != 99 ? o.DealerId == id : o.DealerId > 0) && o.VehicleTypeId == 1).Select(o => o.PAmount).Sum();
                var oi_UV_FE = GetOtherIncome().Where(o => (id != 99 ? o.DealerId == id : o.DealerId > 0) && o.PType == "FE" && o.VehicleTypeId == 2).Select(o => o.PAmount).Sum();
                var oi_UV_Other = GetOtherIncome().Where(o => (id != 99 ? o.DealerId == id : o.DealerId > 0) && o.VehicleTypeId == 2).Select(o => o.PAmount).Sum();
                //var oi_NV_BE = GetOtherIncome().Where(o => (id != 99 ? o.DealerId == id : o.DealerId > 0) && o.PType == "BE" && o.VehicleTypeId == 1).Select(o => o.PAmount).Sum();
                //var oi_UV_BE = GetOtherIncome().Where(o => (id != 99 ? o.DealerId == id : o.DealerId > 0) && o.PType == "BE" && o.VehicleTypeId == 2).Select(o => o.PAmount).Sum();

                // var oi_NV_FR = GetOtherIncome().Where(o => (id != 99 ? o.DealerId == id : o.DealerId > 0) && o.PType == "FR" && o.VehicleTypeId == 1).Select(o => o.PAmount).Sum();
                //var oi_UV_FR = GetOtherIncome().Where(o => (id != 99 ? o.DealerId == id : o.DealerId > 0) && o.PType == "FR" && o.VehicleTypeId == 2).Select(o => o.PAmount).Sum();

                nv_front = nc_front + nt_front + ns_front + oi_NV_FE;
                nv_back = nc_back + nt_back + ns_back + (oi_NV_Other - oi_NV_FE); // oi_NV_BE + oi_NV_FR
                uv_front += oi_UV_FE;
                uv_back += (oi_UV_Other - oi_UV_FE);
                #region Avg Computations
                if (srObj.new_cars > 0)
                {
                    srObj.ave_nc_front = (int?) Math.Round((double)(nc_front / srObj.new_cars), 0);
                    srObj.ave_nc_back = (int?) Math.Round((double)(nc_back / srObj.new_cars), 0);
                }

                if (srObj.new_trucks > 0)
                {
                    srObj.ave_nt_front = (int?)Math.Round((double)(nt_front / srObj.new_trucks), 0);
                    srObj.ave_nt_back = (int?)Math.Round((double)(nt_back / srObj.new_trucks), 0);
                }

                if (srObj.new_suvs > 0)
                {
                    srObj.ave_ns_front = (int?)Math.Round((double)(ns_front / srObj.new_suvs), 0);
                    srObj.ave_ns_back = (int?)Math.Round((double)(ns_back / srObj.new_suvs), 0);
                }

                if ((srObj.total_vehicles - srObj.used_vehicles)>0)
                {
                    srObj.ave_nv_front = (int?)Math.Round((double)(nv_front / (srObj.total_vehicles - srObj.used_vehicles)), 0);
                    srObj.ave_nv_back = (int?)Math.Round((double)(nv_back / (srObj.total_vehicles - srObj.used_vehicles)), 0);
                }

                if (srObj.used_vehicles > 0)
                {
                    srObj.ave_uv_front = (int?)Math.Round((double)(uv_front / srObj.used_vehicles), 0);
                    srObj.ave_uv_back = (int?)Math.Round((double)(uv_back / srObj.used_vehicles), 0);
                }
                #endregion  

                //Total Amounts
                var total_gross = (decimal) Math.Round((double)(nv_back + uv_back),2);
                var total_fe = (decimal) Math.Round((double)(nv_front + uv_front),2);
                srObj.avg_front = (decimal) Math.Round((double)(total_fe / srObj.total_vehicles),0);
                srObj.avg_fi_gross = (decimal) Math.Round((double)(total_gross/ srObj.total_vehicles),2);
                srObj.avg_f_b = (int?) Math.Round((double)((total_fe+total_gross)/srObj.total_vehicles),0);
                srObj.tot_income = total_gross;

                report.Add(srObj);
            }

            //report.Add(new SalesRecapReportObject
            //{
            //    dealership = "FHC Totals",
            //    new_cars = report.Select(r=> r.new_cars).Sum(),
            //    new_trucks = report.Select(r => r.new_trucks).Sum(),
            //    new_suvs = report.Select(r => r.new_suvs).Sum(),
            //    used_vehicles = report.Select(r => r.used_vehicles).Sum(),
            //    total_vehicles = report.Select(r => r.total_vehicles).Sum(),
            //    cash = report.Select(r => r.cash).Sum(),
            //    nc_cash_per = report.Select(r => r.nc_cash_per).Sum(),
            //    nt_cash_per = report.Select(r => r.nt_cash_per).Sum(),
            //    ns_cash_per = report.Select(r => r.ns_cash_per).Sum(),
            //    uv_cash_per = report.Select(r => r.uv_cash_per).Sum(),
            //    conv = report.Select(r => r.conv).Sum(),
            //    nc_conv_per = report.Select(r => r.nc_conv_per).Sum(),
            //    ns_conv_per = report.Select(r => r.ns_conv_per).Sum(),
            //    nt_conv_per = report.Select(r => r.nt_conv_per).Sum(),
            //    uv_conv_per = report.Select(r => r.uv_conv_per).Sum(),
            //    rbf = report.Select(r => r.rbf).Sum(),
            //    nc_rbf_per = report.Select(r => r.nc_rbf_per).Sum(),
            //    ns_rbf_per = report.Select(r => r.).Sum(),
            //    nt_rbf_per = report.Select(r => r.).Sum(),
            //    uv_rbf_per = report.Select(r => r.).Sum(),
            //    osf = report.Select(r => r.osf).Sum(),
            //    nc_osf_per = report.Select(r => r.).Sum(),
            //    ns_osf_per = report.Select(r => r.).Sum(),
            //    nt_osf_per = report.Select(r => r.).Sum(),
            //    uv_osf_per = report.Select(r => r.).Sum(),
            //    ave_nc_front = report.Select(r => r.ave_nc_front).Sum(),
            //    ave_ns_front = report.Select(r => r.ave_ns_front).Sum(),
            //    ave_nt_front = report.Select(r => r.ave_nt_front).Sum(),
            //    ave_nv_front = report.Select(r => r.ave_nv_front).Sum(),
            //    ave_uv_front = report.Select(r => r.ave_uv_front).Sum(),
            //    ave_nc_back = report.Select(r => r.ave_nc_back).Sum(),
            //    ave_ns_back = report.Select(r => r.ave_ns_back).Sum(),
            //    ave_nt_back = report.Select(r => r.ave_nt_back).Sum(),
            //    ave_nv_back = report.Select(r => r.ave_nv_back).Sum(),
            //    ave_uv_back = report.Select(r => r.ave_uv_back).Sum(),
            //    tot_income = report.Select(r => r.tot_income).Sum(),
            //    avg_front = report.Select(r => r.).Sum(),
            //    avg_fi_gross = report.Select(r => r.).Sum(),
            //    avg_f_b = report.Select(r => r.).Sum()
            //});

            return report;
        }

        private IList<MasterFIRecord> GetMasterFIs()
        {
            return context.MasterFIs
                .Where(m => new int[] { 4, 5, 6, 7, 9 }.Contains(m.status)
                        && ((m.delvdate >= StartDate && m.delvdate <= EndDate)
                            || (m.delvdate == new DateTime(1900, 1, 1) && m.salesdate >= StartDate && m.salesdate <= EndDate)))
                 .Select(d => new MasterFIRecord
                 {
                     RecordType = "M",
                     Record = d
                 }).ToList();
        }

        private IList<MasterFIRecord> GetUnwinds()
        {
            return context.MasterFIs
                .Where(m => m.unwinddate >= StartDate && m.unwinddate <= EndDate)
                .Select(d => new MasterFIRecord
                {
                    RecordType = "U",
                    Record = d
                }).ToList();
        }

        private IList<OtherIncome> GetOtherIncome()
        {
            return context.OtherIncomes.Where(o => o.SaleDate >= StartDate
                                                && o.SaleDate <= EndDate
                                                && o.PAmount != 0).ToList();
                                                //.Select(o => new SalesRecap_OtherIncomeObj
                                                //{
                                                //    DealerId = (int)o.DealerId,
                                                //    VehicleTypeID = (int)o.VehicleTypeId,
                                                //    PType =  o.PType,
                                                //    Amount = o.PAmount
                                                //}).ToList().Sum(o=> o.Amount)
        }

        private class SalesRecap_OtherIncomeObj
        {
            public int DealerId { get; set; }
            public int VehicleTypeID { get; set; }
            public string PType { get; set; }
            public decimal? Amount { get; set; }
        }
    }
}