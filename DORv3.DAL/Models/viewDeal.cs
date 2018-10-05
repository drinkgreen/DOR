using System;
using System.Collections.Generic;

namespace DORv3.DAL.Models
{
    public partial class viewDeal
    {
        public int DORId { get; set; }
        public Nullable<int> DealerId { get; set; }
        public Nullable<int> VehicleTypeId { get; set; }
        public Nullable<int> FinanceTypeId { get; set; }
        public Nullable<int> VehicleId { get; set; }
        public string DealNumber { get; set; }
        public string StockNumber { get; set; }
        public string lname1 { get; set; }
        public Nullable<int> StatusId { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public Nullable<decimal> payablegross { get; set; }
        public Nullable<decimal> BEGross { get; set; }
        public string MakeCalc { get; set; }
    }
}
