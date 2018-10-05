using DORv3.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.BLL.BusinessObjects
{
    public class SalespersonsPerDeal
    {
        public int dorID { get; set; }
        public SalesPerson Salesperson { get; set; }
        public string PercentofDeal { get; set; }
    }
}