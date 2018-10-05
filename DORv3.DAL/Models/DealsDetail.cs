using System;
using System.Collections.Generic;

namespace DORv3.DAL.Models
{
    public partial class DealsDetail
    {
        public int DORId { get; set; }
        public Nullable<int> FinanceManagerId { get; set; }
        public Nullable<int> DealerId { get; set; }
        public Nullable<System.DateTime> SaleDate { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public string Vehicle { get; set; }
        public string VehicleType { get; set; }
        public string MakeCalc { get; set; }
        public string FinanceType { get; set; }
        public string PName { get; set; }
        public Nullable<decimal> PAmount { get; set; }
        public Nullable<int> Recap { get; set; }
    }
}
