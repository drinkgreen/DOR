using DORv3.BLL.BusinessObjects;
using DORv3.BLL.ReportObjects;
using DORv3.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.BLL
{
    public class NU_RecapReportBiz
    {
        private FowlerDORContext context;
        private IList<MasterFIRecord> mFIs, mUnwinds;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public NU_RecapReportBiz(DateTime startDate, DateTime endDate)
        {
            context = new FowlerDORContext();
            this.StartDate = startDate;
            this.EndDate = endDate;
            mFIs = GetMasterFIs();
            mUnwinds = GetUnwinds();
        }

        public List<NU_RecapReportObject> BuildNU_RecapReport(List<int> dealerIDs)
        {
            List<NU_RecapReportObject> report = new List<NU_RecapReportObject>();

            //Start Building
            var dealers = context.DealerShips.Where(d => dealerIDs.Contains(d.DealerID) && (d.DisableDate == null || d.DisableDate > StartDate)).Select(d => new { Name = d.DealerName, ID = d.DealerID });
            var finTypes = context.FinanceTypes.Select(f => f.FinanceTypeId.ToString());

            NU_RecapReportObject nuObj = null;

            foreach (var dealer in dealers)
            {
                nuObj = new NU_RecapReportObject();
                nuObj.dealer_name = dealer.Name;
                var id = dealer.ID;

                #region Get (N)ew Values

                var vehicleCountQuery_nv = (mFIs.Union(mUnwinds))
                                .Where(v => (id != 99 ? v.Record.Dealerid == id : v.Record.Dealerid > 0) && v.Record.vehicletype == "N")
                                .Select(v => new
                                {
                                    FinType = v.Record.fitype,
                                    FinResv = v.Record.backend,
                                    GrossProfit = v.Record.payablegross,
                                    Vehicles = (v.RecordType == "U") ? -1 : 1
                                });

                nuObj.tot_vehicle_nv = vehicleCountQuery_nv.Select(x => x.Vehicles).Sum();
                if (nuObj.tot_vehicle_nv == null || nuObj.tot_vehicle_nv == 0) { break; }
                nuObj.tot_tot_nv = 0;


                //Get Financial Counts
                decimal? fe_tot_nv = 0;
                foreach (var fitype in finTypes)
                {
                    var deal_amt = vehicleCountQuery_nv.Where(x => x.FinType == fitype).Select(x => x.Vehicles).Sum();
                    var finresv = vehicleCountQuery_nv.Where(x => x.FinType == fitype).Select(x => x.FinResv).Sum();
                    var grossprofit = Math.Round(vehicleCountQuery_nv.Where(x => x.FinType == fitype).Select(x => x.GrossProfit).Sum(), 2);

                    var deal_per = (nuObj.tot_vehicle_nv > 0) ? Math.Round((double)(deal_amt*1.0 / nuObj.tot_vehicle_nv), 2) : 0;
                    var deal_income_per = (deal_amt > 0) ? Math.Round(grossprofit / deal_amt, 2) : 0;

                    switch (fitype)
                    {
                        case "1":
                            nuObj.cash_deals_nv = deal_amt;
                            nuObj.cash_deals_per_nv = deal_per;
                            nuObj.per_deal_income_cash_nv = deal_income_per;
                            nuObj.cash_tot_nv = grossprofit;
                            break;
                        case "2":
                            nuObj.conv_deals_nv = deal_amt;
                            nuObj.conv_deals_per_nv = deal_per;
                            nuObj.per_deal_income_conv_nv = deal_income_per;
                            nuObj.conv_tot_nv = grossprofit;
                            break;
                        case "3":
                            nuObj.RBF_deals_nv = deal_amt;
                            nuObj.RBF_deals_per_nv = deal_per;
                            nuObj.per_deal_income_RBF_nv = deal_income_per;
                            nuObj.rbf_tot_nv = grossprofit;
                            break;
                        case "4":
                            nuObj.OSF_deals_nv = deal_amt;
                            nuObj.OSF_deals_per_nv = deal_per;
                            nuObj.per_deal_income_OSF_nv = deal_income_per;
                            nuObj.osf_tot_nv = grossprofit;
                            break;
                    }

                    nuObj.tot_tot_nv += grossprofit;
                    fe_tot_nv += finresv;
                }

                if (nuObj.tot_vehicle_nv > 0)
                {
                    nuObj.avg_be_nv = Math.Round((double)(nuObj.tot_tot_nv / nuObj.tot_vehicle_nv), 2);
                    nuObj.avg_fe_nv = Math.Round((double)(fe_tot_nv / nuObj.tot_vehicle_nv), 2);
                }
                nuObj.avg_tot_nv = (decimal)(nuObj.avg_be_nv + nuObj.avg_fe_nv);

                var backendOptions_nv = (mFIs.Union(mUnwinds))
                        .Where(b => (id != 99 ? b.Record.Dealerid == id : b.Record.Dealerid > 0) && b.Record.vehicletype == "N")
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
                                .Where(o => (id != 99 ? o.DealerId == id : o.DealerId > 0) && o.VehicleTypeId == 1)
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

                nuObj.warr_nv = Math.Round((decimal)backendOptions_nv.Select(x => x.Warr).Sum(), 2);
                nuObj.warr_count_nv = backendOptions_nv.Select(x => x.IsWarr).Sum();

                nuObj.dent_nv = Math.Round((decimal)backendOptions_nv.Select(x => x.Dent).Sum(), 2);
                nuObj.dent_count_nv = backendOptions_nv.Select(x => x.IsDent).Sum();

                nuObj.maint_nv = Math.Round((decimal)backendOptions_nv.Select(x => x.Maint).Sum(), 2);
                nuObj.maint_count_nv = backendOptions_nv.Select(x => x.IsMaint).Sum();

                nuObj.cl_nv = Math.Round((decimal)backendOptions_nv.Select(x => x.CreditLife).Sum(), 2);
                nuObj.cl_count_nv = backendOptions_nv.Select(x => x.IsCreditLife).Sum();

                nuObj.ah_nv = Math.Round((decimal)backendOptions_nv.Select(x => x.AH).Sum(), 2);
                nuObj.ah_count_nv = backendOptions_nv.Select(x => x.IsAH).Sum();

                nuObj.env_nv = Math.Round((decimal)backendOptions_nv.Select(x => x.Enviro).Sum(), 2);
                nuObj.env_count_nv = backendOptions_nv.Select(x => x.IsEnviro).Sum();

                nuObj.etch_nv = Math.Round((decimal)backendOptions_nv.Select(x => x.Etch).Sum(), 2);
                nuObj.etch_count_nv = backendOptions_nv.Select(x => x.IsEtch).Sum();

                nuObj.gap_nv = Math.Round((decimal)backendOptions_nv.Select(x => x.Gap).Sum(), 2);
                nuObj.gap_count_nv = backendOptions_nv.Select(x => x.IsGap).Sum();

                nuObj.tw_nv = Math.Round((decimal)backendOptions_nv.Select(x => x.TireWheel).Sum(), 2);
                nuObj.tw_count_nv = backendOptions_nv.Select(x => x.IsTireWheel).Sum();

                if (nuObj.tot_vehicle_nv > 0)
                {
                    nuObj.warr_per_nv = Math.Round((double)((nuObj.warr_count_nv * 1.0) / nuObj.tot_vehicle_nv), 2);
                    nuObj.dent_per_nv = Math.Round((double)((nuObj.dent_count_nv * 1.0) / nuObj.tot_vehicle_nv), 2);
                    nuObj.maint_per_nv = Math.Round((double)((nuObj.maint_count_nv * 1.0) / nuObj.tot_vehicle_nv), 2);
                    nuObj.cl_per_nv = Math.Round((double)((nuObj.cl_count_nv * 1.0) / nuObj.tot_vehicle_nv), 2);
                    nuObj.ah_per_nv = Math.Round((double)((nuObj.ah_count_nv * 1.0) / nuObj.tot_vehicle_nv), 2);
                    nuObj.env_per_nv = Math.Round((double)((nuObj.env_count_nv * 1.0) / nuObj.tot_vehicle_nv), 2);
                    nuObj.etch_per_nv = Math.Round((double)((nuObj.etch_count_nv * 1.0) / nuObj.tot_vehicle_nv), 2);
                    nuObj.gap_per_nv = Math.Round((double)((nuObj.gap_count_nv * 1.0) / nuObj.tot_vehicle_nv), 2);
                    nuObj.tw_per_nv = Math.Round((double)((nuObj.tw_count_nv * 1.0) / nuObj.tot_vehicle_nv), 2);
                }

                nuObj.warr_income_nv = (nuObj.warr_count_nv > 0) ? Math.Round((double)(nuObj.warr_nv / nuObj.warr_count_nv), 2) : 0;
                nuObj.dent_income_nv = (nuObj.dent_count_nv > 0) ? Math.Round((double)(nuObj.dent_nv / nuObj.dent_count_nv), 2) : 0;
                nuObj.maint_income_nv = (nuObj.maint_count_nv > 0) ? Math.Round((double)(nuObj.maint_nv / nuObj.maint_count_nv), 2) : 0;
                nuObj.cl_income_nv = (nuObj.cl_count_nv > 0) ? Math.Round((double)(nuObj.cl_nv / nuObj.cl_count_nv), 2) : 0;
                nuObj.ah_income_nv = (nuObj.ah_count_nv > 0) ? Math.Round((double)(nuObj.ah_nv / nuObj.ah_count_nv), 2) : 0;
                nuObj.env_income_nv = (nuObj.env_count_nv > 0) ? Math.Round((double)(nuObj.env_nv / nuObj.env_count_nv), 2) : 0;
                nuObj.etch_income_nv = (nuObj.etch_count_nv > 0) ? Math.Round((double)(nuObj.etch_nv / nuObj.etch_count_nv), 2) : 0;
                nuObj.gap_income_nv = (nuObj.gap_count_nv > 0) ? Math.Round((double)(nuObj.gap_nv / nuObj.gap_count_nv), 2) : 0;
                nuObj.tw_income_nv = (nuObj.tw_count_nv > 0) ? Math.Round((double)(nuObj.tw_nv / nuObj.tw_count_nv), 2) : 0;

                #endregion

                #region Get(U)sed Values

                var vehicleCountQuery_uv = (mFIs.Union(mUnwinds))
                                .Where(v => (id != 99 ? v.Record.Dealerid == id : v.Record.Dealerid > 0) && v.Record.vehicletype == "U")
                                .Select(v => new
                                {
                                    FinType = v.Record.fitype,
                                    FinResv = v.Record.backend,
                                    GrossProfit = v.Record.payablegross,
                                    Vehicles = (v.RecordType == "U") ? -1 : 1
                                });

                nuObj.tot_vehicle_uv = vehicleCountQuery_uv.Select(x => x.Vehicles).Sum();
                if (nuObj.tot_vehicle_uv == null || nuObj.tot_vehicle_uv == 0) { break; }
                nuObj.tot_tot_uv = 0;

                //Get Financial Counts
                decimal? fe_tot_uv = 0;
                foreach (var fitype in finTypes)
                {
                    var deal_amt = vehicleCountQuery_uv.Where(x => x.FinType == fitype).Select(x => x.Vehicles).Sum();
                    var finresv = vehicleCountQuery_uv.Where(x => x.FinType == fitype).Select(x => x.FinResv).Sum();
                    var grossprofit = Math.Round(vehicleCountQuery_uv.Where(x => x.FinType == fitype).Select(x => x.GrossProfit).Sum(), 2);

                    var deal_per = (nuObj.tot_vehicle_uv > 0) ? Math.Round((double)(deal_amt*1.0 / nuObj.tot_vehicle_uv), 2) : 0;
                    var deal_income_per = (deal_amt > 0) ? Math.Round(grossprofit / deal_amt, 2) : 0;

                    switch (fitype)
                    {
                        case "1":
                            nuObj.cash_deals_uv = deal_amt;
                            nuObj.cash_deals_per_uv = deal_per;
                            nuObj.per_deal_income_cash_uv = deal_income_per;
                            nuObj.cash_tot_uv = grossprofit;
                            break;
                        case "2":
                            nuObj.conv_deals_uv = deal_amt;
                            nuObj.conv_deals_per_uv = deal_per;
                            nuObj.per_deal_income_conv_uv = deal_income_per;
                            nuObj.conv_tot_uv = grossprofit;
                            break;
                        case "3":
                            nuObj.RBF_deals_uv = deal_amt;
                            nuObj.RBF_deals_per_uv = deal_per;
                            nuObj.per_deal_income_RBF_uv = deal_income_per;
                            nuObj.rbf_tot_uv = grossprofit;
                            break;
                        case "4":
                            nuObj.OSF_deals_uv = deal_amt;
                            nuObj.OSF_deals_per_uv = deal_per;
                            nuObj.per_deal_income_OSF_uv = deal_income_per;
                            nuObj.osf_tot_uv = grossprofit;
                            break;
                    }

                    nuObj.tot_tot_uv += grossprofit;
                    fe_tot_uv += finresv;
                }

                if (nuObj.tot_vehicle_uv > 0)
                {
                    nuObj.avg_be_uv = Math.Round((double)(nuObj.tot_tot_uv / nuObj.tot_vehicle_uv), 2);
                    nuObj.avg_fe_uv = Math.Round((double)(fe_tot_uv / nuObj.tot_vehicle_uv), 2);
                }
                nuObj.avg_tot_uv = (decimal)(nuObj.avg_be_uv + nuObj.avg_fe_uv);

                var backendOptions_uv = (mFIs.Union(mUnwinds))
                        .Where(b => (id != 99 ? b.Record.Dealerid == id : b.Record.Dealerid > 0) && b.Record.vehicletype == "U")
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
                                .Where(o => (id != 99 ? o.DealerId == id : o.DealerId > 0) && o.VehicleTypeId == 2)
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

                nuObj.warr_uv = Math.Round((decimal)backendOptions_uv.Select(x => x.Warr).Sum(), 2);
                nuObj.warr_count_uv = backendOptions_uv.Select(x => x.IsWarr).Sum();

                nuObj.dent_uv = Math.Round((decimal)backendOptions_uv.Select(x => x.Dent).Sum(), 2);
                nuObj.dent_count_uv = backendOptions_uv.Select(x => x.IsDent).Sum();

                nuObj.maint_uv = Math.Round((decimal)backendOptions_uv.Select(x => x.Maint).Sum(), 2);
                nuObj.maint_count_uv = backendOptions_uv.Select(x => x.IsMaint).Sum();

                nuObj.cl_uv = Math.Round((decimal)backendOptions_uv.Select(x => x.CreditLife).Sum(), 2);
                nuObj.cl_count_uv = backendOptions_uv.Select(x => x.IsCreditLife).Sum();

                nuObj.ah_uv = Math.Round((decimal)backendOptions_uv.Select(x => x.AH).Sum(), 2);
                nuObj.ah_count_uv = backendOptions_uv.Select(x => x.IsAH).Sum();

                nuObj.env_uv = Math.Round((decimal)backendOptions_uv.Select(x => x.Enviro).Sum(), 2);
                nuObj.env_count_uv = backendOptions_uv.Select(x => x.IsEnviro).Sum();

                nuObj.etch_uv = Math.Round((decimal)backendOptions_uv.Select(x => x.Etch).Sum(), 2);
                nuObj.etch_count_uv = backendOptions_uv.Select(x => x.IsEtch).Sum();

                nuObj.gap_uv = Math.Round((decimal)backendOptions_uv.Select(x => x.Gap).Sum(), 2);
                nuObj.gap_count_uv = backendOptions_uv.Select(x => x.IsGap).Sum();

                nuObj.tw_uv = Math.Round((decimal)backendOptions_uv.Select(x => x.TireWheel).Sum(), 2);
                nuObj.tw_count_uv = backendOptions_uv.Select(x => x.IsTireWheel).Sum();

                if (nuObj.tot_vehicle_uv > 0)
                {
                    nuObj.warr_per_uv = Math.Round((double)((nuObj.warr_count_uv * 1.0) / nuObj.tot_vehicle_uv), 2);
                    nuObj.dent_per_uv = Math.Round((double)((nuObj.dent_count_uv * 1.0) / nuObj.tot_vehicle_uv), 2);
                    nuObj.maint_per_uv = Math.Round((double)((nuObj.maint_count_uv * 1.0) / nuObj.tot_vehicle_uv), 2);
                    nuObj.cl_per_uv = Math.Round((double)((nuObj.cl_count_uv * 1.0) / nuObj.tot_vehicle_uv), 2);
                    nuObj.ah_per_uv = Math.Round((double)((nuObj.ah_count_uv * 1.0) / nuObj.tot_vehicle_uv), 2);
                    nuObj.env_per_uv = Math.Round((double)((nuObj.env_count_uv * 1.0) / nuObj.tot_vehicle_uv), 2);
                    nuObj.etch_per_uv = Math.Round((double)((nuObj.etch_count_uv * 1.0) / nuObj.tot_vehicle_uv), 2);
                    nuObj.gap_per_uv = Math.Round((double)((nuObj.gap_count_uv * 1.0) / nuObj.tot_vehicle_uv), 2);
                    nuObj.tw_per_uv = Math.Round((double)((nuObj.tw_count_uv * 1.0) / nuObj.tot_vehicle_uv), 2);
                }

                nuObj.warr_income_uv = (nuObj.warr_count_uv > 0) ? Math.Round((double)(nuObj.warr_uv / nuObj.warr_count_uv), 2) : 0;
                nuObj.dent_income_uv = (nuObj.dent_count_uv > 0) ? Math.Round((double)(nuObj.dent_uv / nuObj.dent_count_uv), 2) : 0;
                nuObj.maint_income_uv = (nuObj.maint_count_uv > 0) ? Math.Round((double)(nuObj.maint_uv / nuObj.maint_count_uv), 2) : 0;
                nuObj.cl_income_uv = (nuObj.cl_count_uv > 0) ? Math.Round((double)(nuObj.cl_uv / nuObj.cl_count_uv), 2) : 0;
                nuObj.ah_income_uv = (nuObj.ah_count_uv > 0) ? Math.Round((double)(nuObj.ah_uv / nuObj.ah_count_uv), 2) : 0;
                nuObj.env_income_uv = (nuObj.env_count_uv > 0) ? Math.Round((double)(nuObj.env_uv / nuObj.env_count_uv), 2) : 0;
                nuObj.etch_income_uv = (nuObj.etch_count_uv > 0) ? Math.Round((double)(nuObj.etch_uv / nuObj.etch_count_uv), 2) : 0;
                nuObj.gap_income_uv = (nuObj.gap_count_uv > 0) ? Math.Round((double)(nuObj.gap_uv / nuObj.gap_count_uv), 2) : 0;
                nuObj.tw_income_uv = (nuObj.tw_count_uv > 0) ? Math.Round((double)(nuObj.tw_uv / nuObj.tw_count_nv), 2) : 0;

                #endregion

                report.Add(nuObj);
            }
            return report;
        }

        private IList<MasterFIRecord> GetMasterFIs()
        {
            return context.MasterFIs
                .Where(m => new int[] {4,5,6,7,9 }.Contains(m.status)
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