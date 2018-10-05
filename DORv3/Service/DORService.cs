using DORv3.BLL.ReportObjects;
using DORv3.BLL;
using DORv3.Domain;
using DORv3.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.Service
{
    public class DORService
    {
        private FowlerDOR context;
        private DOR1234biz biz;
        public DORService()
        {
            //biz = new DOR1234biz();
            context = new FowlerDOR();
            context.SaveChanges();
        }

        public IList<SalesRecapObject> GetSalesRecapReport_OLD(string startDate, string endDate)
        {
            return context.get_sales_recap(startDate, endDate).ToList();
        }

        //internal IList<SalesRecapReportObject> GetSalesRecapReport(DateTime startDate, DateTime enddate)
        //{
        //    return new Models.ReportObjects.SalesRecap(startDate, enddate).GetSalesRecapReport();
        //}

        internal IList<FinanceRecapObject> GetFinanceRecapReport_OLD(string startDate, string endDate)
        {
            return context.Get_Finance_Recap(startDate, endDate).ToList();
        }

        //internal IList<FinanceRecapReportObject> GetFinanceRecapReport(DateTime startDate, DateTime endDate)
        //{
        //    return new Models.ReportObjects.FinanceRecap(startDate, endDate).GetFinanceRecapReport();
        //}

        internal IList<SalesboardObject> GetSalesboard(string date)
        {
            return context.Get_Salesboard(Convert.ToDateTime(date)).ToList();
        }

        internal IList<MonthToDateObject> GetMonthToDateObjects(string startDate, string endDate, int dealerID, string type)
        {
            return context.Get_MTD_18(startDate, endDate, dealerID, type).ToList();
        }

        internal IList<MonthToDateObject> GetMonthToDateObjects(DateTime startDate, DateTime endDate, int dealerID, string type)
        {
            return context.Get_MTD_18(startDate.ToShortDateString(), endDate.ToShortDateString(), dealerID, type).ToList();
        }

        internal IList<DOR1234Object> GetDOR1234RecapReport(string startDate, string endDate)
        {
            return context.get_dor1234(startDate, endDate).ToList();
        }

        //internal IList<DOR1234ReportObject> GetDOR1234Report(DateTime startDate, DateTime enddate)
        //{
        //    return new Models.ReportObjects.DOR1234(startDate, enddate).GetDOR1234Report();
        //}

        internal void BuildDOR1234Report_OLD(DateTime startDate, DateTime endDate)
        {
            var db = new DORv3.DAL.FowlerDORContext();
            var date_from = startDate;
            var date_to = new DateTime(endDate.Year, endDate.AddMonths(1).Month, 1).AddDays(-1); //end of the specified month

            //Get Working Day Counts
            int wd_tot = DateHelper.WorkingDaysInMonth(date_to);
            int wd_comp = DateHelper.WorkingDaysInMonthUntilDate(endDate);
            int wd_left = wd_tot - wd_comp;

            //Start building report
            #region Get Vehicle Counts

            var mFIs = db.MasterFIs.Where(m => m.Dealerid == 1 
                                                && new string[] { "4", "5", "6", "7", "9" }.Contains(m.status)
                                                && ((m.delvdate >= startDate && m.delvdate <= endDate)
                                                    || (m.delvdate == new DateTime(1900, 1, 1) && m.salesdate >= startDate && m.salesdate <= endDate)));

            var vehicleCountQuery =
                    (from m in db.MasterFIs
                     where new string[] { "4", "5", "6", "7", "9" }.Contains(m.status)
                                 && ((m.delvdate >= startDate && m.delvdate <= endDate)
                                    || (m.delvdate == new DateTime(1900, 1, 1) && m.salesdate >= startDate && m.salesdate <= endDate))
                                 && m.Dealerid == 1
                     select new
                     {
                         Used = m.vehicletype == "U" ? 1 : 0,
                         New = m.vehicletype == "N"? 1 : 0
                         //NewCar = (m.vehicletype == "N" && m.vehicle == "P") ? 1 : 0,
                         //NewTruck = (m.vehicletype == "N" && m.vehicle == "T") ? 1 : 0,
                         //NewSuv = (m.vehicletype == "N" && m.vehicle == "S") ? 1 : 0
                     }).ToList()
                     .Concat
                     (from m in db.MasterFIs
                      where m.unwinddate >= startDate && m.unwinddate <= endDate && m.Dealerid == 1
                      select new
                      {
                          Used = m.vehicletype == "U" ? -1 : 0,
                          New = m.vehicletype == "N" ? -1 : 0
                          //NewCar = (m.vehicletype == "N" && m.vehicle == "P") ? -1 : 0,
                          //NewTruck = (m.vehicletype == "N" && m.vehicle == "T") ? -1 : 0,
                          //NewSuv = (m.vehicletype == "N" && m.vehicle == "S") ? -1 : 0
                      }).ToList();

            var test = new
            {
                UsedCount = vehicleCountQuery.Select(x => x.Used).Sum(),
                NewCount = vehicleCountQuery.Select(x => x.New).Sum(),
                //NewTrucks = vehicleCountQuery.Select(x => x.NewTruck).Sum(),
                //NewSUVs = vehicleCountQuery.Select(x => x.NewSuv).Sum(),
            };

            #endregion

            #region Finance Options

            #endregion

        }

        internal IList<NU_ReportObject> GetNU_Report_OLD(string startDate, string endDate)
        {
            return context.Get_NU_Report(startDate, endDate, 1).ToList();
        }

        //internal IList<NU_RecapReportObject> GetNU_Report(DateTime startDate, DateTime endDate)
        //{
        //    return new Models.ReportObjects.NU_Recap(startDate, endDate).GetNU_RecapReport();
        //}
    }
}