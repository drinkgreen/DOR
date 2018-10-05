using DORv3.BLL;
using DORv3.BLL.ReportObjects;
using DORv3.HelperLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.Models.ReportObjects
{
    public class NU_Recap
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int WorkingDaysTotal { get; set; }
        public int WorkingDaysCompleted { get; set; }
        public int WorkingDaysRemaining { get; set; }
        public List<NU_RecapReportObject> NU_RecapReport { get; set; }

        public NU_Recap(DateTime startDate, DateTime endDate)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        public List<NU_RecapReportObject> GetNU_RecapReport(List<int> dealerIDs)
        {
            SetWorkingDaysCount();
            NU_RecapReport = new NU_RecapReportBiz(StartDate, EndDate).BuildNU_RecapReport(dealerIDs);
            return NU_RecapReport;
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