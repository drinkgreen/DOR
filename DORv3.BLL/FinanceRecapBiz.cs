using DORv3.BLL.BusinessObjects;
using DORv3.BLL.ReportObjects;
using DORv3.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.BLL
{
    public class FinanceRecapBiz
    {
        private FowlerDORContext context;
        private IList<MasterFIRecord> mFIs, mUnwinds;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public FinanceRecapBiz(DateTime startDate, DateTime endDate)
        {
            context = new FowlerDORContext();
            this.StartDate = startDate;
            this.EndDate = endDate;
            mFIs = GetMasterFIs();
            mUnwinds = GetUnwinds();
        }

        public List<FinanceRecapReportObject> BuildFinanceRecapReport(List<int> dealerIDs)
        {
            List<FinanceRecapReportObject> report = new List<FinanceRecapReportObject>();

            var dealers = context.DealerShips.Where(d => dealerIDs.Contains(d.DealerID) && (d.DisableDate == null || d.DisableDate > StartDate)).Select(d => new { Name = d.DealerName, ID = d.DealerID });
            var finTypes = context.FinanceTypes.Select(f => f.FinanceTypeId.ToString());

            FinanceRecapReportObject frObj = null;

            foreach (var dealer in dealers)
            {
                frObj = new FinanceRecapReportObject();
                frObj.dealer_name = dealer.Name;
                var id = dealer.ID;

                //Get Total Vehicle Count
                var vehicleCountQuery = (mFIs.Union(mUnwinds))
                                .Where(v => (id != 99 ? v.Record.Dealerid == id : v.Record.Dealerid > 0))
                                .Select(v => new
                                {
                                    FinType = v.Record.fitype,
                                    FinResv = v.Record.backend,
                                    GrossProfit = v.Record.payablegross,
                                    Vehicles = (v.RecordType == "U") ? -1 : 1
                                });

                frObj.tot_vehicle = vehicleCountQuery.Select(x => x.Vehicles).Sum();
                if (frObj.tot_vehicle == null || frObj.tot_vehicle == 0) { break; }
                frObj.tot_tot = 0;

                //Get Financial Counts
                decimal? fe_tot = 0;
                foreach (var fitype in finTypes)
                {
                    var deal_amt = vehicleCountQuery.Where(x => x.FinType == fitype).Select(x => x.Vehicles).Sum();
                    var finresv = vehicleCountQuery.Where(x => x.FinType == fitype).Select(x => x.FinResv).Sum();
                    var grossprofit = Math.Round(vehicleCountQuery.Where(x => x.FinType == fitype).Select(x => x.GrossProfit).Sum(),2);

                    var deal_per = (frObj.tot_vehicle > 0) ? Math.Round((double)(deal_amt*1.0 / frObj.tot_vehicle),2) : 0;
                    var deal_income_per = (deal_amt > 0) ? Math.Round(grossprofit / deal_amt,2): 0;

                    switch (fitype)
                    {
                        case "1":
                            frObj.cash_deals = deal_amt;
                            frObj.cash_deals_per = deal_per;
                            frObj.per_deal_income_cash = deal_income_per;
                            frObj.cash_tot = grossprofit;
                            break;
                        case "2":
                            frObj.conv_deals = deal_amt;
                            frObj.conv_deals_per = deal_per;
                            frObj.per_deal_income_conv = deal_income_per;
                            frObj.conv_tot = grossprofit;
                            break;
                        case "3":
                            frObj.RBF_deals = deal_amt;
                            frObj.RBF_deals_per = deal_per;
                            frObj.per_deal_income_RBF = deal_income_per;
                            frObj.rbf_tot = grossprofit;
                            break;
                        case "4":
                            frObj.OSF_deals = deal_amt;
                            frObj.OSF_deals_per = deal_per;
                            frObj.per_deal_income_OSF = deal_income_per;
                            frObj.osf_tot = grossprofit;
                            break;
                    }

                    frObj.tot_tot += grossprofit;
                    fe_tot += finresv;
                }

                if (frObj.tot_vehicle > 0)
                {
                    frObj.avg_be = Math.Round((double)(frObj.tot_tot / frObj.tot_vehicle),2);
                    frObj.avg_fe = Math.Round((double)(fe_tot / frObj.tot_vehicle), 2);
                }
                frObj.avg_tot = (decimal)(frObj.avg_be + frObj.avg_fe);

                #region Get Finance Backend Counts
                var backendOptions = (mFIs.Union(mUnwinds))
                        .Where(b => (id != 99 ? b.Record.Dealerid == id : b.Record.Dealerid > 0))
                        .Select(b => new
                        {
                            Dent = b.Record.dent,
                            CreditLife = b.Record.cl,
                            Maint = b.Record.Maint, 
                            Gap = b.Record.gap,
                            Etch = b.Record.etch,
                            TireWheel = b.Record.tirewheel,
                            Enviro = b.Record.enviro,
                            Key = b.Record.TBD,
                            AH = b.Record.ah,
                            Warr = b.Record.vsc,
                            IsDent = ((b.RecordType == "U") ? -1 : 1) * (b.Record.dent > 0 ? 1 : 0),
                            IsCreditLife = ((b.RecordType == "U") ? -1 : 1) * (b.Record.cl > 0 ? 1 : 0),
                            IsMaint = ((b.RecordType == "U") ? -1 : 1) * (b.Record.Maint > 0 ? 1 : 0),
                            IsGap = ((b.RecordType == "U") ? -1 : 1) * (b.Record.gap > 0 ? 1 : 0),
                            IsEtch = ((b.RecordType == "U") ? -1 : 1) * (b.Record.etch > 0 ? 1 : 0),
                            IsTireWheel = ((b.RecordType == "U") ? -1 : 1) * (b.Record.tirewheel > 0 ? 1 : 0),
                            IsEnviro = ((b.RecordType == "U") ? -1 : 1) * (b.Record.enviro > 0 ? 1 : 0),
                            IsKey = ((b.RecordType == "U") ? -1 : 1) * (b.Record.TBD > 0 ? 1 : 0),
                            IsAH = ((b.RecordType == "U") ? -1 : 1) * (b.Record.ah > 0 ? 1 : 0),
                            IsWarr = ((b.RecordType == "U") ? -1 : 1) * (b.Record.vsc != 0 && b.Record.vsc != null ? 1 : 0)
                        }).ToList()
                        .Concat(GetOtherIncome()
                                .Where(o => (id != 99 ? o.DealerId == id : o.DealerId > 0))
                                .Select(o => new
                                {
                                    Dent = (o.OtherProductId == 7 ? o.PAmount : 0),
                                    CreditLife = (o.OtherProductId == 1 ? o.PAmount : 0),
                                    Maint = (o.OtherProductId == 9 ? o.PAmount : 0),
                                    Gap = (o.OtherProductId == 3 ? o.PAmount : 0),
                                    Etch = (o.OtherProductId == 6 ? o.PAmount : 0),
                                    TireWheel = (o.OtherProductId == 12 ? o.PAmount : 0),
                                    Enviro = (o.OtherProductId == 5 ? o.PAmount : 0),
                                    Key = (o.OtherProductId == 13 ? o.PAmount : 0),
                                    AH = (o.OtherProductId == 2 ? o.PAmount : 0),
                                    Warr = (o.OtherProductId == 10 ? o.PAmount : 0),
                                    IsDent = (o.OtherProductId == 7 ? 1 : 0),
                                    IsCreditLife = (o.OtherProductId == 1 ? 1 : 0),
                                    IsMaint = (o.OtherProductId == 9 ? 1 : 0),
                                    IsGap = (o.OtherProductId == 3 ? 1 : 0),
                                    IsEtch = (o.OtherProductId == 6 ? 1 : 0),
                                    IsTireWheel = (o.OtherProductId == 12 ? 1 : 0),
                                    IsEnviro = (o.OtherProductId == 5 ? 1 : 0),
                                    IsKey = (o.OtherProductId == 13 ? 1 : 0),
                                    IsAH = (o.OtherProductId == 2 ? 1 : 0),
                                    IsWarr = (o.OtherProductId == 10 ? 1 : 0)
                                }));

                frObj.warr = Math.Round((decimal)backendOptions.Select(x => x.Warr).Sum(),2);
                frObj.warr_count = backendOptions.Select(x => x.IsWarr).Sum();

                frObj.dent = Math.Round((decimal)backendOptions.Select(x => x.Dent).Sum(), 2);
                frObj.dent_count = backendOptions.Select(x => x.IsDent).Sum();

                frObj.maint = Math.Round((decimal)backendOptions.Select(x => x.Maint).Sum(), 2);
                frObj.maint_count = backendOptions.Select(x => x.IsMaint).Sum();

                frObj.cl = Math.Round((decimal)backendOptions.Select(x => x.CreditLife).Sum(), 2);
                frObj.cl_count = backendOptions.Select(x => x.IsCreditLife).Sum();

                frObj.ah = Math.Round((decimal)backendOptions.Select(x => x.AH).Sum(), 2);
                frObj.ah_count = backendOptions.Select(x => x.IsAH).Sum();

                frObj.env = Math.Round((decimal)backendOptions.Select(x => x.Enviro).Sum(), 2);
                frObj.env_count = backendOptions.Select(x => x.IsEnviro).Sum();

                frObj.etch = Math.Round((decimal)backendOptions.Select(x => x.Etch).Sum(), 2);
                frObj.etch_count = backendOptions.Select(x => x.IsEtch).Sum();

                frObj.gap = Math.Round((decimal)backendOptions.Select(x => x.Gap).Sum(), 2);
                frObj.gap_count = backendOptions.Select(x => x.IsGap).Sum();

                frObj.tw = Math.Round((decimal)backendOptions.Select(x => x.TireWheel).Sum(), 2);
                frObj.tw_count = backendOptions.Select(x => x.IsTireWheel).Sum();

                if (frObj.tot_vehicle > 0)
                {
                    frObj.warr_per = Math.Round((double)((frObj.warr_count*1.0) / frObj.tot_vehicle), 2);
                    frObj.dent_per = Math.Round((double)((frObj.dent_count * 1.0) / frObj.tot_vehicle), 2);
                    frObj.maint_per = Math.Round((double)((frObj.maint_count * 1.0) / frObj.tot_vehicle), 2);
                    frObj.cl_per = Math.Round((double)((frObj.cl_count * 1.0) / frObj.tot_vehicle), 2);
                    frObj.ah_per = Math.Round((double)((frObj.ah_count * 1.0) / frObj.tot_vehicle), 2);
                    frObj.env_per = Math.Round((double)((frObj.env_count * 1.0) / frObj.tot_vehicle), 2);
                    frObj.etch_per = Math.Round((double)((frObj.etch_count * 1.0) / frObj.tot_vehicle), 2);
                    frObj.gap_per = Math.Round((double)((frObj.gap_count * 1.0) / frObj.tot_vehicle), 2);
                    frObj.tw_per = Math.Round((double)((frObj.tw_count * 1.0) / frObj.tot_vehicle), 2);
                }

                frObj.warr_income = (frObj.warr_count > 0) ? Math.Round((double)(frObj.warr / frObj.warr_count), 2) : 0;
                frObj.dent_income = (frObj.dent_count > 0) ? Math.Round((double)(frObj.dent / frObj.dent_count), 2) : 0;
                frObj.maint_income = (frObj.maint_count > 0) ? Math.Round((double)(frObj.maint / frObj.maint_count), 2) : 0;
                frObj.cl_income = (frObj.cl_count > 0) ? Math.Round((double)(frObj.cl / frObj.cl_count), 2) : 0;
                frObj.ah_income = (frObj.ah_count > 0) ? Math.Round((double)(frObj.ah / frObj.ah_count), 2) : 0;
                frObj.env_income = (frObj.env_count > 0) ? Math.Round((double)(frObj.env / frObj.env_count), 2) : 0;
                frObj.etch_income = (frObj.etch_count > 0) ? Math.Round((double)(frObj.etch / frObj.etch_count), 2) : 0;
                frObj.gap_income = (frObj.gap_count > 0) ? Math.Round((double)(frObj.gap / frObj.gap_count), 2) : 0;
                frObj.tw_income = (frObj.tw_count > 0) ? Math.Round((double)(frObj.tw / frObj.tw_count), 2) : 0;

                #endregion

                report.Add(frObj);
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
                                                && o.PAmount != 0
                                                && o.OtherType == "OI").ToList();
        }
    }
}