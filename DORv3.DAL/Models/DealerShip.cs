using System;
using System.Collections.Generic;

namespace DORv3.DAL.Models
{
    public partial class DealerShip
    {
        public int DealerID { get; set; }
        public string DealerName { get; set; }
        public Nullable<System.DateTime> DisableDate { get; set; }
        public string AddUser { get; set; }
        public string UpdUser { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
        public string DefaultMakes { get; set; }
        public string RGBColor { get; set; }
        public string Color { get; set; }
        public int Sort { get; set; }
    }
}
