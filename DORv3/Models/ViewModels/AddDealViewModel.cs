using DORv3.DAL.Models;
using DORv3.BLL.BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DORv3.BLL;

namespace DORv3.Models.ViewModels
{
    public class AddDealViewModel : DORViewModel
    {
        private FowlerDORContext context;

        private List<int> _makeIDs = new List<int>();
        private List<Make> _makes;

        public DealRecord Deal { get; set; }
        //public List<int> DealerIDs { get; set; }

        //public BUSINESSSOURCE BusinessSource { get; set; }
        public List<BUSINESSSOURCE> BusinessSources { get; set; }

        //public DealStatu DealStatus { get; set; }
        public List<DealStatu> DealStatuses { get; set; }

        //public FinanceType FinanceType { get; set; }
        //public FinanceType Intent { get; set; }
        public List<FinanceType> FinanceTypes { get; set; }

        //public Make VehicleMake { get; set; }
        public List<Make> Makes
        {
            get { return this._makes; }
            set
            {
                this._makes = value;
                this._makeIDs = value.Select(m => m.MakeId).ToList();
            }
        }

        //public Model VehicleModel { get; set; }
        public List<Model> VehicleModels { get; set; }

        //public GradeCredit GradeCredit { get; set; }
        public List<GradeCredit> GradeCredits { get; set; }

        //public SalesCategory SalesCategory { get; set; }
        public List<SalesCategory> SalesCategories { get; set; }

        //public Vehicle VehicleKind { get; set; }
        public List<Vehicle> VehicleKinds { get; set; }

        //public VehicleType VehicleType { get; set; }
        public List<VehicleType> VehicleTypes { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime DateToAccounting { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime BookedDate { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime DateToTag { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime DateToBank { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime DatePaid { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime SaleDate { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime DeliveryDate { get; set; }

        //public SalesPerson Salesperson1 { get; set; }
        //public SalesPerson Salesperson2 { get; set; }
        //public SalesPerson Salesperson3 { get; set; }
        public List<SalesPerson> SalesPeople { get; set; }

        //public SalesManager SalesManager { get; set; }
        public List<SalesManager> SalesManagers { get; set; }

        //public FinanceManager FinanceManager { get; set; }
        public List<FinanceManager> FinanceManagers { get; set; }

        //public DORLienHolder LienHolder { get; set; }
        public List<DORLienHolder> LienHolders { get; set; }

        //public Dealership Dealership { get; set; }
        public List<DealerShip> Dealerships { get; set; }

        public AddDealViewModel(int userID, int dealerID) : base(userID)
        {
            context = new FowlerDORContext();

            //this.Dealerships = context.DealerShips.Where(d => (d.DisableDate == null || d.DisableDate > DateTime.Now) && DealerIDs.Contains(d.DealerID)).ToList();
            //this.BusinessSources = context.BUSINESSSOURCEs.Where(b=>b.DisableDate == null).ToList();
            //this.FinanceTypes = context.FinanceTypes.ToList();
            //this.VehicleTypes = context.VehicleTypes.ToList();
            //this.DealStatuses = context.DealStatus.ToList();
            //this.VehicleKinds = context.Vehicles.Where(v => v.DisableDate == null).ToList();
            //this.SalesCategories = context.SalesCategories.ToList();
            //this.GradeCredits = context.GradeCredits.ToList();

            PreLoadLists();

            if (dealerID == 0)
            {
                dealerID = this.Dealerships.Select(d => d.DealerID).First();
            }

            this.Deal = new DealRecord();
            SetDefaultDates();

            this.Makes = context.Makes.Where(m => (m.DisableDate == null || m.DisableDate > DateTime.Now ) && m.Dealer == dealerID).ToList();
            this.VehicleModels = context.Models.Where(m => (m.DisableDate == null || m.DisableDate > DateTime.Now) && _makeIDs.Contains(m.MakeId)).ToList();
            this.SalesPeople = context.SalesPersons.Where(s => (s.DisableDate == null || s.DisableDate > DateTime.Now) && s.Dealer == dealerID).ToList();
            this.SalesManagers = context.SalesManagers.Where(m => (m.DisableDate == null || m.DisableDate > DateTime.Now) && m.Dealer == dealerID).ToList();
            this.FinanceManagers = context.FinanceManagers.Where(fm => (fm.DisableDate == null || fm.DisableDate > DateTime.Now) && fm.Dealer == dealerID).ToList();
            this.LienHolders = context.DORLienHolders.Where(l => (l.DisableDate == null || l.DisableDate > DateTime.Now) && l.Dealer == dealerID).ToList();
        }

        public void PreLoadLists()
        {
            context = new FowlerDORContext();

            this.Dealerships = context.DealerShips.Where(d => (d.DisableDate == null || d.DisableDate > DateTime.Now) && DealerIDs.Contains(d.DealerID)).ToList();
            this.BusinessSources = context.BUSINESSSOURCEs.Where(b => b.DisableDate == null).ToList();
            this.FinanceTypes = context.FinanceTypes.ToList();
            this.VehicleTypes = context.VehicleTypes.ToList();
            this.DealStatuses = context.DealStatus.ToList();
            this.VehicleKinds = context.Vehicles.Where(v => v.DisableDate == null).ToList();
            this.SalesCategories = context.SalesCategories.ToList();
            this.GradeCredits = context.GradeCredits.ToList();
        }

        public void SetDefaultDates()
        {
            Deal.salesdate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            Deal.delvdate = null;
            Deal.datetoacct = null;
            Deal.datepaid = null;
            Deal.datetobank = null;
            Deal.datetotag = null;
        }

        public void AddDealRecord()
        {
            DealBiz biz = new DealBiz();
            biz.AddDealRecord(Deal);
        }

        public AddDealViewModel()
        {

        }
    }
}