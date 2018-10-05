using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.Models
{
    public class SalesboardRefinedObject
    {
        public int DealerID { get; set; }

        public string DealerName { get; set; }

        public string Color { get; set; }

        public List<SalesboardDayOfWeek> DaysOfWeek { get; set; }

        public int ActualNewSalesCount { get; set; }
        public int ActualUsedSalesCount { get; set; }

        public int ActualTotalSalesCount { get { return (Int32)(ActualNewSalesCount + ActualUsedSalesCount); } }

        public double NewTravel { get; set; }
       public double UsedTravel { get; set; }
        public double TotalTravel { get { return (Int32)(NewTravel + UsedTravel); } }

        public double PrevNewTravel { get; set; }
        public double PrevOldTravel { get; set; }
        public double TotalPrevTravel { get { return (Int32)(PrevNewTravel + PrevOldTravel); } }

        public int NewTravelDiff { get; set; }
        public int UsedTravelDiff { get; set; }
        public int TotalTravelDiff { get { return (Int32)(TotalTravel - TotalPrevTravel); } }

        public double AverageDailySales { get; set; }

        public int UnwindCount { get; set; }


        

        public SalesboardRefinedObject()
        {

        }
    }
}