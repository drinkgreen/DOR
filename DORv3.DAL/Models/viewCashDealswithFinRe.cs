using System;
using System.Collections.Generic;

namespace DORv3.DAL.Models
{
    public partial class viewCashDealswithFinRe
    {
        public int DORId { get; set; }
        public string DealNumber { get; set; }
        public Nullable<int> DealerId { get; set; }
        public Nullable<int> FinanceTypeId { get; set; }
        public Nullable<decimal> FinReserve { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
    }
}
