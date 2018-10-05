using System;
using System.Collections.Generic;

namespace DORv3.DAL.Models
{
    public partial class Deal
    {
        public int DORId { get; set; }
        public Nullable<int> StatusId { get; set; }
        public string DealNumber { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
        public Nullable<int> DealerId { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public string Vehicle { get; set; }
        public string VehicleType { get; set; }
        public string MakeCalc { get; set; }
        public string FinanceType { get; set; }
        public Nullable<decimal> payablegross { get; set; }
        public Nullable<decimal> FinReserve { get; set; }
    }
}
