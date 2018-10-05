using DORv3.BLL;
using DORv3.BLL.ReportObjects;
using DORv3.HelperLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.Models.ReportObjects
{
    public class FinanceRecap
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int WorkingDaysTotal { get; set; }
        public int WorkingDaysCompleted { get; set; }
        public int WorkingDaysRemaining { get; set; }
        public List<FinanceRecapReportObject> FinanceRecapReport { get; set; }

        public FinanceRecap(DateTime startDate, DateTime endDate)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        public List<FinanceRecapReportObject> GetFinanceRecapReport(List<int> dealerIDs)
        {
            SetWorkingDaysCount();
            FinanceRecapReport = new FinanceRecapBiz(StartDate, EndDate).BuildFinanceRecapReport(dealerIDs);
            return FinanceRecapReport;
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