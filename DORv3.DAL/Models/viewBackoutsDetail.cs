using System;
using System.Collections.Generic;

namespace DORv3.DAL.Models
{
    public partial class viewBackoutsDetail
    {
        public int DORId { get; set; }
        public Nullable<int> DealerId { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
        public Nullable<System.DateTime> UpdDate { get; set; }
        public Nullable<System.DateTime> BackoutDate { get; set; }
        public Nullable<System.DateTime> SaleDate { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public Nullable<int> VehicleTypeId { get; set; }
        public Nullable<int> StatusId { get; set; }
        public string DealNumber { get; set; }
        public string StockNumber { get; set; }
    }
}
