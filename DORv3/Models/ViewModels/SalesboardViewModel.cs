using DORv3.BLL.ReportObjects;
using DORv3.Domain;
using DORv3.Models.ReportObjects;
using DORv3.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace DORv3.Models.ViewModels
{
    public class SalesboardViewModel : DORViewModel
    {

        private DORService _dorService;

        private IList<SalesboardObject> _SalesboardObjects { get; set; }
        private IList<SalesboardObject> _PrevSalesBoardObjects { get; set; }

       // public IList<string> Dealerships { get; set; }
        
        private IList<Dealership> Dealerships { get; set; }

        public IList<string> DaysOfWeekHeader { get; set; }

        public IList<SalesboardRefinedObject> SalesboardObjects { get; set; }

        [Display(Name = "Report Date")]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime ReportDate { get; set; }

        public int TotalSellDays { get; set; }

        public int SellDaysCurrent { get; set; }
        public int SellDaysRemaining { get; set; }

        public IList<SalesboardReportObject> SalesboardReportObjects { get; set; }

        public SalesboardViewModel(int userID, DateTime date) : base(userID)
        {
            ReportDate = DateTime.Now;
            Salesboard sb = new Salesboard(date);
            SalesboardReportObjects = sb.GetSalesboardReport(DealerIDs);

            TotalSellDays = sb.WorkingDaysTotal;
            SellDaysCurrent = sb.WorkingDaysCompleted;
            SellDaysRemaining = sb.WorkingDaysRemaining;

            this.DaysOfWeekHeader = SalesboardReportObjects.First().DaysOfWeek.Select(d => (d.DayOfTheWeek.ToLower() == "sunday" ? "Su" : d.DayOfTheWeek.Substring(0, 1))).ToList();
            this.ReportDate = date;
        }

        //public SalesboardViewModel(string date)
        //{
        //    _dorService = new DORService();
        //    this._SalesboardObjects = _dorService.GetSalesboard(date); //get Raw Salesboard
        //    //this._PrevSalesBoardObjects = _dorService.GetSalesboard(DORv3.HelperLib.DateHelper.LastDayOfTheMonth(Convert.ToDateTime(date).AddYears(-1)).ToString());
        //    this.SalesboardObjects = new List<SalesboardRefinedObject>();

        //    //pull out the individual Dealerships
        //    this.Dealerships = (from s in this._SalesboardObjects
        //                        select new Dealership { ID = s.DealerId, Name = s.Dealership, RGBColor = s.RGBColor  })
        //                        .GroupBy(d => new {d.ID, d.Name, d.RGBColor})
        //                        .Select(n => n.FirstOrDefault())
        //                        .ToList();

        //    //Build the Refined Salesboard data
        //    foreach(var dealer in this.Dealerships)
        //    {
        //        var daysOfTheWeek = (from s in this._SalesboardObjects
        //                             where s.DealerId == dealer.ID
        //                             select new SalesboardDayOfWeek
        //                             {
        //                                 DateOfSale = s.DateOfSale,
        //                                 DayOfTheWeek = s.DayOfTheWeek,
        //                                 IsSunday = (s.DayOfTheWeek == "Sunday" ? true : false),
        //                                 SellingDay = s.SellingDayNumber,
        //                                 WeekNumber = s.WeekNumber,
        //                                 NewSalesCount = s.NewSalesCount,
        //                                 UsedSalesCount = s.UsedSalesCount

        //                             }).OrderBy(s => s.DateOfSale).ToList();
                

        //        var unwindSalesCount = (int)(from s in this._SalesboardObjects
        //                            where s.DealerId == dealer.ID 
        //                            select s.UnwindSalesCount).Sum();

        //        this.TotalSellDays = (int)daysOfTheWeek.Max(dt => dt.SellingDay);
        //        this.SellDaysCurrent = (int)daysOfTheWeek.First(dt => dt.DateOfSale == Convert.ToDateTime(date)).SellingDay;
        //        this.SellDaysRemaining = TotalSellDays - SellDaysCurrent;
                
        //        var actualNewSalesCount = (Int32)daysOfTheWeek.Where(day => day.IsSunday).ToList().Sum(dy => dy.NewSalesCount);
        //        var actualUsedSalesCount = (Int32)daysOfTheWeek.Where(day => day.IsSunday).ToList().Sum(dy => dy.UsedSalesCount);
        //        var newTravelAmt = Math.Round(Math.Round(((double)actualNewSalesCount / SellDaysCurrent) /1.0,4) * TotalSellDays);
        //        var usedTravelAmt = Math.Round(Math.Round(((double)actualUsedSalesCount / SellDaysCurrent) /1.0,4) * TotalSellDays);

        //        this.SalesboardObjects.Add(
        //            new SalesboardRefinedObject
        //            {
        //                DealerID = dealer.ID,
        //                DealerName = dealer.Name,
        //                Color = dealer.RGBColor,
        //                DaysOfWeek = daysOfTheWeek,
        //                ActualNewSalesCount = actualNewSalesCount,
        //                ActualUsedSalesCount = actualUsedSalesCount,
        //                NewTravel = newTravelAmt,
        //                UsedTravel = usedTravelAmt,
        //                UnwindCount = unwindSalesCount,
        //                AverageDailySales = Math.Round((((double)actualNewSalesCount + actualUsedSalesCount) / SellDaysCurrent) / 1.0, 0),
        //            });

                
                                
        //    }

        //    this.DaysOfWeekHeader = this.SalesboardObjects.First().DaysOfWeek.Select(d => d.DayOfTheWeek.Substring(0, 1)).ToList();

        //    ////Build DataTable
        //    //List<string> headers = new List<string>();
        //    //headers.Add("Dealer Name");
        //    //headers.AddRange(this.DaysOfWeekHeader);

        //    //DataTable sb = new DataTable();
        //    //for (int i = 0; i < headers.Count - 1; i++)
        //    //{
        //    //    sb.Columns.Add(i.ToString());
        //    //}

        //    //DataRow dr = sb.NewRow();
        //    //for (int i = 0; i < headers.Count - 1; i++)
        //    //{
        //    //    dr[i] = headers[i].ToString();
        //    //}
        //    //sb.Rows.Add(dr);

        //    //foreach(var dealerships in Dealerships)
        //    //{

        //    //}





        //}

        //public SalesboardViewModel()
        //{

        //}

    }
}