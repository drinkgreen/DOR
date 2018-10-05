using DORv3.BLL.BusinessObjects;
using DORv3.BLL.ReportObjects;
using DORv3.DAL.Models;
using DORv3.HelperLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.BLL
{
    public class DOR1234biz
    {
        private FowlerDORContext context;
        private IList<MasterFIRecord> mFIs, mUnwinds;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DOR1234biz(DateTime startDate, DateTime endDate)
        {
            context = new FowlerDORContext();
            this.StartDate = startDate;
            this.EndDate = endDate;
            mFIs = GetMasterFIs();
            mUnwinds = GetUnwinds();
        }

        public List<DOR1234ReportObject> BuildDOR1234Report(List<int> dealerIDs)
        {
            List<DOR1234ReportObject> report = new List<DOR1234ReportObject>();
            //Start building report

            var dealers = context.DealerShips.Where(d => (d.DisableDate == null || d.DisableDate > StartDate) && dealerIDs.Contains(d.DealerID)).OrderBy(d=>d.Sort).Select(d => new { Name = d.DealerName, ID = d.DealerID });
            var finTypes = context.FinanceTypes.Select(f => f.FinanceTypeId.ToString()); 
            DOR1234ReportObject reportRecord = null;
            foreach(var dealer in dealers)
            {
                reportRecord = new DOR1234ReportObject();
                reportRecord.Dealership = dealer.Name;
                var id = dealer.ID;

            #region Get Vehicle Counts

            var vehicleCountQuery = (mFIs.Union(mUnwinds))
                                .Where(v => (id != 99 ? v.Record.Dealerid == id : v.Record.Dealerid > 0))
                                .Select(v => new
                                {
                                    FinType = v.Record.fitype,
                                    Used = ((v.RecordType == "U") ? -1 : 1) * (v.Record.vehicletype == "U" ? 1 : 0),
                                    New = ((v.RecordType == "U") ? -1 : 1) * (v.Record.vehicletype == "N" ? 1 : 0),
                                });

                
                reportRecord.UsedVehicles = vehicleCountQuery.Select(x => x.Used).Sum();
                reportRecord.NewVehicles = vehicleCountQuery.Select(x => x.New).Sum();
                reportRecord.TotalVehicles = reportRecord.UsedVehicles + reportRecord.NewVehicles;

                if (reportRecord.TotalVehicles == null || reportRecord.TotalVehicles == 0) { break; }

                foreach (var fitype in finTypes)
                {
                    int dealamt = vehicleCountQuery.Where(d => d.FinType == fitype).Select(x => (x.Used + x.New)).Sum();
                    decimal dealper = (reportRecord.TotalVehicles > 0) ? Math.Round((decimal)((dealamt*1.0) / reportRecord.TotalVehicles), 2) : 0;

                    //TODO Fix Slowdown

                    var finAmt = (mFIs.Union(mUnwinds)).Where(m => (id != 99 ? m.Record.Dealerid == id : m.Record.Dealerid > 0) && m.Record.fitype == fitype)
                                .Select(m => (m.RecordType == "U" ? -1 : 1) * (m.Record.backend - m.Record.finresv)).DefaultIfEmpty(0).Sum();

                    //---------------------------------------

                    var finResv = (mFIs.Union(mUnwinds)).Where(m => (id != 99 ? m.Record.Dealerid == id : m.Record.Dealerid > 0) && m.Record.fitype == fitype)
                        .Select(m => (m.RecordType == "U" ?-1:1) * m.Record.finresv).Sum();

                    decimal? resvper = (dealamt > 0) ? Math.Round((decimal)(finResv / dealamt), 2) : 0;
                    decimal? finIncome = (fitype == "1") ? finAmt : Math.Round((decimal)(finResv + finAmt), 2);
                    switch (fitype)
                    {
                        case "1":
                            reportRecord.CashDeals = dealamt;
                            reportRecord.CashDealsPer = dealper;
                            reportRecord.CashIncome = finIncome;
                            break;
                        case "2":
                            reportRecord.ConvDeals = dealamt;
                            reportRecord.ConvDealsPer = dealper;
                            reportRecord.CONVReserve = finResv;
                            reportRecord.CONVReserveUNIT = resvper;
                            reportRecord.ConvIncome = finIncome;
                            break;
                        case "3":
                            reportRecord.RBFDeals = dealamt;
                            reportRecord.RBFDealsPer = dealper;
                            reportRecord.RBFReserve = finResv;
                            reportRecord.RBFReserveUNIT = resvper;
                            reportRecord.RBFIncome = finIncome;
                            break;
                        case "4":
                            reportRecord.OSFDeals = dealamt;
                            reportRecord.OSFDealsPer = dealper;
                            reportRecord.OSFIncome = finIncome;
                            break;
                    }

                }

                var oiReserve = GetOtherIncome().Where(oi => (id != 99 ? oi.DealerId == id : oi.DealerId > 0) && oi.PType == "FR").Select(oi => oi.PAmount).Sum();
                var oiGross = GetOtherIncome().Where(oi => (id != 99 ? oi.DealerId == id : oi.DealerId > 0) && oi.PType == "BE").Select(oi => oi.PAmount).Sum();

                reportRecord.TotalReserve = (int)(reportRecord.CONVReserve + reportRecord.RBFReserve+ oiReserve);
                reportRecord.TotalReserve_Per = (int)Math.Round((decimal)((reportRecord.TotalReserve * 1.0) / (reportRecord.ConvDeals + reportRecord.RBFDeals)), 0);

            #endregion

            #region Get Finance Backend Counts
            var backendOptions = (mFIs.Union(mUnwinds))
                    .Where(b => (id != 99 ? b.Record.Dealerid == id : b.Record.Dealerid > 0))
                    .Select(b => new
                    {
                        Dent = ((b.RecordType == "U") ? -1 : 1) * (b.Record.dent > 0 ? 1 : 0),
                        CreditLife = ((b.RecordType == "U") ? -1 : 1) * (b.Record.cl > 0 ? 1 : 0),
                        Windsh = ((b.RecordType == "U") ? -1 : 1) * (b.Record.Maint > 0 ? 1 : 0),
                        Gap = ((b.RecordType == "U") ? -1 : 1) * (b.Record.gap > 0 ? 1 : 0),
                        Etch = ((b.RecordType == "U") ? -1 : 1) * (b.Record.etch > 0 ? 1 : 0),
                        TireWheel = ((b.RecordType == "U") ? -1 : 1) * (b.Record.tirewheel > 0 ? 1 : 0),
                        Enviro = ((b.RecordType == "U") ? -1 : 1) * (b.Record.enviro > 0 ? 1 : 0),
                        Key = ((b.RecordType == "U") ? -1 : 1) * (b.Record.TBD > 0 ? 1 : 0),
                        AH = ((b.RecordType == "U") ? -1 : 1) * (b.Record.ah > 0 ? 1 : 0),
                        VSC = ((b.RecordType == "U") ? -1 : 1) * (b.Record.vsc != 0 && b.Record.vsc != null ? 1 : 0),
                        Map = ((b.RecordType == "U") ? -1 : 1) * (b.Record.vscoption == "Map" ? 1 : 0)
                    }).ToList()
                    .Concat(GetOtherIncome()
                            .Where(o => (id != 99 ? o.DealerId == id : o.DealerId > 0) && o.OtherType=="OI")
                            .Select(o => new
                            {
                                Dent = (o.OtherProductId == 7 ? 1 : 0),
                                CreditLife = (o.OtherProductId == 1 ? 1 : 0),
                                Windsh = (o.OtherProductId == 9 ? 1 : 0),
                                Gap = (o.OtherProductId == 3 ? 1 : 0),
                                Etch = (o.OtherProductId == 6 ? 1 : 0),
                                TireWheel = (o.OtherProductId == 12 ? 1 : 0),
                                Enviro = (o.OtherProductId == 5 ? 1 : 0),
                                Key = (o.OtherProductId == 13 ? 1 : 0),
                                AH = (o.OtherProductId == 2 ? 1 : 0),
                                VSC = (o.OtherProductId == 10 ? 1 : 0),
                                Map = 0// ((o.OtherProductId == 10 && o.VSCOption.ToUpper() == "MAP") ? 1 : 0)
                            }));


            reportRecord.Dent = backendOptions.Select(b => b.Dent).Sum();
            reportRecord.CreditLife = backendOptions.Select(b => b.CreditLife).Sum();
            reportRecord.Windsh = backendOptions.Select(b => b.Windsh).Sum();
            reportRecord.GAP = backendOptions.Select(b => b.Gap).Sum();
            reportRecord.ETCH = backendOptions.Select(b => b.Etch).Sum();
            //reportRecord.TireWheel = backendOptions.Select(b => b.TireWheel).Sum();
            reportRecord.Enviro = backendOptions.Select(b => b.Enviro).Sum();
            reportRecord.KEY = backendOptions.Select(b => b.Key).Sum();
            reportRecord.AH = backendOptions.Select(b => b.AH).Sum();
            reportRecord.TOTAL = backendOptions.Select(b => b.VSC).Sum();
            reportRecord.MAP = backendOptions.Select(b => b.Map).Sum();

                reportRecord.WindshPer = Math.Round((decimal)((reportRecord.Windsh*1.0) / reportRecord.TotalVehicles), 2);
                reportRecord.CreditLifePer = Math.Round((decimal)((reportRecord.CreditLife * 1.0) / reportRecord.TotalVehicles), 2);
                reportRecord.AHPer = Math.Round((decimal)((reportRecord.AH * 1.0) / reportRecord.TotalVehicles), 2);
                reportRecord.EnviroPer = Math.Round((decimal)((reportRecord.Enviro * 1.0) / reportRecord.TotalVehicles), 2);
                reportRecord.ETCHPer = Math.Round((decimal)((reportRecord.ETCH * 1.0) / reportRecord.TotalVehicles), 2);
                reportRecord.KEYPer = Math.Round((decimal)((reportRecord.KEY * 1.0) / reportRecord.TotalVehicles), 2);
                reportRecord.GAPPer = (reportRecord.ConvDeals + reportRecord.RBFDeals) > 0
                                    ? Math.Round((decimal)((reportRecord.GAP * 1.0) / (reportRecord.ConvDeals + reportRecord.RBFDeals)), 2)
                                    : 0;
                #endregion

                #region "Get Amounts"
                decimal? otherAmt = GetOtherIncome().Where(o => (id != 99 ? o.DealerId == id : o.DealerId > 0) && o.OtherProductId != 0).Select(o => o.PAmount).DefaultIfEmpty(0).Sum();

                //var dorProds = GetDorProducts().Select(d => d.DORId).ToList();
                decimal? unwindOtherAmt = 0;// GetDorProductsWithUnwind().Where(dp => (id != 99 ? dp.DealerID == id : dp.DealerID > 0)).Select(dp => dp.PAmount).Sum();
                   // .Where(p => mUnwinds.Select(m=>m.Record.DORid).ToList().Contains(p.DORId))
                //var unwindOtherAmt = mUnwinds.Where(u => u.Record.status == "9" && (id != 99 ? u.Record.Dealerid == id : u.Record.Dealerid > 0)).Select(u => (u.Record.backend)).DefaultIfEmpty(0).Sum();

                //var unwindIds = mUnwinds.Where(u => u.Record.Dealerid == id).Select(u => u.Record.DORid).ToList();
                //var unwindOtherAmt = context.DORProducts.Where(dp => dp.Recap == 0 && dp.PAmount != 0 //&& dp.OtherProductId != 0
                //                                        && unwindIds.Contains((int)dp.DORId))
                //                            .Select(dp => dp.PAmount).DefaultIfEmpty(0).Sum();

                //decimal? totalFEp1 = context.MasterFIs.Where(m => (id != 99 ? m.Dealerid == id : m.Dealerid > 0) 
                //                                            && new string[] { "4", "5", "6", "7", "9" }.Contains(m.status)
                //                                            && ((m.delvdate >= StartDate && m.delvdate <= EndDate)
                //                                                || (m.delvdate.ToString() == "01/01/1900" && m.salesdate >= StartDate && m.salesdate <= EndDate)))
                      decimal? totalFEp1 = GetMasterFIs().Where(m => (id != 99 ? m.Record.Dealerid == id : m.Record.Dealerid > 0))
                                               .Select(m => (decimal?) m.Record.payablegross).DefaultIfEmpty(0).Sum();
                   decimal? totalOFEp1 = GetOtherIncome().Where(o => (id != 99 ? o.DealerId == id : o.DealerId > 0) && o.PType =="FE" && o.PAmount != 0).Select(o => o.PAmount).Sum();
                             
                  decimal? totalFEp2 = GetUnwinds().Where(u => (id != 99 ? u.Record.Dealerid == id : u.Record.Dealerid > 0))
                                                .Select(u => (decimal?) u.Record.payablegross).DefaultIfEmpty(0).Sum();

                decimal? totalFE = totalFEp1 - totalFEp2 + totalOFEp1 ;

                decimal? totalgross = GetMasterFIs().Where(m => (id != 99 ? m.Record.Dealerid == id : m.Record.Dealerid > 0))
                                               .Select(m => (decimal?)(m.Record.totalgross)).DefaultIfEmpty(0).Sum();

                totalgross -= GetUnwinds().Where(m => (id != 99 ? m.Record.Dealerid == id : m.Record.Dealerid > 0))
                                               .Select(m => (decimal?)(m.Record.totalgross)).DefaultIfEmpty(0).Sum();

                totalgross += oiReserve + otherAmt + oiGross + (totalOFEp1 + totalFEp2);

                #endregion

                #region "Add and Average Totals"

                reportRecord.TotalIncome = Math.Round((decimal)(reportRecord.CashIncome
                                                                + reportRecord.ConvIncome
                                                                + reportRecord.RBFIncome
                                                                + reportRecord.OSFIncome
                                                                + (otherAmt - unwindOtherAmt)
                                                                + oiReserve
                                                                + oiGross), 0);

                if (reportRecord.TotalVehicles > 0)
                {
                    reportRecord.WarrantiesPer = Math.Round((decimal)((reportRecord.TOTAL*1.0) / reportRecord.TotalVehicles), 2);
                    reportRecord.AvgFront = Math.Round((decimal)(totalFE / reportRecord.TotalVehicles),0);
                    reportRecord.Avg_Front_Back = Math.Round((decimal)(totalgross / reportRecord.TotalVehicles), 0);
                    reportRecord.Avg_FI_Gross = Math.Round((decimal)(reportRecord.TotalIncome / reportRecord.TotalVehicles), 0);
                }

                #endregion
                //Add This Dealer's Report
                report.Add(reportRecord);
            }

            return report;


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
                                                //&& o.OtherIncomeId != 0
                                                //&& o.OtherType == "OI"
                                                && o.PAmount != 0).ToList();
        }

        private IList<DORProduct> GetDorProducts()
        {
            return context.DORProducts.Where(d => d.Recap == 0 && d.PAmount != 0 && d.OtherProductId != 0).Select(d => d).ToList();
        }

        private IList<DORProductAmount> GetDorProductsWithUnwind()
        {
            return (from dp in context.DORProducts
                    join m in context.MasterFIs on dp.DORId equals m.DORid
                    where m.status == 9
                         && m.unwinddate >= StartDate && m.unwinddate <= EndDate
                         && dp.Recap == 0
                    select new DORProductAmount()
                    {
                        ID = m.DORid,
                        DealerID = m.Dealerid,
                        PAmount = dp.PAmount
                    }).ToList();
        }

        private class DORProductAmount
        {
            public int ID { get; set; }
            public int DealerID { get; set; }
            public decimal? PAmount { get; set; }
        }
    }
}