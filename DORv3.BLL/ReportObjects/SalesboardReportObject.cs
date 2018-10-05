using DORv3.BLL.BusinessObjects;
using DORv3.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.BLL.ReportObjects
{
    public class SalesboardReportObject
    {
        public DealerShip Dealership { get; set; }

        public List<SalesboardRecord> SalesboardRecords { get; set; }

        public List<SalesboardDayOfTheWeek> DaysOfWeek { get; set; }

        public int ActualNewSalesCount { get; set; }
        public int ActualUsedSalesCount { get; set; }

        public int ActualTotalSalesCount { get { return (Int32)(ActualNewSalesCount + ActualUsedSalesCount); } }

        public double NewTravel { get; set; }
        public double UsedTravel { get; set; }
        public double TotalTravel { get { return (Int32)(NewTravel + UsedTravel); } }

        public double PrevNewTravel { get; set; }
        public double PrevOldTravel { get; set; }
        public double TotalPrevTravel { get { return (Int32)(PrevNewTravel + PrevOldTravel); } }

        public int NewTravelDiff { get { return (Int32)(NewTravel - PrevNewTravel); } set { } }
        public int UsedTravelDiff { get { return (Int32)(UsedTravel - PrevOldTravel); } set { } }
        public int TotalTravelDiff { get { return (Int32)(TotalTravel - TotalPrevTravel); } }

        public double AverageDailySales { get; set; }
        public int NewBackoutCount { get; set; }
        public int UsedBackoutCount { get; set; }
        public int UnwindCount { get; set; }

        public SalesboardReportObject()
        {
            this.SalesboardRecords = new List<SalesboardRecord>();
            this.DaysOfWeek = new List<SalesboardDayOfTheWeek>();

        }

    }
}