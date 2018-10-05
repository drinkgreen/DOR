using System;
using System.Collections.Generic;

namespace DORv3.DAL.Models
{
    public partial class FindUnwidDeal
    {
        public int DORId { get; set; }
        public string StockNumber { get; set; }
        public Nullable<int> DealerId { get; set; }
        public string DealNumber { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public Nullable<System.DateTime> UnwindDate { get; set; }
        public Nullable<decimal> payablegross { get; set; }
        public Nullable<decimal> FinReserve { get; set; }
        public Nullable<decimal> BEGross { get; set; }
        public Nullable<decimal> TotGross { get; set; }
        public Nullable<int> FinanceTypeId { get; set; }
    }
}
