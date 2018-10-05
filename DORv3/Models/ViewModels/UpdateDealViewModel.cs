using DORv3.BLL;
using DORv3.BLL.BusinessObjects;
using DORv3.DAL.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace DORv3.Models.ViewModels
{
    public class UpdateDealViewModel : DORViewModel
    {
        FowlerDORContext context;

        private List<int> _makeIDs = new List<int>();
        private List<Make> _makes;

        public DealRecord Deal { get; set; }
        public List<DealTradeObject> Trades { get; set; }
        public List<SalespersonsPerDeal> SalespeopleOnDeal { get; set; }

        public List<BUSINESSSOURCE> BusinessSources { get; set; }
        public List<FinanceType> FinanceTypes { get; set; }
        public List<Make> Makes {
            get { return this._makes; }
            set
            {
                this._makes = value;
                this._makeIDs = value.Select(m => m.MakeId).ToList();
            }
        }
        public List<Model> VehicleModels { get; set; }

        public List<VehicleType> VehicleTypes { get; set; }
        public List<DealStatu> DealStatuses { get; set; }
        public List<Vehicle> VehicleKinds { get; set; }
        public List<SalesCategory> SalesCategories { get; set; }

        public int DealerID { get; set; }
        public List<SalesManager> SalesManagers { get; set; }
        public List<SalesPerson> SalesPeople { get; set; }
        public List<FinanceManager> FinanceManagers { get; set; }
        public List<DORLienHolder> LienHolders { get; private set; }
        public List<GradeCredit> GradeCredits { get; private set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateToAccounting { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BookedDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateToTag { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateToBank { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DatePaid { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SaleDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DeliveryDate { get; set; }


        public bool IsAdmin { get; set; }
        public bool CanUpdate { get; set; }
        public bool IsCurrentMonth { get; set; }

        public UpdateDealViewModel(int userID, int dorID) : base(userID)
        {
            context = new FowlerDORContext();
            this.BusinessSources = context.BUSINESSSOURCEs.ToList();
            this.FinanceTypes = context.FinanceTypes.ToList();
            
            this.VehicleTypes = context.VehicleTypes.ToList();
            this.DealStatuses = context.DealStatus.ToList();
            this.VehicleKinds = context.Vehicles.Where(v => v.DisableDate == null).ToList();
            this.SalesCategories = context.SalesCategories.ToList();
            this.GradeCredits = context.GradeCredits.ToList();
            

            DealBiz biz = new DealBiz();
            this.Deal = biz.GetDealRecord(dorID);
            //Deal.GetType().GetProperty("DealerId").CustomAttributes.Add();
            this.Makes = context.Makes.Where(m=> (m.DisableDate == null || m.DisableDate > Deal.salesdate) && m.Dealer == Deal.Dealerid).ToList();
            this.VehicleModels = context.Models.Where(m => (m.DisableDate == null || m.DisableDate > Deal.salesdate) && _makeIDs.Contains(m.MakeId)).ToList();
            this.Trades = biz.GetTrades(Deal);
            this.SalespeopleOnDeal = biz.GetSalespersons(Deal);
            this.SalesManagers = context.SalesManagers.Where(m => (m.DisableDate == null || m.DisableDate > Deal.salesdate) && m.Dealer == Deal.Dealerid).ToList();
            this.SalesPeople = context.SalesPersons.Where(p => (p.DisableDate == null || p.DisableDate > Deal.salesdate) && p.Dealer == Deal.Dealerid).ToList();
            this.FinanceManagers = context.FinanceManagers.Where(fm => (fm.DisableDate == null || fm.DisableDate > Deal.salesdate) && fm.Dealer == Deal.Dealerid).ToList();
            this.LienHolders = context.DORLienHolders.Where(l => (l.DisableDate == null || l.DisableDate > Deal.salesdate) && l.Dealer == Deal.Dealerid).ToList();

            this.SaleDate = Convert.ToDateTime(this.Deal.salesdate);
            this.DeliveryDate = Convert.ToDateTime(this.Deal.delvdate);
            this.DateToAccounting = Convert.ToDateTime(this.Deal.datetoacct);
            this.BookedDate = Convert.ToDateTime(this.Deal.bookeddate);
            this.DateToTag = Convert.ToDateTime(this.Deal.datetotag);
            this.DateToBank = Convert.ToDateTime(this.Deal.datetobank);
            this.DatePaid = Convert.ToDateTime(this.Deal.datepaid);

            this.IsCurrentMonth = (Deal.salesdate.Month == DateTime.Now.Month ? true : false);
            this.CanUpdate = CanUserUpdate();
            this.IsAdmin = (IsSiteAdmin || CurrentUser.AccessLevels.Exists(a => a.DealerId == Deal.Dealerid && a.Role.IsAdmin));
            //this.CanUpdate = (isCurrentMonth || IsAdmin? true : false);
        }


        public void UpdateDealRecord()
        {
            DealBiz biz = new DealBiz();
            biz.UpdateDealRecord(Deal);
        }
        
        private bool CanUserUpdate()
        {
            bool retVal = true;
            if (!IsSiteAdmin) //Not a Global Admin
            {
                retVal = (CurrentUser.AccessLevels.Exists(a => a.DealerId == Deal.Dealerid && a.Role.CanUpdate) ? true : false);
            }
            return retVal;
        }

        private void AddBlankValueToDropDown(List<object> modelList)
        {
            
        }
    }
}