using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.BLL.BusinessObjects
{
    public class DealTradeObject
    {
        public bool Status { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string OtherMake { get; set; }
        public string OtherModel { get; set; }
        public int? Year { get; set; }
        public int? Mileage { get; set; }
        public string Intent { get; set; }
        public string Title { get; set; }
        public string LienHolder { get; set; }
        public decimal? ACV { get; set; }
        public decimal? Payoff { get; set; }
        public decimal? Equity { get; set; }
    }
}