using DORv3.BLL;
using DORv3.BLL.FilterObjects;
using DORv3.BLL.ReportObjects;
using DORv3.DAL.Models;
//using DORv3.Domain;
using DORv3.Models.ReportObjects;
using QueryDesigner;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace DORv3.Models.ViewModels
{
    public class MTDViewModel : DORViewModel
    {
        public IList<dynamic> MTDRecords { get; set; }

        public decimal? Dent { get; set; }
        public decimal? CL { get; set; }
        public decimal? Warr { get; set; }
        public decimal? Enviro { get; set; }
        public decimal? Etch { get; set; }
        public decimal? Gap { get; set; }
        public decimal? TW { get; set; }
        public decimal? Finance { get; set; }
        public decimal? FrontEnd { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BookedStartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BookedEndDate { get; set; }

        public DealerShip Dealership { get; set; }

        public List<DealerShip> Dealerships { get; set; }

        public VehicleType VehicleType { get; set; }
        public List<VehicleType> VehicleTypes { get; set; }

        public DealStatu DealStatus { get; set; }
        public List<DealStatu> DealStatuses { get; set; }

        public Vehicle VehicleKind { get; set; }
        public List<Vehicle> VehicleKinds { get; set; }

        public SalesCategory SalesCategory { get; set; }
        public List<SalesCategory> SalesCategories { get; set; }

        public List<MTDReportObject> MTDReport { get; set; }

        public List<MTDFilterObj> Filters { get; set; }

        public MTDRecapBiz BizObject { get; set; }
        public FinanceManager FinanceManager { get; set; }
        public List<FinanceManager> FinanceManagers { get; private set; }
        public SalesManager SalesManager { get; set; }
        public List<SalesManager> SalesManagers { get; private set; }
        public SalesPerson SalesPerson { get; set; }
        public List<SalesPerson> SalesPeople { get; private set; }
        public BUSINESSSOURCE BusinessSource { get; set; }
        public List<BUSINESSSOURCE> BusinessSources { get; private set; }

        public MTDViewModel(int userID, DateTime startDate, DateTime endDate, int dealerID, List<MTDFilterObj> filters) : base(userID)
        {
            this.StartDate = startDate.Date;
            this.EndDate = endDate.Date;
            this.Filters = filters;



            this.Dealerships = new List<DealerShip>();
            this.VehicleTypes = new List<VehicleType>();
            this.DealStatuses = new List<DealStatu>();
            this.VehicleKinds = new List<Vehicle>();
            this.BusinessSources = new List<BUSINESSSOURCE>();
            this.SalesCategories = new List<SalesCategory>();
            this.FinanceManagers = new List<FinanceManager>();
            this.SalesManagers = new List<SalesManager>();
            this.SalesPeople = new List<SalesPerson>();

            MTDRecapBiz biz = new MTDRecapBiz(DealerIDs,StartDate, EndDate, dealerID, Filters);
            this.MTDReport = biz.BuildMTDReport();
            this.Dealerships = biz.Dealerships;
            this.Dealership = biz.Dealership;
            this.VehicleTypes = biz.VehicleTypes;
            this.DealStatuses = biz.DealStatuses;
            this.VehicleType = biz.VehicleType;
            this.VehicleKinds = biz.VehicleKinds;
            this.BusinessSources = biz.BusinessSources.Where(b => (b.DisableDate == null || b.DisableDate > this.StartDate)).ToList();
            this.SalesCategories = biz.SalesCategories;
            this.FinanceManagers = biz.FinanceManagers.Where(f=> (f.DisableDate == null || f.DisableDate >= this.StartDate)).ToList();
            this.SalesManagers = biz.SalesManagers.Where(sm => (sm.DisableDate == null || sm.DisableDate > this.StartDate)).ToList();
            this.SalesPeople = biz.SalesPeople.Where(sp => (sp.DisableDate == null || sp.DisableDate > this.StartDate)).ToList();

            this.VehicleTypes.Add(new VehicleType { VehicleTypeId = 0, VehicleType1 = "All" });
            this.DealStatuses.Add(new DealStatu { StatusId = 0, StatusName = "All" });
            this.VehicleKinds.Add(new Vehicle { VehicleId = 0, Vehicle1 = "All" });
            this.SalesCategories.Add(new SalesCategory { SalesCategoryId = 0, SalesCategory1 = "All" });
            this.FinanceManagers.Add(new FinanceManager { FMId = 0, FMName = "All" });
            this.SalesManagers.Add(new SalesManager { SMId = 0, SMName = "All" });
            this.SalesPeople.Add(new SalesPerson { ID = 0, SPName = "[All]" });
            this.BusinessSources.Add(new BUSINESSSOURCE { BusinessSourceID = 0, BusinessSource1 = "All" });
            


            

        }

        public MTDViewModel(int userID, DateTime startDate, DateTime endDate, int dealerID, string saleType) : base(userID)
        {
            this.StartDate = startDate.Date;
            this.EndDate = endDate.Date;
            this.Dealerships = new List<DealerShip>();
            this.VehicleTypes = new List<VehicleType>();
            this.DealStatuses = new List<DealStatu>();
            this.VehicleKinds = new List<Vehicle>();
            this.SalesCategories = new List<SalesCategory>();
            this.BusinessSources = new List<BUSINESSSOURCE>();
            this.SalesCategories = new List<SalesCategory>();
            this.FinanceManagers = new List<FinanceManager>();
            this.SalesManagers = new List<SalesManager>();
            this.SalesPeople = new List<SalesPerson>();


            //MTDRecap mtd = new MTDRecap(StartDate, EndDate, dealerID, VehicleType);
            //MTDReport = mtd.BuildMTDREport();
            //this.Dealership = mtd.Dealership;
            //this.Dealerships = mtd.Dealerships;
            //this.VehicleType = mtd.VehicleType;

            MTDRecapBiz biz = new MTDRecapBiz(DealerIDs,StartDate, EndDate, dealerID, saleType);
            this.MTDReport = biz.BuildMTDReport();
            this.Dealerships = biz.Dealerships;
            this.Dealership = biz.Dealership;
            this.VehicleTypes = biz.VehicleTypes;
            this.DealStatuses = biz.DealStatuses;
            this.VehicleType = biz.VehicleType;
            this.VehicleKinds = biz.VehicleKinds;
            this.BusinessSources = biz.BusinessSources;
            this.SalesCategories = biz.SalesCategories;
            this.FinanceManagers = biz.FinanceManagers.Where(f => (f.DisableDate == null || f.DisableDate >= this.StartDate)).ToList();
            this.SalesManagers = biz.SalesManagers.Where(sm => (sm.DisableDate == null || sm.DisableDate > this.StartDate)).ToList();
            this.SalesPeople = biz.SalesPeople.Where(sp => (sp.DisableDate == null || sp.DisableDate > this.StartDate)).ToList();

            this.VehicleTypes.Add(new VehicleType { VehicleTypeId = 0, VehicleType1 = "All" });
            this.DealStatuses.Add(new DealStatu { StatusId = 0, StatusName = "All" });
            this.VehicleKinds.Add(new Vehicle { VehicleId = 0, Vehicle1 = "All" });
            this.SalesCategories.Add(new SalesCategory { SalesCategoryId = 0, SalesCategory1 = "All" });
            this.FinanceManagers.Add(new FinanceManager { FMId = 0, FMName = "All" });
            this.SalesManagers.Add(new SalesManager { SMId = 0, SMName = "All" });
            this.SalesPeople.Add(new SalesPerson { ID = 0, SPName = "[All]" });
            this.BusinessSources.Add(new BUSINESSSOURCE { BusinessSourceID = 0, BusinessSource1 = "All" });

            this.BizObject = biz;

        }
    }
}