using System;
using System.Collections.Generic;

namespace DORv3.DAL.Models
{
    public partial class DealsbyFinMgr
    {
        public int DORId { get; set; }
        public Nullable<int> StatusId { get; set; }
        public Nullable<int> DealerId { get; set; }
        public Nullable<int> FinanceManagerId { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public Nullable<decimal> BEGross { get; set; }
    }
}
