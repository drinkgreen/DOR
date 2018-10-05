using DORv3.BLL;
using DORv3.BLL.ReportObjects;
using DORv3.Domain;
using DORv3.HelperLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.Models.ReportObjects
{
    public class DOR1234
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int WorkingDaysTotal { get; set; }
        public int WorkingDaysCompleted { get; set; }
        public int WorkingDaysRemaining { get; set; }
        public List<DOR1234ReportObject> DOR1234Report { get; set; }


        public DOR1234(DateTime startDate, DateTime endDate)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        public List<DOR1234ReportObject> GetDOR1234Report(List<int> dealerIDs)
        {
            SetWorkingDaysCount();
            DOR1234Report = new DOR1234biz(StartDate, EndDate).BuildDOR1234Report(dealerIDs);
            return DOR1234Report;
        }

        private void SetWorkingDaysCount()
        {
            DateTime date_to = new DateTime(EndDate.Year, EndDate.AddMonths(1).Month, 1).AddDays(-1); //end of the specified month

            WorkingDaysTotal = DateHelper.WorkingDaysInMonth(EndDate);
            WorkingDaysCompleted = DateHelper.WorkingDaysInMonthUntilDate(EndDate);
            WorkingDaysRemaining = WorkingDaysTotal - WorkingDaysCompleted;
        }

        //public void BuildDOR1234Report(DateTime startDate, DateTime endDate)
        //{
        //    //var db = new FowlerDORContext();
        //    var date_from = startDate;
        //    var date_to = new DateTime(endDate.Year, endDate.AddMonths(1).Month, 1).AddDays(-1); //end of the specified month

        //    //Get Working Day Counts
        //    int wd_tot = DateHelper.WorkingDaysInMonth(date_to);
        //    int wd_comp = DateHelper.WorkingDaysInMonthUntilDate(endDate);
        //    int wd_left = wd_tot - wd_comp;

        //    //Start building report
        //    #region Get Vehicle Counts

        //    mFIs = GetMasterFIs();
        //    mUnwinds = GetUnwinds();

        //    var vehicleCountQuery = mFIs.Where(m => m.Dealerid == 1).Select(v =>
        //        new
        //        {
        //            Used = v.vehicletype == "U" ? 1 : 0,
        //            New = v.vehicletype == "N" ? 1 : 0
        //        }).ToList().Concat(mUnwinds.Where(u => u.Dealerid == 1).Select(u =>
        //        new
        //        {
        //            Used = u.vehicletype == "U" ? -1 : 0,
        //            New = u.vehicletype == "N" ? -1 : 0
        //        }));
        //                 //(from m in context.MasterFIs
        //                 // where m.unwinddate >= startDate && m.unwinddate <= endDate && m.Dealerid == 1
        //                 // select new
        //                 // {
                              
        //                 //     //NewCar = (m.vehicletype == "N" && m.vehicle == "P") ? -1 : 0,
        //                 //     //NewTruck = (m.vehicletype == "N" && m.vehicle == "T") ? -1 : 0,
        //                 //     //NewSuv = (m.vehicletype == "N" && m.vehicle == "S") ? -1 : 0
        //                 // }).ToList();

        //    var test = new
        //    {
        //        UsedCount = vehicleCountQuery.Select(x => x.Used).Sum(),
        //        NewCount = vehicleCountQuery.Select(x => x.New).Sum(),
        //        //NewTrucks = vehicleCountQuery.Select(x => x.NewTruck).Sum(),
        //        //NewSUVs = vehicleCountQuery.Select(x => x.NewSuv).Sum(),
        //    };

        //    #endregion

        //    #region Finance Backend Options
        //    var backendOptions = mFIs.Where(m => m.Dealerid == 1).Select(b =>
        //        new
        //        {
        //            Dent = b.dent > 0 ? 1 : 0,
        //            CreditLife = b.cl > 0 ? 1 : 0,
        //            Maint = b.Maint > 0 ? 1 : 0,
        //            Gap = b.gap > 0 ? 1 : 0,
        //            Etch = b.etch > 0 ? 1 : 0,
        //            TireWheel = b.tirewheel > 0 ? 1 : 0,
        //            Enviro = b.enviro > 0 ? 1 : 0,
        //            Key = b.TBD > 0 ? 1 : 0,
        //            AH = b.ah > 0 ? 1 : 0,
        //            VSC = b.vsc != 0 ? 1 : 0,
        //            Map = b.vscoption == "Map" ? 1 : 0
        //        }).ToList();
        //    #endregion
        //}

        //private IQueryable<MasterFI> GetMasterFIs()
        //{
        //    return context.MasterFIs.Where(m => m.Dealerid == 1
        //                                        && new string[] { "4", "5", "6", "7", "9" }.Contains(m.status)
        //                                        && ((m.delvdate >= StartDate && m.delvdate <= EndDate)
        //                                            || (m.delvdate == new DateTime(1900, 1, 1) && m.salesdate >= StartDate && m.salesdate <= EndDate)));
        //}

        //private IQueryable<MasterFI> GetUnwinds()
        //{
        //    return context.MasterFIs.Where(m => m.unwinddate >= StartDate && m.unwinddate <= EndDate);
        //}
    }
}