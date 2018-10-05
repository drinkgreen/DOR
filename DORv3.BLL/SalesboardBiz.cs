using DORv3.BLL.BusinessObjects;
using DORv3.BLL.ReportObjects;
using DORv3.DAL.Models;
using DORv3.HelperLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.BLL
{
    public class SalesboardBiz
    {
        private FowlerDORContext context;
        private IList<MasterFIRecord> mFIs, mUnwinds;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public SalesboardBiz(DateTime startDate, DateTime endDate)
        {
            context = new FowlerDORContext();
            this.StartDate = startDate;
            this.EndDate = endDate;
            mFIs = GetMasterFIsForSalesboard();
            mUnwinds = GetUnwindsForSalesboard();
        }

        public List<SalesboardReportObject> BuildSalesboardReport(List<int> dealerIDs)
        {
            List<SalesboardReportObject> report = new List<SalesboardReportObject>();

            //pull out the individual Dealerships
            List<DealerShip> dealers = context.DealerShips.Where(d => dealerIDs.Contains(d.DealerID) && (d.DisableDate == null || d.DisableDate > StartDate)).ToList();

            SalesboardReportObject sbObj = null;
            var sundays = DateHelper.GetAllDatesOfSpecifiedDayOfWeekInMonth(EndDate, DayOfWeek.Sunday);
            foreach (var dealer in dealers)
            {
                sbObj = new SalesboardReportObject();
                sbObj.Dealership = dealer;
                var id = dealer.DealerID;
                var saleDate = StartDate;
                SalesboardRecord sbRecord = null;
                while(saleDate <= EndDate)
                {
                    sbRecord = new SalesboardRecord();
                    sbRecord.Dealership = dealer.DealerName;
                    sbRecord.DateOfSale = saleDate;
                    sbRecord.DayOfTheWeek = saleDate.DayOfWeek.ToString();
                    sbRecord.SellingDayNumber = DateHelper.WorkingDaysInMonthUntilDate(saleDate);
                    sbRecord.WeekNumber = (saleDate.DayOfWeek == DayOfWeek.Sunday) ? sundays.IndexOf(saleDate) + 1 : 0;

                    var salesBoardQuery = (mFIs.Union(mUnwinds))
                            .Where(s => (id == 99 ? s.Record.Dealerid > 0 : s.Record.Dealerid == id) 
                                        && ((s.RecordType=="M") ? s.Record.delvdate : s.Record.unwinddate) == saleDate)
                            .Select(s => new
                            {
                                New = (s.RecordType == "M" && s.Record.vehicletype == "N" ? 1 : 0),
                                Used = (s.RecordType == "M" && s.Record.vehicletype == "U" ? 1 : 0),
                                BackoutNew = (s.RecordType == "M" && s.Record.vehicletype == "N" && s.Record.status == 8 ? 1 : 0),
                                BackoutUsed = (s.RecordType == "M" && s.Record.vehicletype == "U" && s.Record.status == 8 ? 1 : 0),
                                Unwind = (s.RecordType == "U") ? 1 : 0
                            });

                    int newSales = 0, usedSales =0;
                    if (sbRecord.WeekNumber == 1) //First Sunday
                    {
                        newSales = sbObj.SalesboardRecords
                            .Where(s => s.DateOfSale >= DateHelper.FirstDayOfTheMonth(saleDate) && s.DateOfSale <= saleDate)
                            .Select(s => s.NewSalesCount).Sum();

                        usedSales = sbObj.SalesboardRecords
                            .Where(s => s.DateOfSale >= DateHelper.FirstDayOfTheMonth(saleDate) && s.DateOfSale <= saleDate)
                            .Select(s => s.UsedSalesCount).Sum();

                    } else if (sbRecord.WeekNumber > 1) //Sunday besides the First Sunday
                    {
                        newSales = sbObj.SalesboardRecords
                            .Where(s => s.DateOfSale >= saleDate.AddDays(-6) && s.DateOfSale <= saleDate)
                            .Select(s => s.NewSalesCount).Sum();

                        usedSales = sbObj.SalesboardRecords
                            .Where(s => s.DateOfSale >= saleDate.AddDays(-6) && s.DateOfSale <= saleDate)
                            .Select(s => s.UsedSalesCount).Sum();
                    }
                    else //Weekday
                    {
                        newSales = salesBoardQuery.Select(x => x.New).Sum();
                        usedSales = salesBoardQuery.Select(x => x.Used).Sum();
                    }
                    sbRecord.NewSalesCount = newSales;
                    sbRecord.UsedSalesCount = usedSales;
                    
                    sbRecord.NewBackoutCount = salesBoardQuery.Select(x => x.BackoutNew).Sum();
                    sbRecord.UsedBackoutCount = salesBoardQuery.Select(x => x.BackoutUsed).Sum();
                    sbRecord.UnwindSalesCount = salesBoardQuery.Select(x => x.Unwind).Sum();

                    sbObj.SalesboardRecords.Add(sbRecord);

                    saleDate = saleDate.AddDays(1);
                }

                //Report is Built.  Not we have to set the Report totals
                sbObj.DaysOfWeek = sbObj.SalesboardRecords
                    .Select(s => new SalesboardDayOfTheWeek
                    {
                        DateOfSale = s.DateOfSale,
                        DayOfTheWeek = s.DayOfTheWeek,
                        IsSunday = (s.DayOfTheWeek == "Sunday" ? true : false),
                        SellingDay = s.SellingDayNumber,
                        WeekNumber = s.WeekNumber,
                        NewSalesCount = s.NewSalesCount,
                        UsedSalesCount = s.UsedSalesCount
                    }).OrderBy(s=>s.DateOfSale).ToList();

                sbObj.ActualNewSalesCount = sbObj.SalesboardRecords.Where(x=>x.DayOfTheWeek != "Sunday").Select(x => x.NewSalesCount).Sum();
                sbObj.ActualUsedSalesCount = sbObj.SalesboardRecords.Where(x => x.DayOfTheWeek != "Sunday").Select(x => x.UsedSalesCount).Sum();
                sbObj.NewBackoutCount = sbObj.SalesboardRecords.Select(x => x.NewBackoutCount).Sum();
                sbObj.UsedBackoutCount = sbObj.SalesboardRecords.Select(x => x.UsedBackoutCount).Sum();
                sbObj.UnwindCount = sbObj.SalesboardRecords.Select(x => x.UnwindSalesCount).Sum();
                var sbPrevTravelQuery = GetPrevSalesboardCount().Where(s => (id == 99 ? s.Record.Dealerid > 0 : s.Record.Dealerid == id));
                sbObj.PrevNewTravel = sbPrevTravelQuery.Where(x => x.Record.vehicletype == "N").Count();
                sbObj.PrevOldTravel = sbPrevTravelQuery.Where(x => x.Record.vehicletype == "U").Count();

                report.Add(sbObj);
            }


            return report;
            
        }

        private IList<MasterFIRecord> GetMasterFIsForSalesboard()
        {
            return context.MasterFIs
                .Where(m => new int[] { 4, 5, 6, 7, 9 }.Contains(m.status) //m.status != "6" //No Wholesale
                        && (m.delvdate >= StartDate && m.delvdate <= EndDate)
                            //|| (m.delvdate == new DateTime(1900, 1, 1) && m.salesdate >= StartDate && m.salesdate <= EndDate)))
                 ).Select(d => new MasterFIRecord
                 {
                     RecordType = "M",
                     Record = d
                 }).ToList();
        }

        private IList<MasterFIRecord> GetUnwindsForSalesboard()
        {
            return context.MasterFIs
                .Where(m => m.status == 9 && m.unwinddate >= StartDate && m.unwinddate <= EndDate)
                .Select(d => new MasterFIRecord
                {
                    RecordType = "U",
                    Record = d
                }).ToList();
        }

        private IList<MasterFIRecord> GetPrevSalesboardCount()
        {
            DateTime prevStartDate = DateHelper.FirstDayOfTheMonth(StartDate.AddYears(-1));
            DateTime prevEndDate = DateHelper.LastDayOfTheMonth(StartDate.AddYears(-1));

            IList<MasterFIRecord> mRecs = context.MasterFIs
                .Where(m => m.status != 6 //No Wholesale
                        && ((m.delvdate >= prevStartDate && m.delvdate <= prevEndDate)
                            || (m.delvdate == new DateTime(1900, 1, 1) && m.salesdate >= prevStartDate && m.salesdate <= prevEndDate)))
                 .Select(d => new MasterFIRecord
                 {
                     RecordType = "M",
                     Record = d
                 }).ToList();
           var ret = mRecs.Union(context.MasterFIs.Where(m => m.status != 6 && m.unwinddate >= prevStartDate && m.unwinddate <= prevEndDate)
                 .Select(d => new MasterFIRecord
                 {
                     RecordType = "U",
                     Record = d
                 }).ToList());

            return ret.ToList();
        }
    }
}