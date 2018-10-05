using DORv3.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.BLL.BusinessObjects
{
    public class DealRecord_Summary
    {
        public int dorID { get; set; }
        public string buyerlname { get; set; }
        public string buyerfname { get; set; }
        public string cobuyerlname { get; set; }
        public string cobuyerfname { get; set; }
        public string vehicle { get; set; }
        public string vehicletype { get; set; }
        public string status { get; set; }
        public Nullable<int> DaysInStock { get; set; }
        public string dealnum { get; set; }
        public string stocknum { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public System.DateTime salesdate { get; set; }
        public System.DateTime delvdate { get; set; }
        public string Trade1Status { get; set; }
        public string SalesManager { get; set; }
        public List<SalespersonsPerDeal> Salespersons { get; set;}
        public string FinanceManager { get; set; }
        public string FinanceType { get; set; }
        public Nullable<decimal> backend { get; set; }
        public Nullable<decimal> totalgross { get; set; }
    }
}