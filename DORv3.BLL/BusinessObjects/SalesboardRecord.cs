using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.BLL.BusinessObjects
{
    public class SalesboardRecord
    {
        public int DealerId { get; set; }
        public string Dealership { get; set; }
        public System.DateTime DateOfSale { get; set; }
        public string DayOfTheWeek { get; set; }
        public int SellingDayNumber { get; set; }
        public int WeekNumber { get; set; }
        public int NewSalesCount { get; set; }
        public int UsedSalesCount { get; set; }
        public int NewBackoutCount { get; set; }
        public int UsedBackoutCount { get; set; }
        public int UnwindSalesCount { get; set; }
    }
}