using DORv3.BLL;
using DORv3.BLL.ReportObjects;
using DORv3.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.Models.ReportObjects
{
    public class MTDRecap
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int DealerID { get; set; }
        public DealerShip Dealership { get; set; }
        public List<DealerShip> Dealerships { get; set; }
        public string VehicleType { get; set; }

        public List<MTDReportObject> MTDReport { get; set; }

        public MTDRecap(DateTime startDate, DateTime endDate, int dealerID, string saleType)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.DealerID = dealerID;
            this.VehicleType = saleType;
        }

        public List<MTDReportObject> BuildMTDREport(List<int> DealerIDs)
        {
            MTDRecapBiz biz = new MTDRecapBiz(DealerIDs,StartDate, EndDate, DealerID, VehicleType);
            this.Dealerships = biz.Dealerships;
            this.Dealership = biz.Dealership;
            this.MTDReport = biz.BuildMTDReport();
            return MTDReport;
        }
    }
}