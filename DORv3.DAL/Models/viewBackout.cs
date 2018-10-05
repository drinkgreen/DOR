using System;
using System.Collections.Generic;

namespace DORv3.DAL.Models
{
    public partial class viewBackout
    {
        public int DORId { get; set; }
        public string DealNumber { get; set; }
        public Nullable<int> DealerId { get; set; }
        public Nullable<int> StatusId { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public Nullable<decimal> payablegross { get; set; }
        public Nullable<decimal> BEGross { get; set; }
    }
}
