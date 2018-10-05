using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DORv3.Models
{
    public class SalesboardDayOfWeek
    {
        public SalesboardDayOfWeek()
        {

        }

        public DateTime DateOfSale { get; set; }

        public string DayOfTheWeek { get; set; }

        public bool IsSunday { get; set; }

        public int? SellingDay { get; set; }

        public int? WeekNumber { get; set; }

        [Display(Name="New")]
        public int? NewSalesCount { get; set; }

        [Display(Name="Used")]
        public int? UsedSalesCount { get; set; }

        [Display(Name="Total")]
        public int TotalSalesCount { get { return (Int32)(NewSalesCount + UsedSalesCount); } }

    }
}