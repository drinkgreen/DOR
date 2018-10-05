using DORv3.BLL.ReportObjects;
using DORv3.BLL;
using DORv3.HelperLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.Models.ReportObjects
{
    public class Salesboard
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int WorkingDaysTotal { get; set; }
        public int WorkingDaysCompleted { get; set; }
        public int WorkingDaysRemaining { get; set; }
        public List<SalesboardReportObject> SalesboardReport {get; set;}

        public Salesboard(DateTime date)
        {
            this.StartDate = DateHelper.FirstDayOfTheMonth(date);
            this.EndDate = date;
            
        }

        public List<SalesboardReportObject> GetSalesboardReport(List<int> dealerIDs)
        {
            SetWorkingDaysCount();
            SalesboardReport = new SalesboardBiz(StartDate, EndDate).BuildSalesboardReport(dealerIDs);
            if (this.WorkingDaysCompleted > 0) { CalculateTravel(); }
            return SalesboardReport;
        }

        private void CalculateTravel()
        {
            foreach(var obj in SalesboardReport)
            {
                obj.NewTravel = Math.Round((((double)obj.ActualNewSalesCount / this.WorkingDaysCompleted) * (double)this.WorkingDaysTotal), 0);
                obj.UsedTravel = Math.Round((((double)obj.ActualUsedSalesCount / this.WorkingDaysCompleted) * (double)this.WorkingDaysTotal), 0);
                obj.AverageDailySales = Math.Round((double)(obj.ActualTotalSalesCount*1.0 / this.WorkingDaysCompleted), 0);
            }
        }

        private void SetWorkingDaysCount()
        {
            DateTime date_to = new DateTime(EndDate.Year, EndDate.AddMonths(1).Month, 1).AddDays(-1); //end of the specified month

            WorkingDaysTotal = DateHelper.WorkingDaysInMonth(EndDate);
            WorkingDaysCompleted = DateHelper.WorkingDaysInMonthUntilDate(EndDate);
            WorkingDaysRemaining = WorkingDaysTotal - WorkingDaysCompleted;
        }
    }
}