using System;
using System.Collections.Generic;

namespace DORv3.DAL.Models
{
    public partial class OtherIncome
    {
        public int OtherIncomeId { get; set; }
        public Nullable<int> OtherProductId { get; set; }
        public Nullable<int> DealerId { get; set; }
        public string PType { get; set; }
        public Nullable<decimal> PAmount { get; set; }
        public string fname1 { get; set; }
        public string lname1 { get; set; }
        public Nullable<System.DateTime> AdjDate { get; set; }
        public Nullable<System.DateTime> SaleDate { get; set; }
        public string Reason { get; set; }
        public string AddDate { get; set; }
        public Nullable<System.DateTime> DisableDate { get; set; }
        public string AddUser { get; set; }
        public string UpdUser { get; set; }
        public Nullable<int> DealNum { get; set; }
        public string VSCOption { get; set; }
        public Nullable<int> FinanceManagerId { get; set; }
        public Nullable<System.DateTime> UpdDate { get; set; }
        public Nullable<int> VehicleTypeId { get; set; }
        public string OtherType { get; set; }
        public Nullable<int> VehicleId { get; set; }
    }
}
